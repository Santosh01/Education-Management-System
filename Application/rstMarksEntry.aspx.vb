Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rstMarksEntry
    Inherits EducarePage
    'Dim objBO As Application.marksentryBO
    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            '           SessionUserData.UserAccess.MenuID = PageMenuID

            btnRemoveAttendance.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to remove marks?')==0) {return false;} ")

            '            objBO = New Application.marksentryBO
            If Not IsPostBack Then
                sysstandardno.ToolTip = "Standard"
                sysdivisionno.ToolTip = "Division"
                sysexamno.ToolTip = "Exam"
                syssubjectno.ToolTip = "Subject"
                btnsave.ToolTip = "Save"
                btnCancel.ToolTip = "Cancel"
                btnRemoveAttendance.ToolTip = "Remove Atttendance"
                sysstandardno.DataSource = GetStandardDetails(0)
                sysstandardno.DataBind()
                sysstandardno.Items.Insert(0, "--SELECT STANDARD--")

            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid()
        Try
            If Val(sysexamno.Text) > 0 Then
                'Dim dt As DataTable
                'dt = ExamMarksEntryDetails(SessionUserData.AdditionalInfo.AccadamicYear, Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text), Val(syssubjectno.Text))
                'If dt.Rows.Count <> 0 Then
                '    gvList.DataSource = dt
                '    gvList.DataBind()
                'End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub InitializeControls()
        Try
            strPK = 0
            sysmarksno.Text = ""
            syssubjectno.Text = Nothing
            sysstandardno.Text = Nothing
            sysdivisionno.Text = Nothing
            sysexamno.Text = Nothing
            OEM.Text = ""
            WEM.Text = ""
            written.Text = ""
            oral.Text = ""
            lbloral.Text = ""
            lblwritten.Text = ""

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub SetValueToControls_Edit(ByVal strPK As Double)
        Try
            'Dim dt As New DataTable
            'dt = objBO.List(strPK, "")

            'If dt.Rows.Count > 0 Then
            '    sysmarksno.Text = dt.Rows(0)("sysmarksno").ToString
            '    sysstandardno.Text = dt.Rows(0)("sysstandardno").ToString
            '    sysdivisionno.Text = dt.Rows(0)("sysdivisionno").ToString
            '    sysexamno.Text = dt.Rows(0)("sysexamno").ToString

            '    syssubjectno.Text = dt.Rows(0)("syssubjectno").ToString
            'End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            InitializeControls()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Val(sysstandardno.Text) > 0 And Val(sysdivisionno.Text) > 0 And Val(sysexamno.Text) > 0 And Val(syssubjectno.Text) > 0 Then 'ID

                Response.Write("<script type='text/javascript'>detailedresults=window.open('rstMarksEntryBrowse.aspx?sysstandardno=" & sysstandardno.Text & "&sysdivisionno=0" & sysdivisionno.Text & "&sysexamno=0" & sysexamno.Text & "&syssubjectno=0" & syssubjectno.Text & "&ID=" & PageMenuID & " ');</script>")

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
        Try
            If sysstandardno.SelectedIndex = 0 Then
                ErrorMessage = ErrorMessage & "Select Standard.\n "
                Exit Sub
            End If

            sysdivisionno.DataSource = GetDivisionDetails(0)
            sysdivisionno.DataBind()
            sysdivisionno.Items.Insert(0, "")

            Dim dt As DataTable
            dt = StandardWiseExam(Val(sysstandardno.Text))
            If dt.Rows.Count <> 0 Then
                sysexamno.DataSource = dt
                sysexamno.DataBind()
                sysexamno.Items.Insert(0, "")
            End If
            RefreshGrid()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub syssubjectno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles syssubjectno.SelectedIndexChanged
        Try
            'Dim dt1 As DataTable
            'dt1 = objBO.MarksDetails(SessionUserData.AdditionalInfo.AccadamicYear, Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text), Val(syssubjectno.Text), "")
            'If dt1.Rows.Count <> 0 Then
            '    written.Text = dt1.Rows(0)("writtenexam").ToString
            '    oral.Text = dt1.Rows(0)("oralexam").ToString
            'End If
            ''
            'Dim dt As DataTable
            'dt = StdExamPortionDetail(SessionUserData.AdditionalInfo.AccadamicYear, Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text), Val(syssubjectno.Text))
            'If dt.Rows.Count > 0 Then
            '    lblwritten.Text = "Writtem Exam Marks : " & dt.Rows(0)("writtenexammarks").ToString
            '    WEM.Text = dt.Rows(0)("writtenexammarks")
            '    If dt.Rows(0)("oralexam") = "Y" Then
            '        lbloral.Text = "Oral Exam Marks : " & dt.Rows(0)("oralexammarks").ToString
            '        OEM.Text = dt.Rows(0)("oralexammarks")
            '    End If
            'End If
            ''
            'RefreshGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub sysexamno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysexamno.SelectedIndexChanged
        Try
            RefreshGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub sysdivisionno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysdivisionno.SelectedIndexChanged
        Try
            If sysdivisionno.SelectedIndex = 0 Then
                ErrorMessage = ErrorMessage & "Select Division.\n "
                Exit Sub
            End If
            Dim dt1 As DataTable
            dt1 = StandardWiseSubjectDetail(sysstandardno.Text, Val(sysdivisionno.Text))
            If dt1.Rows.Count <> 0 Then
                syssubjectno.DataSource = dt1
                syssubjectno.DataBind()
                syssubjectno.Items.Insert(0, "")
            End If
            RefreshGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Protected Sub btnRemoveAttendance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAttendance.Click
        Try

            'Dim strErrorMessage As String = ""

            'If SessionUserData.AdditionalInfo.AccadamicYear = 0 Then
            '    strErrorMessage = strErrorMessage & "Year Cannot Be Blank" & vbNewLine
            'End If
            'If Val(sysstandardno.Text) = 0 Then
            '    strErrorMessage = strErrorMessage & "Standard Cannot Be Blank" & vbNewLine
            'End If
            'If Val(sysdivisionno.Text) = 0 Then
            '    strErrorMessage = strErrorMessage & "Division Cannot Be Blank" & vbNewLine
            'End If
            'If Val(sysexamno.Text) = 0 Then
            '    strErrorMessage = strErrorMessage & "Exam Cannot Be Blank" & vbNewLine
            'End If
            'If Val(syssubjectno.Text) = 0 Then
            '    strErrorMessage = strErrorMessage & "Subject Cannot Be Blank" & vbNewLine
            'End If

            'If strErrorMessage.Length > 0 Then
            '    DisplayCustomMessageSummary(strErrorMessage)
            '    Exit Sub
            'End If

            'If SessionUserData.AdditionalInfo.AccadamicYear > 0 And (sysstandardno.Text) > 0 And Val(sysdivisionno.Text) > 0 And Val(sysexamno.Text) > 0 And Val(syssubjectno.Text) > 0 Then
            '    Dim strSqlQuery As String = ""
            '    strSqlQuery = "DELETE FROM  marksentry WHERE yearcd = 0" & SessionUserData.AdditionalInfo.AccadamicYear & "   AND   sysstandardno =  0" & Val(sysstandardno.Text) & "   AND   sysdivisionno =  0" & Val(sysdivisionno.Text) & "   AND   sysexamno =  0" & Val(sysexamno.Text) & "   AND   syssubjectno =  0" & Val(syssubjectno.Text) & " "
            '    DataSetCreator.ExecuteQuery(strSqlQuery)
            '    RefreshGrid()
            'Else
            '    DisplayCustomMessageSummary("Data cannot be blank")
            'End If

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
   
    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        'This condition is used to check RowType is Header
        If e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To gvList.Columns.Count - 1
                e.Row.Cells(i).ToolTip = gvList.Columns(i).HeaderText
            Next
        End If
    End Sub

   

End Class
