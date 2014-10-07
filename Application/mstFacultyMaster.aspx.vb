Imports System
Imports System.Data.SqlClient
Imports Educare.Utility
Imports System.Data
'Imports System.Data.DataRow
Imports System.Data.DataTable
Imports Educare.Application.BusinessLayer
Partial Class mstFacultyMaster
    Inherits EducarePage
    Dim strMessage As String
    Dim con As New SqlConnection
    Dim com As New SqlCommand
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        SetValueType(TextType.DateField, joineddt)
        SetValueType(TextType.DateField, birthdt)
        SetValueType(TextType.TelephoneField, mobileno)
        SetValueType(TextType.TelephoneField, telno)
        SetValueType(TextType.NumericField, pincode)
        SetValueType(TextType.AlphNumericField, qualification)
        SetValueType(TextType.CharacterField, facultyname)
        btnCancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return false;} ")



        If Not IsPostBack Then
            facultycode.ToolTip = "Faculty Code"
            sysschoolno.ToolTip = "School Name"
            status.ToolTip = "Status"
            facultyname.ToolTip = "Faculty Name"
            birthdt.ToolTip = "Birth Date"
            gender.ToolTip = "Gender"
            maritalstatus.ToolTip = "Marital Status"
            qualification.ToolTip = "Qualification"
            emailid.ToolTip = "Email Id"
            telno.ToolTip = "Telephone Number"
            mobileno.ToolTip = "Mobile Number"
            joineddt.ToolTip = "Joined Date"
            address1.ToolTip = "Residence Address"
            pincode.ToolTip = "Pincode"
            btnsave.ToolTip = "Save"
            btnCancel.ToolTip = "Cancel"
            sysschoolno.DataSource = GetschoolDetails(0)
            sysschoolno.DataBind()
            sysschoolno.Items.Insert(0, "--SELECT SCHOOL NAME--")

            facultyname1.DataSource = GeneralCodeData("SALU")
            facultyname1.DataBind()

            maritalstatus.DataSource = GeneralCodeData("MRST")
            maritalstatus.DataBind()
            maritalstatus.Items.Insert(0, "--SELECT MARITAL STATUS--")

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
            com = New SqlCommand("SELECT MAX( facultycode) AS Max_Number FROM faculty", con)
            NextNo = com.ExecuteScalar() + 1
            con.Close()
            facultycode.Text = NextNo.ToString()
            facultycode.Enabled = False
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try

    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Response.Redirect("Dashboard.aspx")
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click

        Try
            Dim strMessage As String
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()

            Dim com As New SqlCommand("SELECT * FROM faculty WHERE sysfacultyno =0" & sysfacultyno.Text, con)

            Dim ds As New DataSet
            Dim adaptor As New SqlDataAdapter(com)
            adaptor.Fill(ds)
            Dim dr As DataRow
            If ds.Tables(0).Rows.Count = 0 Then
                dr = ds.Tables(0).NewRow
                strMessage = "Added Successfully"
            Else
                dr = ds.Tables(0).Rows(0)
                strMessage = "Updated Successfully"
            End If

            dr("sysfacultyno") = Val(sysfacultyno.Text)
            dr("facultycode") = facultycode.Text
            dr("facultyname1") = facultyname1.Text
            dr("facultyname") = facultyname.Text
            dr("gender") = gender.SelectedItem.Value

            dr("telno") = telno.Text
            dr("mobileno") = mobileno.Text
            dr("emailid") = emailid.Text
            dr("address1") = address1.Text
            dr("pincode") = pincode.Text
            dr("sysschoolno") = sysschoolno.SelectedItem.Value

            If birthdt.Text.Length > 0 Then
                dr("birthdt") = FormatDate.ConvertToDataBase(birthdt.Text)
            End If
            dr("maritalstatus") = maritalstatus.SelectedItem.Value
            If joineddt.Text.Length > 0 Then
                dr("joineddt") = FormatDate.ConvertToDataBase(joineddt.Text)

            End If
            dr("qualification") = qualification.Text
            dr("status") = status.SelectedItem.Value

            dr("deleted") = "N"
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
        sysfacultyno.Text = ""
        facultycode.Text = ""
        facultyname.Text = ""
        gender.Text = Nothing
        telno.Text = ""
        mobileno.Text = ""
        emailid.Text = ""
        birthdt.Text = ""
        maritalstatus.Text = Nothing
        joineddt.Text = ""
        qualification.Text = ""
        address1.Text = ""
        pincode.Text = ""
        sysschoolno.Text = Nothing

    End Sub

    'Protected Sub CalendarButtonExtender1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
    '    joineddt.Text = Image1.SelectedDate.ToShortDateString("dd/mm/yyyy")
    'End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        InitilizeControls()
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysfacultyno.Text = row.Cells(0).Text

            Dim ds As New DataSet
            ds = DataSetCreator.GetDataSet("SELECT * FROM faculty WHERE  sysfacultyno=0" & sysfacultyno.Text)
            facultycode.Text = ds.Tables(0).Rows(0)("facultycode")

            sysfacultyno.Text = ds.Tables(0).Rows(0)("sysfacultyno")
            facultyname1.Text = ds.Tables(0).Rows(0)("facultyname1")
            facultyname.Text = ds.Tables(0).Rows(0)("facultyname")

            telno.Text = ds.Tables(0).Rows(0)("telno")
            mobileno.Text = ds.Tables(0).Rows(0)("mobileno")
            joineddt.Text = ds.Tables(0).Rows(0)("joineddt")

            birthdt.Text = ds.Tables(0).Rows(0)("birthdt")
            address1.Text = ds.Tables(0).Rows(0)("address1")
            pincode.Text = ds.Tables(0).Rows(0)("pincode")
            qualification.Text = ds.Tables(0).Rows(0)("qualification")
            emailid.Text = ds.Tables(0).Rows(0)("emailid")
            status.Text = ds.Tables(0).Rows(0)("status")
            gender.Text = ds.Tables(0).Rows(0)("gender")
            maritalstatus.Text = ds.Tables(0).Rows(0)("maritalstatus")
            sysschoolno.Text = ds.Tables(0).Rows(0)("sysschoolno")


        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysfacultyno.Text = row.Cells(0).Text
            DataSetCreator.ExecuteQuery("UPDATE faculty SET deleted = 'Y' WHERE sysfacultyno =0" & sysfacultyno.Text)
            RefreshGrid()
            InitilizeControls()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid()
        gvList.DataSource = DataSetCreator.GetDataSet("SELECT * FROM faculty WHERE deleted = 'N' ORDER BY sysfacultyno")
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
