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
    public partial class DisplayEmployeeListUserControl : UserControl
    {
        public DisplayEmployeeListUserControl()
        {
            InitializeComponent();
        }

        private void DisplayEmployeeListUserControl_Load(object sender, EventArgs e)
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();

            employees.Add(new EmployeeModel {
                FirstName = "Raniel",
                LastName = "Garcia",
                Address = "Balibago primero",
                MobileNumber = "09979022241",
                EmailAddress = "Raniel.Garcia@onsemi.com",
                DateHire = DateTime.Now,
                BranchAssign = "OSPI Tarlac"
            });

            employees.Add(new EmployeeModel
            {
                FirstName = "Raniel",
                LastName = "Garcia",
                Address = "Balibago primero",
                MobileNumber = "09979022241",
                EmailAddress = "Raniel.Garcia@onsemi.com",
                DateHire = DateTime.Now,
                BranchAssign = "OSPI Tarlac"
            });

            employees.Add(new EmployeeModel
            {
                FirstName = "Raniel",
                LastName = "Garcia",
                Address = "Balibago primero",
                MobileNumber = "09979022241",
                EmailAddress = "Raniel.Garcia@onsemi.com",
                DateHire = DateTime.Now,
                BranchAssign = "OSPI Tarlac"
            });

            foreach (var employee in employees)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGVEmployees);

                row.Cells[0].Value = employee.Id;
                row.Cells[1].Value = employee.FirstName;
                row.Cells[2].Value = employee.LastName;
                row.Cells[3].Value = employee.Address;
                row.Cells[4].Value = employee.BirthDate.ToShortDateString();
                row.Cells[5].Value = employee.MobileNumber;
                DGVEmployees.Rows.Add(row);
            }
        }
    }
}
