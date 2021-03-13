using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.AttendanceTerminal
{
    public partial class AttendanceTerminalForm : Form
    {
        private readonly ILogger<LoginFrm> _logger;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;

        public AttendanceTerminalForm(ILogger<LoginFrm> logger, 
                                    IEmployeeData employeeData,
                                    IEmployeeAttendanceData employeeAttendanceData)
        {
            InitializeComponent();
            _logger = logger;
            _employeeData = employeeData;
            _employeeAttendanceData = employeeAttendanceData;
        }

        private void AttendanceTerminalForm_Load(object sender, EventArgs e)
        {
            DisplayAttendanceRecordForToday();
        }

        public string GetMinDecimalToHrsFormat(decimal minutes)
        {
            if (minutes < 60)
            {
                return minutes.ToString() + "mins";
            }

            decimal hrsAndMins = minutes / 60;

            int hrsSide = (int)Math.Truncate(hrsAndMins);
            double frac = (double)hrsAndMins % 1;

            int minsSide = (int)Math.Truncate(frac * 60);

            return $"{hrsSide.ToString()}.{minsSide.ToString()}";
        }

        public void DisplayAttendanceRecordForToday()
        {
            var attendanceRecord = this._employeeAttendanceData.GetAllAttendanceRecordByWorkDate(DateTime.Now);

            if (attendanceRecord != null)
            {
                this.LViewAttendanceHistoryForToday.Items.Clear();
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

                    string whoDayTotalHrs = this.GetMinDecimalToHrsFormat(attendance.FirstHalfHrs + attendance.SecondHalfHrs);
                    string late = this.GetMinDecimalToHrsFormat(attendance.FirstHalfLateMins + attendance.SecondHalfLateMins);
                    string underTime = this.GetMinDecimalToHrsFormat(attendance.FirstHalfUnderTimeMins + attendance.SecondHalfUnderTimeMins);
                    string overTime = this.GetMinDecimalToHrsFormat(attendance.OverTimeMins);

                    var row = new string[]
                    {
                        attendance.EmployeeNumber,
                        $"{attendance.Employee.FirstName} {attendance.Employee.LastName}",
                        attendance.Shift.Shift,
                        $"{attendance.Shift.StartTime.ToString("hh:mm tt")} to {attendance.Shift.EndTime.ToString("hh:mm tt")}",
                        firstTimeINandOUT,
                        secondTimeINandOUT,
                        whoDayTotalHrs,
                        late,
                        underTime,
                        overTime
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = attendance;

                    this.LViewAttendanceHistoryForToday.Items.Add(listViewItem);
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

        private void TBoxCurrentEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                var empNumber = TBoxCurrentEmployeeNumber.Text;
                var empDetails = this._employeeData.GetByEmployeeNumber(empNumber);

                if (empDetails != null)
                {
                    if (empDetails.Shift == null)
                    {
                        MessageBox.Show("Employee's shift not found.", "Searching employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                            // insert the attendance record
                            if (_employeeAttendanceData.Add(attendance) > 0)
                            {
                                DisplayConfirmationForm(true);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }
                        }
                        else if (startDateTime >= todaysDateAndTime && earlyTimeOutDateTime > todaysDateAndTime)
                        {
                            //MessageBox.Show("good time-in for first half");
                            // good time-in for first half

                            attendance.FirstTimeIn = todaysDateAndTime;

                            // insert the attendance record
                            _employeeAttendanceData.Add(attendance);
                        }
                        else if (startDateTime < todaysDateAndTime &&
                                earlyTimeOutDateTime < todaysDateAndTime &&
                                lateTimeInDateTime >= todaysDateAndTime)
                        {
                            // good time-in for second half
                            //MessageBox.Show("good time-in for second half");


                            attendance.SecondTimeIn = todaysDateAndTime;

                            // insert the attendance record
                            if (_employeeAttendanceData.Add(attendance) > 0)
                            {
                                DisplayConfirmationForm(true);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
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


                            // insert the attendance record
                            if (_employeeAttendanceData.Add(attendance) > 0)
                            {
                                DisplayConfirmationForm(true);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
                            }

                        }
                        else if (startDateTime < todaysDateAndTime &&
                                 lateTimeInDateTime > todaysDateAndTime &&
                                 hrsDiffFromINandLateTimeIN <= 1)
                        {
                            // early time-in for second-half
                            //MessageBox.Show("early time-in for second-half");

                            attendance.SecondTimeIn = todaysDateAndTime;


                            // insert the attendance record
                            if (_employeeAttendanceData.Add(attendance) > 0)
                            {
                                DisplayConfirmationForm(true);
                            }
                            else
                            {
                                DisplayConfirmationForm(false);
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

                                if (_employeeAttendanceData.Update(todayAttendance))
                                {
                                    DisplayConfirmationForm(true);
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
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


                                if (_employeeAttendanceData.Update(todayAttendance))
                                {
                                    DisplayConfirmationForm(true);
                                }
                                else
                                {
                                    DisplayConfirmationForm(false);
                                }

                            }
                            else if (todaysDateAndTime > earlyTimeOutDateTime && todaysDateAndTime > lateTimeInDateTime)
                            {
                                TimeSpan firstTimeOutHrsTimespan = earlyTimeOutDateTime - startDateTime;
                                decimal firstTimeOutHrs = (int)firstTimeOutHrsTimespan.TotalMinutes;

                                todayAttendance.IsTimeOutProvided = true;
                                todayAttendance.FirstTimeOut = earlyTimeOutDateTime;
                                todayAttendance.FirstHalfHrs = firstTimeOutHrs;

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


                                    if (_employeeAttendanceData.Update(todayAttendance))
                                    {
                                        DisplayConfirmationForm(true);
                                    }
                                    else
                                    {
                                        DisplayConfirmationForm(false);
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

                                    if (_employeeAttendanceData.Update(todayAttendance))
                                    {
                                        DisplayConfirmationForm(true);
                                    }
                                    else
                                    {
                                        DisplayConfirmationForm(false);
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

    }
}
