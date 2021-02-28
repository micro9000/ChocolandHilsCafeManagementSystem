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
            this.employeeNumber = "";
            this.LblActionForEmployeeDetails.Text = "Add new employee";
            this.GBoxSearchEmployee.Visible = false;

            this.BtnCancelUpdateEmployee.Visible = true;

            this.IsNew = true;
            this.ClearForm();
            MoveToNextTabSaveEmployeeDetails();
        }

        private void BtnActionUpdateEmployeeDetails_Click(object sender, EventArgs e)
        {
            this.LblActionForEmployeeDetails.Text = "Update employee details";
            this.GBoxSearchEmployee.Visible = true;
            this.BtnCancelUpdateEmployee.Visible= true;
            this.ClearForm();
            this.IsNew = false;
        }

        private void BtnActionSearchEmployeeByEmployeeNumber_Click(object sender, EventArgs e)
        {
            this.EmployeeNumber = TbxEmployeeNumber.Text;
        }

        private void BtnCancelUpdateEmployee_Click(object sender, EventArgs e)
        {
            this.GBoxSearchEmployee.Visible = false;
            this.BtnCancelUpdateEmployee.Visible = false;
            this.ClearForm();
            this.IsNew = true;
            TabControlSaveEmployeeDetails.SelectedIndex = 0;
        }

        private void BtnMoveToNextTab_Click(object sender, EventArgs e)
        {
            MoveToNextTabSaveEmployeeDetails();
        }

        private void DisplayAddedNewGovtIds()
        {
            this.ListViewEmpGovtIdCards.Items.Clear();

            if (EmployeeGovtIds != null)
            {
                foreach (var govtId in EmployeeGovtIdCards)
                {
                    var row = new string[] { 
                        govtId.EmployeeGovtIdCard.GovernmentAgency.GovtAgency, 
                        govtId.EmployeeGovtIdCard.EmployeeIdNumber,
                        (govtId.IsExisting ? "EXISTING" : "NEW")
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = govtId;

                    this.ListViewEmpGovtIdCards.Items.Add(listViewItem);
                }
            }
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

                    DisplayAddedNewGovtIds();
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
