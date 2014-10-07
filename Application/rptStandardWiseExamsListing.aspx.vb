Imports System
Imports System.Data.SqlClient
Imports Educare.Utility
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.DataTable
Imports Educare.Application.BusinessLayer
Partial Class rptStandardWiseExamsListing
    Inherits EducarePage
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            sysstandardno.DataSource = GetStandardDetails(0)
            sysstandardno.DataBind()

            sysdivisionno.DataSource = GetDivisionDetails(0)
            sysdivisionno.DataBind()

            sysexamno.DataSource = GetExamDetails(0)
            sysexamno.DataBind()

        End If
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click

    End Sub
    Private Sub InitilizeControls()

    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("Dashboard.aspx")
    End Sub
End Class



