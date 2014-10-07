Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class secUserGroups
    Inherits EducarePage
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnCancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return FALSE;} ")

        If Not IsPostBack Then
            btnSave.ToolTip = "Save"
            btnCancel.ToolTip = "Cancel"
            groupcode.ToolTip = "Group code"
            description.ToolTip = "Description"
            comment.ToolTip = "Comment"
            status.ToolTip = "Status"
            status.DataSource = GeneralCodeData("STAT")
            status.DataBind()
            RefreshGrid()
        End If
    End Sub
    Private Sub RefreshGrid()
        gvList.DataSource = GetUserGroupsDetails()
        gvList.DataBind()
    End Sub
    Private Sub InitilizeControls()
        sysgroupno.Text = ""
        groupcode.Text = ""
        description.Text = ""
        comment.Text = ""
        status.Text = Nothing
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim strMessage As String
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()
            Dim com As New SqlCommand("SELECT * FROM usergroups WHERE sysgroupno =0" & sysgroupno.Text, con)
            Dim ds As New DataSet
            Dim adaptor As New SqlDataAdapter(com)
            adaptor.Fill(ds)
            Dim dr As DataRow
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables(0).NewRow
                strMessage = "Added Successfully"
            Else
                dr = ds.Tables(0).Rows(0)
                strMessage = "Updated Successfully"
            End If

            dr("groupcode") = groupcode.Text
            dr("description") = description.Text
            dr("comment") = comment.Text
            dr("status") = status.Text
            dr("lupdnuser") = "" & Session("userid")
            dr("lupdndt") = Now
            If ds.Tables(0).Rows.Count = 0 Then
                ds.Tables(0).Rows.Add(dr)
            End If
            Dim cmdbld As New SqlCommandBuilder(adaptor)
            adaptor.Update(ds)
            RefreshGrid()
            InitilizeControls()
            DisplayCustomMessageSummary(strMessage)

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysgroupno.Text = row.Cells(0).Text

            Dim ds As New DataSet
            ds = DataSetCreator.GetDataSet("select * from usergroups where sysgroupno =0" & sysgroupno.Text)

            sysgroupno.Text = ds.Tables(0).Rows(0)("sysgroupno")
            groupcode.Text = ds.Tables(0).Rows(0)("groupcode")
            description.Text = ds.Tables(0).Rows(0)("description")
            comment.Text = ds.Tables(0).Rows(0)("comment")
            status.Text = ds.Tables(0).Rows(0)("status")

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim strMessage As String
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysgroupno.Text = row.Cells(0).Text
            DataSetCreator.ExecuteQuery("Delete from usergroups WHERE sysgroupno =0" & sysgroupno.Text)
            strMessage = "Deleated Successfully"
            RefreshGrid()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        InitilizeControls()
    End Sub

    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated

        If e.Row.RowType = DataControlRowType.Pager Then
            e.Row.Cells(0).Visible = True
        End If
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
        End If
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        'This condition is used to check RowType is Header
        If e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To gvList.Columns.Count - 1
                e.Row.Cells(i).ToolTip = gvList.Columns(i).HeaderText
            Next
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

