Imports System
Imports System.Data
Imports System.Data.OLEDB
Imports EducarePage
Imports Educare.Utility
Imports Educare.Application.BusinessLayer
Imports System.IO

Partial Class Main
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        currentdt.Text = FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(Now))


        If Not IsPostBack Then
            GenerateMainMenu()
        End If

    End Sub

    Protected Sub GenerateMainMenu()
        Menu1.Items.Clear()

        Menu1.Visible = True
        Menu1.DisappearAfter = 1000
        Dim strMenuString As String = ""
        strMenuString = "SELECT v_menupermission.menuid, v_menupermission.menucaption, v_menupermission.description, v_menupermission.url, v_menupermission.parent " & _
                                          "FROM   v_menupermission " & _
                                          "WHERE  groupcode  = 'SAG'" & _
                                          "AND    left(permission,1) = '1' " & _
                                          "ORDER  BY v_menupermission.srno "
        Dim ds As DataSet
        ds = DataSetCreator.GetDataSet(strMenuString)
        ds.DataSetName = "Menus"
        ds.Tables(0).TableName = "Menu"

        Dim relation As DataRelation = New DataRelation("ParentChild", _
        ds.Tables("Menu").Columns("menuid"), ds.Tables("Menu").Columns("parent"), True)

        relation.Nested = True
        ds.Relations.Add(relation)

        For Each dr As DataRow In ds.Tables(0).Rows
            If IsDBNull(dr("parent")) Then
                Dim _MenuItem As New MenuItem
                _MenuItem.Text = dr("menucaption")
                _MenuItem.ToolTip = dr("description")
                _MenuItem.Value = dr("menuid")
                _MenuItem.NavigateUrl = dr("url")
                'Menu1.Items.Add(_MenuItem)

                If dr.GetChildRows("ParentChild").Length <> 0 Then GetChildMenus(dr, _MenuItem)
                Menu1.Items.Add(_MenuItem)
            End If
        Next
        If Not (Request("Sel") Is Nothing) Then
            Response.Redirect(Request("Sel"))
        End If
        Menu1.Visible = True
    End Sub

    Protected Sub GetChildMenus(ByVal dr As DataRow, ByRef MasterMenu As MenuItem)
        For Each drc As DataRow In dr.GetChildRows("ParentChild")
            Dim y As New MenuItem

            y.Text = drc("menucaption")
            y.ToolTip = drc("description")
            y.NavigateUrl = drc("url")
            y.Value = drc("menuid")

            If dr.GetChildRows("ParentChild").Length <> 0 Then GetChildMenus(drc, y)
            MasterMenu.ChildItems.Add(y)
            Dim strUrlPage As String = ""
            If InStr(drc("url"), "?") > 0 Then
                strUrlPage = Server.MapPath(Right(drc("url").ToString.Split("?")(0), Len(drc("url").ToString.Split("?")(0)) - 2))
            Else
                strUrlPage = Server.MapPath(Right(drc("url"), Len(drc("url")) - 2))
            End If
            '
            If File.Exists(strUrlPage) Then
                y.Enabled = True
            Else
                y.Enabled = False
            End If
        Next
    End Sub


End Class

