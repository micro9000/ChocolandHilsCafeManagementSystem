using EmployeeManagementUserControls.CustomModels;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementUserControls
{
    public partial class AddUpdateEmployeeUserControl : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private List<GovernmentAgencyModel> govtAgencies;

        public List<GovernmentAgencyModel> GovtAgencies
        {
            get { return govtAgencies; }
            set { govtAgencies = value; }
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



        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }



        public event EventHandler EmployeeSaved;
        protected virtual void OnEmployeeSaved (EventArgs e)
        {
            EmployeeSaved?.Invoke(this, e);
        }

        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set {
                employeeNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(EmployeeNumber));
                }
            }
        }

        public AddUpdateEmployeeUserControl()
        {
            InitializeComponent();
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

        private void AddUpdateEmployeeUserControl_Load(object sender, EventArgs e)
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


        }

        public void ClearForm()
        {
            this.employeeNumber = "";
            this.IsNew = true;


            this.LblActionForEmployeeDetails.Text = "Add new employee";
            this.TbxFirstName.Text = "";
            this.TbxLastName.Text = "";
            this.DTPicBirthDate.Value = DateTime.Now;
            this.TbxMobileNumber.Text = "";
            this.DTPicHireDate.Value = DateTime.Now;
            this.TbxAddress.Text = "";
            this.TbxBranchAssign.Text = "";
            this.TbxEmail.Text = "";
            this.TbxEmployeeNumber.Text = "";
            this.CboxGovtAgencies.SelectedIndex = -1;

            this.TboxEmpIdNumber.Text = "";


            this.GBoxSearchEmployee.Visible = false;
            this.BtnCancelUpdateEmployee.Visible = false;

            TabControlSaveEmployeeDetails.SelectedIndex = 0;

            this.BtnActionAddNewEmployee.Enabled = true;
            this.BtnActionUpdateEmployeeDetails.Enabled = true;
            this.BtnCancelUpdateEmployee.Visible = true;
            this.ListViewEmpGovtIdCards.Items.Clear();

            this.EmployeeGovtIdCards = new List<EmployeeGovtIdCardTempModel>();
            
        }


        public void DisplayEmployeeDetails(EmployeeModel employeeDetails)
        {
            if (employeeDetails != null)
            {
                this.TbxFirstName.Text = employeeDetails.FirstName;
                this.TbxLastName.Text = employeeDetails.LastName;
                this.DTPicBirthDate.Value = employeeDetails.BirthDate;
                this.TbxMobileNumber.Text = employeeDetails.MobileNumber;
                this.DTPicHireDate.Value = employeeDetails.DateHire;
                this.TbxAddress.Text = employeeDetails.Address;
                this.TbxBranchAssign.Text = employeeDetails.BranchAssign;
                this.TbxEmail.Text = employeeDetails.EmailAddress;

                DisplayEmployeeGovtIds();
            }
        }

        private void DisplayEmployeeGovtIds()
        {
            this.ListViewEmpGovtIdCards.Items.Clear();

            if (EmployeeGovtIdCards != null)
            {
                foreach (var govtId in EmployeeGovtIdCards)
                {
                    if (govtId.EmployeeGovtIdCard != null)
                    {
                        var row = new string[] {
                            govtId.EmployeeGovtIdCard.GovernmentAgency != null ? govtId.EmployeeGovtIdCard.GovernmentAgency.GovtAgency : "",
                            govtId.EmployeeGovtIdCard.EmployeeIdNumber,
                            (govtId.IsExisting ? "EXISTING" : "NEW")
                        };

                        var listViewItem = new ListViewItem(row);
                        listViewItem.Tag = govtId;

                        this.ListViewEmpGovtIdCards.Items.Add(listViewItem);
                    }

                    
                }
            }
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            //if (this.RBtnUpdate.Checked == false && this.RBtnNew.Checked == false)
            //{
            //    MessageBox.Show("Kindly choose action.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            Employee = new EmployeeModel
            {
                FirstName = this.TbxFirstName.Text,
                LastName = this.TbxLastName.Text,
                BirthDate = this.DTPicBirthDate.Value,
                MobileNumber = this.TbxMobileNumber.Text,
                DateHire = this.DTPicHireDate.Value,
                Address = this.TbxAddress.Text,
                BranchAssign = this.TbxBranchAssign.Text,
                EmailAddress = this.TbxEmail.Text
            };

            if (this.IsNew == false)
            {
                Employee.EmployeeNumber = this.TbxEmployeeNumber.Text;
            }

            OnEmployeeSaved(EventArgs.Empty);
        }

        public void MoveToNextTabSaveEmployeeDetails()
        {
            TabControlSaveEmployeeDetails.SelectedIndex = (TabControlSaveEmployeeDetails.SelectedIndex + 1 < TabControlSaveEmployeeDetails.TabCount) ?
                             TabControlSaveEmployeeDetails.SelectedIndex + 1 : TabControlSaveEmployeeDetails.SelectedIndex;
        }

        private void BtnActionAddNewEmployee_Click(object sender, EventArgs e)
        {
            this.LblActionForEmployeeDetails.Text = "Add new employee";
            this.ClearForm();
            this.BtnCancelUpdateEmployee.Visible = true;
            this.BtnActionUpdateEmployeeDetails.Enabled = false;

            // if update, disable the update employee button, 
            //the user needs to click cancel in order to choose update employee
            MoveToNextTabSaveEmployeeDetails();
        }

        private void BtnActionUpdateEmployeeDetails_Click(object sender, EventArgs e)
        {
            this.LblActionForEmployeeDetails.Text = "Update employee details";
            this.ClearForm();
            this.IsNew = false;
            this.GBoxSearchEmployee.Visible = true;
            this.BtnCancelUpdateEmployee.Visible = true;

            // if update, disable the add employee button, 
            //the user needs to click cancel in order to choose add new
            this.BtnActionAddNewEmployee.Enabled = false;
        }

        private void BtnActionSearchEmployeeByEmployeeNumber_Click(object sender, EventArgs e)
        {
            this.EmployeeNumber = TbxEmployeeNumber.Text;
        }

        private void BtnCancelUpdateEmployee_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void BtnMoveToNextTab_Click(object sender, EventArgs e)
        {
            MoveToNextTabSaveEmployeeDetails();
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

        private void ListViewEmpGovtIdCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    MessageBox.Show($"{selectedEmpGovtId.EmployeeGovtIdCard.EmployeeIdNumber} {selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyId}");
                }
            }
            
        }

        private void TabControlSaveEmployeeDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //private void TbxEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.Handled = true;
        //        this.EmployeeNumber = TbxEmployeeNumber.Text;
        //    }
        //}

        //private void RBtnUpdate_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton rb = sender as RadioButton;

        //    if (rb != null && rb.Checked)
        //    {
        //        this.IsNew = false;
        //        TbxEmployeeNumber.Enabled = true;
        //    }
        //}

        //private void RBtnNew_CheckedChanged(object sender, EventArgs e)
        //{
        //    RadioButton rb = sender as RadioButton;

        //    if (rb != null && rb.Checked)
        //    {
        //        this.IsNew = true;
        //        TbxEmployeeNumber.Enabled = false;
        //    }
        //}
    }


}
