
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class misSemisterResultBrowse
    Inherits EducarePage
    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            GetReport(Request.QueryString("sysexamno"), Request.QueryString("sysstandardno"), Request.QueryString("sysdivisionno"), Request.QueryString("rollno"))
        Catch ex As Exception
        End Try
    End Sub

    Sub GetReport(ByVal sysexamno As String, ByVal sysstandardno As String, ByVal sysdivisionno As String, ByVal rollno As String)

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
            '  Dim dt As DataTable
            ' dt = AccountYearDetail(Val(yearcd))
            'If dt.Rows.Count > 0 Then
            '    startyear = dt.Rows(0)("fromdt").ToString
            '    endyear = dt.Rows(0)("todt").ToString
            'End If
            syear = Year(FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(startyear)))
            eyear = Year(FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(endyear)))
            sysexamno = sysexamno.Replace("|", "'")

            Dim myReportDocument As CrystalDecisions.CrystalReports.Engine.ReportDocument
            Dim myDS As New DataSet()
            sReportParms = "Result "
            'sReportParms1 = SessionUserData.UserData.userid

            'sReportcomm = SessionUserData.AdditionalInfo.Address1 & "," & SessionUserData.AdditionalInfo.Address2 & "," & SessionUserData.AdditionalInfo.Address3
            '  sReportTitle = SessionUserData.AdditionalInfo.SchoolName
            '


            If ErrorMessage.Length = 0 Then

                strSQL = " sp_SemesterResult '" & _
                            sysexamno & "'," & _
                            sysstandardno & "," & _
                            sysdivisionno & ",'" & _
                            rollno & "'," & _
                            0 & ""
                sReportInFile = "SemesterResult.rpt"


                Dim DA As New SqlDataAdapter(strSQL, Connection)
                DA.Fill(myDS)

                myReportDocument = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                myReportDocument.Load(Server.MapPath("Reports\") & sReportInFile & "")
                myReportDocument.Database.Tables(0).SetDataSource(myDS.Tables(0))

                myReportDocument.SummaryInfo.ReportTitle = sReportTitle
                myReportDocument.SummaryInfo.ReportComments = sReportcomm
                myReportDocument.SetParameterValue("pRepHeading", sReportParms)
                myReportDocument.SetParameterValue("pExamName", "")
                myReportDocument.SetParameterValue("pClassTeacher", "Class Teacher")
                myReportDocument.SetParameterValue("pPrincipal", "Principal")
                myReportDocument.SetParameterValue("pHeadLine1", "")
                myReportDocument.SetParameterValue("pHeadLine2", "")
            End If

            'sReportParms = "RESULT OF " & examname & " ON " & ExamDate



            CrystalReportViewer1.DisplayGroupTree = False
            CrystalReportViewer1.ReportSource = myReportDocument
            CrystalReportViewer1.DataBind()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
End Class
