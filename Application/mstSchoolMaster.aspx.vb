Imports System
Imports System.Data.SqlClient
Imports Educare.Utility
Imports System.Data
'Imports System.Data.DataRow
Imports System.Data.DataTable
Imports Educare.Application.BusinessLayer
Imports System.Text.RegularExpressions

Partial Class mstSchoolMaster
    Inherits EducarePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'SetValueType(TextType.DateField, establishmentdt)
        SetValueType(TextType.TelephoneField, phoneno)
        SetValueType(TextType.TelephoneField, faxno)
        SetValueType(TextType.NumericField, pincode)

        SetValueType(TextType.TelephoneField, mobileno)
        BtnCancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return false;} ")


        If Not IsPostBack Then
            schoolsname.ToolTip = "School Short Name"
            schoolname.ToolTip = "School Name"
            fromstd.ToolTip = "From Standard"
            tostd.ToolTip = "To Standard"
            principalname.ToolTip = "Principal Name"
            phoneno.ToolTip = "Phone Number"
            address1.ToolTip = "Address"
            pincode.ToolTip = "Pincode"
            faxno.ToolTip = "Fax Number"
            mobileno.ToolTip = "Mobile Number"
            emailid.ToolTip = "Email Id"
            website.ToolTip = "Website"
            state.ToolTip = "State"
            city.ToolTip = "City"
            status.ToolTip = "Status"
            BtnSave.ToolTip = "Save"

            fromstd.DataSource = GetStandardDetails(0)
            fromstd.DataBind()
            fromstd.Items.Insert(0, "--  From Std  --")

            tostd.DataSource = GetStandardDetails(0)
            tostd.DataBind()
            tostd.Items.Insert(0, "--   To Std   --")


            status.DataSource = GeneralCodeData("STAT")
            status.DataBind()
            RefreshGrid()

        End If
  
    End Sub

    Private Function IsValidEmail(ByVal emailid As String) As Boolean


        Try
            If emailid.Trim.Length = 0 Then
                MsgBox("Please enter the email Address")
                Return False
            End If
            Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
            Dim emailAddressMatch As Match = Regex.Match(emailid, pattern)
            If emailAddressMatch.Success Then
                Return True
            Else
                MsgBox("Please enter the valid email address")
                Return False
            End If
        Catch ex As Exception
        End Try
    End Function



    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click

        Try
            Dim strMessage As String
            Dim con As New SqlConnection
            con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            con.Open()

            Dim com As New SqlCommand("SELECT * FROM school WHERE sysschoolno =0" & sysschoolno.Text, con)


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

            dr("sysschoolno") = Val(sysschoolno.Text)
            dr("schoolsname") = schoolsname.Text
            dr("schoolname") = schoolname.Text
            dr("fromstd") = fromstd.SelectedItem.Value
            dr("tostd") = tostd.SelectedItem.Value
            dr("principalname") = principalname.Text
            dr("phoneno") = phoneno.Text
            dr("address1") = address1.Text
            dr("pincode") = pincode.Text
            dr("faxno") = faxno.Text
            dr("mobileno") = mobileno.Text

            Dim email As String
            Dim hold As String
            email = emailid.Text
            hold = IsValidEmail(email)

            If hold = True Then
                dr("emailid") = emailid.Text
                Session.Clear()
            Else
                MsgBox("Inavlid Email-ID", MsgBoxStyle.SystemModal Or MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel, "Email")
                Session("EMAILID") = emailid.Text
                emailid.Focus()
            End If

            dr("website") = website.Text
            dr("city") = city.Text
            dr("state") = state.Text
            dr("status") = status.SelectedItem.Value
            dr("lupdnuser") = "" & Session("userid")
            dr("lupdndt") = Now
            dr("deleted") = "N"
            dr("yearcd") = 0


            If ds.Tables(0).Rows.Count = 0 Then
                ds.Tables(0).Rows.Add(dr)
            End If
            Dim cmdbld As New SqlCommandBuilder(adaptor)
            adaptor.Update(ds)
            DisplayCustomMessageSummary(strMessage)
            RefreshGrid()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
        InitilizeControls()
    End Sub

    Private Sub InitilizeControls()
        sysschoolno.Text = ""
        schoolsname.Text = ""
        schoolname.Text = ""
        fromstd.Text = Nothing
        tostd.Text = Nothing
        principalname.Text = ""
        phoneno.Text = ""
        address1.Text = ""
        pincode.Text = ""
        faxno.Text = ""
        mobileno.Text = ""
        emailid.Text = ""
        website.Text = ""
        state.Text = ""
        city.Text = ""
        status.Text = Nothing
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        InitilizeControls()
    End Sub

    
    Protected Sub fromstd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fromstd.SelectedIndexChanged
        Try
            If fromstd.SelectedIndex = 0 Then
                ErrorMessage = ErrorMessage & "Select Standard.\n "
                Exit Sub
            End If

            tostd.DataSource = GetStandardDetails(0)
            tostd.DataBind()
            tostd.Items.Insert(0, "")

            RefreshGrid()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysschoolno.Text = row.Cells(0).Text

            Dim ds As New DataSet
            ds = DataSetCreator.GetDataSet("SELECT * FROM school WHERE  sysschoolno=0" & sysschoolno.Text)

            sysschoolno.Text = ds.Tables(0).Rows(0)("sysschoolno")
            schoolsname.Text = ds.Tables(0).Rows(0)("schoolsname")
            schoolname.Text = ds.Tables(0).Rows(0)("schoolname")
            fromstd.Text = ds.Tables(0).Rows(0)("fromstd")
            tostd.Text = ds.Tables(0).Rows(0)("tostd")
            principalname.Text = ds.Tables(0).Rows(0)("principalname")
            phoneno.Text = ds.Tables(0).Rows(0)("phoneno")
            address1.Text = ds.Tables(0).Rows(0)("address1")
            city.Text = ds.Tables(0).Rows(0)("city")
            state.Text = ds.Tables(0).Rows(0)("state")
            pincode.Text = ds.Tables(0).Rows(0)("pincode")
            faxno.Text = ds.Tables(0).Rows(0)("faxno")
            mobileno.Text = ds.Tables(0).Rows(0)("mobileno")
            emailid.Text = ds.Tables(0).Rows(0)("emailid")
            website.Text = ds.Tables(0).Rows(0)("website")
            status.Text = ds.Tables(0).Rows(0)("status")
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim update As LinkButton = DirectCast(sender, LinkButton)
            Dim row As GridViewRow = DirectCast(update.NamingContainer, GridViewRow)
            sysschoolno.Text = row.Cells(0).Text
            DataSetCreator.ExecuteQuery("UPDATE school SET deleted = 'Y' WHERE sysschoolno =0" & sysschoolno.Text)
            RefreshGrid()
            InitilizeControls()
        Catch ex As Exception
            DisplayCustomMessageSummary(ex.Message)
        End Try
    End Sub

    Private Sub RefreshGrid()
        gvList.DataSource = DataSetCreator.GetDataSet("SELECT * FROM school WHERE deleted = 'N' ORDER BY sysschoolno")
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
