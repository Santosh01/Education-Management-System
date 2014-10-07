Imports Educare.Application
Imports Educare.Application.BusinessLayer
Imports Educare.Utility
Imports System.Net.NetworkInformation
Imports System.Data.SqlClient
Imports System.Data
Partial Class Login
    Inherits EducarePage

    Dim cmd As New SqlCommand
    Dim db As New SqlDataAdapter
    Dim ds As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        btnLogin.ToolTip = "login"
        btnCancel.ToolTip = "Cancel"
        userid.ToolTip = "UserID"
        Password.ToolTip = "Password"

        currentdt.Text = FormatDate.ConvertToDataBase(FormatDate.ConvertToForm(Now))

        Dim con As New SqlConnection
        con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
        con.Open()

        Dim x As String
        x = "select * from users"
        cmd = New SqlCommand(x, con)
        db = New SqlDataAdapter(cmd)
        db.Fill(ds, "users")
        con.Close()
        Try

        Catch ex As Exception

            Response.Redirect("Login.aspx")
        End Try

    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim bol As Boolean
        Dim username, pass As String
        Dim dr As DataRow

        username = userid.Text
        pass = Password.Text
        bol = False
        For Each dr In ds.Tables(0).Rows
            If dr("username") = username And dr("password") = pass Then

                bol = True
            End If
        Next

        If bol = True Then
            Session("userid") = userid.Text
            Session("password") = Password.Text
            Session.Clear()
            Response.Redirect("Dashboard.aspx")

        ElseIf userid.Text = "" And Password.Text = "" Then
            MsgBox("Please Enter Your UserID And Password", MsgBoxStyle.SystemModal Or MsgBoxStyle.Information, "Login")
            userid.Focus()
            userid.BorderColor = Drawing.Color.Red
            Password.BorderColor = Drawing.Color.Red
        Else
            If userid.Text = "" Then
                MsgBox("Please Enter Your UserID ", MsgBoxStyle.SystemModal Or MsgBoxStyle.Exclamation, "Login")
                userid.Focus()
                Password.BorderColor = Drawing.Color.Black
            Else
                If Password.Text = "" Then
                    MsgBox("Please Enter Your Password ", MsgBoxStyle.SystemModal Or MsgBoxStyle.Exclamation, "Login")
                    Password.Focus()
                    userid.BorderColor = Drawing.Color.Black
                Else
                    MsgBox("Wrong UserID And Password", MsgBoxStyle.SystemModal Or MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel, "Login")
                    userid.Text = ""
                    Password.Text = ""
                    userid.BorderColor = Drawing.Color.Black
                    Password.BorderColor = Drawing.Color.Black
                    userid.Focus()
                End If
            End If
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session.Abandon()
    End Sub


End Class

