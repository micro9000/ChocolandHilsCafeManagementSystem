using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using EntitiesShared.PayrollManagement.Models;
using Microsoft.Extensions.Logging;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Main.Forms.AttendanceTerminal
{
    public partial class AttendanceTerminalForm : Form
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IWorkforceScheduleData _workforceScheduleData;
        private readonly Sessions _sessions;

        public AttendanceTerminalForm(ILogger<LoginFrm> logger,
                                    DecimalMinutesToHrsConverter decimalMinutesToHrsConverter,
                                    IEmployeeData employeeData,
                                    IEmployeeAttendanceData employeeAttendanceData,
                                    IWorkforceScheduleData workforceScheduleData,
                                    Sessions sessions)
        {
            InitializeComponent();
            _logger = logger;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
            _employeeData = employeeData;
            _employeeAttendanceData = employeeAttendanceData;
            _workforceScheduleData = workforceScheduleData;
            _sessions = sessions;
        }

        private void AttendanceTerminalForm_Load(object sender, EventArgs e)
        {
            DisplayAttendanceRecordForToday();

            if (_sessions != null && _sessions.CurrentLoggedInUser != null && 
                _sessions.CurrentLoggedInUser.Role != null && 
                _sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.admin)
            {
                this.GBoxEditEmployeeAttendanceControls.Visible = true;
            }
        }

        public void DisplayAttendanceRecordForToday()
        {
            var attendanceRecord = this._employeeAttendanceData.GetAllAttendanceRecordByWorkDate(DateTime.Now);
            DisplayAttendanceRecord(attendanceRecord);
        }

        public void DisplayAttendanceRecord(List<EmployeeAttendanceModel> attendanceRecord)
        {
            if (attendanceRecord != null)
            {
                this.LViewAttendanceHistory.Items.Clear();
                foreach (var attendance in attendanceRecord)
                {
                    DateTime firstTimeOut = DateTime.Now;
                    if (attendance.FirstTimeOut == DateTime.MinValue)
                    {
                        firstTimeOut = attendance.Shift.EarlyTimeOut;
                    }
                    else
                    {
                        firstTimeOut = attendance.FirstTimeOut;
                    }

                    string firstTimeINandOUT = $"{attendance.FirstTimeIn.ToString("hh:mm")} {firstTimeOut.ToString("hh:mm")}";

                    string secondTimeINandOUT = "";

                    if (attendance.IsTimeOutProvided)
                    {
                        secondTimeINandOUT = $"{attendance.SecondTimeIn.ToString("hh:mm")} {attendance.SecondTimeOut.ToString("hh:mm")}";
                    }

                    string wholeDayTotalHrs = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalHrs); //attendance.FirstHalfHrs + attendance.SecondHalfHrs
                    string late = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalLate); //attendance.FirstHalfLateMins + attendance.SecondHalfLateMins
                    string underTime = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalUnderTime);//attendance.FirstHalfUnderTimeMins + attendance.SecondHalfUnderTimeMins
                    string overTime = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.OverTimeMins);

                    var row = new string[]
                    {
                        attendance.WorkDate.ToShortDateString(),
                        attendance.EmployeeNumber,
                        $"{attendance.Employee.FirstName} {attendance.Employee.LastName}",
                        attendance.Shift.Shift,
                        $"{attendance.Shift.StartTime.ToString("hh:mm tt")} to {attendance.Shift.EndTime.ToString("hh:mm tt")}",
                        firstTimeINandOUT,
                        secondTimeINandOUT,
                        wholeDayTotalHrs,
                        late,
                        underTime,
                        overTime
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = attendance;

                    this.LViewAttendanceHistory.Items.Add(listViewItem);
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LblCurrentDate.Text = DateTime.Now.ToLongDateString();
            this.LblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt", CultureInfo.CurrentCulture);
        }

        private void DisplayConfirmationForm(bool isSuccess)
        {
            var confirmationForm = new FrmConfirmation();
            confirmationForm.IsSuccess = isSuccess;
            confirmationForm.Show();
        }


        private DailySalaryComputation GetDailySalaryComputation(decimal empDailyRate, decimal shiftHrs, EmployeeAttendanceModel empAttendance)
        {
            decimal hourlyRate = empDailyRate / shiftHrs;
            decimal minuteRate = hourlyRate / 60;

            //// Whole day salary
            //decimal wholeDayMins = empAttendance.FirstHalfHrs + empAttendance.SecondHalfHrs;
            //Tuple<decimal, decimal> wholeDayHrsAndMins = _decimalMinutesToHrsConverter.GetHrsAndMinsSide(wholeDayMins);
            //decimal wholeDayHrsSideTotalRate = wholeDayHrsAndMins.Item1 * hourlyRate;
            //decimal wholeDayMinsSideTotalRate = wholeDayHrsAndMins.Item2 * minuteRate;

            if (empAttendance.FirstTimeIn == DateTime.MinValue && empAttendance.SecondTimeIn != DateTime.MinValue)
            {
                empDailyRate = empDailyRate / 2;
            }

            if (empAttendance.FirstTimeIn != DateTime.MinValue && empAttendance.FirstTimeOut != DateTime.MinValue &&
                empAttendance.SecondTimeIn == DateTime.MinValue && empAttendance.SecondTimeOut == DateTime.MinValue)
            {
                empDailyRate = empDailyRate / 2;
            }


            // late deduction computation
            decimal lateInMunites = empAttendance.FirstHalfLateMins + empAttendance.SecondHalfLateMins;
            decimal lateHrsSideTotal = 0;
            decimal lateMinsSideTotal = 0;
            decimal totalLateDeduction = 0;
            if (lateInMunites >= 1)
            {
                Tuple<decimal, decimal> lateHrsAndMins = _decimalMinutesToHrsConverter.GetHrsAndMinsSide(lateInMunites);
                lateHrsSideTotal = lateHrsAndMins.Item1 * hourlyRate;
                lateMinsSideTotal = lateHrsAndMins.Item2 * minuteRate;
                totalLateDeduction = lateHrsSideTotal + lateMinsSideTotal;
            }
            

            // undertime deduction computation
            decimal underTimeInMinutes = empAttendance.FirstHalfUnderTimeMins + empAttendance.SecondHalfUnderTimeMins;
            decimal underTimeHrsSideTotal = 0;
            decimal underTimeMinsSideTotal = 0;
            decimal totalUnderTimeDeduction = 0;
            if (underTimeInMinutes >= 1)
            {
                Tuple<decimal, decimal> underTimeHrsAndMins = _decimalMinutesToHrsConverter.GetHrsAndMinsSide(underTimeInMinutes);
                underTimeHrsSideTotal = underTimeHrsAndMins.Item1 * hourlyRate;
                underTimeMinsSideTotal = underTimeHrsAndMins.Item2 * minuteRate;
                totalUnderTimeDeduction = underTimeHrsSideTotal + underTimeMinsSideTotal;
            }

            // (wholeDayHrsSideTotalRate + wholeDayMinsSideTotalRate)
            // whole day salary computation
            decimal totalWholeDaySalary = empDailyRate - (totalLateDeduction + totalUnderTimeDeduction);

            // will check if overtime is paid
            // for now we will not add overtime
            //decimal overTimeInMunites = empAttendance.OverTimeMins; 

            return new DailySalaryComputation
            {
                LateTotalDeduction = totalLateDeduction,
                UnderTimeTotalDeduction = totalUnderTimeDeduction,
                TotalDailySalary = totalWholeDaySalary
            };

        }


        private void TBoxCurrentEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                var empNumber = TBoxCurrentEmployeeNumber.Text;
                var empDetails = this._employeeData.GetByEmployeeNumber(empNumber);

                if (empDetails != null)
                {
                    if (empDetails.SalaryRates == null)
                    {
                        MessageBox.Show($"{empDetails.FullName} don't have salary rate. Kindly update employee details", "Salary Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (empDetails.Shift == null)
                    {
                        MessageBox.Show("Employee's shift not found. \nKindly set employee shift.", "Searching employee details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var shiftDetails = empDetails.Shift;
                    var shiftDays = shiftDetails.ShiftDays;

                    string workingDays = string.Join(", ", shiftDays.Select(x => x.DayName).ToList().ToArray());
                    this.LblCurrentEmployeeSchedule.Text = $"{shiftDetails.Shift} (from {shiftDetails.StartTime.ToShortTimeString()} to {shiftDetails.EndTime.ToShortTimeString()}) \nDays: {workingDays}";

                    // we need to get the schedule time and align them on today's date and time
                    // if today is 2021/03/13 and schedule time is 8:30AM
                    // the startTime should be 2021/03/13 8:30AM, because in our database, the date is different, 
                    // so we need to align the date to today's date
                    DateTime startDateTime = DateTime.Today.Add(shiftDetails.StartTime.TimeOfDay);
                    DateTime endDateTime = DateTime.Today.Add(shiftDetails.EndTime.TimeOfDay);
                    DateTime earlyTimeOutDateTime = DateTime.Today.Add(shiftDetails.EarlyTimeOut.TimeOfDay);
                    DateTime lateTimeInDateTime = DateTime.Today.Add(shiftDetails.LateTimeIn.TimeOfDay);

                    // kung anong araw ngaun
                    DateTime todaysDateAndTime = this.DPickerTesting.Value; //DateTime.Now;
                    //var culture = CultureInfo.CurrentCulture;
                    //var workDateDayAbbr = culture.DateTimeFormat.GetAbbreviatedDayName(workDate.DayOfWeek);

                    var workforceSchedule = _workforceScheduleData.GetScheduleByEmpAndDate(empDetails.EmployeeNumber, todaysDateAndTime);

                    if (workforceSchedule == null)
                    {
                        MessageBox.Show("No workforce schedule specify in your account.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var todayAttendance = _employeeAttendanceData.GetEmployeeAttendanceByWorkDate(empDetails.EmployeeNumber, todaysDateAndTime);
                    if (todayAttendance != null && this.RBtnTimeIN.Checked)
                    {
                        MessageBox.Show("Invalid transaction, you already have TIME-IN transaction", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    // Invalid transaction for TIME-OUT
                    // employee should have TIME-IN transaction first
                    if (this.RBtnTimeOUT.Checked && todayAttendance == null)
                    {
                        MessageBox.Show("Invalid transaction, no TIME-IN Transaction", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (this.RBtnTimeIN.Checked)
                    {
                        TimeSpan hrsDiffFromINandLateTimeINTimespan = lateTimeInDateTime - todaysDateAndTime;
                        int hrsDiffFromINandLateTimeIN = (int)hrsDiffFromINandLateTimeINTimespan.TotalHours;

                        TimeSpan hrsDiffFromINandEndDateTimeTimespan = endDateTime - todaysDateAndTime;
                        int hrsDiffFromINandEndDateTime = (int)hrsDiffFromINandEndDateTimeTimespan.TotalHours;


                        var attendance = new EmployeeAttendanceModel
                        {
                            EmployeeNumber = empDetails.EmployeeNumber,
                            ShiftId = empDetails.ShiftId,
                            WorkDate = todaysDateAndTime
                        };


                        if (startDateTime < todaysDateAndTime &&
                            earlyTimeOutDateTime > todaysDateAndTime &&
                            hrsDiffFromINandLateTimeIN > 1)
                        {
                            //MessageBox.Show("compute late for first-half");
                            // compute late for first-half


                            TimeSpan lateInterval = todaysDateAndTime - startDateTime;
                            //int lateHrs = (int)lateInterval.TotalHours;
                            decimal lateMins = (decimal)lateInterval.TotalMinutes;

                            attendance.FirstTimeIn = todaysDateAndTime;
                            attendance.FirstHalfLateMins = lateMins;

                            using (var transaction = new TransactionScope())
                            {
                                // insert the attendance record
                                if (_employeeAttendanceData.Add(attendance) > 0)
                                {
                                    DisplayConfirmationForm(true);
                                    //workforceSchedule.isDone = true;
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }
                                transaction.Complete();
                            }
                            
                        }
                        else if (startDateTime >= todaysDateAndTime && earlyTimeOutDateTime > todaysDateAndTime)
                        {
                            //MessageBox.Show("good time-in for first half");
                            // good time-in for first half

                            attendance.FirstTimeIn = todaysDateAndTime;

                            using (var transaction = new TransactionScope())
                            {
                                // insert the attendance record
                                if (_employeeAttendanceData.Add(attendance) > 0)
                                {
                                    DisplayConfirmationForm(true);
                                    //workforceSchedule.isDone = true;
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }
                                transaction.Complete();
                            }
                            
                        }
                        else if (startDateTime < todaysDateAndTime &&
                                earlyTimeOutDateTime < todaysDateAndTime &&
                                lateTimeInDateTime >= todaysDateAndTime)
                        {
                            // good time-in for second half
                            //MessageBox.Show("good time-in for second half");


                            attendance.SecondTimeIn = todaysDateAndTime;

                            using (var transaction = new TransactionScope())
                            {
                                // insert the attendance record
                                if (_employeeAttendanceData.Add(attendance) > 0)
                                {
                                    DisplayConfirmationForm(true);
                                    //workforceSchedule.isDone = true;
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }
                                transaction.Complete();
                            }
                            

                        }
                        else if (startDateTime < todaysDateAndTime &&
                               earlyTimeOutDateTime < todaysDateAndTime &&
                               lateTimeInDateTime < todaysDateAndTime &&
                               endDateTime > todaysDateAndTime &&
                               hrsDiffFromINandEndDateTime >= 1)
                        {
                            // put null for first-half time and out and 0 for hrs
                            // compute late for second half
                            //MessageBox.Show("put null for first-half time and out and 0 for hrs \n compute late for second half");


                            TimeSpan lateInterval = todaysDateAndTime - lateTimeInDateTime;
                            //int lateHrs = (int)lateInterval.TotalHours;
                            decimal lateMins = (decimal)lateInterval.TotalMinutes;

                            attendance.SecondTimeIn = todaysDateAndTime;
                            attendance.SecondHalfLateMins = lateMins;


                            using (var transaction = new TransactionScope())
                            {
                                // insert the attendance record
                                if (_employeeAttendanceData.Add(attendance) > 0)
                                {
                                    DisplayConfirmationForm(true);
                                    //workforceSchedule.isDone = true;
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }
                                transaction.Complete();
                            }

                            

                        }
                        else if (startDateTime < todaysDateAndTime &&
                                 lateTimeInDateTime > todaysDateAndTime &&
                                 hrsDiffFromINandLateTimeIN <= 1)
                        {
                            // early time-in for second-half
                            //MessageBox.Show("early time-in for second-half");

                            attendance.SecondTimeIn = todaysDateAndTime;

                            using (var transaction = new TransactionScope())
                            {
                                // insert the attendance record
                                if (_employeeAttendanceData.Add(attendance) > 0)
                                {
                                    DisplayConfirmationForm(true);
                                    //workforceSchedule.isDone = true;
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }
                                transaction.Complete();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Invalid transaction.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else if (this.RBtnTimeOUT.Checked)
                    {
                        if (todayAttendance != null)
                        {
                            if (todayAttendance.IsTimeOutProvided == true)
                            {
                                MessageBox.Show("Time-out transaction already provided.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            
                            // time-out time should not earlier than shift start-time
                            if (todaysDateAndTime <= startDateTime)
                            {
                                MessageBox.Show("Invalid transaction", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (todaysDateAndTime > earlyTimeOutDateTime && lateTimeInDateTime >= todaysDateAndTime)
                            {
                                //MessageBox.Show("Good time-out for first-half");

                                TimeSpan firstTimeOutHrsTimespan = todaysDateAndTime - startDateTime;
                                decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes; // no need to store the sec

                                todayAttendance.IsTimeOutProvided = true;
                                todayAttendance.FirstTimeOut = todaysDateAndTime;
                                todayAttendance.FirstHalfHrs = firstTimeOutHrs;

                                var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                                todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                                todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                                todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                                todayAttendance.OverTimeTotalDeduction = 0;

                                using (var transaction = new TransactionScope())
                                {
                                    if (_employeeAttendanceData.Update(todayAttendance))
                                    {
                                        DisplayConfirmationForm(true);
                                        workforceSchedule.isDone = true;

                                        _workforceScheduleData.Update(workforceSchedule);
                                    }
                                    else
                                    {
                                        DisplayConfirmationForm(false);
                                    }

                                    transaction.Complete();
                                }

                                
                            }
                            else if (todaysDateAndTime < earlyTimeOutDateTime && lateTimeInDateTime >= todaysDateAndTime)
                            {
                                TimeSpan firstTimeOutHrsTimespan = todaysDateAndTime - startDateTime;
                                decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes; // no need to store the sec

                                TimeSpan underTimeTimespan = earlyTimeOutDateTime - todaysDateAndTime;
                                decimal underTime = (int)underTimeTimespan.TotalMinutes;// no need to store the sec

                                todayAttendance.IsTimeOutProvided = true;
                                todayAttendance.FirstTimeOut = todaysDateAndTime;
                                todayAttendance.FirstHalfHrs = firstTimeOutHrs;
                                todayAttendance.FirstHalfUnderTimeMins = underTime;

                                var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                                todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                                todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                                todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                                todayAttendance.OverTimeTotalDeduction = 0;

                                using (var transaction = new TransactionScope())
                                {
                                    if (_employeeAttendanceData.Update(todayAttendance))
                                    {
                                        DisplayConfirmationForm(true);
                                        workforceSchedule.isDone = true;

                                        _workforceScheduleData.Update(workforceSchedule);
                                    }
                                    else
                                    {
                                        DisplayConfirmationForm(false);
                                    }
                                    transaction.Complete();
                                }


                            }
                            else if (todaysDateAndTime > earlyTimeOutDateTime && todaysDateAndTime > lateTimeInDateTime)
                            {
                                TimeSpan firstTimeOutHrsTimespan = earlyTimeOutDateTime - startDateTime;
                                decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes;

                                todayAttendance.IsTimeOutProvided = true;

                                if (todayAttendance.FirstTimeIn != DateTime.MinValue)
                                {
                                    todayAttendance.FirstTimeOut = earlyTimeOutDateTime;
                                    todayAttendance.FirstHalfHrs = firstTimeOutHrs;
                                }

                                if (todaysDateAndTime < endDateTime)
                                {

                                    TimeSpan secondTimeOutHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                                    decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec

                                    TimeSpan underTimeTimespan = endDateTime - todaysDateAndTime;
                                    decimal underTime = (int)underTimeTimespan.TotalMinutes;// no need to store the sec

                                    todayAttendance.SecondTimeIn = lateTimeInDateTime;
                                    todayAttendance.SecondTimeOut = todaysDateAndTime;
                                    todayAttendance.SecondHalfHrs = secondTimeOutHrs;

                                    todayAttendance.SecondHalfUnderTimeMins = underTime;

                                    var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                                    todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                                    todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                                    todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                                    todayAttendance.OverTimeTotalDeduction = 0;

                                    using (var transaction = new TransactionScope())
                                    {
                                        if (_employeeAttendanceData.Update(todayAttendance))
                                        {
                                            DisplayConfirmationForm(true);
                                            workforceSchedule.isDone = true;

                                            _workforceScheduleData.Update(workforceSchedule);
                                        }
                                        else
                                        {
                                            DisplayConfirmationForm(false);
                                        }

                                        transaction.Complete();
                                    }

                                    
                                }
                                else
                                {

                                    TimeSpan secondTimeOutHrsTimespan = endDateTime - lateTimeInDateTime;
                                    decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec

                                    TimeSpan overTimeHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                                    decimal overTimeHrs = (int)overTimeHrsTimespan.TotalMinutes - secondTimeOutHrs;// no need to store the sec

                                    todayAttendance.SecondTimeIn = lateTimeInDateTime;
                                    todayAttendance.SecondTimeOut = todaysDateAndTime;
                                    todayAttendance.SecondHalfHrs = secondTimeOutHrs;

                                    todayAttendance.OverTimeMins = overTimeHrs;

                                    var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                                    todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                                    todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                                    todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                                    todayAttendance.OverTimeTotalDeduction = 0;

                                    using (var transaction = new TransactionScope())
                                    {
                                        if (_employeeAttendanceData.Update(todayAttendance))
                                        {
                                            DisplayConfirmationForm(true);
                                            workforceSchedule.isDone = true;

                                            _workforceScheduleData.Update(workforceSchedule);
                                        }
                                        else
                                        {
                                            DisplayConfirmationForm(false);
                                        }

                                        transaction.Complete();
                                    }
                                    
                                }

                                //MessageBox.Show("Compute first-half hrs and second-half hrs");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kindly select Time IN or OUT", "Time IN or OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    DisplayAttendanceRecordForToday();

                }
                else
                {
                    MessageBox.Show("Employee details not found!", "Searching employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnFilterAttendance_Click(object sender, EventArgs e)
        {
            var start = this.DPickerFilterAttendanceStart.Value;
            var end = this.DPickerFilterAttendanceEnd.Value;

            var attendanceRecord = this._employeeAttendanceData.GetAllAttendanceRecordByWorkDateRange(start, end);
            DisplayAttendanceRecord(attendanceRecord);
        }

        private void BtnUpdateEmployeeAttendance_Click(object sender, EventArgs e)
        {
            string employeeNumber = this.TboxEditAttendanceEmployeeNumber.Text;
            DateTime attendanceDate = this.DPickerAttendanceDateEditAttendance.Value;
            DateTime attendanceTime = this.DPicTimeEditAttendance.Value;

            var empDetails = this._employeeData.GetByEmployeeNumber(employeeNumber);

            if (empDetails != null)
            {
                if (empDetails.SalaryRates == null)
                {
                    MessageBox.Show($"{empDetails.FullName} don't have salary rate. Kindly update employee details", "Salary Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (empDetails.Shift == null)
                {
                    MessageBox.Show("Employee's shift not found. \nKindly set employee shift.", "Searching employee details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var shiftDetails = empDetails.Shift;
                var shiftDays = shiftDetails.ShiftDays;

                DateTime startDateTime = DateTime.Today.Add(shiftDetails.StartTime.TimeOfDay);
                DateTime endDateTime = DateTime.Today.Add(shiftDetails.EndTime.TimeOfDay);
                DateTime earlyTimeOutDateTime = DateTime.Today.Add(shiftDetails.EarlyTimeOut.TimeOfDay);
                DateTime lateTimeInDateTime = DateTime.Today.Add(shiftDetails.LateTimeIn.TimeOfDay);

                // use the specified time as time in/out time
                DateTime todaysDateAndTime = attendanceTime;

                var workforceSchedule = _workforceScheduleData.GetScheduleByEmpAndDate(empDetails.EmployeeNumber, todaysDateAndTime);

                if (workforceSchedule == null)
                {
                    MessageBox.Show("No workforce schedule specify in your account.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // retrieve the attendance record by the specified date
                var todayAttendance = _employeeAttendanceData.GetEmployeeAttendanceByWorkDate(empDetails.EmployeeNumber, attendanceDate);
                if (todayAttendance == null)
                {
                    MessageBox.Show($"Invalid transaction, No attendance record for {todaysDateAndTime.ToShortDateString()}", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //if (todayAttendance.IsPaid)
                //{
                //    MessageBox.Show($"Invalid transaction, the attendance record you are trying to edit is already mark as paid.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                if (this.RBtnTimeINEditAttendance.Checked)
                { // edit time in

                    TimeSpan hrsDiffFromINandLateTimeINTimespan = lateTimeInDateTime - todaysDateAndTime;
                    int hrsDiffFromINandLateTimeIN = (int)hrsDiffFromINandLateTimeINTimespan.TotalHours;

                    TimeSpan hrsDiffFromINandEndDateTimeTimespan = endDateTime - todaysDateAndTime;
                    int hrsDiffFromINandEndDateTime = (int)hrsDiffFromINandEndDateTimeTimespan.TotalHours;

                    if (startDateTime < todaysDateAndTime &&
                            earlyTimeOutDateTime > todaysDateAndTime &&
                            hrsDiffFromINandLateTimeIN > 1)
                    {
                        // compute late for first-half

                        TimeSpan lateInterval = todaysDateAndTime - startDateTime;
                        //int lateHrs = (int)lateInterval.TotalHours;
                        decimal lateMins = (decimal)lateInterval.TotalMinutes;

                        todayAttendance.FirstTimeIn = todaysDateAndTime;
                        todayAttendance.FirstHalfLateMins = lateMins;

                        // Re compute late mins, late deduction and daily salary
                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);
                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;

                        // Re compute first half hrs
                        TimeSpan firstTimeOutHrsTimespan = earlyTimeOutDateTime - startDateTime;
                        decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes;
                        todayAttendance.FirstHalfHrs = firstTimeOutHrs;

                        using (var transaction = new TransactionScope())
                        {
                            // insert the attendance record
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                            transaction.Complete();
                        }

                    }
                    else if (startDateTime >= todaysDateAndTime && earlyTimeOutDateTime > todaysDateAndTime)
                    {
                        //MessageBox.Show("good time-in for first half");
                        // good time-in for first half

                        todayAttendance.FirstTimeIn = todaysDateAndTime;
                        todayAttendance.FirstHalfLateMins = 0;

                        if (todayAttendance.SecondTimeIn != DateTime.MinValue)
                        {
                            todayAttendance.FirstTimeOut = earlyTimeOutDateTime;
                        }

                        // Re compute late mins, late deduction and daily salary
                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);
                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = 0;

                        // Re compute first half hrs
                        TimeSpan firstTimeOutHrsTimespan = earlyTimeOutDateTime - startDateTime;
                        decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes;
                        todayAttendance.FirstHalfHrs = firstTimeOutHrs;

                        using (var transaction = new TransactionScope())
                        {
                            // insert the attendance record
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                                //workforceSchedule.isDone = true;
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                            transaction.Complete();
                        }

                    }
                    else if (startDateTime < todaysDateAndTime &&
                               earlyTimeOutDateTime < todaysDateAndTime &&
                               lateTimeInDateTime >= todaysDateAndTime)
                    {
                        // good time-in for second half


                        todayAttendance.FirstTimeIn = DateTime.MinValue;
                        todayAttendance.FirstTimeOut = DateTime.MinValue;
                        todayAttendance.FirstHalfHrs = 0;
                        todayAttendance.FirstHalfLateMins = 0;
                        todayAttendance.FirstHalfUnderTimeMins = 0;

                        todayAttendance.SecondTimeIn = todaysDateAndTime;
                        todayAttendance.SecondHalfLateMins = 0;

                        // Re compute late mins, late deduction and daily salary
                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);
                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = 0;

                        TimeSpan secondTimeOutHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                        decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec

                        todayAttendance.SecondHalfHrs = secondTimeOutHrs;

                        using (var transaction = new TransactionScope())
                        {
                            // insert the attendance record
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                            transaction.Complete();
                        }


                    }
                    else if (startDateTime < todaysDateAndTime &&
                              earlyTimeOutDateTime < todaysDateAndTime &&
                              lateTimeInDateTime < todaysDateAndTime &&
                              endDateTime > todaysDateAndTime &&
                              hrsDiffFromINandEndDateTime >= 1)
                    {
                        // put null for first-half time and out and 0 for hrs
                        // compute late for second half
                        //MessageBox.Show("put null for first-half time and out and 0 for hrs \n compute late for second half");


                        TimeSpan lateInterval = todaysDateAndTime - lateTimeInDateTime;
                        //int lateHrs = (int)lateInterval.TotalHours;
                        decimal lateMins = (decimal)lateInterval.TotalMinutes;

                        todayAttendance.SecondTimeIn = todaysDateAndTime;
                        todayAttendance.SecondHalfLateMins = lateMins;

                        // Re compute late mins, late deduction and daily salary
                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);
                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;


                        TimeSpan secondTimeOutHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                        decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec
                        todayAttendance.SecondHalfHrs = secondTimeOutHrs;


                        using (var transaction = new TransactionScope())
                        {
                            // insert the attendance record
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                                //workforceSchedule.isDone = true;
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                            transaction.Complete();
                        }
                    }
                    else if (startDateTime < todaysDateAndTime &&
                                 lateTimeInDateTime > todaysDateAndTime &&
                                 hrsDiffFromINandLateTimeIN <= 1)
                    {
                        // early time-in for second-half
                        //MessageBox.Show("early time-in for second-half");

                        todayAttendance.FirstTimeIn = DateTime.MinValue;
                        todayAttendance.FirstTimeOut = DateTime.MinValue;
                        todayAttendance.FirstHalfHrs = 0;
                        todayAttendance.FirstHalfLateMins = 0;
                        todayAttendance.FirstHalfUnderTimeMins = 0;

                        todayAttendance.SecondTimeIn = todaysDateAndTime;

                        todayAttendance.SecondHalfLateMins = 0;

                        // Re compute late mins, late deduction and daily salary
                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);
                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = 0;

                        if (todayAttendance.SecondTimeOut != DateTime.MinValue)
                        {
                            TimeSpan secondTimeOutHrsTimespan = todayAttendance.SecondTimeOut - lateTimeInDateTime;
                            decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec
                            todayAttendance.SecondHalfHrs = secondTimeOutHrs;
                        }
                        else
                        {
                            TimeSpan secondTimeOutHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                            decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec
                            todayAttendance.SecondHalfHrs = secondTimeOutHrs;
                        }

                        

                        using (var transaction = new TransactionScope())
                        {
                            // insert the attendance record
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                                //workforceSchedule.isDone = true;
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                            transaction.Complete();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid transaction.", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else if (this.RBtnTimeOutEditAttendance.Checked)
                {// time out

                    // time-out time should not earlier than shift start-time
                    if (todaysDateAndTime <= startDateTime)
                    {
                        MessageBox.Show("Invalid transaction", "Attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (todaysDateAndTime >= earlyTimeOutDateTime && lateTimeInDateTime >= todaysDateAndTime && todayAttendance.FirstTimeIn != DateTime.MinValue)
                    {
                        //MessageBox.Show("Good time-out for first-half");

                        TimeSpan firstTimeOutHrsTimespan = todaysDateAndTime - startDateTime;
                        decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes; // no need to store the sec

                        todayAttendance.IsTimeOutProvided = true;
                        todayAttendance.FirstTimeOut = todaysDateAndTime;
                        todayAttendance.FirstHalfHrs = firstTimeOutHrs;


                        todayAttendance.SecondTimeIn = DateTime.MinValue;
                        todayAttendance.SecondTimeOut = DateTime.MinValue;
                        todayAttendance.SecondHalfHrs = 0;
                        todayAttendance.SecondHalfLateMins = 0;
                        todayAttendance.SecondHalfUnderTimeMins = 0;


                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                        todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                        todayAttendance.OverTimeTotalDeduction = 0;

                        using (var transaction = new TransactionScope())
                        {
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                                workforceSchedule.isDone = true;

                                _workforceScheduleData.Update(workforceSchedule);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }

                            transaction.Complete();
                        }
                    }
                    else if (todaysDateAndTime < earlyTimeOutDateTime && lateTimeInDateTime >= todaysDateAndTime)
                    {
                        TimeSpan firstTimeOutHrsTimespan = todaysDateAndTime - startDateTime;
                        decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes; // no need to store the sec

                        TimeSpan underTimeTimespan = earlyTimeOutDateTime - todaysDateAndTime;
                        decimal underTime = (int)underTimeTimespan.TotalMinutes;// no need to store the sec

                        todayAttendance.IsTimeOutProvided = true;
                        todayAttendance.FirstTimeOut = todaysDateAndTime;
                        todayAttendance.FirstHalfHrs = firstTimeOutHrs;
                        todayAttendance.FirstHalfUnderTimeMins = underTime;

                        var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                        todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                        todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                        todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                        todayAttendance.OverTimeTotalDeduction = 0;
                        todayAttendance.OverTimeMins = 0;

                        using (var transaction = new TransactionScope())
                        {
                            if (_employeeAttendanceData.Update(todayAttendance))
                            {
                                DisplayConfirmationForm(true);
                                workforceSchedule.isDone = true;

                                _workforceScheduleData.Update(workforceSchedule);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                            transaction.Complete();
                        }
                    }
                    else if (todaysDateAndTime > earlyTimeOutDateTime && todaysDateAndTime > lateTimeInDateTime)
                    {
                        // second half time-out transactions:

                        TimeSpan firstTimeOutHrsTimespan = earlyTimeOutDateTime - startDateTime;
                        decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes;

                        todayAttendance.IsTimeOutProvided = true;

                        if (todayAttendance.FirstTimeIn != DateTime.MinValue)
                        {
                            todayAttendance.FirstTimeOut = earlyTimeOutDateTime;
                            todayAttendance.FirstHalfHrs = firstTimeOutHrs;
                        }


                        if (todaysDateAndTime < endDateTime)
                        {

                            TimeSpan secondTimeOutHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                            decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec

                            TimeSpan underTimeTimespan = endDateTime - todaysDateAndTime;
                            decimal underTime = (int)underTimeTimespan.TotalMinutes;// no need to store the sec

                            todayAttendance.SecondTimeIn = lateTimeInDateTime;
                            todayAttendance.SecondTimeOut = todaysDateAndTime;
                            todayAttendance.SecondHalfHrs = secondTimeOutHrs;

                            todayAttendance.SecondHalfUnderTimeMins = underTime;

                            var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                            todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                            todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                            todayAttendance.UnderTimeTotalDeduction = dailyRateComputation.UnderTimeTotalDeduction;
                            todayAttendance.OverTimeTotalDeduction = 0;
                            todayAttendance.OverTimeMins = 0;

                            using (var transaction = new TransactionScope())
                            {
                                if (_employeeAttendanceData.Update(todayAttendance))
                                {
                                    DisplayConfirmationForm(true);
                                    workforceSchedule.isDone = true;

                                    _workforceScheduleData.Update(workforceSchedule);
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }

                                transaction.Complete();
                            }


                        }
                        else
                        {
                            // Time out with overtime
                            TimeSpan secondTimeOutHrsTimespan = endDateTime - lateTimeInDateTime;
                            decimal secondTimeOutHrs = (int)secondTimeOutHrsTimespan.TotalMinutes;// no need to store the sec

                            TimeSpan overTimeHrsTimespan = todaysDateAndTime - lateTimeInDateTime;
                            decimal overTimeHrs = (int)overTimeHrsTimespan.TotalMinutes - secondTimeOutHrs;// no need to store the sec

                            todayAttendance.SecondTimeIn = lateTimeInDateTime;
                            todayAttendance.SecondTimeOut = todaysDateAndTime;
                            todayAttendance.SecondHalfHrs = secondTimeOutHrs;

                            todayAttendance.OverTimeMins = overTimeHrs;

                            var dailyRateComputation = GetDailySalaryComputation(empDetails.SalaryRates.DailyRate, empDetails.Shift.NumberOfHrs, todayAttendance);

                            todayAttendance.TotalDailySalary = dailyRateComputation.TotalDailySalary;
                            todayAttendance.LateTotalDeduction = dailyRateComputation.LateTotalDeduction;
                            todayAttendance.UnderTimeTotalDeduction = 0;//dailyRateComputation.UnderTimeTotalDeduction;
                            todayAttendance.SecondHalfUnderTimeMins = 0;
                            //todayAttendance.OverTimeTotalDeduction = 0; // need to rename this
                            //todayAttendance.OverTimeMins = 0;

                            using (var transaction = new TransactionScope())
                            {
                                if (_employeeAttendanceData.Update(todayAttendance))
                                {
                                    DisplayConfirmationForm(true);
                                    workforceSchedule.isDone = true;

                                    _workforceScheduleData.Update(workforceSchedule);
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }

                                transaction.Complete();
                            }

                        }

                        //MessageBox.Show("Compute first-half hrs and second-half hrs");
                    }
                }
                else
                {
                    MessageBox.Show("Kindly select Time IN or OUT", "Time IN or OUT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DisplayAttendanceRecordForToday();

            }

            else
            {
                MessageBox.Show("Employee details not found!", "Searching employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
