Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class stdAttendanceEntry
    Inherits EducarePage

    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            btnRemoveAttendance.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to remove attendance?')==0) {return false;} ")

            SetValueType(TextType.DateField, trndt)

            If Not IsPostBack Then
                trndt.ToolTip = "Date"
                sysstandardno.ToolTip = "Standard"
                sysdivisionno.ToolTip = "Division"
                btnRemoveAttendance.ToolTip = "Remove Attendance"
                btnSave.ToolTip = "Save"

                trndt.Text = FormatDate.ConvertToForm(Now.Date)

                sysstandardno.DataSource = GetStandardDetails(0)
                sysstandardno.DataBind()
                sysstandardno.Items.Insert(0, "")
                sysstandardno.BackColor = Drawing.Color.MintCream
                sysdivisionno.DataSource = GetDivisionDetails(0)
                sysdivisionno.DataBind()
                sysdivisionno.Items.Insert(0, "")
                sysdivisionno.BackColor = Drawing.Color.MintCream
                gvStudentList.DataSource = StudentAttendance(Val(sysstandardno.Text), Val(sysdivisionno.Text), FormatDate.ConvertToDataBase(trndt.Text))
                gvStudentList.DataBind()

                gvattsummery.DataSource = AttendenceSummery(Val(sysstandardno.Text), Val(sysdivisionno.Text), FormatDate.ConvertToDataBase(trndt.Text))
                gvattsummery.DataBind()
            End If

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim grow As GridViewRow
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()
            For Each grow In gvStudentList.Rows
                Dim com As New SqlCommand("SELECT * FROM studentattendence WHERE sysstudentno = 0" & Val(grow.Cells(1).Text) & " AND sysstandardno = 0" & Val(sysstandardno.Text) & " AND sysdivisionno = 0" & Val(sysdivisionno.Text & " AND trndt = '" & FormatDate.ConvertToDataBase(trndt.Text) & "'"), con)
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
                'dr("sysstudattno") = 0 & grow.Cells(0).Text
                dr("sysstudentno") = 0 & grow.Cells(1).Text
                dr("sysstandardno") = 0 & sysstandardno.Text
                dr("sysdivisionno") = 0 & sysdivisionno.Text
                dr("systeacherno") = 0 & systeacherno.Text
                dr("trndt") = FormatDate.ConvertToDataBase(trndt.Text)
                dr("monthname") = monthdesc.Text
                dr("monthdays") = 0 & monthdays.Text
                dr("attstatus") = CType(grow.FindControl("attstatus"), DropDownList).Text
                dr("yearcd") = 1
                dr("deleted") = "N"
                dr("lupdnuser") = "" & Session("userid")
                dr("lupdndt") = Now()
                If ds.Tables(0).Rows.Count = 0 Then
                    ds.Tables(0).Rows.Add(dr)
                End If
                Dim cmdbld As New SqlCommandBuilder(adaptor)
                adaptor.Update(ds)
            Next
            DisplayCustomMessageSummary("Updated Successfully..")
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
        DisplayCustomMessageSummary(ErrorMessage)
    End Sub

    Private Sub InitializeControls()
        Try
            strPK = 0
            sysdivisionno.Text = Nothing
            sysstandardno.Text = Nothing

            systeacherno.Text = ""

            trndt.Text = ""
            Monthdesc.Text = ""
            Monthdays.Text = 0
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

    Private Sub RefreshGrid(Optional ByVal SearchCriteria As String = "")
        Try
            gvStudentList.DataSource = StudentAttendance(Val(sysstandardno.Text), Val(sysdivisionno.Text), FormatDate.ConvertToDataBase(trndt.Text))
            gvStudentList.DataBind()
            gvattsummery.DataSource = AttendenceSummery(Val(sysstandardno.Text), Val(sysdivisionno.Text), FormatDate.ConvertToDataBase(trndt.Text))
            gvattsummery.DataBind()
            Dim dTrndt As Date
            dTrndt = FormatDate.ConvertToDataBase(trndt.Text)
            MonthInfo(dTrndt.Month)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub gvStudentList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvStudentList.PageIndexChanging
        Try
            gvStudentList.PageIndex = e.NewPageIndex
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub gvStudentList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudentList.RowCreated
        Try
            If e.Row.RowType = DataControlRowType.Pager Then
                e.Row.Cells(0).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(1).Visible = False
                e.Row.Cells(5).Visible = False
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub gvStudentList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvStudentList.RowDataBound
        Try

            'This condition is used to check RowType is Header
            If e.Row.RowType = DataControlRowType.Header Then
                For i As Integer = 0 To gvStudentList.Columns.Count - 1
                    e.Row.Cells(i).ToolTip = gvStudentList.Columns(i).HeaderText
                Next
            End If

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim dAttStatus As DropDownList
                dAttStatus = e.Row.FindControl("attstatus")

                If e.Row.Cells(5).Text = "02" Then
                    e.Row.Cells(0).ForeColor = Drawing.Color.Red
                    e.Row.Cells(1).ForeColor = Drawing.Color.Red
                    e.Row.Cells(2).ForeColor = Drawing.Color.Red
                    e.Row.Cells(3).ForeColor = Drawing.Color.Red
                    e.Row.Cells(4).ForeColor = Drawing.Color.Red
                End If

                If e.Row.Cells(5).Text = "&nbsp;" Then
                    dAttStatus.DataSource = GeneralCodeData("ATST")
                    dAttStatus.DataBind()
                Else
                    dAttStatus.DataSource = GeneralCodeData("ATST")
                    dAttStatus.DataBind()
                    dAttStatus.Text = e.Row.Cells(5).Text
                    If dAttStatus.Text = "01" Then
                        dAttStatus.BackColor = Drawing.Color.LightBlue
                    End If
                    If dAttStatus.Text = "02" Then
                        dAttStatus.BackColor = Drawing.Color.Tomato
                    End If
                    If dAttStatus.Text = "03" Then
                        dAttStatus.BackColor = Drawing.Color.Aqua
                    End If
                    dAttStatus.BackColor = System.Drawing.Color.FromName("#D1E5FF")
                End If
                e.Row.Attributes.Add("onclick", "javascript:ChangeRowColor('" & e.Row.ClientID & "')")


            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub sysdivisionno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysdivisionno.SelectedIndexChanged
        Try
            If sysdivisionno.SelectedItem.Text = "" Then
                DisplayCustomMessageSummary("Please select division")
                Exit Sub
            End If
            If sysdivisionno.SelectedItem.Text <> "" And trndt.Text <> "" Then
                systeacherno.Text = ""

                RefreshGrid()
            Else
                systeacherno.Text = ""

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub trndt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trndt.TextChanged
        Try
            Dim dTrndt As Date
            If trndt.Text <> "" Then
                dTrndt = FormatDate.ConvertToDataBase(trndt.Text)
                If sysdivisionno.SelectedItem.Text <> "" Then
                    RefreshGrid()
                End If
            End If
            MonthInfo(dTrndt.Month)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
        Try

            systeacherno.Text = ""


            Dim dt As DataTable
            dt = GetDivisionDetails(Val(sysstandardno.Text)).Tables(0)
            sysdivisionno.DataSource = dt
            sysdivisionno.DataBind()
            sysdivisionno.Items.Insert(0, "")
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub MonthInfo(ByVal monthno As Decimal)
        Try
            'Dim monthno As Decimal
            'monthno = Month(trndt)

            Select Case monthno

                Case 1
                    monthdesc.Text = "January"
                    monthdays.Text = 31

                Case 2
                    monthdesc.Text = "February"
                    monthdays.Text = 28

                Case 3
                    monthdesc.Text = "March"
                    monthdays.Text = 31

                Case 4
                    monthdesc.Text = "April"
                    monthdays.Text = 30

                Case 5
                    monthdesc.Text = "May"
                    monthdays.Text = 31

                Case 6
                    monthdesc.Text = "June"
                    monthdays.Text = 30

                Case 7
                    monthdesc.Text = "July"
                    monthdays.Text = 31

                Case 8
                    monthdesc.Text = "August"
                    monthdays.Text = 31

                Case 9
                    monthdesc.Text = "September"
                    monthdays.Text = 30

                Case 10
                    monthdesc.Text = "October"
                    monthdays.Text = 31

                Case 11
                    monthdesc.Text = "November"
                    monthdays.Text = 30

                Case 12
                    monthdesc.Text = "December"
                    monthdays.Text = 31

            End Select

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub btnRemoveAttendance_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAttendance.Click
        Try

            Dim strErrorMessage As String = ""


            If trndt.Text.Length <= 0 Then
                strErrorMessage = strErrorMessage & "Date Cannot Be Blank" & vbNewLine
            End If
            If Val(sysstandardno.Text) = 0 Then
                strErrorMessage = strErrorMessage & "Standard Cannot Be Blank" & vbNewLine
            End If
            If Val(sysdivisionno.Text) = 0 Then
                strErrorMessage = strErrorMessage & "Division Cannot Be Blank" & vbNewLine
            End If
            If strErrorMessage.Length > 0 Then
                DisplayCustomMessageSummary(strErrorMessage)
                Exit Sub
            End If

            If trndt.Text.Length > 0 And Val(sysdivisionno.Text) > 0 And Val(sysstandardno.Text) > 0 Then
                Dim strSqlQuery As String = ""
                strSqlQuery = "DELETE FROM  studentattendence WHERE trndt = '" & FormatDate.ConvertToDataBase(trndt.Text) & "'    AND   sysstandardno =  0" & Val(sysstandardno.Text) & "   AND   sysdivisionno =  0" & Val(sysdivisionno.Text) & "      "
                DataSetCreator.ExecuteQuery(strSqlQuery)
                RefreshGrid()
            Else
                DisplayCustomMessageSummary("Data cannot be blank")
            End If

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Public Function StudentAttendance(ByVal sysstandardno As Double, ByVal sysdivisionno As Double, ByVal trndt As String) As DataTable
        Try

            Dim strSqlString As String

            strSqlString = " SELECT studentattendence.sysstudentno ,   sysstudattno , student.grno , student.rollno , student.sfirstname + ' ' + student.smiddlename + ' ' + student.slastname fullname ,     studentattendence.attstatus   " & _
                            " FROM  studentattendence  " & _
                            " INNER  JOIN student ON " & _
                            "        student.sysstudentno = studentattendence.sysstudentno  " & _
                            " WHERE studentattendence.sysstandardno=0" & sysstandardno & _
                            " AND   studentattendence.sysdivisionno=0" & sysdivisionno & _
                            " AND   studentattendence.trndt='" & trndt & "'" & _
                            " UNION   " & _
                            " SELECT student.sysstudentno , 0 sysstudattno, student.grno ,student.rollno , student.sfirstname + ' ' + student.smiddlename + ' ' + student.slastname fullname ,   '' attstatus  " & _
                            " FROM   student  " & _
                            " WHERE student.sysstandardno=0" & sysstandardno & _
                            " AND   student.sysdivisionno=0" & sysdivisionno & _
                            " AND   student.studentstatus = '01' " & _
                            " AND   student.sysstudentno NOT IN " & _
                            "                                ( SELECT sysstudentno " & _
                            "                                  FROM   studentattendence  " & _
                            "                                  WHERE  studentattendence.sysstandardno=0" & sysstandardno & _
                            "                                  AND    studentattendence.sysdivisionno=0" & sysdivisionno & _
                            "                                  AND    studentattendence.trndt='" & trndt & "')" & _
                            "   ORDER  BY rollno "


            Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function AttendenceSummery(ByVal sysstandardno As Double, ByVal sysdivisionno As Double, ByVal trndt As String) As DataTable
        Dim strSqlString As String = ""
        Try

            strSqlString = " SELECT trndt ,  " & _
                           " COUNT(CASE WHEN attstatus ='01' THEN 'Present'  " & _
                           "             END  ) AS Present,  " & _
                           " COUNT(CASE WHEN attstatus ='02' THEN 'Absent'  " & _
                           "             END  ) AS Absent,  " & _
                           " COUNT(CASE WHEN attstatus ='03' THEN 'Sick'  " & _
                           "             END  ) AS Sick ,    " & _
                           " COUNT(CASE WHEN attstatus ='04' THEN 'Sports'  " & _
                           "             END  ) AS Sports ,    " & _
                           " COUNT(CASE WHEN attstatus ='01' THEN 'Present'  " & _
                           "             END  )   +  " & _
                           " COUNT(CASE WHEN attstatus ='02' THEN 'Absent'  " & _
                           "             END  )   +  " & _
                           " COUNT(CASE WHEN attstatus ='03' THEN 'Sick'  " & _
                           "             END  )   +  " & _
                           " COUNT(CASE WHEN attstatus ='04' THEN 'Sports'  " & _
                           "             END  ) AS Total       " & _
                           " FROM  studentattendence   " & _
                           " WHERE studentattendence.sysstandardno=0" & sysstandardno & _
                           " AND   studentattendence.sysdivisionno=0" & sysdivisionno & _
                           " AND   studentattendence.trndt='" & trndt & "'" & _
                           " GROUP BY       sysstandardno ,  " & _
                           " sysdivisionno, trndt, yearcd"
            Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Protected Sub gvattsummery_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvattsummery.RowDataBound
        'This condition is used to check RowType is Header
        If e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To gvattsummery.Columns.Count - 1
                e.Row.Cells(i).ToolTip = gvattsummery.Columns(i).HeaderText
            Next
        End If
    End Sub


End Class
