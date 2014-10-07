Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Educare.Utility
Imports Educare.Application.BusinessLayer

Partial Class dlpFacultyAttendance
    Inherits EducarePage

    Dim strPK As Double

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            PageMenuID = Request.QueryString("ID")
            'SessionUserData.UserAccess.MenuID = PageMenuID

            'objBO = New Application.facultyattendanceBO
            'btnClose.Attributes.Add("onClick", "self.location.replace(""" & Replace(SessionUserData.UserData.DashboardPage, "~/", "") & """); return false;")

            btnRemoveAttendance.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to remove attendance?')==0) {return false;} ")

            SetValueType(TextType.DateField, trndt)

            If Not IsPostBack Then
                trndt.ToolTip = "Date"
                btnRemoveAttendance.ToolTip = "Remove Attendance"
                btnSave.ToolTip = "Save"

                trndt.Text = FormatDate.ConvertToForm(Now.Date)

                gvfacultyList.DataSource = facultyAttendance(FormatDate.ConvertToDataBase(trndt.Text))
                gvfacultyList.DataBind()

                gvattsummery.DataSource = AttendenceSummery(FormatDate.ConvertToDataBase(trndt.Text))
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
            For Each grow In gvfacultyList.Rows
                Dim com As New SqlCommand("SELECT * FROM facultyattendance WHERE sysfacultyno = 0" & Val(grow.Cells(1).Text) & "   AND trndt = '" & FormatDate.ConvertToDataBase(trndt.Text) & "'", con)
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
                'dr("sysfacultyattno") = 0 & grow.Cells(0).Text
                dr("sysfacultyno") = 0 & grow.Cells(1).Text
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
         
            trndt.Text = ""
            monthdesc.Text = ""
            monthdays.Text = 0
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
            gvfacultyList.DataSource = facultyAttendance(FormatDate.ConvertToDataBase(trndt.Text))
            gvfacultyList.DataBind()
            gvattsummery.DataSource = AttendenceSummery(FormatDate.ConvertToDataBase(trndt.Text))
            gvattsummery.DataBind()
            Dim dTrndt As Date
            dTrndt = FormatDate.ConvertToDataBase(trndt.Text)
            MonthInfo(dTrndt.Month)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Protected Sub gvfacultyList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvfacultyList.RowCreated
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

    Protected Sub gvfacultyList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvfacultyList.RowDataBound
        Try
            'This condition is used to check RowType is Header
            If e.Row.RowType = DataControlRowType.Header Then
                For i As Integer = 0 To gvfacultyList.Columns.Count - 1
                    e.Row.Cells(i).ToolTip = gvfacultyList.Columns(i).HeaderText
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
                    'If dAttStatus.Text = "01" Then
                    '    dAttStatus.BackColor = Drawing.Color.LightBlue
                    'End If
                    'If dAttStatus.Text = "02" Then
                    '    dAttStatus.BackColor = Drawing.Color.Tomato
                    'End If
                    'If dAttStatus.Text = "03" Then
                    '    dAttStatus.BackColor = Drawing.Color.Aqua
                    'End If
                    dAttStatus.BackColor = System.Drawing.Color.FromName("#D1E5FF")
                End If
                e.Row.Attributes.Add("onclick", "javascript:ChangeRowColor('" & e.Row.ClientID & "')")
            End If
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub trndt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles trndt.TextChanged
        Try
            Dim dTrndt As Date
            If trndt.Text <> "" Then
                dTrndt = FormatDate.ConvertToDataBase(trndt.Text)
                RefreshGrid()
            End If
            MonthInfo(dTrndt.Month)
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
          
            If strErrorMessage.Length > 0 Then
                DisplayCustomMessageSummary(strErrorMessage)
                Exit Sub
            End If

            If trndt.Text.Length > 0 Then
                Dim strSqlQuery As String = ""
                strSqlQuery = "DELETE FROM  facultyattendance WHERE trndt = '" & FormatDate.ConvertToDataBase(trndt.Text) & "'     "
                DataSetCreator.ExecuteQuery(strSqlQuery)
                RefreshGrid()
            Else
                DisplayCustomMessageSummary("Data cannot be blank")
            End If

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Public Function facultyAttendance(ByVal trndt As String) As DataTable
        Try

            Dim strSqlString As String

            strSqlString = " SELECT facultyattendance.sysfacultyno ,   sysfacultyattno , '' grno , faculty.facultycode , faculty.facultyname facultyname ,     facultyattendance.attstatus   " & _
                            " FROM  facultyattendance  " & _
                            " INNER  JOIN faculty ON " & _
                            "        faculty.sysfacultyno = facultyattendance.sysfacultyno  " & _
                            " WHERE facultyattendance.trndt='" & trndt & "'" & _
                            " UNION   " & _
                            " SELECT faculty.sysfacultyno , 0 sysfacultyattno, '' grno ,faculty.facultycode , faculty.facultyname facultyname ,   '' attstatus  " & _
                            " FROM   faculty  " & _
                            " WHERE faculty.status = '01' " & _
                            " AND   faculty.sysfacultyno NOT IN " & _
                            " ( SELECT sysfacultyno " & _
                            "   FROM   facultyattendance  " & _
                            "   WHERE  facultyattendance.trndt='" & trndt & "')" & _
                            "   ORDER  BY facultyname "


            Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Function AttendenceSummery(ByVal trndt As String) As DataTable
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
                           " FROM  facultyattendance   " & _
                           " WHERE facultyattendance.trndt='" & trndt & "'" & _
                           " GROUP BY          " & _
                           "  trndt, yearcd"
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
