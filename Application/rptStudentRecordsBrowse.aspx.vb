Imports System.Data
Imports System.Data.SqlClient

Imports System.Web.UI.WebControls.GridView
Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rptStudentRecordsBrowse
    Inherits EducarePage
    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetReport(Request.QueryString("yearcd"), Request.QueryString("sysstandardno"), Request.QueryString("division"), Request.QueryString("reporttype"), Request.QueryString("month"), Request.QueryString("strstandard"), Request.QueryString("strdivision"), Val(Request.QueryString("monthcd")))
        Catch ex As Exception
        End Try
        '=" & strstandard & "&=" & strdivision
    End Sub

    Sub GetReport(ByVal yearcd As Double, ByVal sysstandardno As Double, ByVal division As Double, ByVal reporttype As String, ByVal month As String, ByVal strstandard As String, ByVal strdivision As String, ByVal monthcd As Double)
        Try
            Dim strSQL As String = ""
            Dim sReportcomm As String = ""
            Dim sReportParms As String = ""
            '
            Dim sReportInFile As String = ""
            Dim sReportOutFile As String = ""
            Dim sReportTitle As String = ""
            Dim sPrintedBy As String = ""

            Dim strStd As Double = 0
            Dim strSub As Double = 0
            Dim strDiv As Double = 0

            If sysstandardno = 0 Then
                strStd = 0
            Else
                strStd = sysstandardno
            End If

            If division = 0 Then
                strDiv = 0
            Else
                strDiv = division
            End If
          

            If ErrorMessage.Length > 0 Then
                DisplayCustomMessageSummary(ErrorMessage)
                Exit Sub
            End If
            Dim strConnection As String = DatabaseConnection.GetConnectionSQLClient()
            Dim Connection As New SqlConnection(strConnection)
            '
            '

            Dim syear As String
            Dim eyear As String
            Dim startyear As DateTime
            Dim endyear As DateTime
            Dim dt As DataTable
           
            syear = ""
            eyear = ""


            If ErrorMessage.Length = 0 Then
               
                If reporttype = "S" Then
                    strSQL = "rpt_StudentAttendanceRegister 0" & yearcd & ", 0" & strStd & ", 0" & strDiv & ",'" & monthcd & "'"

                    sReportInFile = "DailyAttendanceReport.rpt"
                    sReportParms = "Students Daily Attendance Sheet For the Month " & month & " (Standard : " & strstandard & "   Division : " & strdivision & ") ()"
                End If
            End If

            sPrintedBy = ""

            sReportcomm = ""
            sReportTitle = ""
            '
            Dim myDS As New DataSet()
            Dim DA As New SqlDataAdapter(strSQL, Connection)
            DA.Fill(myDS)

            Dim myReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument

            myReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            myReportDocument.Load(Server.MapPath("Reports\") & sReportInFile & "")
            myReportDocument.Database.Tables(0).SetDataSource(myDS.Tables(0))

            myReportDocument.SummaryInfo.ReportTitle = sReportTitle
            myReportDocument.SummaryInfo.ReportComments = sReportcomm
            myReportDocument.SetParameterValue("pRepHeading", sReportParms)
            myReportDocument.SetParameterValue("pUser", sPrintedBy)
            CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myReportDocument
            CrystalReportViewer1.DataBind()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

End Class
