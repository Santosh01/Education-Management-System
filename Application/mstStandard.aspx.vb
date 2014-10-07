Imports System
Imports System.Data.SqlClient
Imports Educare.Utility
Imports Educare.Application.BusinessLayer
Imports System.Data
'Imports System.Data.DataRow
Imports System.Data.DataTable
Imports System.Windows.Forms.Form

Partial Class mstStandard
    Inherits EducarePage
    Dim strMessage As String
    Dim con As New SqlConnection
    Dim com As New SqlCommand
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BtnCancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return false;} ")
        If Not IsPostBack Then
            standardcode.ToolTip = "Standard Code"
            standarddesc.ToolTip = "Standard Description"
            status.ToolTip = "Status"
            BtnSave.ToolTip = "Save"
            BtnCancel.ToolTip = "Cancel"
            status.DataSource = GeneralCodeData("STAT")
            status.DataBind()

            RefreshGrid()
            AutoNumberNo()
        End If
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Try
            Dim strMessage As String
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()

            Dim com As New SqlCommand("SELECT * FROM standard WHERE sysstandardno =0" & sysstandardno.Text, con)

            Dim ds As New DataSet
            Dim adaptor As New SqlDataAdapter(com)
            adaptor.Fill(ds)

            Dim dr As DataRow
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables(0).NewRow
                dr("createduser") = Session("userid")
                dr("createddt") = Now
                strMessage = "Added Successfully"
            Else
                dr = ds.Tables(0).Rows(0)
                strMessage = "Updated Successfully"
            End If

            dr("sysstandardno") = Val(sysstandardno.Text)
            dr("standardcode") = standardcode.Text
            dr("standarddesc") = standarddesc.Text
            dr("status") = status.Text
            dr("lupdnuser") = "" & Session("userid")
            dr("lupdndt") = Now
            dr("deleted") = "N"
            If ds.Tables(0).Rows.Count = 0 Then
                ds.Tables(0).Rows.Add(dr)
            End If
            Dim cmdbld As New SqlCommandBuilder(adaptor)
            adaptor.Update(ds)
            DisplayCustomMessageSummary(strMessage)
            RefreshGrid()

            InitilizeControls()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        InitilizeControls()
    End Sub
    Private Sub InitilizeControls()
        sysstandardno.Text = ""
        standardcode.Text = ""
        standarddesc.Text = ""
    End Sub
    Protected Sub AutoNumberNo()
        Dim NextNo As Integer
        Try
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()
            com = New SqlCommand("SELECT MAX(standardcode) AS Max_Number FROM standard", con)
            NextNo = com.ExecuteScalar() + 1
            con.Close()
            standardcode.Text = NextNo.ToString()
            standardcode.Enabled = False

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try

    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        'This condition is used to check RowType is Header
        If e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To gvList.Columns.Count - 1
                e.Row.Cells(i).ToolTip = gvList.Columns(i).HeaderText
            Next
        End If
    End Sub
    

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysstandardno.Text = row.Cells(0).Text

            Dim ds As New DataSet
            ds = DataSetCreator.GetDataSet("SELECT * FROM standard WHERE sysstandardno =0" & sysstandardno.Text)

            sysstandardno.Text = ds.Tables(0).Rows(0)("sysstandardno")
            standardcode.Text = ds.Tables(0).Rows(0)("standardcode")
            standarddesc.Text = ds.Tables(0).Rows(0)("standarddesc")
            status.Text = ds.Tables(0).Rows(0)("status")
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
   

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysstandardno.Text = row.Cells(0).Text
            DataSetCreator.ExecuteQuery("UPDATE standard SET deleted = 'Y' WHERE sysstandardno =0" & sysstandardno.Text)
            RefreshGrid()
            InitilizeControls()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid()
        gvList.DataSource = DataSetCreator.GetDataSet("SELECT * FROM standard WHERE deleted = 'N' ORDER BY standardcode ")
        gvList.DataBind()
    End Sub

    
    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated

        If e.Row.RowType = DataControlRowType.Pager Then
            e.Row.Cells(0).Visible = True
        End If
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
        End If
    End Sub

    

    Protected Sub gvlist_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Try
            gvList.PageIndex = e.NewPageIndex
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)

        End Try
    End Sub
End Class


