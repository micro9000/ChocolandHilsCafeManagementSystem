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
    public partial class EmployeePersonalInfoUserControl : UserControl
    {
        public EmployeePersonalInfoUserControl()
        {
            InitializeComponent();
        }

        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        private List<EmployeeGovtIdCardModel> employeeGovtIdCards = new List<EmployeeGovtIdCardModel>();

        public List<EmployeeGovtIdCardModel> EmployeeGovtIdCards
        {
            get { return employeeGovtIdCards; }
            set { employeeGovtIdCards = value; }
        }

        private void EmployeePersonalInfoUserControl_Load(object sender, EventArgs e)
        {
            this.PnlDetailsContainer.Location = new Point(this.ClientSize.Width / 2 - this.PnlDetailsContainer.Size.Width / 2, this.ClientSize.Height / 2 - this.PnlDetailsContainer.Size.Height / 2);
            this.PnlDetailsContainer.Anchor = AnchorStyles.None;


            EmployeeGovtIdCards.Add(new EmployeeGovtIdCardModel {
                EmployeeNumber = "20200001",
                EmployeeIdNumber = "0000000000"
            });

            EmployeeGovtIdCards.Add(new EmployeeGovtIdCardModel
            {
                EmployeeNumber = "20200001",
                EmployeeIdNumber = "0000000000"
            });

            foreach(var card in EmployeeGovtIdCards)
            {
                var row = new string[] { card.EmployeeNumber, card.EmployeeIdNumber };
                var listViewItem = new ListViewItem(row);
                listViewItem.Tag = card;

                ListViewEmpGovtIdCards.Items.Add(listViewItem);
            }

        }
    }
}
