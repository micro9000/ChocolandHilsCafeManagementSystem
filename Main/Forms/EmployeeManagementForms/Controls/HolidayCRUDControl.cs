﻿using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class HolidayCRUDControl : UserControl
    {
        public HolidayCRUDControl()
        {
            InitializeComponent();
        }

        private void HolidayCRUDControl_Load(object sender, EventArgs e)
        {
            SetDGVHolidaysFontAndColors();
        }

        private List<HolidayModel> holidays;

        public List<HolidayModel> Holidays
        {
            get { return holidays; }
            set { holidays = value; }
        }

        private long holidayIdToDelete;

        public long HolidayIdToDelete
        {
            get { return holidayIdToDelete; }
            set { holidayIdToDelete = value; }
        }

        private HolidayModel newHolidayToAdd;

        public HolidayModel NewHolidayToAdd
        {
            get { return newHolidayToAdd; }
            set { newHolidayToAdd = value; }
        }


        // Event handler for saving
        public event EventHandler HolidaySaved;
        protected virtual void OnHolidaySaved(EventArgs e)
        {
            HolidaySaved?.Invoke(this, e);
        }

        // Event handler for saving
        public event EventHandler HolidayDelete;
        protected virtual void OnHolidayDelete(EventArgs e)
        {
            HolidayDelete?.Invoke(this, e);
        }

        private void SetDGVHolidaysFontAndColors()
        {
            this.DGVHolidays.BackgroundColor = Color.White;
            this.DGVHolidays.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVHolidays.RowHeadersVisible = false;
            this.DGVHolidays.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVHolidays.AllowUserToResizeRows = false;
            this.DGVHolidays.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVHolidays.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVHolidays.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVHolidays.MultiSelect = false;

            this.DGVHolidays.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVHolidays.ColumnHeadersHeight = 30;
        }

        public void ResetForm()
        {
            this.TbxHoliday.Text = "";
            this.CBoxHolidayDayNum.SelectedIndex = -1;
            this.CboxHolidayMonthAbbv.SelectedIndex = -1;
        }


        public void DisplayHolidays()
        {
            this.DGVHolidays.Rows.Clear();
            if (this.Holidays != null)
            {
                this.DGVHolidays.ColumnCount = 4;

                this.DGVHolidays.Columns[0].Name = "HolidayId";
                this.DGVHolidays.Columns[0].Visible = false;

                this.DGVHolidays.Columns[1].Name = "Holiday";
                this.DGVHolidays.Columns[1].HeaderText = "Holiday";

                this.DGVHolidays.Columns[2].Name = "Month";
                this.DGVHolidays.Columns[2].HeaderText = "Month";

                this.DGVHolidays.Columns[3].Name = "Day";
                this.DGVHolidays.Columns[3].HeaderText = "Day";


                //// Update button
                //DataGridViewImageColumn btnUpdateLeaveTypeImg = new DataGridViewImageColumn();
                ////btnUpdateLeaveTypeImg.Name = "";
                //btnUpdateLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnUpdateLeaveTypeImg.Image = Image.FromFile("./Resources/edit-24.png");
                //this.DGVHolidays.Columns.Add(btnUpdateLeaveTypeImg);

                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVHolidays.Columns.Add(btnDeleteLeaveTypeImg);


                foreach (var holiday in this.Holidays)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVHolidays);

                    row.Cells[0].Value = holiday.Id;
                    row.Cells[1].Value = holiday.Holiday;
                    row.Cells[2].Value = holiday.MonthAbbr;
                    row.Cells[3].Value = holiday.DayNum.ToString();

                    DGVHolidays.Rows.Add(row);
                }
            }
        }

        private void BtnSaveHoliday_Click(object sender, EventArgs e)
        {
            if (this.CboxHolidayMonthAbbv.SelectedIndex > -1 && this.CBoxHolidayDayNum.SelectedIndex > -1)
            {
                string selectedMonthAbbr = this.CboxHolidayMonthAbbv.GetItemText(this.CboxHolidayMonthAbbv.SelectedItem);
                 string selectedDayNum = this.CBoxHolidayDayNum.GetItemText(this.CBoxHolidayDayNum.SelectedItem);

                 this.NewHolidayToAdd = new HolidayModel { 
                     Holiday = this.TbxHoliday.Text,
                     MonthAbbr = selectedMonthAbbr,
                     DayNum = int.Parse(selectedDayNum)
                 };

                 OnHolidaySaved(EventArgs.Empty);
            }

            
        }

        private void DGVHolidays_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVHolidays.CurrentRow != null)
                {
                    string holidayId = DGVHolidays.CurrentRow.Cells[0].Value.ToString();
                    HolidayIdToDelete = long.Parse(holidayId);
                    OnHolidayDelete(EventArgs.Empty);
                }
            }
        }
    }
}
