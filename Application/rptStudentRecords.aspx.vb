Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rptStudentRecords
    Inherits EducarePage
    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                sysstandardno.ToolTip = "Standard"
                division.ToolTip = "Division"
                month.ToolTip = "Month"
                opt_std_att.ToolTip = "Student Attendance Check"
                btnprint.ToolTip = "Print"
                sysstandardno.DataSource = GetStandardDetails(0)
                sysstandardno.DataBind()


                sysstandardno.Items.Insert(0, "--SELECT STANDARD--")
                division.DataSource = GetDivisionDetails(0)
                division.DataBind()
                division.Items.Insert(0, "--SELECT DIVISION--")



                month.DataSource = GeneralCodeData("MNTH")
                month.DataBind()
                month.Items.Insert(0, "--SELECT MONTH--")
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
        Try

            division.DataSource = GetDivisionDetails(0)
            division.DataBind()

            division.Items.Insert(0, "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnprint.Click
        Try

            Dim strReportType As String = ""
            Dim vsysstandardno As Double = 0
            Dim vsyssubjectno As Double = 0
            Dim vdivision As Double = 0
            Dim vmonth As String = ""
            Dim vmonthCD As String = ""

          

            If opt_std_att.Checked = True Then
                If sysstandardno.SelectedIndex = 0 Then
                    DisplayCustomMessageSummary("Select Standard")
                    Exit Sub
                    vsysstandardno = 0
                Else
                    vsysstandardno = Val(sysstandardno.Text)
                End If

                If division.SelectedIndex = 0 Then
                    DisplayCustomMessageSummary("Select Division")
                    Exit Sub
                    vdivision = 0
                Else
                    vdivision = Val(division.Text)
                End If
                If month.SelectedIndex = 0 Then
                    DisplayCustomMessageSummary("Select Month")
                    Exit Sub
                    vmonth = ""
                Else
                    vmonth = month.SelectedItem.Text
                    vmonthCD = month.Text
                End If
            End If



            If opt_std_att.Checked = True Then
                strReportType = "S"
            End If

            Dim strstandard As String = ""
            Dim strdivision As String = ""

            strstandard = sysstandardno.SelectedItem.Text
            strdivision = division.SelectedItem.Text


            Response.Write("<script type='text/javascript'>detailedresults=window.open('rptStudentRecordsBrowse.aspx?yearcd=1" & "&sysstandardno=0" & vsysstandardno & "&division=0" & vdivision & "&reporttype=" & strReportType & "&month=" & vmonth & "&strstandard=" & strstandard & "&strdivision=" & strdivision & "&monthcd=" & vmonthCD & " ');</script>")
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub


   

End Class
