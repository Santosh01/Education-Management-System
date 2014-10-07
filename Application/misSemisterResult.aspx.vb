
Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class misSemisterResult
    Inherits EducarePage

    'Dim objBO As Application.examtimetableBO
    Dim strPK As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            'SessionUserData.UserAccess.MenuID = PageMenuID
            btnClose.Attributes.Add("onClick", "self.location.replace(""Dashboard.aspx""); return false;")
            If Not IsPostBack Then
                sysstandardno.ToolTip = "Standard"
                sysdivisionno.ToolTip = "Division"
                btnprint.ToolTip = "Print"
                btnClose.ToolTip = "Close"
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
            If sysstandardno.SelectedIndex = 0 Then
                DisplayCustomMessageSummary("Select Standard.")
                Exit Sub
            End If
            'If sysexamno.SelectedIndex = 0 Then
            '    DisplayCustomMessageSummary("Select Exam.")
            '    Exit Sub
            'End If
            Dim vstandard As Double = 0
            Dim vexam As String = "0"
            Dim vdivision As Double = 0
            Dim vrollno As String = ""
            If sysstandardno.SelectedIndex = 0 Then
                vstandard = 0
            Else
                vstandard = Val(sysstandardno.Text)
            End If

            'If sysexamno.SelectedIndex = 0 Then
            '    vexam = 0
            'Else
            '    vexam = Val(sysexamno.Text)
            'End If

            Dim grow As GridViewRow

            For Each grow In gvList.Rows
                If CType(grow.FindControl("Selected"), CheckBox).Checked Then
                    vexam = vexam & "," & grow.Cells(1).Text & ""
                End If
            Next
            '
            vexam = vexam.Replace("'", "|")
            If sysdivisionno.SelectedIndex = 0 Then
                vdivision = 0
            Else
                vdivision = Val(sysdivisionno.Text)
            End If
            If rollno.Text = "" Then
                vrollno = ""
            Else
                vrollno = rollno.Text
            End If
            Response.Write("<script type='text/javascript'>detailedresults=window.open('misSemisterResultBrowse.aspx?sysexamno=" & vexam & "&sysstandardno=" & vstandard & "&sysdivisionno=" & vdivision & "&rollno=" & vrollno & " ');</script>")
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
        Try
            sysdivisionno.DataSource = GetDivisionDetails(0)
            sysdivisionno.DataBind()
            sysdivisionno.Items.Insert(0, "")
            RefreshGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid(Optional ByVal SearchCriteria As String = "")
        Try
            If Val(sysstandardno.Text) <> 0 Then
                gvList.DataSource = StandardWiseExam(Val(sysstandardno.Text))
                gvList.DataBind()
            Else
                gvList.DataSource = Nothing
                gvList.DataBind()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub gvlist_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Pager Then
                e.Row.Cells(0).Visible = True
            End If
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(1).Visible = False
            End If
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
