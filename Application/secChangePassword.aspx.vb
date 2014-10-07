Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Educare.Utility
Imports Educare.Application.BusinessLayer
Imports System.Data.OleDb
Imports System.Data.OleDb.OleDbCommand
Partial Class secChangePassword
    Inherits EducarePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Cancel.Attributes.Add("onClick", "if(ConfirmYesno('Are you sure to cancel?')==0) {return FALSE;} ")
        If Not IsPostBack Then
            username.ToolTip = "User Name"
            password.ToolTip = "New Password"
            password1.ToolTip = "Confirm Password"
            'SecretQuestion.ToolTip = "Secret Question"
            'SecretAnswer.ToolTip = "Secret Answer"
            Changepassword.ToolTip = "Change Password"
            Cancel.ToolTip = "Cancel"

        End If
    End Sub


    Protected Sub Changepassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Changepassword.Click
        If password.Text.Length < 5 Then
            DisplayCustomMessageSummary("The New Password Should be of Atleast 5 Characters")
            password.Text = ""
            password1.Text = ""
            password.BackColor = Drawing.Color.LightGreen
            password.Focus()
            'Session.Clear()
        End If

        If (password.Text = password1.Text) Then



            Try
                Dim strMessage As String
                Dim con As New SqlConnection
                con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
                con.Open()

                Dim com As New SqlCommand("UPDATE users SET [password] =[@password], SecretQuestion = @SecretQuestion, SecretAnswer = @SecretAnswer", con)

               With com.Parameters
                    .AddWithValue("@[password]", password.Text)
                    '.AddWithValue("@SecretQuestion", SecretQuestion.Text)
                    '.AddWithValue("@SecretAnswer", SecretAnswer.Text)

                End With

                strMessage = "Password Changed Successfully, Now Login into System"

                com.ExecuteNonQuery()
                DisplayCustomMessageSummary(strMessage)

                InitilizeControls()
            Catch ex As Exception
                DisplayCustomMessageSummary(ex.Message)
            End Try
        End If
    End Sub






    Private Sub InitilizeControls()
        Try
            sysuserno.Text = ""
            username.Text = ""
            username.Text = ""
            password.Text = ""
            'SecretQuestion.Text = ""
            'SecretAnswer.Text = ""


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub



    Protected Sub Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cancel.Click
        InitilizeControls()

    End Sub
End Class
