Imports System
Imports System.Data.SqlClient
Imports Educare.Utility
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.DataTable
Imports Educare.Application.BusinessLayer

Partial Class stdStudentForm
    Inherits EducarePage
    Dim strMessage As String
    Dim con As New SqlConnection
    Dim com As New SqlCommand

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetValueType(TextType.DateField, admissiondt)
        SetValueType(TextType.DateField, birthdt)
        SetValueType(TextType.NumericField, homepincode)
        SetValueType(TextType.TelephoneField, resphoneno)
        SetValueType(TextType.TelephoneField, mobileno)
        Btncancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return false;} ")

        If Not IsPostBack Then

            rollno.ToolTip = "Roll No"
            admissiondt.ToolTip = "Admission Date"
            sysstandardno.ToolTip = "Standard"
            sysdivisionno.ToolTip = "Division"
            schoolname.ToolTip = "School Name"
            status.ToolTip = "Status"
            sfirstname.ToolTip = "Student First Name"
            smiddlename.ToolTip = "Student Middle Name"
            slastname.ToolTip = "Student Last Name"
            ffirstname.ToolTip = "Father First Name"
            fmiddlename.ToolTip = "Father Middle Name"
            flastname.ToolTip = "Father Last Name"
            mfirstname.ToolTip = "Mother First Name"
            mmiddlename.ToolTip = "Mother Middle Name"
            mlastname.ToolTip = "Mother Last Name"
            birthdt.ToolTip = "Birth Date"
            gender.ToolTip = "Gender"
            emailid.ToolTip = "Email Id"
            homeaddress1.ToolTip = "Residence Address"
            homepincode.ToolTip = "Pincode"
            resphoneno.ToolTip = "Telephone Number"
            mobileno.ToolTip = "Mobile Number"
            Btnsave.ToolTip = "Save"
            Btncancel.ToolTip = "Cancel"


            schoolname.DataSource = GetschoolDetails(0)
            schoolname.DataBind()
            schoolname.Items.Insert(0, "--SELECT SCHOOL--")
            sysstandardno.DataSource = GetStandardDetails(0)
            sysstandardno.DataBind()
            sysstandardno.Items.Insert(0, "--SELECT STANDARD--")

            sysdivisionno.DataSource = GetDivisionDetails(0)
            sysdivisionno.DataBind()
            sysdivisionno.Items.Insert(0, "--SELECT DIVISION--")
            status.DataSource = GeneralCodeData("STST")
            status.DataBind()
            gender.DataSource = GeneralCodeData("GEND")
            gender.DataBind()
            gender.Items.Insert(0, "--SELECT GENDER--")
            RefreshGrid()
            AutoNumberNo()
        End If
    End Sub
   
    Protected Sub AutoNumberNo()
        Dim NextNo As Integer

        Try
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()
            com = New SqlCommand("SELECT MAX(rollno) AS Max_Number FROM student", con)
            NextNo = com.ExecuteScalar() + 1
            con.Close()
            rollno.Text = NextNo.ToString()
            rollno.Enabled = False
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try

    End Sub
    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsave.Click
     
        Try
            Dim strMessage As String
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()
            Dim com As New SqlCommand("SELECT * FROM student WHERE sysstudentno =0" & sysstudentno.Text, con)
            Dim ds As New DataSet
            Dim adaptor As New SqlDataAdapter(com)
            adaptor.Fill(ds)
            Dim dr As DataRow
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables(0).NewRow
                dr("createduser") = "" & Session("userid")
                dr("createddt") = Now
                strMessage = "Added Successfully"
            Else
                dr = ds.Tables(0).Rows(0)
                strMessage = "Updated Successfully"
            End If
            dr("rollno") = Val(rollno.Text)
            If admissiondt.Text.Length > 0 Then
                dr("admissiondt") = FormatDate.ConvertToForm(admissiondt.Text)
            End If
            dr("status") = status.SelectedItem.Value
            dr("lupdnuser") = "" & Session("userid")
            dr("lupdndt") = Now
            dr("deleted") = "N"
            dr("sysstandardno") = Val(sysstandardno.SelectedItem.Value)
            dr("sysdivisionno") = Val(sysdivisionno.SelectedItem.Value)

            dr("sysstudentno") = Val(sysstudentno.Text)
            dr("sfirstname") = sfirstname.Text
            dr("smiddlename") = smiddlename.Text
            dr("slastname") = slastname.Text
            If birthdt.Text.Length > 0 Then
                dr("birthdt") = FormatDate.ConvertToForm(birthdt.Text)
            End If
            dr("rollno") = Val(rollno.Text)

            dr("gender") = gender.SelectedItem.Value
            dr("homeaddress1") = homeaddress1.Text
            dr("homepincode") = Val(homepincode.Text)
            dr("resphoneno") = resphoneno.Text
            dr("schoolname") = schoolname.SelectedItem.Value
            dr("ffirstname") = ffirstname.Text
            dr("fmiddlename") = fmiddlename.Text
            dr("flastname") = flastname.Text
            dr("mfirstname") = mfirstname.Text
            dr("mmiddlename") = mmiddlename.Text
            dr("mlastname") = mlastname.Text
            dr("emailid") = emailid.Text
            dr("mobileno") = mobileno.Text

            If ds.Tables(0).Rows.Count = 0 Then
                ds.Tables(0).Rows.Add(dr)
            End If
            Dim cmdbld As New SqlCommandBuilder(adaptor)
            adaptor.Update(ds)
            RefreshGrid()
            InitilizeControls()
            DisplayCustomMessageSummary(strMessage)

        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub InitilizeControls()
        rollno.Text = ""
        sysstudentno.Text = Nothing
        admissiondt.Text = ""
        status.Text = Nothing
        sfirstname.Text = ""
        smiddlename.Text = ""
        slastname.Text = ""
        ffirstname.Text = ""
        fmiddlename.Text = ""
        flastname.Text = ""
        mfirstname.Text = ""
        mmiddlename.Text = ""
        mlastname.Text = ""
        birthdt.Text = ""
        gender.Text = Nothing
        homeaddress1.Text = ""
        homepincode.Text = ""
        resphoneno.Text = ""
        emailid.Text = ""
        mobileno.Text = ""
        sysstandardno.Text = Nothing
        sysdivisionno.Text = Nothing
        schoolname.Text = Nothing
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btncancel.Click
        InitilizeControls()
    End Sub
    'Protected Sub birthdt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles birthdt.TextChanged
    '    Try
    '        Dim birthdate As Date
    '        Dim currentdate As Date

    '        If birthdt.Text = "" Then
    '            DisplayCustomMessageSummary("Enter Birth Date")
    '        Else
    '            birthdate = FormatDate.ConvertToDataBase(birthdt.Text)
    '            currentdate = FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(Now))
    '            If (DateDiff(DateInterval.Year, birthdate, currentdate) - 1) <= 0 Then

    '                birthdt.Text = ""
    '                ErrorMessage = ErrorMessage & "Please enter the correct birth date.\n"
    '                DisplayCustomMessageSummary(ErrorMessage)
    '                birthdt.Focus()
    '                Exit Sub
    '            End If
    '        End If
    '    Catch ex As Exception
    '        DisplayCustomMessageSummary(ex.Message)
    '    End Try
    'End Sub



    'Protected Sub sysstandardno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sysstandardno.SelectedIndexChanged
    '    Try
    '        If sysstandardno.SelectedIndex = 0 Then
    '            ErrorMessage = ErrorMessage & "Select Standard.\n "
    '            Exit Sub
    '        End If

    '        sysdivisionno.DataSource = GetDivisionDetails(0)
    '        sysdivisionno.DataBind()
    '        sysdivisionno.Items.Insert(0, "")

    '        RefreshGrid()

    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysstudentno.Text = row.Cells(0).Text

            Dim ds As New DataSet
            ds = DataSetCreator.GetDataSet("SELECT * FROM student WHERE  sysstudentno=0" & sysstudentno.Text)

            sysstudentno.Text = ds.Tables(0).Rows(0)("sysstudentno")
            sfirstname.Text = ds.Tables(0).Rows(0)("sfirstname")
            smiddlename.Text = ds.Tables(0).Rows(0)("smiddlename")
            slastname.Text = ds.Tables(0).Rows(0)("slastname")
            sysstandardno.Text = ds.Tables(0).Rows(0)("sysstandardno")
            sysdivisionno.Text = ds.Tables(0).Rows(0)("sysdivisionno")

            rollno.Text = ds.Tables(0).Rows(0)("rollno")

            birthdt.Text = ds.Tables(0).Rows(0)("birthdt")
            ffirstname.Text = ds.Tables(0).Rows(0)("ffirstname")
            fmiddlename.Text = ds.Tables(0).Rows(0)("fmiddlename")
            flastname.Text = ds.Tables(0).Rows(0)("flastname")
            schoolname.Text = ds.Tables(0).Rows(0)("schoolname")
            mfirstname.Text = ds.Tables(0).Rows(0)("mfirstname")
            mmiddlename.Text = ds.Tables(0).Rows(0)("mmiddlename")
            mlastname.Text = ds.Tables(0).Rows(0)("mlastname")
            admissiondt.Text = ds.Tables(0).Rows(0)("admissiondt")
            homeaddress1.Text = ds.Tables(0).Rows(0)("homeaddress1")
            homepincode.Text = ds.Tables(0).Rows(0)("homepincode")
            mobileno.Text = ds.Tables(0).Rows(0)("mobileno")

            emailid.Text = ds.Tables(0).Rows(0)("emailid")
            resphoneno.Text = ds.Tables(0).Rows(0)("resphoneno")

            gender.Text = ds.Tables(0).Rows(0)("gender")

            status.Text = ds.Tables(0).Rows(0)("status")
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysstudentno.Text = row.Cells(0).Text
            DataSetCreator.ExecuteQuery("UPDATE student SET deleted = 'Y' WHERE sysstudentno =0" & sysstudentno.Text)
            RefreshGrid()
            InitilizeControls()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid()
        gvList.DataSource = DataSetCreator.GetDataSet("SELECT student.*, standard.sysstandardno,division.sysdivisionno, RIGHT(CONVERT(VARCHAR(10),admissiondt,112),2) + '/' + LEFT(RIGHT(CONVERT(VARCHAR(10),admissiondt,112),4),2) + '/' + LEFT(CONVERT(VARCHAR(10),admissiondt,112),4) vadmissiondt " & _
                                                      "FROM  student " & _
                                                      "INNER JOIN standard  on " & _
                                                      "      standard.sysstandardno = student.sysstandardno " & _
                                                      " INNER JOIN division on " & _
                                                      "      division.sysdivisionno = student.sysdivisionno ")





        gvList.DataBind()
        



    End Sub

    Protected Sub gvList_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvList.PageIndexChanged

    End Sub

    Protected Sub gvList_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowCreated

        If e.Row.RowType = DataControlRowType.Pager Then
            e.Row.Cells(0).Visible = True
        End If
        If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(0).Visible = False
        End If
    End Sub

    Protected Sub gvList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvList.RowDataBound
        'This condition is used to check RowType is Header
        If e.Row.RowType = DataControlRowType.Header Then
            For i As Integer = 0 To gvList.Columns.Count - 1
                e.Row.Cells(i).ToolTip = gvList.Columns(i).HeaderText
            Next
        End If

    End Sub

    Protected Sub gvlist_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvList.PageIndexChanging
        Try
            gvList.PageIndex = e.NewPageIndex
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub
End Class