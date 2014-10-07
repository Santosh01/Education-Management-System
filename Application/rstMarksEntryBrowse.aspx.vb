Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rstMarksEntryBrowse
    Inherits EducarePage
    

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            '        SessionUserData.UserAccess.MenuID = PageMenuID

            MaintainScrollPositionOnPostBack = True


            LinkButton1.Attributes.Add("onclick", "window.close()")

            If Not IsPostBack Then

     
                sysstandardno.DataSource = GetStandardDetails(Val(Request.QueryString("sysstandardno")))
                sysstandardno.DataBind()
                sysstandardno.Text = Request.QueryString("sysstandardno")

                sysdivisionno.DataSource = GetDivisionDetails(Val(Request.QueryString("sysdivisionno")))
                sysdivisionno.DataBind()
                sysdivisionno.Text = Request.QueryString("sysdivisionno")

                sysexamno.DataSource = GetExamDetails(Val(Request.QueryString("sysexamno")))
                sysexamno.DataBind()
                sysexamno.Text = Request.QueryString("sysexamno")

                syssubjectno.DataSource = GetSubjectDetails(Val(Request.QueryString("syssubjectno")))
                syssubjectno.DataBind()
                syssubjectno.Text = Request.QueryString("syssubjectno")
                '
                ' ExamMarksEntry.Visible = False
                '
                'Dim dt1 As DataTable
                'dt1 = objBO.MarksDetails(Val(yearcd.Text), Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text), Val(syssubjectno.Text), "")
                'If dt1.Rows.Count <> 0 Then
                '    written.Text = dt1.Rows(0)("writtenexam").ToString
                '    oral.Text = dt1.Rows(0)("oralexam").ToString
                'End If
                ''
                'Dim dt As DataTable
                'dt = StdExamPortionDetail(Val(yearcd.Text), Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text), Val(syssubjectno.Text))
                'If dt.Rows.Count > 0 Then
                '    lblwritten.Text = "Writtem Exam Marks : " & dt.Rows(0)("writtenexammarks").ToString
                '    WEM.Text = dt.Rows(0)("writtenexammarks")
                '    If dt.Rows(0)("oralexam") = "Y" Then
                '        lbloral.Text = "Oral Exam Marks : " & dt.Rows(0)("oralexammarks").ToString
                '        OEM.Text = dt.Rows(0)("oralexammarks")
                '    End If
                'End If

                RefreshGrid()
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            'Dim objBO As Application.marksentryBO
            Dim grow As GridViewRow
            For Each grow In gvList.Rows
                ' objBO = New Application.marksentryBO
                If CType(grow.FindControl("Selected"), CheckBox).Checked Then
                    If written.Text = "Y" Then
                        If Val(WEM.Text) > 0 Then
                            If Val(CType(grow.FindControl("writtenmark"), TextBox).Text) > Val(WEM.Text) Then
                                DisplayCustomMessageSummary("Marks Should Not be Greater than Total Written Marks")
                                'CType(grow.FindControl("writtenmark"), TextBox).Text = "0"
                                Exit Sub
                            End If
                        End If
                    End If
                    If oral.Text = "Y" Then
                        If Val(OEM.Text) > 0 Then
                            If Val(CType(grow.FindControl("oralmark"), TextBox).Text) > Val(OEM.Text) Then
                                DisplayCustomMessageSummary("Marks Should Not be Greater than Total Oral Marks")
                                'CType(grow.FindControl("oralmark"), TextBox).Text = "0"
                                Exit Sub
                            End If
                        End If
                    End If
                    Dim strSqlQuery As String = ""
                    If Val(grow.Cells(0).Text) = 0 Then
                        strSqlQuery = "INSERT INTO marksentry " & _
                                                    "         (sysstandardno,                  sysdivisionno,                      sysexamno,                  sysstudentno,                   syssubjectno,                 yearcd,                   writtenmark,                                                      oralmark,                                                     description,                                                   gracemark,                                                  preabsstatus,                                                       trndt,        lupdnuser,                          lupdndt,      createduser,                        createddt, deleted) " & _
                                                    " VALUES  (" & Val(sysstandardno.Text) & "," & Val(sysdivisionno.Text) & "," & Val(sysexamno.Text) & "," & Val(grow.Cells(1).Text) & "," & Val(syssubjectno.Text) & ",0," & Val(CType(grow.FindControl("writtenmark"), TextBox).Text) & "," & Val(CType(grow.FindControl("oralmark"), TextBox).Text) & ",'" & CType(grow.FindControl("description"), TextBox).Text & "'," & Val(CType(grow.FindControl("gracemark"), TextBox).Text) & ",'" & CType(grow.FindControl("preabsstatus"), DropDownList).Text & "', GETDATE(),'" & Session("userid") & "',GETDATE(),'" & Session("userid") & "',GETDATE(),'N')"
                    Else
                        strSqlQuery = "UPDATE marksentry " & _
                                      "   SET " & _
                                      "       sysstandardno = " & Val(sysstandardno.Text) & ", " & _
                                      "       sysdivisionno = " & Val(sysdivisionno.Text) & ", " & _
                                      "       sysexamno = " & Val(sysexamno.Text) & ", " & _
                                      "       sysstudentno = " & Val(grow.Cells(1).Text) & ", " & _
                                      "       syssubjectno = " & Val(syssubjectno.Text) & ", " & _
                                      "       oralmark =  " & Val(CType(grow.FindControl("oralmark"), TextBox).Text) & ", " & _
                                      "       writtenmark =  " & Val(CType(grow.FindControl("writtenmark"), TextBox).Text) & ", " & _
                                      "       gracemark =  " & Val(CType(grow.FindControl("gracemark"), TextBox).Text) & ", " & _
                                      "       preabsstatus =  '" & CType(grow.FindControl("preabsstatus"), DropDownList).Text & "', " & _
                                      "       description =  '" & CType(grow.FindControl("description"), TextBox).Text & "', " & _
                                      "       trndt = GETDATE(), " & _
                                      "       deleted = 'N', " & _
                                      "       lupdnuser =   '" & Session("userid") & "', " & _
                                      "       lupdndt = GETDATE() " & _
                                      "WHERE sysmarksno = 0" & Val(grow.Cells(0).Text)
                    End If
                    DataSetCreator.ExecuteQuery(strSqlQuery)
                End If
            Next
            RefreshGrid()
            DisplayCustomMessageSummary("Updated Successfully")
        Catch ex As Exception
            DisplayCustomMessageSummary("Updated Failed")
        End Try
    End Sub


    Private Sub RefreshGrid(Optional ByVal SearchCriteria As String = "")
        Try
            'If written.Text = "Y" Then
            '    If Val(WEM.Text) <= 0 Then
            '        DisplayCustomMessageSummary("Writter Exam Maximum Marks Not Entered")
            '        Exit Sub
            '    End If
            'End If
            'If oral.Text = "Y" Then
            '    If Val(OEM.Text) <= 0 Then
            '        DisplayCustomMessageSummary("Oral Exam Maximum Marks Not Entered")
            '        Exit Sub
            '    End If
            'End If
            If Val(sysstandardno.Text) > 0 And Val(sysdivisionno.Text) > 0 And Val(sysexamno.Text) > 0 And Val(syssubjectno.Text) > 0 Then
                Dim dt As DataTable
                dt = MarksEntry(Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text), Val(syssubjectno.Text))
                If dt.Rows.Count <> 0 Then
                    gvList.DataSource = dt
                    gvList.DataBind()
                    '   ExamMarksEntry.Visible = True
                Else
                    ' ExamMarksEntry.Visible = False
                End If
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Pager Then
                e.Row.Cells(0).Visible = True
            End If
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(1).Visible = False
                'e.Row.Cells(2).Visible = False
                'e.Row.Cells(3).Visible = False
                'e.Row.Cells(4).Visible = False
                e.Row.Cells(5).Visible = False
                'e.Row.Cells(6).Visible = False
                e.Row.Cells(7).Visible = False
                e.Row.Cells(9).Visible = False
                e.Row.Cells(10).Visible = False
                e.Row.Cells(11).Visible = False
                e.Row.Cells(13).Visible = False
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim dchk As CheckBox
                dchk = e.Row.FindControl("Selected")

                If Val(e.Row.Cells(0).Text) <> "0" Then
                    dchk.Checked = True
                Else
                    dchk.Checked = False
                End If

                Dim dwrittenmarks As TextBox
                dwrittenmarks = e.Row.FindControl("writtenmark")
                If e.Row.Cells(5).Text = "&nbsp;" Then
                    dwrittenmarks.Text = ""
                Else
                    dwrittenmarks.Text = e.Row.Cells(5).Text
                End If

                Dim doralmark As TextBox
                doralmark = e.Row.FindControl("oralmark")
                If e.Row.Cells(7).Text = "&nbsp;" Then
                    doralmark.Text = ""
                Else
                    doralmark.Text = e.Row.Cells(7).Text
                End If

                Dim dgracemark As TextBox
                dgracemark = e.Row.FindControl("gracemark")
                If e.Row.Cells(9).Text = "&nbsp;" Then
                    dgracemark.Text = ""
                Else
                    dgracemark.Text = e.Row.Cells(9).Text
                End If
                If written.Text = "Y" Then
                    dwrittenmarks.Enabled = True
                Else
                    dwrittenmarks.Enabled = True
                End If

                If oral.Text = "Y" Then
                    doralmark.Enabled = True
                Else
                    doralmark.Enabled = True
                End If

                Dim dAttStatus As DropDownList
                dAttStatus = e.Row.FindControl("preabsstatus")
                If e.Row.Cells(11).Text = "&nbsp;" Then
                Else
                    dAttStatus.Text = e.Row.Cells(11).Text
                    dAttStatus.BackColor = System.Drawing.Color.FromName("#D1E5FF")
                End If

                Dim ddesc As TextBox
                ddesc = e.Row.FindControl("description")
                If e.Row.Cells(13).Text = "&nbsp;" Then
                    ddesc.Text = ""
                Else
                    ddesc.Text = e.Row.Cells(13).Text
                End If

                If dAttStatus.Text = "02" Then
                    ddesc.Enabled = True
                Else
                    ddesc.Enabled = False
                End If
                SetValueType(TextType.NumericField, dwrittenmarks)
                SetValueType(TextType.NumericField, doralmark)
                SetValueType(TextType.NumericField, dgracemark)

                dwrittenmarks.TabIndex = e.Row.RowIndex + 1
                doralmark.TabIndex = e.Row.RowIndex + 1
                btnsave.TabIndex = e.Row.RowIndex + 2

            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub



    Protected Sub preabsstatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim AttStatus As DropDownList = DirectCast(sender, DropDownList)
            Dim row As GridViewRow = DirectCast(AttStatus.NamingContainer, GridViewRow)
            AttStatus = CType(row.FindControl("preabsstatus"), DropDownList)

            If AttStatus.Text = "02" Then
                CType(row.FindControl("description"), TextBox).Enabled = True
            Else
                CType(row.FindControl("description"), TextBox).Enabled = False
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub oralmark_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try

            Dim oralmark As TextBox = DirectCast(sender, TextBox)
            Dim row As GridViewRow = DirectCast(oralmark.NamingContainer, GridViewRow)
            oralmark = CType(row.FindControl("oralmark"), TextBox)

            Dim mark As String
            mark = CType(row.FindControl("oralmark"), TextBox).Text

            If OEM.Text <> "" Then
                If Val(CType(row.FindControl("oralmark"), TextBox).Text) > Val(OEM.Text) Then
                    DisplayCustomMessageSummary("Marks Should Not be Greater than Total Marks")
                    CType(row.FindControl("oralmark"), TextBox).Text = "0"
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Protected Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged

        Dim chkValue As Boolean = False
        If chkSelectAll.Checked Then
            chkValue = True
        Else
            chkValue = False
        End If
        Dim grow As GridViewRow
        For Each grow In gvList.Rows
            CType(grow.FindControl("Selected"), CheckBox).Checked = chkValue
        Next
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Dim delete As LinkButton = DirectCast(sender, LinkButton)
            'Dim row As GridViewRow = DirectCast(delete.NamingContainer, GridViewRow)
            'delete = CType(row.FindControl("btnDelete"), LinkButton)

            'Dim strSqlQuery As String
            'strSqlQuery = "DELETE FROM marksentry WHERE marksentry.sysstudentno = 0" & Val(row.Cells(1).Text) & " " & _
            '              "AND  sysstandardno = 0" & Val(sysstandardno.Text) & " " & _
            '              "AND  sysdivisionno = 0" & Val(sysdivisionno.Text) & " " & _
            '              "AND  syssubjectno = 0" & Val(syssubjectno.Text) & " " & _
            '              "AND  sysexamno = 0" & Val(sysexamno.Text) & " " & _
            '              "AND  yearcd = 0" & Val(yearcd.Text)

            'DataSetCreator.ExecuteQuery(strSqlQuery)
            'DisplayCustomMessageSummary("Deleted Successfully")
            'RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

End Class
