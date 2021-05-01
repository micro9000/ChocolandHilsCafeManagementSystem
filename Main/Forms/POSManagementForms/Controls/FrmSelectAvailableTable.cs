﻿using EntitiesShared;
using Main.Controllers.POSControllers.ControllerInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmSelectAvailableTable : Form
    {
        private readonly IPOSReadController _pOSReadController;

        public FrmSelectAvailableTable(IPOSReadController pOSReadController)
        {
            InitializeComponent();
            _pOSReadController = pOSReadController;
        }

        public int SelectedTableNumber { get; set; }

        public long SelectedTableCurrentTransactionId { get; set; }

        private void FrmSelectAvailableTable_Load(object sender, EventArgs e)
        {
            var tableStatus = _pOSReadController.GetTableStatus();

            this.FlowLayoutTables.Controls.Clear();
            foreach (var table in tableStatus)
            {
                var tableItemControl = new RestaurantTableItemControl()
                {
                    TransactionId = table.CurrentTransactionId,
                    IsOccupied = table.Status == StaticData.TableStatus.Occupied,
                    TableNumber = table.TableNumber,
                    TableTitle = table.TableTitle
                };

                tableItemControl.ClickThisTable += HandleClickTableItem;

                this.FlowLayoutTables.Controls.Add(tableItemControl);
            }
        }

        private void HandleClickTableItem(object sender, EventArgs e)
        {
            RestaurantTableItemControl tableItemControl = (RestaurantTableItemControl)sender;
            if (tableItemControl.IsOccupied)
            {
                MessageBox.Show("This table is already occupied", "Select table", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.SelectedTableNumber = tableItemControl.TableNumber;
            this.SelectedTableCurrentTransactionId = tableItemControl.TransactionId;

            this.Close();
        }
    }
}
