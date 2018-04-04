Imports CrossCutting
Imports System.IO

Public Module BusinessLogic_Mod

    Public Const DATEHIRED_FORMAT As String = "mmddyy"
    Public Const EMPLOYEENUM_FORMAT As String = DATEHIRED_FORMAT & "####"

    Sub Main()
    End Sub

    'Trims the argument directly. Not sure if this will work fine coz strings are immutable.
    Public Function MyTrim(ByRef str As String) As String
        str = Trim(str)
        Return str
    End Function

    '''FLAG: EMPLOYEE ID EXTRACTION - For [mmddyy####] Format
    Public Function empNumExtractor(ByVal employeeNumber As String) As UInteger
        Dim strEmpNum As String = Trim(employeeNumber)
        Try
            strEmpNum = stringChecker(strEmpNum, EMPLOYEENUM_FORMAT.Length)
        Catch sqliex As SQLInjectionException
            'Log the suspected 'value' and throw as an BusinessException
            Logger.possibleSQLInjection(employeeNumber, sqliex.StackTrace)
            sqliex.overrideMessage("`Employee number`" & sqliex.Message)
            Throw sqliex
        Catch bex As BusinessException
            bex.overrideMessage("`Employee Number`" & bex.Message)
            Throw bex
        End Try

        Return CULng(removeZeroPadding(getPaddedEmpNum(strEmpNum)))
    End Function

    Private Function getPaddedEmpNum(ByVal employeeNumber As String) As String
        Dim l_Last4Digit As String
        l_Last4Digit = employeeNumber.Substring(DATEHIRED_FORMAT.Length)
        Return l_Last4Digit
    End Function

    'Recursion is use to extract all the leading zeroes
    Private Function removeZeroPadding(ByVal last4Digit As String) As String
        If last4Digit.Substring(0, 1) = "0" Then
            last4Digit = last4Digit.Substring(1)
            removeZeroPadding(last4Digit)
        End If
        Return last4Digit
    End Function

    Public Function dateHiredExtractor(ByVal employeeNumber As String) As String
        Dim strEmpNum As String
        Try
            strEmpNum = stringChecker(employeeNumber, EMPLOYEENUM_FORMAT.Length)
        Catch sqliex As SQLInjectionException
            'Log the suspected 'value' and throw as an BusinessException
            Logger.possibleSQLInjection(employeeNumber, sqliex.StackTrace)
            sqliex.overrideMessage("`Employee Number`" & sqliex.Message)
            Throw sqliex
        Catch bex As BusinessException
            bex.overrideMessage("`Employee Number`" & bex.Message)
            Throw bex
        End Try

        Return getDateFromEmpNum(strEmpNum)
    End Function

    Private Function getDateFromEmpNum(ByVal employeeNumber As String) As String
        Dim dateHired As String
        dateHired = employeeNumber.Substring(0, DATEHIRED_FORMAT.Length)

        Return dateHired
    End Function


    'USER
    Public Enum UserTypeCode
        Administrator = 1
        User = 2
    End Enum

    Function convUTCToString(ByVal userType As UShort) As String
        'If Not UserTypeCode.IsDefined(GetType(UserTypeCode), userType) Then
        '    Throw New MyApplicationException("User Type for this user is 'Unknown'")
        'End If
        Select Case userType
            Case 1
                Return "Administrator"
            Case 2
                Return "User"
            Case Else
                'This is not neccessary if the IsDefined function will work.
                Throw New MyApplicationException("User Type for this user is 'Unknown'")
        End Select
    End Function

    Function convUserTypeToUTC(ByVal userType As String) As UInt16
        If userType.Equals("Administrator") Then
            Return CType(UserTypeCode.Administrator, UInt16)
        ElseIf userType.Equals("User") Then
            Return CType(UserTypeCode.User, UInt16)
        Else
            Throw New MyApplicationException("User Type for this user is 'Unknown'")
        End If
    End Function

    Function convUserActiveToString(ByVal active As UShort) As String
        Select Case active
            Case 0
                Return "Inactive"

            Case Else
                Return "Active"
        End Select
    End Function

    'EMPLOYEE
    '''DEPRECATED FUNCTIONS
    Private Function convertToMySQLDate(ByVal dateHired As String) As String
        Dim mm, dd, yy As String
        mm = dateHired.Substring(0, 2)
        dd = dateHired.Substring(2, 2)
        yy = dateHired.Substring(4, 2)

        Return ""
    End Function

    Private Function formatYearToFourDigit(ByVal yy As String) As String
        Return ""
    End Function

    Public Sub TestConnection()
        Try
            DataAccess.TestConnection()
        Catch daex As DataAccessException
            Throw daex
        End Try
    End Sub

    Public Function customeSelect(ByVal SQL As String) As System.Data.DataTable
        Dim dTable As System.Data.DataTable = Nothing
        Try
            DataAccess.customSelect(SQL)
        Catch daex As DataAccessException
            Throw daex
        End Try

        Return dTable
    End Function

    'IMPORTANT: The MySQL path should be added in the Environment variables in the machine where the database is located
    ' Else this method will not work
    Public Sub database_backup(ByVal dbName As String, ByVal directory As String, ByVal filename As String)
        Try
            Dim username As String = CrossCutting.getDB_user()
            Dim password As String = CrossCutting.getDB_password()
            Dim database As String = dbName

            Dim path As String = String.Format("{0}\{1}", directory, filename)
            'Start Back-up on new Process
            Dim p As New System.Diagnostics.Process()
            p.StartInfo.FileName = "mysqldump.exe"
            p.StartInfo.WorkingDirectory = "C:\"
            Dim strArgs As String = String.Format("-u {0} -p{1} {2} -r {3}{4}{5}", _
                                                  username, password, database, Chr(34), path, Chr(34))
            p.StartInfo.Arguments = strArgs
            p.Start()
            'Wait for the process to exit or time out.
            p.WaitForExit(15000)
            'Check to see if the process is still running.
            If p.HasExited = False Then
                'Process is still running.
                'Test to see if the process is hung up.
                If p.Responding Then
                    'Process was responding; close the main window.
                    p.CloseMainWindow()
                Else
                    'Process was not responding; force the process to close.
                    p.Kill()
                End If
                'Throw exception if timeout for 15 seconds which most probably the mysqldump.exe hanged-up
                Throw New MyApplicationException()
            End If

            Dim fileLen As Integer = New FileInfo(path).Length
            If Not System.IO.File.Exists(path) AndAlso fileLen < 1 Then
                Throw New MyApplicationException()
            End If
        Catch myerror As SystemException
            Throw New MyApplicationException()
        Finally

        End Try
    End Sub

    'IMPORTANT: The MySQL path should be added in the Environment variables in the machine where the database is located
    ' Else this method will not work
    Public Sub database_restore(ByVal dbName As String, ByVal filename As String)
        Try
            Dim username As String = CrossCutting.getDB_user()
            Dim password As String = CrossCutting.getDB_password()
            Dim database As String = dbName
            
            Dim p As New System.Diagnostics.Process()
            p.StartInfo.FileName = "cmd.exe"
            p.StartInfo.UseShellExecute = False
            p.StartInfo.WorkingDirectory = "C:\"
            p.StartInfo.RedirectStandardInput = True
            p.StartInfo.RedirectStandardOutput = True
            p.Start()

            Dim myStreamWriter As StreamWriter = p.StandardInput
            Dim mystreamreader As StreamReader = p.StandardOutput
            Dim strArgs As String = String.Format("mysql -u {0} -p{1} {2} < {3}{4}{5}", _
                                                  username, password, database, Chr(34), filename, Chr(34))
            myStreamWriter.WriteLine(strArgs)
            myStreamWriter.Close()
            p.WaitForExit(15000)
            'Check to see if the process is still running.
            If p.HasExited = False Then
                'Process is still running.
                'Test to see if the process is hung up.
                If p.Responding Then
                    'Process was responding; close the main window.
                    p.CloseMainWindow()
                Else
                    'Process was not responding; force the process to close.
                    p.Kill()
                End If
                'Throw exception if timed-out for 15 seconds which most probably the mysqldump.exe hanged-up
                Throw New MyApplicationException()
            End If
        Catch myerror As SystemException
            Throw New ApplicationException
        End Try
    End Sub
End Module