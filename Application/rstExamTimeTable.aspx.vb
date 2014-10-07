Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class rstExamTimeTable
    Inherits EducarePage
    'Dim objBO As Application.examtimetableBO
    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            ' SessionUserData.UserAccess.MenuID = PageMenuID

            If Not IsPostBack Then
                sysstandardno.ToolTip = "Standard"
                sysdivisionno.ToolTip = "Division"
                sysexamno.ToolTip = "Exam"
                btnsave.ToolTip = "Save"
                btnCancel.ToolTip = "Cancel"
               
                sysstandardno.DataSource = GetStandardDetails(0)
                sysstandardno.DataBind()
                sysstandardno.Items.Insert(0, "--SELECT STANDARD--")

                sysexamno.Items.Insert(0, "")
                ExamPortionCriteria.Visible = False

            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try

            Dim grow As GridViewRow
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()

            For Each grow In gvList.Rows
                '    objBO = New Application.examtimetableBO

                If CType(grow.FindControl("Selected"), CheckBox).Checked Then
                    Dim com As New SqlCommand("SELECT * FROM examtimetable WHERE syssubjectno = 0" & Val(grow.Cells(1).Text) & " AND sysstandardno = 0" & Val(sysstandardno.Text) & " AND sysdivisionno = 0" & Val(sysdivisionno.Text) & " AND sysexamno = 0" & Val(sysexamno.Text), con)
                    Dim ds As New DataSet
                    Dim adaptor As New SqlDataAdapter(com)
                    adaptor.Fill(ds)
                    Dim dr As DataRow
                    If ds.Tables(0).Rows.Count = 0 Then
                        dr = ds.Tables(0).NewRow
                        dr("createduser") = Session("userid")
                        dr("createddt") = Now
                    Else
                        dr = ds.Tables(0).Rows(0)
                    End If

                    'dr("sysexamtimetblno") = 0 & grow.Cells(0).Text
                    dr("sysstandardno") = 0 & sysstandardno.Text
                    dr("sysdivisionno") = 0 & sysdivisionno.Text
                    dr("sysexamno") = 0 & sysexamno.Text
                    dr("syssubjectno") = 0 & grow.Cells(1).Text
                    dr("trndt") = FormatDate.ConvertToDataBase(CType(grow.FindControl("trndt"), TextBox).Text)
                    dr("fromtime") = CType(grow.FindControl("fromtime"), TextBox).Text
                    dr("totime") = CType(grow.FindControl("totime"), TextBox).Text
                    dr("yearcd") = 1
                    dr("deleted") = "N"
                    dr("lupdnuser") = Session("userid")
                    dr("lupdndt") = Now()

                    If ds.Tables(0).Rows.Count = 0 Then
                        ds.Tables(0).Rows.Add(dr)
                    End If
                    Dim cmdbld As New SqlCommandBuilder(adaptor)
                    adaptor.Update(ds)
                Else
                    If Val(0 & grow.Cells(0).Text) <> 0 Then
                        DataSetCreator.ExecuteQuery("DELETE FROM examtimetable WHERE sysexamtimetblno = 0" & grow.Cells(0).Text)
                    End If
                End If
            Next
            DisplayCustomMessageSummary("Updated Successfully..")
            RefreshGrid()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
        DisplayCustomMessageSummary(ErrorMessage)
    End Sub

    Private Sub RefreshGrid(Optional ByVal SearchCriteria As String = "")
        Try
            gvList.DataSource = Nothing
            gvList.DataBind()

            Dim dt As DataTable
            dt = ExamTimeTable(Val(sysstandardno.Text), Val(sysdivisionno.Text), Val(sysexamno.Text))
            If dt.Rows.Count <> 0 Then
                gvList.DataSource = dt
                gvList.DataBind()
                ExamPortionCriteria.Visible = True

            Else
                ExamPortionCriteria.Visible = True

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    'Protected Sub gvList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
    '    Try
    '        gvList.PageIndex = e.NewPageIndex
    '        RefreshGrid()
    '    Catch ex As Exception
    '        DisplayCustomMessageSummary(ex.Message)
    '    End Try
    'End Sub

    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Pager Then
                e.Row.Cells(0).Visible = True
            End If
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(1).Visible = False
                e.Row.Cells(4).Visible = False
                e.Row.Cells(6).Visible = False
                e.Row.Cells(8).Visible = False
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        Try

            'This condition is used to check RowType is Header
            If e.Row.RowType = DataControlRowType.Header Then
                For i As Integer = 0 To gvList.Columns.Count - 1
                    e.Row.Cells(i).ToolTip = gvList.Columns(i).HeaderText
                Next
            End If


            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim dchk As CheckBox
                dchk = e.Row.FindControl("Selected")

                If Val(e.Row.Cells(0).Text) <> "0" Then
                    dchk.Checked = True
                Else
                    dchk.Checked = False
                End If

                Dim dtrndt As TextBox
                dtrndt = e.Row.FindControl("trndt")
                If e.Row.Cells(4).Text = "&nbsp;" Then
                    dtrndt.Text = ""
                Else
                    dtrndt.Text = FormatDate.ConvertToForm(e.Row.Cells(4).Text)
                End If

                Dim dfromtime As TextBox
                dfromtime = e.Row.FindControl("fromtime")
                If e.Row.Cells(6).Text = "&nbsp;" Then
                    dfromtime.Text = ""
                Else
                    dfromtime.Text = e.Row.Cells(6).Text
                End If
                Dim dtotime As TextBox
                dtotime = e.Row.FindControl("totime")
                If e.Row.Cells(8).Text = "&nbsp;" Then
                    dtotime.Text = ""
                Else
                    dtotime.Text = e.Row.Cells(8).Text
                End If

                SetValueType(TextType.DateField, dtrndt)

            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub InitializeControls()
        Try
            strPK = 0
            sysexamtimetblno.Text = ""
            'syssubjectno.Text = Nothing
            sysstandardno.Text = Nothing
            sysdivisionno.Text = Nothing
            sysexamno.Text = Nothing



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
            RefreshGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub sysdivisionno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysdivisionno.SelectedIndexChanged
        Try

            RefreshGrid()
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

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            InitializeControls()
            ExamPortionCriteria.Visible = False

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


End Class
