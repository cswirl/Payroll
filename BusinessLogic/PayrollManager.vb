Imports BusinessLogic.BusinessEntity
Imports CrossCutting
Imports DataAccess
Imports System.Data
Imports Bridge

Public Class PayrollManager
    Inherits ManagerBase

    Friend WithEvents payrollDAO As Payroll_DAO
    Private payrollData_Courier As Payroll

    Private repGen As ReportGenerator

    Sub New()
        payrollDAO = New Payroll_DAO
    End Sub

    ''' <summary>
    ''' Returns the newly inserted Payroll ID. If an error occurs, return zero(0)
    ''' </summary>
    Public Function add(ByVal payroll As Bridge.IPayroll, ByVal project_IDs() As UInteger) As UInteger
        payrollData_Courier = payroll
        Dim payrollNum As UInteger = 0
        Try
            If Me.payrollData_Courier Is Nothing Then Throw New Exception("`Payroll instance` is not initialized.")
            insert_inspectData()
            If Not isEmployee_unlocked(payroll.empNum) Then Throw New BusinessException("A payroll had been created for this employee.")
            payrollNum = payrollDAO.add(payroll, project_IDs)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            ExceptionLog_DAO.log(ex)
            Throw ex
        Finally
            'Release the object after use
            payrollData_Courier = Nothing
        End Try

        Return payrollNum
    End Function

    'Returns true if an employee is not locked using Payroll's 5 days locking mechanism
    Private Function isEmployee_unlocked(ByVal employeeNumber As UInteger) As Boolean
        Try
            Dim em As New EmployeeManager
            Dim dtEmpNum As New DataTable
            dtEmpNum = em.retrieveUnlockedEmployee
            For Each drv As DataRowView In dtEmpNum.DefaultView
                If CUInt(DBNullToNumeric(drv("empNum"))) = employeeNumber Then
                    Return True
                End If
            Next
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Returns the reversed Payroll ID. If an error occurs, return zero(0)
    ''' </summary>
    Public Function reverse(ByVal payrollNum As UInteger) As Integer
        Dim i As Integer = 0
        Try
            If Not isAdmin(getCurrentUser) Then
                Throw New BusinessException("Please call an Administrator for payroll reversal.")
            End If
            If payrollNum < 1 Then
                Throw New MyApplicationException("Invalid Payroll Number.")
            End If
            i = payrollDAO.reverse(payrollNum)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return i
    End Function

    Public Overloads Function retrieveByPayrollNum(ByVal payrollNum As UInteger) As DataTable
        Dim dTable As DataTable
        Try
            dTable = payrollDAO.retrieveByPayrollNum(payrollNum)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return dTable
    End Function

    Public Overloads Function retrieveByPayrollNum(ByVal payrollNum As UInteger, ByVal isReversed As Boolean) As DataTable
        Dim dTable As DataTable
        Try
            dTable = payrollDAO.retrieveByPayrollNum(payrollNum, isReversed)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return dTable
    End Function

    'Returns the employee number
    Public Function getEmpNum(ByVal payrollNum As UInteger) As UInteger
        Dim empNum As UInteger
        Try
            Dim pm As New ProjectManager
            empNum = pm.getEmpNum(payrollNum)
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Throw ex
        End Try

        Return empNum
    End Function


    'Shared Functions
#Region "Shared Functions"
    Public Shared Function getTaxPayerStatus_pKey(ByVal civilStat As String, ByVal numberOfDependents As UShort) As UInt16
        Dim status As String = getTaxPayerStatus(civilStat, numberOfDependents)
        If status.Equals("Z") Then
            Return 1
        ElseIf status.Equals("S") OrElse status.Equals("ME") Then
            Return 2
        ElseIf status.Equals("S1") OrElse status.Equals("ME1") Then
            Return 3
        ElseIf status.Equals("S2") OrElse status.Equals("ME2") Then
            Return 4
        ElseIf status.Equals("S3") OrElse status.Equals("ME3") Then
            Return 5
        ElseIf status.Equals("S4") OrElse status.Equals("ME4") Then
            Return 6
        Else
            Throw New MyApplicationException("Employee Tax Status (Civil Status | Number of Dependents) is invalid.")
        End If
    End Function

    Public Shared Function getTaxPayerStatus(ByVal civilStat As String, ByVal numberOfDependents As UShort) As String
        Dim stat As String = "Z"
        If civilStat.Equals("Single") Or civilStat.Equals("Separated") Or civilStat.Equals("Widow") Or _
            civilStat.Equals("Widower") Then
            stat = "S"
        ElseIf civilStat.Equals("Married") Then
            stat = "ME"
        End If

        'Though Z-stat is not allowed in this application 
        'Append Number of Dependents if any
        If Not stat.Equals("Z") Then
            If numberOfDependents > 3 Then
                stat = stat & "4"
            ElseIf numberOfDependents > 2 Then
                stat = stat & "3"
            ElseIf numberOfDependents > 1 Then
                stat = stat & "2"
            ElseIf numberOfDependents > 0 Then
                stat = stat & "1"
            Else
                'Append Nothing
            End If
        End If

        Return stat
    End Function

    Public Shared Function getDailyRate(ByVal payMethod As String, ByVal basicRate As Double) As Double
        Dim dailyRate As Double
        If payMethod.Equals("Daily") Or payMethod.Equals("Weekly") Then
            Return basicRate
        ElseIf payMethod.Equals("Monthly") Or payMethod.Equals("Semi") Then
            dailyRate = (basicRate * 12) / 365
        Else
            Throw New MyApplicationException("Invalid Pay Method.")
        End If

        Return dailyRate
    End Function

    Public Shared Function getBasicRatePerHour(ByVal payMethod As String, ByVal basicRate As Double) As Double
        Dim rate_per_hour As Double
        Dim dailyRate As Double = getDailyRate(payMethod, basicRate)
        If payMethod.Equals("Daily") Or payMethod.Equals("Weekly") Then
            rate_per_hour = dailyRate / 8
        ElseIf payMethod.Equals("Monthly") Or payMethod.Equals("Semi") Then
            rate_per_hour = dailyRate / 8
        Else
            Throw New MyApplicationException("Invalid Pay Method.")
        End If

        Return rate_per_hour
    End Function

    Public Shared Function getWorkdays_total(ByVal payMethod As String, ByVal basicRate As Double, _
                                             ByVal workdays As Integer) As Double
        Dim total As Double = 0

        Try
            Dim dailyRate As Double = getDailyRate(payMethod, basicRate)
            total = dailyRate * workdays
        Catch myex As MyApplicationException
            Throw myex
        Catch ex As Exception
            Throw New MyApplicationException("An error occur while getting `Workdays Total`.")
        End Try

        Return total
    End Function

    Public Shared Function computePAGIBIG_contribution(ByVal basicPay As Double) As Double
        Dim retVal As Double
        If basicPay < 1 Then Return 0
        If basicPay >= 1500 Then
            retVal = basicPay * 0.02
        Else
            retVal = basicPay * 0.01
        End If

        Return retVal
    End Function

    Public Shared Function getDivisor(ByVal payMethod As WTax_DAO.PayMethods, ByVal _date As Date)
        Select Case payMethod
            Case WTax_DAO.PayMethods.Weekly
                Return numberOfWeeks(_date)
            Case WTax_DAO.PayMethods.Semi
                Return 2
            Case Else
                Return 1
        End Select
    End Function

    Private Shared Function numberOfWeeks(ByVal _date As Date) As Integer
        Return New WeeksComputer().numberOfWeeksInMonth(_date)
    End Function

    Public Function getContribution_for_Weekly(ByVal empNum As UInteger, ByVal _from As Date, _
                                               ByVal deduction As Payroll_DAO.Weekly_Deduction, _
                                               ByVal currentRate As Double) As Double
        Dim contrib As Double = 0
        Try
            Dim dTable As DataTable
            Select Case deduction
                Case Payroll_DAO.Weekly_Deduction.SSS
                    dTable = payrollDAO.TrackSSSContribution(empNum, contruct_dateFrom(_from), _
                                               construct_dateTo(_from))
                Case Payroll_DAO.Weekly_Deduction.PhilHealth
                    dTable = payrollDAO.TrackPhilHealthContribution(empNum, contruct_dateFrom(_from), _
                                               construct_dateTo(_from))
                Case Else
                    dTable = Nothing
            End Select

            'Extract Data
            Dim prevTotRate As Double
            Dim prevTotContrib As Double
            If dTable Is Nothing Then
                prevTotRate = 0
                prevTotContrib = 0
            Else
                'Tot is short for Total
                prevTotRate = CDbl(DBNullToNumeric(dTable.Compute("SUM(prevTotalRate)", "")))
                prevTotContrib = CDbl(DBNullToNumeric(dTable.Compute("SUM(prevTotalContrib)", "")))
            End If

            'Find Contribution
            Dim totalRate As Double = currentRate + prevTotRate
            Dim currentContrib As Double
            Select Case deduction
                Case Payroll_DAO.Weekly_Deduction.SSS
                    Dim sssDAO As New SSS_DAO
                    currentContrib = sssDAO.find_Contribution(totalRate)
                Case Payroll_DAO.Weekly_Deduction.PhilHealth
                    Dim philHealthDAO As New PhilHealth_DAO
                    Dim rangeFrom_min As Double = philHealthDAO.getRangeFrom_minimum
                    'If total rate is below minimum range
                    If totalRate < rangeFrom_min Then
                        currentContrib = philHealthDAO.find_Contribution(rangeFrom_min)
                    Else
                        currentContrib = philHealthDAO.find_Contribution(totalRate)
                    End If
            End Select

            contrib = currentContrib - prevTotContrib
        Catch bex As BusinessException
            Throw bex
        Catch daex As DataAccessException
            Throw daex
        Catch ex As Exception
            Bugs_DAO.log(ex)
            Throw ex
        End Try
        Return contrib
    End Function

    Private Function contruct_dateFrom(ByVal _date As Date) As Date
        Dim dateTo As String = _
            String.Format("{0}-{1}-01", _date.ToString("yyyy"), _
                          _date.ToString("MM"))
        Return CDate(dateTo)
    End Function

    Private Function construct_dateTo(ByVal _date As Date) As Date
        Dim dateTo As String = _
            String.Format("{0}-{1}-{2}", _date.ToString("yyyy"), _
                          _date.ToString("MM"), dayFormat(WeeksComputer.getLastDay(_date)))
        Return CDate(dateTo)
    End Function

    Private Function dayFormat(ByVal day As Integer, Optional ByVal format As String = "00") As String
        Dim formatted As String = day.ToString
        If format.Equals("00") Then
            If day.ToString.Length < 2 Then
                formatted = String.Format("0{0}", day)
            ElseIf day.ToString.Length < 0 Then
                Return "00"
            End If
        End If
        Return formatted
    End Function
#End Region

#Region "Manager Based"
    Protected Overrides Sub insert_checkRequiredData()
        With payrollData_Courier
            Try
                NON_ZERO(.empNum)
            Catch bex As BusinessException
                bex.overrideMessage("`Employee` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.payFrom)
            Catch bex As BusinessException
                bex.overrideMessage("`Pay From` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.payTo)
            Catch bex As BusinessException
                bex.overrideMessage("`Pay To` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.civilStat)
            Catch bex As BusinessException
                bex.overrideMessage("`Civil Status` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.tp_status)
            Catch bex As BusinessException
                bex.overrideMessage("`Tax Payer Status` is required.")
                Throw bex
            End Try

            Try
                REQUIRED(.payMethod)
            Catch bex As BusinessException
                bex.overrideMessage("`Pay Method` is required.")
                Throw bex
            End Try

            Try
                NON_ZERO(.basicRate)
            Catch bex As BusinessException
                bex.overrideMessage("`Basic rate` should be greater than zero.")
                Throw bex
            End Try

            Try
                NON_ZERO(.regOT_rate)
            Catch bex As BusinessException
                bex.overrideMessage("`regOT rate` should be greater than zero.")
                Throw bex
            End Try

            Try
                NON_ZERO(.sunOT_rate)
            Catch bex As BusinessException
                bex.overrideMessage("`sunOT rate` should be greater than zero.")
                Throw bex
            End Try

            Try
                NON_ZERO(.holOT_rate)
            Catch bex As BusinessException
                bex.overrideMessage("`holOt rate` should be greater than zero.")
                Throw bex
            End Try

            Try
                NON_ZERO(.netPay)
            Catch bex As BusinessException
                bex.overrideMessage("`Net Pay` should atleast greater than zero(0).")
                Throw bex
            End Try
        End With
    End Sub

    Protected Overrides Sub insert_validateData()
    End Sub

    Protected Overrides Sub update_checkRequiredData()
        With payrollData_Courier
            Try
                NON_ZERO(.payrollNum)
            Catch bex As BusinessException
                bex.overrideMessage("`Payroll Number` is required.")
                Throw bex
            End Try
        End With
    End Sub

    Protected Overrides Sub update_validateData()
    End Sub
#End Region

#Region "Inner Class"
    Protected Class WeeksComputer
        Private weeksCounter As Integer = 1
        Private Const FEB As Integer = 2
        Private Shared _31() As Integer = {1, 3, 5, 7, 8, 10, 12}
        Private lastDay As Integer


        Public Function numberOfWeeksInMonth(ByVal _date As Date) As Integer
            lastDay = getLastDay(_date)
            backCounter(_date.Day)
            forwardCounter(_date.Day)

            Return weeksCounter
        End Function

        Public Shared Function getLastDay(ByVal _date As Date) As Integer
            Dim mo As Integer = _date.Month
            Dim lastDay As Integer
            If mo = FEB Then
                If Date.IsLeapYear(_date.Year) Then
                    lastDay = 29
                Else
                    lastDay = 28
                End If
            Else
                Dim is_31 As Boolean = False
                For x = 0 To _31.Length - 1
                    If _31(x) = mo Then
                        is_31 = True
                        Exit For
                    End If
                Next
                If is_31 Then lastDay = 31 Else lastDay = 30
            End If
            Return lastDay
        End Function

        Private Sub backCounter(ByVal day As Integer)
            If day - 7 > 0 Then
                weeksCounter += 1
                backCounter(day)
            End If
        End Sub

        Private Sub forwardCounter(ByVal day As Integer)
            If day + 7 <= lastDay Then
                weeksCounter += 1
                forwardCounter(day)
            End If
        End Sub
    End Class
#End Region
End Class