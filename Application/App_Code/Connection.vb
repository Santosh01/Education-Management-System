Imports Microsoft.VisualBasic
Imports system.data

Namespace Educare.Utility
       Public Class DatabaseConnection
        Public Shared Function GetConnection() As String
            Return "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EDUCARE_KC;Data Source=SANTOSH-PC"


        End Function

        Public Shared Function GetConnectionSQLClient() As String
            Return "data source=.;user id=SA;password=abc#123;Initial Catalog=EDUCARE_KC"
        End Function
    End Class
End Namespace

