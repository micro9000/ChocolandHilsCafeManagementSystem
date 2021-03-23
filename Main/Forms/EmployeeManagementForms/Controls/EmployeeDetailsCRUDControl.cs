using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using EntitiesShared.OtherDataManagement;
using Shared.CustomModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Shared.Helpers;
using System.Globalization;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmployeeDetailsCRUDControl : UserControl
    {
        public EmployeeDetailsCRUDControl(DecimalMinutesToHrsConverter decimalMinutesToHrsConverter)
        {
            InitializeComponent();
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private List<GovernmentAgencyModel> govtAgencies;

        public List<GovernmentAgencyModel> GovtAgencies
        {
            get { return govtAgencies; }
            set { govtAgencies = value; }
        }


        public event EventHandler WorkShiftSelected;
        protected virtual void OnWorkShiftSelected(EventArgs e)
        {
            WorkShiftSelected?.Invoke(this, e);
        }

        private long selectedShiftId;

        public long SelectedShiftId
        {
            get { return selectedShiftId; }
            set { selectedShiftId = value; }
        }


        private List<EmployeeShiftModel> workShifts;

        public List<EmployeeShiftModel> WorkShifts
        {
            get { return workShifts; }
            set { workShifts = value; }
        }


        private List<EmployeeShiftDayModel> workShiftDays = new List<EmployeeShiftDayModel>();

        public List<EmployeeShiftDayModel> WorkShiftDays
        {
            get { return workShiftDays; }
            set { workShiftDays = value; }
        }


        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private List<EmployeeGovtIdCardTempModel> employeeGovtIdCards = new List<EmployeeGovtIdCardTempModel>();

        public List<EmployeeGovtIdCardTempModel> EmployeeGovtIdCards
        {
            get { return employeeGovtIdCards; }
            set { employeeGovtIdCards = value; }
        }


        private EmployeeSalaryRateModel employeeSalary;

        public EmployeeSalaryRateModel EmployeeSalary
        {
            get { return employeeSalary; }
            set { employeeSalary = value; }
        }



        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        private Dictionary<DateTime, AttendanceRecord> attendanceToDisplay = new Dictionary<DateTime, AttendanceRecord>();

        public Dictionary<DateTime, AttendanceRecord> AttendanceToDisplay
        {
            get { return attendanceToDisplay; }
            set { attendanceToDisplay = value; }
        }



        public event EventHandler EmployeeSaved;
        protected virtual void OnEmployeeSaved(EventArgs e)
        {
            EmployeeSaved?.Invoke(this, e);
        }

        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set
            {
                employeeNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(EmployeeNumber));
                }
            }
        }


        public static void EnableTab(TabPage page, bool enable)
        {
            EnableControls(page.Controls, enable);
        }
        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }

        private List<EmployeeAttendanceModel> attendanceHistory;

        public List<EmployeeAttendanceModel> AttendanceHistory
        {
            get { return attendanceHistory; }
            set { attendanceHistory = value; }
        }


        private List<EmployeeLeaveModel> employeeLeaveHistory;

        public List<EmployeeLeaveModel> EmployeeLeaveHistory
        {
            get { return employeeLeaveHistory; }
            set { employeeLeaveHistory = value; }
        }

        private List<HolidayModel> holidays;

        public List<HolidayModel> Holidays
        {
            get { return holidays; }
            set { holidays = value; }
        }

        private List<WorkforceScheduleModel> workforceSchedules;

        public List<WorkforceScheduleModel> WorkforceSchedules
        {
            get { return workforceSchedules; }
            set { workforceSchedules = value; }
        }



        private void EmployeeDetailsCRUDControl_Load(object sender, EventArgs e)
        {
            // Govt. agencies load in combo box
            if (this.GovtAgencies != null)
            {
                ComboboxItem item;
                foreach (var agency in this.GovtAgencies)
                {
                    item = new ComboboxItem();
                    item.Text = agency.GovtAgency;
                    item.Value = agency.Id;
                    this.CboxGovtAgencies.Items.Add(item);
                }
            }

            // Work shifts load in combo box
            if (this.WorkShifts != null)
            {
                ComboboxItem item;
                foreach (var shift in this.WorkShifts)
                {
                    item = new ComboboxItem();
                    item.Text = $"{shift.Shift} - from {shift.StartTime.ToShortTimeString()} to {shift.EndTime.ToShortTimeString()}";
                    item.Value = shift.Id;
                    this.CBoxShiftList.Items.Add(item);
                }
            }

        }

        public void ClearForm()
        {
            this.employeeNumber = "";
            this.IsNew = true;

            if (PicBoxEmpImage.Image != null)
            {
                PicBoxEmpImage.Image.Dispose();
                PicBoxEmpImage.ImageLocation = null;
                PicBoxEmpImage.Image = null;
            }

            this.LViewAttendanceHistory.Items.Clear();
            this.AttendanceHistory = null;

            this.LblActionForEmployeeDetails.Text = "Add new employee";
            this.TbxFirstName.Text = "";
            this.TbxLastName.Text = "";
            this.TbxMiddleInitial.Text = "";
            this.DTPicBirthDate.Value = DateTime.Now;
            this.TbxMobileNumber.Text = "";
            this.DTPicHireDate.Value = DateTime.Now;
            this.TbxAddress.Text = "";
            this.TbxBranchAssign.Text = "";
            this.TbxEmail.Text = "";
            this.TbxEmpPosition.Text = "";
            this.TbxEmployeeNumber.Text = "";
            this.CboxGovtAgencies.SelectedIndex = -1;

            this.CBoxShiftList.SelectedIndex = -1;
            this.LblShiftWorkingDays.Text = "";

            this.TboxEmpIdNumber.Text = "";

            this.TbxSalaryRate.Text = "";
            this.TboxHalfMonthRate.Text = "";
            this.TbxDailySalaryRate.Text = "";

            this.GBoxSearchEmployee.Visible = false;
            this.BtnCancelUpdateEmployee.Visible = false;

            TabControlSaveEmployeeDetails.SelectedIndex = 0;

            this.BtnActionAddNewEmployee.Enabled = true;
            this.BtnActionUpdateEmployeeDetails.Enabled = true;
            this.BtnCancelUpdateEmployee.Visible = true;
            this.ListViewEmpGovtIdCards.Items.Clear();
            this.NumUpDwnEmployeeContribution.Value = 0;
            this.NumUpDwnEmployerContribution.Value = 0;

            this.BtnUndoToDelete.Visible = false;
            this.BtnDeleteEmpIdCard.Visible = false;

            this.EmployeeGovtIdCards = new List<EmployeeGovtIdCardTempModel>();

        }


        public void DisplayEmployeeDetails(EmployeeModel employeeDetails)
        {
            if (employeeDetails != null)
            {
                this.TbxFirstName.Text = employeeDetails.FirstName;
                this.TbxLastName.Text = employeeDetails.LastName;
                this.TbxMiddleInitial.Text = employeeDetails.MiddleName;
                this.DTPicBirthDate.Value = employeeDetails.BirthDate;
                this.TbxMobileNumber.Text = employeeDetails.MobileNumber;
                this.DTPicHireDate.Value = employeeDetails.DateHire;
                this.TbxAddress.Text = employeeDetails.Address;
                this.TbxBranchAssign.Text = employeeDetails.BranchAssign;
                this.TbxEmail.Text = employeeDetails.EmailAddress;
                this.TbxEmpPosition.Text = employeeDetails.Position;



                string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var EmployeeImgsDirInfo = Directory.CreateDirectory(appPath + "\\EmployeeImgs\\");

                if (EmployeeImgsDirInfo.Exists)
                {
                    string empImgPath = appPath + "\\EmployeeImgs\\" + employeeDetails.ImageFileName;

                    if (File.Exists(empImgPath))
                    {
                        PicBoxEmpImage.Image = new Bitmap(empImgPath);
                        PicBoxEmpImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }


                var shift = employeeDetails.Shift;

                for(int i=0; i < this.CBoxShiftList.Items.Count; i++)
                {
                    var item = this.CBoxShiftList.Items[i] as ComboboxItem;
                    if (long.Parse(item.Value.ToString()) == employeeDetails.ShiftId)
                    {
                        this.CBoxShiftList.SelectedIndex = i;
                        break;
                    }
                }

                this.WorkShiftDays = shift.ShiftDays;
                DisplayWorkShiftDays();

                DisplayEmployeeGovtIds();
                DisplayEmployeeSalaryRate();
            }
        }

        private void DisplayEmployeeGovtIds()
        {
            this.ListViewEmpGovtIdCards.Items.Clear();

            if (EmployeeGovtIdCards != null)
            {
                this.BtnDeleteEmpIdCard.Visible = true;

                foreach (var govtId in EmployeeGovtIdCards)
                {
                    if (govtId.EmployeeGovtIdCard != null)
                    {
                        var row = new string[] {
                            govtId.EmployeeGovtIdCard.GovernmentAgency != null ? govtId.EmployeeGovtIdCard.GovernmentAgency.GovtAgency : "",
                            govtId.EmployeeGovtIdCard.EmployeeIdNumber,
                            govtId.EmployeeGovtIdCard.EmployeeContribution.ToString(),
                            govtId.EmployeeGovtIdCard.EmployerContribution.ToString(),
                            (govtId.IsExisting ? "EXISTING" : "NEW"),
                            govtId.EmployeeGovtIdCard.IsDeleted ? "To Delete" : ""
                        };

                        var listViewItem = new ListViewItem(row);
                        listViewItem.Tag = govtId;

                        this.ListViewEmpGovtIdCards.Items.Add(listViewItem);
                    }


                }
            }
        }


        private void DisplayEmployeeSalaryRate()
        {
            if (this.EmployeeSalary != null)
            {
                this.TbxSalaryRate.Text = this.EmployeeSalary.SalaryRate.ToString();
                this.TboxHalfMonthRate.Text = this.EmployeeSalary.HalfMonthRate.ToString();
                this.TbxDailySalaryRate.Text = this.EmployeeSalary.DailyRate.ToString();
            }
        }


        public string UploadEmployeeImage(string employeeNum)
        {
            try
            {
                if (openFileDialogBrowseEmpImg.CheckFileExists)
                {
                    string filename = Path.GetFileName(openFileDialogBrowseEmpImg.FileName);
                    string fileExt = Path.GetExtension(openFileDialogBrowseEmpImg.FileName);
                    if (filename != null && fileExt != null && File.Exists(openFileDialogBrowseEmpImg.FileName))
                    {
                        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        var directoryInfo = Directory.CreateDirectory(appPath + "\\EmployeeImgs\\");

                        string newFileName = $"{employeeNum}{fileExt}";

                        if (directoryInfo.Exists && File.Exists(appPath + "\\EmployeeImgs\\" + newFileName) == false)
                        {
                            System.IO.File.Copy(openFileDialogBrowseEmpImg.FileName, appPath + "\\EmployeeImgs\\" + newFileName, true);
                            MessageBox.Show("Image uploaded successfully.", "Upload image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return newFileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ ex.Message } { ex.StackTrace }", "File Already exits");
            }
            return "";
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            //if (this.RBtnUpdate.Checked == false && this.RBtnNew.Checked == false)
            //{
            //    MessageBox.Show("Kindly choose action.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}


            var selectedWorkShift = this.CBoxShiftList.SelectedItem as ComboboxItem;

            if (selectedWorkShift == null)
            {
                MessageBox.Show("Kindly choose emplooyee shift.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            long selectedWorkShiftId = long.Parse(selectedWorkShift.Value.ToString());


            Employee = new EmployeeModel
            {
                FirstName = this.TbxFirstName.Text,
                LastName = this.TbxLastName.Text,
                MiddleName = this.TbxMiddleInitial.Text,
                BirthDate = this.DTPicBirthDate.Value,
                MobileNumber = this.TbxMobileNumber.Text,
                DateHire = this.DTPicHireDate.Value,
                Address = this.TbxAddress.Text,
                BranchAssign = this.TbxBranchAssign.Text,
                EmailAddress = this.TbxEmail.Text,
                Position = this.TbxEmpPosition.Text,
                ShiftId = selectedWorkShiftId
            };

            if (this.IsNew == false)
            {
                Employee.EmployeeNumber = this.TbxEmployeeNumber.Text;
            }


            decimal salaryRate = 0;
            decimal halfMonthSalaryRate = 0;
            decimal dailySalaryRate = 0;

            if (decimal.TryParse(this.TbxSalaryRate.Text, out salaryRate) == false)
            {
                MessageBox.Show("Invalid salary rate", "Convert salary to decimal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(this.TboxHalfMonthRate.Text, out halfMonthSalaryRate) == false)
            {
                MessageBox.Show("Invalid half month rate", "Convert half month to decimal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(this.TbxDailySalaryRate.Text, out dailySalaryRate) == false)
            {
                MessageBox.Show("Invalid daily salary rate", "Convert daily salary to decimal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EmployeeSalary = new EmployeeSalaryRateModel
            {
                SalaryRate = salaryRate,
                HalfMonthRate = halfMonthSalaryRate,
                DailyRate = dailySalaryRate
            };

            OnEmployeeSaved(EventArgs.Empty);
        }

        public void MoveToNextTabSaveEmployeeDetails()
        {
            TabControlSaveEmployeeDetails.SelectedIndex = (TabControlSaveEmployeeDetails.SelectedIndex + 1 < TabControlSaveEmployeeDetails.TabCount) ?
                             TabControlSaveEmployeeDetails.SelectedIndex + 1 : TabControlSaveEmployeeDetails.SelectedIndex;
        }

        private void BtnActionAddNewEmployee_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.BtnCancelUpdateEmployee.Visible = true;
            this.BtnActionUpdateEmployeeDetails.Enabled = false;
            this.LblActionForEmployeeDetails.Text = "Add new employee";

            // if update, disable the update employee button, 
            //the user needs to click cancel in order to choose update employee
            MoveToNextTabSaveEmployeeDetails();
        }

        public void UpdateEmployeeDetails()
        {
            this.ClearForm();
            this.IsNew = false;
            this.GBoxSearchEmployee.Visible = true;
            this.BtnCancelUpdateEmployee.Visible = true;
            this.LblActionForEmployeeDetails.Text = "Update employee details";

            // if update, disable the add employee button, 
            //the user needs to click cancel in order to choose add new
            this.BtnActionAddNewEmployee.Enabled = false;
        }

        private void BtnActionUpdateEmployeeDetails_Click(object sender, EventArgs e)
        {
            UpdateEmployeeDetails();
        }

        private void BtnActionSearchEmployeeByEmployeeNumber_Click(object sender, EventArgs e)
        {
            this.EmployeeNumber = TbxEmployeeNumber.Text;
        }

        private void BtnCancelUpdateEmployee_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void BtnAddNewEmpGovtId_Click(object sender, EventArgs e)
        {
            string empGovtIdNumber = this.TboxEmpIdNumber.Text;
            if (this.CboxGovtAgencies.SelectedIndex >= 0 && string.IsNullOrEmpty(empGovtIdNumber) == false)
            {
                var selectedGovtAgency = this.CboxGovtAgencies.SelectedItem as ComboboxItem;

                if (selectedGovtAgency != null)
                {
                    int selectedGovtAgencyId = int.Parse(selectedGovtAgency.Value.ToString());

                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyId == selectedGovtAgencyId).FirstOrDefault();

                    var tmpEmployeeGovtIdCard = new EmployeeGovtIdCardTempModel
                    {
                        IsExisting = false,
                        IsNeedToUpdate = false,
                        EmployeeGovtIdCard = new EmployeeGovtIdCardModel
                        {
                            // we can't add the employee number on this code
                            // I assume that every transaction is add new employee, and we will wait for the employee number to generate
                            // I will add the employee number in EmployeeController.cs
                            EmployeeIdNumber = empGovtIdNumber,
                            GovtAgencyId = selectedGovtAgencyId,
                            EmployeeContribution = NumUpDwnEmployeeContribution.Value,
                            EmployerContribution = NumUpDwnEmployerContribution.Value,
                            GovernmentAgency = new GovernmentAgencyModel
                            {
                                // add temporary object to get the name or title of the govt. agency
                                GovtAgency = selectedGovtAgency.Text.ToString()
                            }
                        }
                    };

                    if (addedNewGovtId == null)
                    {
                        // if completely new id, just add it
                        EmployeeGovtIdCards.Add(tmpEmployeeGovtIdCard);
                    }
                    else if (addedNewGovtId != null)
                    {
                        if (addedNewGovtId.IsExisting)
                        {
                            // if existing in our database, we just need to update
                            // the employee govt. id number
                            addedNewGovtId.IsNeedToUpdate = true;
                            addedNewGovtId.EmployeeGovtIdCard.EmployeeIdNumber = empGovtIdNumber;
                        }
                        else
                        {
                            // if new id, we need to replace
                            EmployeeGovtIdCards.Remove(addedNewGovtId);
                            EmployeeGovtIdCards.Add(tmpEmployeeGovtIdCard);
                        }
                    }

                    DisplayEmployeeGovtIds();
                }
            }
        }

        private void BtnDeleteEmpIdCard_Click(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyId == selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyId).FirstOrDefault();

                    if (addedNewGovtId != null)
                    {
                        if (addedNewGovtId.IsExisting == false)
                        {
                            EmployeeGovtIdCards.Remove(addedNewGovtId);
                        }
                        else
                        {
                            addedNewGovtId.EmployeeGovtIdCard.IsDeleted = true;
                            addedNewGovtId.EmployeeGovtIdCard.DeletedAt = DateTime.Now;
                        }
                    }

                    this.DisplayEmployeeGovtIds();
                }
            }
        }


        private void ListViewEmpGovtIdCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyId == selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyId).FirstOrDefault();


                    if (addedNewGovtId.EmployeeGovtIdCard.IsDeleted == true)
                    {
                        this.BtnUndoToDelete.Visible = true;
                    }
                    else
                    {
                        this.BtnUndoToDelete.Visible = false;
                    }
                }
                else
                {
                    this.BtnUndoToDelete.Visible = false;
                }
            }
            else
            {
                this.BtnUndoToDelete.Visible = false;
            }
        }

        private void BtnUndoToDelete_Click(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyId == selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyId).FirstOrDefault();

                    addedNewGovtId.EmployeeGovtIdCard.IsDeleted = false;
                    addedNewGovtId.EmployeeGovtIdCard.DeletedAt = DateTime.MinValue;

                    this.BtnUndoToDelete.Visible = false;
                    this.DisplayEmployeeGovtIds();
                }
            }
        }

        private void CBoxShiftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBoxShiftList.SelectedIndex >= 0)
            {
                var selectedShift = this.CBoxShiftList.SelectedItem as ComboboxItem;

                if (selectedShift != null)
                {
                    SelectedShiftId = long.Parse(selectedShift.Value.ToString());
                    OnWorkShiftSelected(EventArgs.Empty);
                }

            }
        }


        public void DisplayWorkShiftDays()
        {
            this.LblShiftWorkingDays.Text = "";
            // Display shift days
            if (this.WorkShiftDays != null)
            {
                string workDays = string.Join(", ", this.WorkShiftDays.OrderBy(x => x.OrderNum).Select(x => x.DayName).ToArray());
                this.LblShiftWorkingDays.Text = workDays;
            }
        }

        private void BtnBrowseEmployeeImage_Click(object sender, EventArgs e)
        {
            openFileDialogBrowseEmpImg.InitialDirectory = "C://Desktop";
            openFileDialogBrowseEmpImg.Title = "Select image to be upload.";
            openFileDialogBrowseEmpImg.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialogBrowseEmpImg.FilterIndex = 1;

            try
            {
                if (openFileDialogBrowseEmpImg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialogBrowseEmpImg.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialogBrowseEmpImg.FileName);
                        //label1.Text = path;
                        PicBoxEmpImage.Image = new Bitmap(openFileDialogBrowseEmpImg.FileName);
                        PicBoxEmpImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload image.");
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }



        // ########################################################

        public void AddThisToAttendanceListView(AttendanceRecordType attendanceRecordType, DateTime day, AttendanceRecord record)
        {
            if (this.AttendanceToDisplay.ContainsKey(day))
            {
                var existingRecord = this.AttendanceToDisplay[day];
                int existingRecordTypeHierarchy = (int)existingRecord.recordType;
                int attendanceRecordTypeHierarchy = (int)attendanceRecordType;

                record.recordType = attendanceRecordType;
                record.WorkDate = day;

                if (attendanceRecordType == AttendanceRecordType.timeInOut)
                {
                    this.AttendanceToDisplay[day] = record;
                }
                else if (attendanceRecordTypeHierarchy > existingRecordTypeHierarchy)
                {
                    this.AttendanceToDisplay[day] = record;
                }
            }
            else
            {
                record.recordType = attendanceRecordType;
                record.WorkDate = day;

                this.AttendanceToDisplay.Add(day, record);
            }
        }



        public bool CheckIfDayOff(DateTime workDay)
        {
            if (WorkShiftDays == null)
                return true;

            string[] workdays = WorkShiftDays.Select(x => x.DayName).ToList().ToArray();
            return workdays.Contains(workDay.ToString("ddd", CultureInfo.InvariantCulture)) == false;
        }

        public bool CheckIfAbsentOnEmpShift(DateTime workDay)
        {
            var workforceSched = WorkforceSchedules != null ? WorkforceSchedules.Where(x => x.WorkDate == workDay).FirstOrDefault() : null;

            bool isAbsentOnWorkSched = workforceSched == null ? true : workDay > DateTime.Now && workforceSched.isDone == false;

            return CheckIfDayOff(workDay) == false && isAbsentOnWorkSched == true;
        }



        private void AddThisAttendanceRecordToListView (EmployeeAttendanceModel attendance, DateTime day)
        {

            if (attendance == null && CheckIfAbsentOnEmpShift(day))
            { // for absent
                var row = new string[]
                {
                    day.ToShortDateString(),
                    day.ToString("ddd", CultureInfo.InvariantCulture),
                    "", "", "AWOL"
                };

                AddThisToAttendanceListView(AttendanceRecordType.awol, day, new AttendanceRecord { record = row });

            }else if (attendance == null && CheckIfDayOff(day) == true)
            {
                var row = new string[]
                {
                    day.ToShortDateString(),
                    day.ToString("ddd", CultureInfo.InvariantCulture),
                    "OFF", "", ""
                };

                AddThisToAttendanceListView(AttendanceRecordType.off, day, new AttendanceRecord { record = row });
            }

            if (attendance != null)
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

                string whoDayTotalHrs = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalHrs); //attendance.FirstHalfHrs + attendance.SecondHalfHrs
                string late = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalLate); // attendance.FirstHalfLateMins + attendance.SecondHalfLateMins
                string underTime = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalUnderTime); //attendance.FirstHalfUnderTimeMins + attendance.SecondHalfUnderTimeMins
                string overTime = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.OverTimeMins);

                var row = new string[]
                {
                    attendance.WorkDate.ToShortDateString(),
                    day.ToString("ddd", CultureInfo.InvariantCulture),
                    attendance.Shift.Shift,
                    $"{attendance.Shift.StartTime.ToString("hh:mm tt")} to {attendance.Shift.EndTime.ToString("hh:mm tt")}",
                    firstTimeINandOUT,
                    secondTimeINandOUT,
                    whoDayTotalHrs,
                    late,
                    underTime,
                    overTime
                };


                AddThisToAttendanceListView(AttendanceRecordType.timeInOut, day, new AttendanceRecord { record = row });

            }
        }


        private void DisplayThisEmployeeLeaveRecInListInview(EmployeeLeaveModel leave, DateTime currentDate)
        {
            if (leave != null)
            {
                var row = new string[]
                {
                    currentDate.ToShortDateString(),
                    currentDate.ToString("ddd", CultureInfo.InvariantCulture),
                    $"LV: {leave.LeaveType.LeaveType}",
                    "",
                    leave.StartDate.ToShortDateString(),
                    leave.EndDate.ToShortDateString(),
                    leave.NumberOfDays.ToString() + "d",
                    "","","",""
                };


                AddThisToAttendanceListView(AttendanceRecordType.leave, currentDate, new AttendanceRecord { record = row });

            }
        }

        private void DisplayThisHolidayListInview(HolidayModel holiday, DateTime currentDate)
        {
            if (holiday != null)
            {
                var row = new string[]
                {
                    currentDate.ToShortDateString(),
                    currentDate.ToString("ddd", CultureInfo.InvariantCulture),
                    $"HD: {holiday.Holiday}",
                    "","", "", "","","","",""
                };


                AddThisToAttendanceListView(AttendanceRecordType.holiday, currentDate, new AttendanceRecord { record = row });
            }
        }


        public void DisplayAttendanceFromTemporaryLocation()
        {
            if (this.AttendanceToDisplay != null)
            {
                this.LViewAttendanceHistory.Items.Clear();

                foreach (var record in this.AttendanceToDisplay)
                {
                    var listViewItem = new ListViewItem(record.Value.record);

                    if (record.Value.recordType == AttendanceRecordType.timeInOut)
                    {
                        listViewItem.ForeColor = Color.FromArgb(50, 168, 82); // green
                    }else if (record.Value.recordType == AttendanceRecordType.awol)
                    {
                        listViewItem.ForeColor = Color.FromArgb(207, 54, 54); // red
                    }

                    this.LViewAttendanceHistory.Items.Add(listViewItem);
                }
            }
        }


        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void DisplayAttendanceRecord(DateTime startDate, DateTime endDate)
        {
            if (this.AttendanceHistory != null)
            {
                this.AttendanceToDisplay = new Dictionary<DateTime, AttendanceRecord>();

                foreach (DateTime day in EachDay(startDate, endDate))
                {
                    var dayAttendanceRec = this.AttendanceHistory.Where(x => x.WorkDate == day).FirstOrDefault();
                    var dayLeaveRec = this.EmployeeLeaveHistory.Where(x => x.StartDate <= day && x.EndDate >= day).FirstOrDefault();
                    var holidayRec = this.Holidays.Where(x => 
                                        x.DayNum == day.Day && 
                                        x.MonthAbbr == day.ToString("MMM", CultureInfo.InvariantCulture)).FirstOrDefault();

                    AddThisAttendanceRecordToListView(dayAttendanceRec, day);
                    DisplayThisEmployeeLeaveRecInListInview(dayLeaveRec, day);
                    DisplayThisHolidayListInview(holidayRec, day);
                }

                DisplayAttendanceFromTemporaryLocation();
                //this.LViewAttendanceHistory.Items[this.LViewAttendanceHistory.Items.Count - 1].EnsureVisible();
            }
        }


        private DateTime filterAttendanceStartDate;

        public DateTime FilterAttendanceStartDate
        {
            get { return filterAttendanceStartDate; }
            set { filterAttendanceStartDate = value; }
        }


        private DateTime filterAttendanceEndDate;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;

        public DateTime FilterAttendanceEndDate
        {
            get { return filterAttendanceEndDate; }
            set { filterAttendanceEndDate = value; }
        }


        // Event handler for saving leave type
        public event EventHandler FilterEmployeeAttendance;
        protected virtual void OnFilterEmployeeAttendance(EventArgs e)
        {
            FilterEmployeeAttendance?.Invoke(this, e);
        }


        private void BtnFilterAttendanceHistory_Click(object sender, EventArgs e)
        {
            FilterAttendanceStartDate = this.DPickerFilterAttendanceStartDate.Value;
            FilterAttendanceEndDate = this.DPickerFilterAttendanceEndDate.Value;

            if (string.IsNullOrEmpty(this.EmployeeNumber))
            {
                MessageBox.Show("Search employee first.", "Search employee details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OnFilterEmployeeAttendance(EventArgs.Empty);
        }

        private void TbxEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }

    public enum AttendanceRecordType
    {
        timeInOut = 5,
        off = 4,
        holiday = 3,
        leave = 2,
        awol = 1
    }

    public class AttendanceRecord
    {
        public DateTime WorkDate { get; set; }

        public string[] record { get; set; }

        public AttendanceRecordType recordType { get; set; }
    }
}
