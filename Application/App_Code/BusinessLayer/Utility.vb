Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.Configuration
Imports System
Imports System.Data
Imports System.Data.OleDb

Namespace Educare.Utility

    Public Class SystemTypeToDataType

        Public Shared Function ConvertDbTypeToOleDbType(ByVal DbType As String) As OleDbType
            Dim OleDbType As OleDbType
            Select Case DbType
                Case "System.Int16"
                    OleDbType = OleDbType.SmallInt
                Case "System.Int32"
                    OleDbType = OleDbType.BigInt
                Case "System.Int64"
                    OleDbType = OleDbType.BigInt
                Case "System.Double"
                    OleDbType = OleDbType.Double
                Case "System.Object"
                    OleDbType = OleDbType.Variant
                Case "System.Guid"
                    OleDbType = OleDbType.Guid
                Case "System.Boolean"
                    OleDbType = OleDbType.Boolean
                Case "System.Byte"
                    OleDbType = OleDbType.Binary
                    'Case "System.Byte"
                    '    OleDbType = Data.OleDbType.Image
                    'Case "System.Byte"
                    '    OleDbType = Data.OleDbType.Timestamp
                    'Case "System.Byte"
                    '    OleDbType = Data.OleDbType.TinyInt
                    'Case "System.Byte"
                    '    OleDbType = Data.OleDbType.VarBinary
                    'Case "System.String"
                    '    OleDbType = Data.OleDbType.Char
                    'Case "System.String"
                    '    OleDbType = Data.OleDbType.NChar
                    'Case "System.String"
                    '    OleDbType = Data.OleDbType.NVarChar
                    'Case "System.String"
                    '    OleDbType = Data.OleDbType.Text
                Case "System.String"
                    OleDbType = OleDbType.VarChar
                Case "System.DateTime"
                    OleDbType = OleDbType.Date
                    'Case "System.DateTime"
                    '    OleDbType = Data.OleDbType.SmallDateTime
                Case "System.Decimal"
                    OleDbType = OleDbType.Decimal
                    'Case "System.Decimal"
                    '    OleDbType = Data.OleDbType.Money
                    'Case "System.Decimal"
                    '    OleDbType = Data.OleDbType.SmallMoney
                Case "System.Single"
                    OleDbType = OleDbType.Single
                    'Case "System.Single"
                    '    OleDbType = Data.OleDbType.Real
            End Select
            Return OleDbType
        End Function
    End Class

    Public Class FormatDate
        Public Shared Function ConvertToDataBase(ByVal SourceDate As String) As String
            Dim sDate As String = ""
            If SourceDate <> "" Then
                Dim sNewDate As String = ""
                Dim sDay As String
                Dim sMonth As String
                Dim sYear As String
                'sMonth = Format("mmm", SourceDate)
                Dim s As Array
                s = Split(SourceDate, "/")
                If s.Length = 3 Then
                    sDay = s(0).ToString.PadLeft(2, "0")
                    sMonth = s(1).ToString.PadLeft(2, "0")
                    sYear = s(2)
                    sNewDate = sMonth & "/" & sDay & "/" & Left(sYear, 4)

                    sMonth = GetMonthName(sMonth)
                    sDate = sDay & "-" & sMonth & "-" & sYear
                Else
                    sDate = ""
                End If
            Else
                sDate = ""
            End If
            Return sDate
        End Function

        Public Shared Function ConvertToForm(ByVal SourceDate As DateTime) As String
            Dim sDate As String = ""

            If IsDate(SourceDate) Then
                Dim sDay As Integer = Day(SourceDate)
                Dim sMonth As Integer = Month(SourceDate)
                Dim sYear As Integer = Year(SourceDate)
                sDate = sDay.ToString.PadLeft(2, "0") & "/" & sMonth.ToString.PadLeft(2, "0") & "/" & sYear.ToString
            Else
                sDate = ""
            End If

            Return sDate
        End Function

        Private Shared Function GetMonthName(ByVal MonthNo As String) As String
            Dim MonthName As String = ""
            Select Case MonthNo
                Case "01"
                    MonthName = "JAN"
                Case "02"
                    MonthName = "FEB"
                Case "03"
                    MonthName = "MAR"
                Case "04"
                    MonthName = "APR"
                Case "05"
                    MonthName = "MAY"
                Case "06"
                    MonthName = "JUN"
                Case "07"
                    MonthName = "JUL"
                Case "08"
                    MonthName = "AUG"
                Case "09"
                    MonthName = "SEP"
                Case "10"
                    MonthName = "OCT"
                Case "11"
                    MonthName = "NOV"
                Case "12"
                    MonthName = "DEC"
            End Select
            Return MonthName
        End Function

        Public Shared Function GetCurrDate(ByVal type As String) As String
            Dim CurrDate As String = ""

            Select Case type.ToUpper
                Case "F"
                    CurrDate = Now().ToString
                Case "SH"
                    CurrDate = Now().Date
                Case "MO"
                    CurrDate = Right("0" & Now().Month, 2)
                Case "Y"
                    CurrDate = Now().Year
                Case "MI"
                    CurrDate = Now().Minute
                Case "S"
                    CurrDate = Now().Second
                Case "MS"
                    CurrDate = Now().Millisecond
                Case "FD"
                    CurrDate = "01" & "/" & Right("0" & Now().Month, 2) & "/" & Now().Year
            End Select
            Return CurrDate.ToString
        End Function

        Public Shared Function GetLastDayInMonth(ByVal dtDate As Date) As Date
            'example for #2009-02-20# we want to get the last day in the month 02,
            ' (ie. date for last day in Feb)

            Return DateAdd(DateInterval.Day, _
           (Day(DateAdd(DateInterval.Month, 1, dtDate))) * -1, _
                   DateAdd(DateInterval.Month, 1, dtDate))
        End Function

        Public Shared Function GetFirstDayInMonth(ByVal dtDate As Date) As Date
            Return DateAdd(DateInterval.Day, 0 - (dtDate.Day - 1), dtDate.Date)
        End Function
    End Class

    Public Class DataSetCreator
        Public Shared Function GetDataSet(ByVal strSql As String) As DataSet
            Dim strConnectionString As String = DatabaseConnection.GetConnection
            Dim strConnection As New OleDbConnection(strConnectionString)
            Dim Command As OleDbCommand = New OleDbCommand(strSql, strConnection)
            Dim ds As New DataSet("data")
            Dim Adaptor As New OleDbDataAdapter(Command)
            Try

                Adaptor.Fill(ds)
            Catch e As OleDbException
                ' Handle exception.
                MsgBox(e.Message)
            Finally
                strConnection.Close()
            End Try
            Return ds
        End Function

        Public Shared Function ExecuteQuery(ByVal strSql As String) As String
            Dim strMessage As String = ""
            Dim strConnectionString As String = DatabaseConnection.GetConnection
            Dim strConnection As New OleDbConnection(strConnectionString)
            strConnection.Open()
            Dim Command As OleDbCommand = New OleDbCommand(strSql, strConnection)
            Try
                strMessage = Command.ExecuteNonQuery()
            Catch e As OleDbException
                Throw New Exception(strMessage)
            Finally
                strConnection.Close()
            End Try
            Return strMessage
        End Function

        Public Shared Function ExecuteQuery(ByVal strSql As Array) As String
            Dim strMessage As String = ""
            Dim strConnectionString As String = DatabaseConnection.GetConnection
            Dim strConnection As New OleDbConnection(strConnectionString)
            strConnection.Open()
            Dim Command As OleDbCommand = New OleDbCommand(strSql(0), strConnection)
            Try
                strMessage = Command.ExecuteNonQuery()
            Catch e As OleDbException
                Throw New Exception(strMessage)
            Finally
                strConnection.Close()
            End Try
            Return strMessage
        End Function
    End Class

End Namespace