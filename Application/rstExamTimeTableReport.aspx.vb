Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rstExamTimeTableReport
    Inherits EducarePage

    Dim strPK As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")


            If Not IsPostBack Then

                sysstandardno.ToolTip = "Standard"
                sysexamno.ToolTip = "Exam"
                sysdivisionno.ToolTip = "Division"
                btnprint.ToolTip = "Print"

                sysexamno.Items.Insert(0, "--SELECT EXAM--")

                sysstandardno.DataSource = GetStandardDetails(0)
                sysstandardno.DataBind()
                sysstandardno.Items.Insert(0, "--SELECT STANDARD--")

                'sysdivisionno.DataSource = DivisionDetail(0)
                'sysdivisionno.DataBind()
                sysdivisionno.Items.Insert(0, "--SELECT DIVISION--")
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnprint.Click
        Try
            Dim vstandard As Double = 0
            Dim vexam As Double = 0
            Dim vdivision As Double = 0
            If sysstandardno.SelectedIndex = 0 Then
                vstandard = 0
            Else
                vstandard = Val(sysstandardno.Text)
            End If
            If sysexamno.SelectedIndex = 0 Then
                vexam = 0
            Else
                vexam = Val(sysexamno.Text)
            End If
            If sysdivisionno.SelectedIndex = 0 Then
                vdivision = 0
            Else
                vdivision = Val(sysdivisionno.Text)
            End If
            
            Response.Write("<script type='text/javascript'>detailedresults=window.open('rstExamTimeTableReportBrowse.aspx?sysexamno=" & vexam & "&sysstandardno=" & vstandard & "&sysdivisionno=" & vdivision & " ');</script>")
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
        Try
           
            Dim dt As DataTable
            dt = StandardWiseExam(Val(sysstandardno.Text))
            If dt.Rows.Count <> 0 Then
                sysexamno.DataSource = dt
                sysexamno.DataBind()
                sysexamno.Items.Insert(0, "")
            End If

            sysdivisionno.DataSource = GetDivisionDetails(0)
            sysdivisionno.DataBind()
            sysdivisionno.Items.Insert(0, "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
