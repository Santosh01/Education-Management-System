Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class secUsers
    Inherits EducarePage
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnCancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return FALSE;} ")
        If Not IsPostBack Then

            btnSave.ToolTip = "Save"
            btnCancel.ToolTip = "Cancel"
            userid.ToolTip = "User Id"
            password.ToolTip = "Password"
            SecretQuestion.ToolTip = "Secret-Question"
            SecretAnswer.ToolTip = "Secret-Answer"
            username.ToolTip = "User-Name"
            groupcode.ToolTip = "Groupcode"
            userstatus.ToolTip = "Status"
            userstatus.DataSource = GeneralCodeData("STAT")
            userstatus.DataBind()
            groupcode.DataSource = GetUserGroupsDetails()
            groupcode.DataBind()
            groupcode.Items.Insert(0, "- - SELECT GROUPS - -")
            RefreshGrid()
        End If
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim strMessage As String
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()
            Dim com As New SqlCommand("SELECT * FROM users WHERE sysuserno =0" & sysuserno.Text, con)
            Dim ds As New DataSet
            Dim adaptor As New SqlDataAdapter(com)
            adaptor.Fill(ds)
            Dim dr As DataRow
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables(0).NewRow
                dr("createddt") = Now
                strMessage = "Added Successfully"
            Else
                dr = ds.Tables(0).Rows(0)
                strMessage = "Updated Successfully"
            End If

            dr("sysuserno") = Val(sysuserno.Text)
            dr("userid") = userid.Text
            dr("username") = username.Text
            dr("password") = password.Text
            dr("groupcode") = groupcode.SelectedItem.Value
            dr("SecretAnswer") = SecretAnswer.Text
            dr("SecretQuestion") = SecretQuestion.Text
            dr("userstatus") = userstatus.SelectedItem.Value
            dr("lupdnuser") = "" & Session("userid")
            dr("lupdndt") = Now

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
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysuserno.Text = row.Cells(0).Text

            Dim ds As New DataSet
            ds = DataSetCreator.GetDataSet("select * from users where sysuserno =0" & sysuserno.Text)

            sysuserno.Text = ds.Tables(0).Rows(0)("sysuserno")
            userid.Text = ds.Tables(0).Rows(0)("userid")
            username.Text = ds.Tables(0).Rows(0)("username")
            password.Text = ds.Tables(0).Rows(0)("password")
            groupcode.Text = ds.Tables(0).Rows(0)("groupcode")
            userstatus.Text = ds.Tables(0).Rows(0)("userstatus")
            SecretAnswer.Text = ds.Tables(0).Rows(0)("SecretAnswer")
            SecretQuestion.Text = ds.Tables(0).Rows(0)("SecretQuestion")

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysuserno.Text = row.Cells(0).Text
            DataSetCreator.ExecuteQuery("Delete from users WHERE sysuserno =0" & sysuserno.Text)
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        InitilizeControls()

    End Sub


    Private Sub InitilizeControls()
        Try
            sysuserno.Text = ""
            userid.Text = ""
            username.Text = ""
            password.Text = ""
            SecretQuestion.text = ""
            SecretAnswer.text = ""

            groupcode.Text = Nothing
            userstatus.Text = Nothing
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid()

        gvList.DataSource = GetUsersDetails()
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

