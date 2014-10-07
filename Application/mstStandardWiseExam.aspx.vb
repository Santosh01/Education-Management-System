Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class mstStandardWiseExam
    Inherits EducarePage

    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            If chkAllSelected.Checked = True Then
                btnCancel.Enabled = False
            Else
                btnCancel.Enabled = True

            End If
            If Not IsPostBack Then
                sysstandardno.ToolTip = "Standard"
                btnsave.ToolTip = "Save"
                btnCancel.ToolTip = "Cancel"
                sysstandardno.DataSource = GetStandardDetails(0)
                sysstandardno.DataBind()
                sysstandardno.Items.Insert(0, "")


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
                If CType(grow.FindControl("Selected"), CheckBox).Checked Then

                    Dim com As New SqlCommand("SELECT * FROM stdwiseexam WHERE sysexamno = 0" & Val(grow.Cells(1).Text) & " AND sysstandardno = 0" & Val(sysstandardno.Text), con)
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

                    dr("sysstdexamno") = 0 & grow.Cells(0).Text
                    dr("sysstandardno") = 0 & sysstandardno.Text
                    dr("sysexamno") = 0 & grow.Cells(1).Text

                    dr("yearcd") = 1
                    dr("deleted") = "N"
                    dr("lupdnuser") = "" & Session("userid")
                    dr("lupdndt") = Now()
                    If ds.Tables(0).Rows.Count = 0 Then
                        ds.Tables(0).Rows.Add(dr)
                    End If
                    Dim cmdbld As New SqlCommandBuilder(adaptor)
                    adaptor.Update(ds)
                Else
                    If Val(0 & grow.Cells(0).Text) <> 0 Then
                        DataSetCreator.ExecuteQuery("DELETE FROM stdwiseexam WHERE sysstdexamno = 0" & grow.Cells(0).Text)
                    End If
                End If

            Next

            DisplayCustomMessageSummary("Updated Successfully..")

            InitializeControls()
            RefreshGrid()

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
        DisplayCustomMessageSummary(ErrorMessage)
    End Sub

    Private Sub RefreshGrid(Optional ByVal SearchCriteria As String = "")
        Try

            If Val(sysstandardno.Text) = 0 Then
                Exit Sub
            End If
            Dim dt As DataTable
            dt = StandardWiseExamination(Val(sysstandardno.Text), IIf(chkAllSelected.Checked, "SELECTED", "ALL"))
            If dt.Rows.Count <> 0 Then
                gvList.DataSource = dt
                gvList.DataBind()
                gvList.Visible = True
            Else
                gvList.Visible = False
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

    Protected Sub gvlist_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvlist.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dchk As CheckBox
                dchk = e.Row.FindControl("Selected")
                If Val(e.Row.Cells(0).Text) <> "0" Then
                    dchk.Checked = True
                Else
                    dchk.Checked = False
                End If
            End If

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub InitializeControls()
        Try
            strPK = 0
            gvList.DataSource = Nothing
            gvList.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub


    Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
        Try
            If sysstandardno.SelectedIndex = 0 Then
                ErrorMessage = ErrorMessage & "* Select standard.\n "
                Exit Sub
            End If
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub chkAllSelected_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAllSelected.CheckedChanged
        Try

            RefreshGrid()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Try
            InitializeControls()
            gvList.Visible = False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
