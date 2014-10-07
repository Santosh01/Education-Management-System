Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Educare
Imports Educare.Utility
Imports Educare.Application.BusinessLayer
Partial Class Dashboard
    Inherits EducarePage
    Dim ds As New DataSet

    Dim cmd As New SqlCommand
    Dim db As New SqlDataAdapter
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            Dim DayName As DayOfWeek

            DayName = Now.DayOfWeek
            'Dim DT As New DataTable
            'Dim con As New SqlConnection
            'con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
            'con.Open()

            'db = New SqlDataAdapter("select * from users", con)

            'db.Fill(ds, "users")
            'Grid1.DataSource = ds.Tables("users")
            'Grid1.DataMember = ds.Tables("users").ToString()

            'Grid1.DataBind()
            'con.Dispose()

        Catch ex As Exception
            Response.Redirect("Login.aspx")

        End Try
    End Sub

    'Public Function fillexamalert()
    '    Dim con As New SqlConnection
    '    con.ConnectionString = DatabaseConnection.GetConnectionSQLClient
    '    con.Open()

    '    db = New SqlDataAdapter("select * from timetable", con)

    '    db.Fill(ds, "timetable")
    '    Grid1.DataSource = ds.Tables("timetable")
    '    Grid1.DataBind()
    '    con.Dispose()
    '    Return 1
    'End Function

    Protected Sub SqlDataSource1_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs)

    End Sub
End Class
