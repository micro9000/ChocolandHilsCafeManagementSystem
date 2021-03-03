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
    public partial class GovtAgenciesCRUDUserControl : UserControl
    {
        public GovtAgenciesCRUDUserControl()
        {
            InitializeComponent();
        }

        private List<GovernmentAgencyModel> governmentAgencies;

        public List<GovernmentAgencyModel> GovernmentAgencies
        {
            get { return governmentAgencies; }
            set { governmentAgencies = value; }
        }


        private GovernmentAgencyModel governmentAgencyToAddUpdate;

        public GovernmentAgencyModel GovernmentAgencyToAddUpdate
        {
            get { return governmentAgencyToAddUpdate; }
            set { governmentAgencyToAddUpdate = value; }
        }

        public bool IsSaveNew { get; set; } = true;

        // Event handler for saving leave type
        public event EventHandler GovernmentAgencySaved;
        protected virtual void OnGovernmentAgencySaved(EventArgs e)
        {
            GovernmentAgencySaved?.Invoke(this, e);
        }


        // Use on clicking update button
        public event PropertyChangedEventHandler PropertySelectedGovernmentAgencyIdToUpdateChanged;

        private string selectedGovernmentAgencyIdToUpdate;

        public string SelectedGovernmentAgencyIdToUpdate
        {
            get { return selectedGovernmentAgencyIdToUpdate;; }
            set {
                selectedGovernmentAgencyIdToUpdate = value;

                if (PropertySelectedGovernmentAgencyIdToUpdateChanged != null)
                {
                    PropertySelectedGovernmentAgencyIdToUpdateChanged(this, new PropertyChangedEventArgs(SelectedGovernmentAgencyIdToUpdate));
                }
            }
        }

        // Use on clicking delete button
        public event PropertyChangedEventHandler PropertySelectedGovernmentAgencyIdToDeleteChanged;

        private string selectedGovernmentAgencyIdToDelete;

        public string SelectedGovernmentAgencyIdToDelete
        {
            get { return selectedGovernmentAgencyIdToDelete; ; }
            set
            {
                selectedGovernmentAgencyIdToDelete = value;

                if (PropertySelectedGovernmentAgencyIdToDeleteChanged != null)
                {
                    PropertySelectedGovernmentAgencyIdToDeleteChanged(this, new PropertyChangedEventArgs(SelectedGovernmentAgencyIdToDelete));
                }
            }
        }

        private void GovtAgenciesCRUDUserControl_Load(object sender, EventArgs e)
        {
            SetDGVGovernmentAgenciesFontAndColors();
        }


        private void SetDGVGovernmentAgenciesFontAndColors()
        {
            this.DGVGovernmentAgencies.BackgroundColor = Color.White;
            this.DGVGovernmentAgencies.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGovernmentAgencies.RowHeadersVisible = false;
            this.DGVGovernmentAgencies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVGovernmentAgencies.AllowUserToResizeRows = false;
            this.DGVGovernmentAgencies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVGovernmentAgencies.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVGovernmentAgencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVGovernmentAgencies.MultiSelect = false;

            this.DGVGovernmentAgencies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVGovernmentAgencies.ColumnHeadersHeight = 30;
        }


        public void ResetForm()
        {
            this.TbxAgency.Text = "";
            this.SelectedGovernmentAgencyIdToUpdate = "";
            this.SelectedGovernmentAgencyIdToDelete = "";
            this.BtnCancelUpdate.Visible = false;
            this.GBoxGovtAgencyForm.Text = "Add new";
            this.IsSaveNew = true;
            this.GovernmentAgencyToAddUpdate = null;
        }

        public void DisplaySelectedGovernmentAgency()
        {
            if (this.GovernmentAgencyToAddUpdate != null)
            {
                this.TbxAgency.Text = this.GovernmentAgencyToAddUpdate.GovtAgency;
            }
        }

        private void BtnSaveAgency_Click(object sender, EventArgs e)
        {

        }
    }
}
