Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rstExamTimeTableReportBrowse
    Inherits EducarePage
    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetReport(Request.QueryString("sysexamno"), Request.QueryString("sysstandardno"), Request.QueryString("sysdivisionno"))
        Catch ex As Exception
        End Try
    End Sub

    Sub GetReport(ByVal sysexamno As String, ByVal sysstandardno As String, ByVal sysdivisionno As String)

        Try
            Dim strSQL As String = ""
            Dim sReportcomm As String = ""
            Dim sReportParms As String = ""
            Dim sReportParms1 As String = ""
            '
            Dim sReportInFile As String = ""
            Dim sReportOutFile As String = ""
            Dim sReportTitle As String = ""

            If ErrorMessage.Length > 0 Then
                DisplayCustomMessageSummary(ErrorMessage)
                Exit Sub
            End If
            Dim strConnection As String = DatabaseConnection.GetConnectionSQLClient()
            Dim Connection As New SqlConnection(strConnection)
            '
            Dim syear As String
            Dim eyear As String
            Dim startyear As DateTime
            Dim endyear As DateTime


            syear = Year(FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(startyear)))
            eyear = Year(FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(endyear)))

            If ErrorMessage.Length = 0 Then

                strSQL = " rpt_ExamTimeTable " & _
                            " 0," & _
                            sysstandardno & "," & _
                            sysdivisionno & "," & _
                            sysexamno
            End If
            sReportInFile = "rptExamTimeTable.rpt"
            sReportParms = "Exam Time Table For Acadamic Year " & " " & 2012 & " - " & 2013
            sReportParms1 = ""

            'sReportcomm = SessionUserData.AdditionalInfo.Address1 & "," & SessionUserData.AdditionalInfo.Address2 & "," & SessionUserData.AdditionalInfo.Address3
            'sReportTitle = SessionUserData.AdditionalInfo.SchoolName

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
            myReportDocument.SetParameterValue("pUserid", sReportParms1)
            CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myReportDocument
            CrystalReportViewer1.DataBind()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

End Class
