using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Data.InventoryManagement.Contracts;
using Main.Controllers.InventoryControllers.ControllerInterface;
using Main.Forms.InventoryManagementForms.Controls;

namespace Main.Forms.InventoryManagementForms
{
    public partial class FrmInventory : Form
    {
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientCategoryData _ingredientCategoryData;
        private readonly IIngInventoryTransactionData _ingInventoryTransactionData;
        private readonly IProductCategoryData _productCategoryData;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly IComboSetProductData _comboSetProductData;
        private readonly IIngredientCategoryController _ingredientCategoryController;

        public FrmInventory(IIngredientData ingredientData,
                            IIngredientCategoryData ingredientCategoryData,
                            IIngInventoryTransactionData ingInventoryTransactionData,
                            IProductCategoryData productCategoryData,
                            IProductData productData,
                            IProductIngredientData productIngredientData,
                            IComboSetData comboSetData,
                            IComboSetProductData comboSetProductData,
                            IIngredientCategoryController ingredientCategoryController)
        {
            InitializeComponent();
            _ingredientData = ingredientData;
            _ingredientCategoryData = ingredientCategoryData;
            _ingInventoryTransactionData = ingInventoryTransactionData;
            _productCategoryData = productCategoryData;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _comboSetProductData = comboSetProductData;
            _ingredientCategoryController = ingredientCategoryController;
        }

        private void ContextMenuIngredient_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TSItemIngredientCategories")
            {
                DisplayGeneratePayrollControl();
            }
        }

        #region Inventory Categories

        public void DisplayGeneratePayrollControl()
        {
            this.PanelMainContainer.Controls.Clear();
            var categoryControlObj = new IngredientCategoryControl();
            categoryControlObj.Location = new Point(this.ClientSize.Width / 2 - categoryControlObj.Size.Width / 2, this.ClientSize.Height / 2 - categoryControlObj.Size.Height / 2);
            categoryControlObj.Anchor = AnchorStyles.None;

            categoryControlObj.IngredientCategories = _ingredientCategoryData.GetAllNotDeleted();

            categoryControlObj.IngredientCategorySaved += HandleIngredientCategorySaved;
            categoryControlObj.SelectCategoryToUpdate += HandleSelectedCategoryToUpdate;
            categoryControlObj.SelectCategoryToDelete += HandleSelectedCategoryToDelete;

            this.PanelMainContainer.Controls.Add(categoryControlObj);
        }

        private void HandleIngredientCategorySaved(object sender, EventArgs e)
        {
            IngredientCategoryControl categoryControlObj = (IngredientCategoryControl)sender;

            var newCategory = categoryControlObj.CategoryToAddUpdate;
            bool isNew = categoryControlObj.IsSaveNew;

            if (newCategory != null)
            {
                var saveResults = _ingredientCategoryController.Save(newCategory, isNew);
                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }


                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save category details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    categoryControlObj.ResetForm();
                    categoryControlObj.IngredientCategories = _ingredientCategoryData.GetAllNotDeleted();
                    categoryControlObj.DisplayIngredientsInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save category details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void HandleSelectedCategoryToUpdate(object sender, EventArgs e)
        {
            IngredientCategoryControl categoryControlObj = (IngredientCategoryControl)sender;
            int selectedCategoryId = categoryControlObj.SelectedCategoryId;

            categoryControlObj.CategoryToAddUpdate = _ingredientCategoryData.Get(selectedCategoryId);
            categoryControlObj.DisplaySelectedCategoryDetails();

        }

        private void HandleSelectedCategoryToDelete(object sender, EventArgs e)
        {
            IngredientCategoryControl categoryControlObj = (IngredientCategoryControl)sender;
            int selectedCategoryId = categoryControlObj.SelectedCategoryId;

            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                var deleteResults = _ingredientCategoryController.Delete(selectedCategoryId);

                string resultMessages = "";
                foreach (var msg in deleteResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (deleteResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    categoryControlObj.ResetForm();
                    categoryControlObj.IngredientCategories = _ingredientCategoryData.GetAllNotDeleted();
                    categoryControlObj.DisplayIngredientsInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        #endregion
    }
}
