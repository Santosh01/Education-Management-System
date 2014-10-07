
Imports System
Imports System.Data
Imports System.Data.OleDb

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class secMenuPermission
    Inherits EducarePage
    Dim inx As Int64 = 0
    Dim strb As New StringBuilder
    Dim strPK As Double
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PageMenuID = Request.QueryString("ID")
        btnClose.Attributes.Add("onClick", "self.location.replace(""Dashboard.aspx""); return false;")
   
        If Not IsPostBack Then

            Groupcode.ToolTip = "Group Code"
            Show.ToolTip = "Show"
            selectall.ToolTip = "Select All"
            unselectall.ToolTip = "Unselect All"
            done.ToolTip = "Done"
            btnClose.ToolTip = "Close"
            Groupcode.DataSource = GetUserGroupsDetails()
            Groupcode.DataBind()
            Groupcode.Items.Insert(0, "- - SELECT GROUPS - -")
        End If
    End Sub

    Protected Sub Show_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Show.Click
        RefreshGrid()
        Show.Enabled = False
    End Sub

    Protected Sub selectall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles selectall.Click
        For Each row As GridViewRow In gvMenupermission.Rows
            For Each ctrl As Object In row.Controls(0).Controls
                If ctrl.GetType.ToString = GetType(System.Web.UI.WebControls.CheckBox).ToString Then
                    Dim chk As CheckBox = CType(ctrl, CheckBox)
                    chk.Checked = False
                    If chk.Visible Then
                        chk.Checked = True
                        'Call gvMenupermission_ChkVisibleChange(chk, e)
                    End If
                End If
            Next
        Next
    End Sub

    Protected Sub unselectall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles unselectall.Click

        For Each row As GridViewRow In gvMenupermission.Rows
            For Each ctrl As Object In row.Controls(0).Controls
                If ctrl.GetType.ToString = GetType(System.Web.UI.WebControls.CheckBox).ToString Then
                    Dim chk As CheckBox = CType(ctrl, CheckBox)
                    chk.Checked = False
                    'Call gvMenupermission_ChkVisibleChange(chk, e)
                End If
            Next
        Next
    End Sub
 Protected Sub gvMenupermission_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMenupermission.PreRender
        chkid.Text = strb.ToString

    End Sub
    Protected Sub gvMenupermission_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMenupermission.RowDataBound
        
        Select Case e.Row.RowType
            Case DataControlRowType.Header

            Case DataControlRowType.DataRow
                e.Row.Cells(1).Style.Add("text-align", "center")
                If CType(e.Row.Controls(0).FindControl("lblParent"), Label).Text.ToString = "" Then
                    CType(e.Row.Controls(0).FindControl("lblMenucaption"), Label).Font.Bold = True
                    If e.Row.RowIndex <> 0 Then
                        strb.Append(";")
                    End If
                    CType(e.Row.Controls(0).FindControl("visible"), CheckBox).Attributes.Add("onclick", "cheKUnK(this," & inx & ")")
                    inx += 1
                Else
                    strb.Append(CType(e.Row.Controls(0).FindControl("visible"), CheckBox).UniqueID & "|")
                End If
        End Select

    End Sub

    Protected Sub done_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles done.Click
        Try
      
            Save(Groupcode.SelectedItem.Value, gvMenupermission)
         
            RefreshGrid()

            DisplayCustomMessageSummary("Updated Successfully")

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try

    End Sub

    Protected Sub gvMenupermission_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvMenupermission.PageIndexChanging
        Try
            gvMenupermission.PageIndex = e.NewPageIndex
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Public Sub RefreshGrid()
        gvMenupermission.DataSource = List(Groupcode.Text)
        gvMenupermission.DataBind()
    End Sub
    Public Function List(ByVal groupcode As String) As DataTable
        Try
            Dim strSqlString As String = ""

            strSqlString = "SELECT '" & groupcode & "' groupcode,menu.menuid, menu.menucaption, " & _
                           "       ISNULL(menupermission.permission,1) view_access , " & _
                           "       ISNULL(menupermission.permission,'1') permission , " & _
                           "       menu.parent " & _
                           "FROM   menu  " & _
                           "LEFT   OUTER JOIN menupermission ON " & _
                           "       menu.menuid = menupermission.menuid " & _
                           "AND    menupermission.groupcode = '" & groupcode & "' " & _
                           "ORDER  BY menu.menuid "


            Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function Save(ByVal groupcode As String, ByVal gvMenu As GridView) As String
        Try
            Dim conn As New OleDbConnection(DatabaseConnection.GetConnection)
            Dim da As New OleDbDataAdapter
            Dim ds As New DataSet
            conn.Open()
            da = New OleDbDataAdapter("SELECT * FROM menupermission " & _
                                      "WHERE " & _
                                      " groupcode = '" & groupcode & "'", conn)

            Dim objcmdBuilder As New OleDbCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds)


            For Each row As GridViewRow In gvMenu.Rows
                Dim lgroupcode As Label = CType(row.FindControl("groupcode"), Label)
                Dim lmenuid As Label = CType(row.FindControl("menuid"), Label)
                Dim lvisible As CheckBox = CType(row.FindControl("visible"), CheckBox)

                Dim drW() As DataRow = ds.Tables(0).Select(" menuid = '" & lmenuid.Text & "' AND groupcode = '" & groupcode & "'")

                If drW.Length = 0 Then
                    Dim permissions As String = ""
                    Dim dr As DataRow = ds.Tables(0).NewRow
                    dr("groupcode") = lgroupcode.Text
                    dr("menuid") = lmenuid.Text
                    dr("permission") = IIf(lvisible.Checked, "1", "0")
                    ds.Tables(0).Rows.Add(dr)
                Else
                    drW(0)("permission") = IIf(lvisible.Checked, "1", "0")
                End If
            Next

            da.Update(ds)
            conn.Close()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return ""
    End Function
 

End Class
