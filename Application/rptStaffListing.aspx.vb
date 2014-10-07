Imports System
Imports System.Data.SqlClient
Imports Educare.Utility
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.DataTable
Imports Educare.Application.BusinessLayer
Partial Class rptStaffListing

    Inherits EducarePage
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            sysfacultyno.DataSource = GetfacultyDetails(0)
            sysfacultyno.DataBind()
        End If
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub
    Private Sub InitilizeControls()

    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Response.Redirect("Dashboard.aspx")
    End Sub
End Class
