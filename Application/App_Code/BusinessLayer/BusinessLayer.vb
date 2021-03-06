Imports system
Imports system.Data
Imports System.Data.OleDb
Imports Educare.Utility.FormatDate
Imports System.Collections.Generic
Imports System.Reflection
Imports Microsoft.VisualBasic
Imports Educare.Utility
Imports Educare.Application

Namespace Educare.Application
    Public Class BusinessLayer
        Public Shared Function GetfacultyDetails(ByVal sysschoolno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM faculty WHERE deleted = 'N' ORDER BY facultyname")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetQualificationDetails(ByVal sysqulno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM qualificationtion WHERE deleted = 'N' AND status = '00' ORDER BY quldesc")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetDesignationDetails(ByVal sysdesignationno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM designation WHERE deleted = 'N' AND status = '00' ORDER BY designationdesc")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetStandardDetails(ByVal sysstandardno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM standard WHERE deleted = 'N' order by standarddesc")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetDivisionDetails(ByVal sysdivisionno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM division WHERE deleted = 'N' order by divisiondesc")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetStandardDivisionDetails(ByVal sysstandardno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM division WHERE deleted = 'N' AND status = '00' and sysstandardno = 0" & sysstandardno & " ORDER BY divisiondesc")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetSubjectDetails(ByVal syssubjectno As Double) As DataSet
            Try
                If syssubjectno = 0 Then
                    Return DataSetCreator.GetDataSet("SELECT * FROM subjectmaster WHERE deleted = 'N' ORDER BY subjectcode")
                Else
                    Return DataSetCreator.GetDataSet("SELECT * FROM subjectmaster WHERE syssubjectno = 0" & syssubjectno)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetExamDetails(ByVal sysexamno As Double) As DataSet
            Try
                If sysexamno = 0 Then
                    Return DataSetCreator.GetDataSet("SELECT * FROM exammaster WHERE deleted = 'N' ORDER BY examcode")
                Else
                    Return DataSetCreator.GetDataSet("SELECT * FROM exammaster WHERE sysexamno = 0" & sysexamno)
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetschoolDetails(ByVal sysschoolno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM school WHERE deleted = 'N' ORDER BY SCHOOLNAME ")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetStudentDetails(ByVal sysschoolno As Double) As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM student WHERE deleted = 'N' ORDER BY sfirstname")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GeneralCodeData(ByVal gctype As String) As DataTable
            Try
                Dim strSqlString As String = "SELECT gctype,ltrim(rtrim(gccode)) gccode,gcname,gcsname " & _
                                             "FROM   generalcodes " & _
                                             "WHERE  generalcodes.gctype = '" & gctype & "' " & _
                                             "ORDER  BY generalcodes.parameters, generalcodes.gccode "

                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function StandardWiseSubject(ByVal sysstandardno As Double, ByVal sysdivisionno As Double, ByVal AllSelected As String) As DataTable
            Try

                Dim strSqlString As String = ""

                strSqlString = "SELECT  sysstdsubjectno, stdwisesubject.syssubjectno, subjectcode, subjectname, 0 as id " & _
                                "FROM   stdwisesubject " & _
                                "INNER  JOIN subjectmaster ON " & _
                                "       subjectmaster.syssubjectno = stdwisesubject.syssubjectno " & _
                                "WHERE  stdwisesubject.sysstandardno = 0" & sysstandardno & " " & _
                                "AND    stdwisesubject.sysdivisionno = 0" & sysdivisionno & "   "

                If AllSelected = "SELECTED" Then
                    strSqlString = strSqlString & " ORDER BY  subjectcode  "
                End If
                If AllSelected = "ALL" Then
                    strSqlString = strSqlString & "UNION  " & _
                                "SELECT 0 as sysstdsubjectno, syssubjectno, subjectcode, subjectname, 1 as id    " & _
                                "FROM    subjectmaster  " & _
                                "WHERE   syssubjectno NOT IN  " & _
                                "        (SELECT syssubjectno " & _
                                "         FROM   stdwisesubject " & _
                                "         WHERE  sysstandardno = 0" & sysstandardno & " " & _
                                "         AND    sysdivisionno = 0" & sysdivisionno & ") " & _
                                "ORDER BY  subjectcode  "

                End If
                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function StandardWiseExamination(ByVal sysstandardno As Double, ByVal AllSelected As String) As DataTable
            Try

                Dim strSqlString As String
                strSqlString = " SELECT  sysstdexamno,stdwiseexam.sysexamno,examcode,examdesc,marksinfinalresult,oralexam,0 as id, NULL tentativedate, '' vtentativedate " & _
                                " FROM   stdwiseexam " & _
                                "INNER  JOIN exammaster ON " & _
                                "       exammaster.sysexamno = stdwiseexam.sysexamno " & _
                                " WHERE  stdwiseexam.sysstandardno = 0" & sysstandardno & " "
                If AllSelected = "SELECTED" Then
                    strSqlString = strSqlString & " ORDER BY  sysstdexamno  "
                ElseIf AllSelected = "ALL" Then
                    strSqlString = strSqlString & "UNION" & _
                                " SELECT 0 as sysstdexamno,sysexamno,examcode,examdesc,'' marksinfinalresult,'' oralexam,1 as id, NULL tentativedate, '' vtentativedate " & _
                                " FROM    exammaster   " & _
                                " WHERE   exammaster.sysexamno NOT IN " & _
                                "        (select sysexamno " & _
                                "from  stdwiseexam " & _
                                "WHERE  sysstandardno =0" & sysstandardno & ")" & _
                                " ORDER BY examcode "
                End If
                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function StandardWiseExam(ByVal sysstandardno As Double) As DataTable
            Try
                Dim strExamCond As String = ""
                Dim strSqlString As String
                If sysstandardno <> 0 Then
                    strSqlString = " SELECT * " & _
                                   " FROM   stdwiseexam " & _
                                   " INNER  JOIN exammaster ON " & _
                                   "        exammaster.sysexamno = stdwiseexam.sysexamno " & _
                                   " WHERE  stdwiseexam.sysstandardno =0" & sysstandardno & _
                                   " ORDER  BY exammaster.examcode"
                Else
                    strSqlString = " SELECT * " & _
                                   " FROM  stdwiseexam " & _
                                   " INNER  JOIN exammaster ON " & _
                                   "        exammaster.sysexamno = stdwiseexam.sysexamno " & _
                                   " WHERE  stdwiseexam.sysstandardno =0" & _
                                   " ORDER  BY exammaster.examcode"
                End If
                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function StandardWiseSubjectDetail(ByVal sysstandardno As Double, ByVal sysdivisionno As Double) As DataTable
            Try

                Dim strSqlString As String

                strSqlString = " SELECT * " & _
                               " FROM   stdwisesubject " & _
                               " INNER  JOIN subjectmaster ON " & _
                               "        subjectmaster.syssubjectno = stdwisesubject.syssubjectno " & _
                               " WHERE  stdwisesubject.sysstandardno = 0" & sysstandardno & " " & _
                               "  AND   stdwisesubject.sysdivisionno = 0" & sysdivisionno & " " & _
                               " ORDER  BY stdwisesubject.syssubjectno"

                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function MarksEntry(ByVal sysstandardno As Double, ByVal sysdivisionno As Double, ByVal sysexamno As Double, ByVal syssubjectno As Double) As DataTable
            Try

                Dim strSqlString As String
                strSqlString = " SELECT sysmarksno,marksentry.sysstudentno,rollno,  sfirstname + ' ' + smiddlename + ' ' + slastname  fullname, CASE WHEN marksentry.writtenmark = 0 THEN '' ELSE CONVERT(VARCHAR(20),marksentry.writtenmark) END writtenmark, CASE WHEN marksentry.oralmark = 0 THEN '' ELSE CONVERT(VARCHAR(20),marksentry.oralmark) END oralmark, CASE WHEN marksentry.gracemark = 0 THEN '' ELSE CONVERT(VARCHAR(20),marksentry.gracemark) END gracemark ,marksentry.preabsstatus,marksentry.description,0 as id " & _
                "                FROM   marksentry    " & _
                "                INNER  JOIN student ON " & _
                "                       student.sysstudentno = marksentry.sysstudentno " & _
                "                WHERE  marksentry.sysstandardno = 0" & sysstandardno & " " & _
                "                And    marksentry.sysdivisionno = 0" & sysdivisionno & " " & _
                "                AND    marksentry.sysexamno     =   0" & sysexamno & " " & _
                "                And    marksentry.syssubjectno = 0" & syssubjectno & "  " & _
                "                UNION  " & _
                "                SELECT 0 as sysmarksno,sysstudentno,rollno,  sfirstname + ' ' + smiddlename + ' ' + slastname  fullname, '' writtenmark, '' oralmark,'' gracemark,'' preabsstatus,'' description,1 as id    " & _
                "                FROM   student     " & _
                "                WHERE  sysstandardno = 0" & sysstandardno & "  " & _
                "                And    sysdivisionno = 0" & sysdivisionno & "  " & _
                "                And    student.studentstatus = '01' " & _
                "                AND    student.sysstudentno NOT IN    " & _
                "                                    (SELECT  sysstudentno   " & _
                "                                     FROM    marksentry    " & _
                "                                     WHERE sysstandardno = 0" & sysstandardno & " " & _
                "                                     And   sysdivisionno = 0" & sysdivisionno & " " & _
                "                                     AND   sysexamno     =  0" & sysexamno & "  " & _
                "                                     And   syssubjectno = 0" & syssubjectno & "  )   " & _
                "ORDER BY rollno "

                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function



        Public Shared Function ExamTimeTable(ByVal sysstandardno As Double, ByVal sysdivisionno As Double, ByVal sysexamno As Double) As DataTable
            Try

                Dim strSqlString As String
                strSqlString = " SELECT         sysexamtimetblno,subjectmaster.syssubjectno,subjectname,examtimetable.trndt," & _
                                     "          examtimetable.fromtime,examtimetable.totime,0 as id    " & _
                                     " FROM     examtimetable  " & _
                                     " INNER    JOIN subjectmaster ON " & _
                                     "          subjectmaster.syssubjectno =  examtimetable.syssubjectno " & _
                                     " WHERE    sysstandardno = 0" & sysstandardno & _
                                     " And      sysdivisionno = 0" & sysdivisionno & _
                                     " AND      sysexamno     = 0" & sysexamno & _
                                     " UNION     " & _
                                     " SELECT   0 as sysexamtimetblno,subjectmaster.syssubjectno,subjectname,null trndt," & _
                                     "          '' fromtime,'' totime,1 as id   " & _
                                     " FROM     stdwisesubject   " & _
                                     "INNER     JOIN subjectmaster ON " & _
                                     "          subjectmaster.syssubjectno =  stdwisesubject.syssubjectno " & _
                                     " WHERE    sysstandardno = 0" & sysstandardno & _
                                     " And      sysdivisionno = 0" & sysdivisionno & _
                                     " AND      stdwisesubject.syssubjectno NOT IN   " & _
                                     "                                         (SELECT  syssubjectno  " & _
                                     "                                           FROM   examtimetable  " & _
                                     "                                           WHERE  sysstandardno = 0" & sysstandardno & _
                                     "                                           And    sysdivisionno = 0" & sysdivisionno & _
                                     "                                           AND    sysexamno     = 0" & sysexamno & _
                                     "                                         )  " & _
                                     " ORDER BY id "

                Return DataSetCreator.GetDataSet(strSqlString).Tables(0)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetUserGroupsDetails() As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM usergroups")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Shared Function GetUsersDetails() As DataSet
            Try
                Return DataSetCreator.GetDataSet("SELECT * FROM users")
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
    End Class

End Namespace

