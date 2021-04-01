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
using Shared.Helpers;

namespace Main.Forms.InventoryManagementForms
{
    public partial class FrmInventory : Form
    {
        private readonly UOMConverter _uOMConverter;
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientCategoryData _ingredientCategoryData;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private readonly IIngInventoryTransactionData _ingInventoryTransactionData;
        private readonly IProductCategoryData _productCategoryData;
        private readonly IProductData _productData;
        private readonly IProductIngredientData _productIngredientData;
        private readonly IComboSetProductData _comboSetProductData;
        private readonly IIngredientCategoryController _ingredientCategoryController;
        private readonly IIngredientController _ingredientController;
        private readonly IIngredientInventoryController _ingredientInventoryController;

        public FrmInventory(UOMConverter uOMConverter,
                            IIngredientData ingredientData,
                            IIngredientCategoryData ingredientCategoryData,
                            IIngredientInventoryData ingredientInventoryData,
                            IIngInventoryTransactionData ingInventoryTransactionData,
                            IProductCategoryData productCategoryData,
                            IProductData productData,
                            IProductIngredientData productIngredientData,
                            IComboSetData comboSetData,
                            IComboSetProductData comboSetProductData,
                            IIngredientCategoryController ingredientCategoryController,
                            IIngredientController ingredientController,
                            IIngredientInventoryController ingredientInventoryController)
        {
            InitializeComponent();
            _uOMConverter = uOMConverter;
            _ingredientData = ingredientData;
            _ingredientCategoryData = ingredientCategoryData;
            _ingredientInventoryData = ingredientInventoryData;
            _ingInventoryTransactionData = ingInventoryTransactionData;
            _productCategoryData = productCategoryData;
            _productData = productData;
            _productIngredientData = productIngredientData;
            _comboSetProductData = comboSetProductData;
            _ingredientCategoryController = ingredientCategoryController;
            _ingredientController = ingredientController;
            _ingredientInventoryController = ingredientInventoryController;
        }

        private void ContextMenuIngredient_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TSItemIngredientInventory")
            {
                DisplayIgredientInventoryControl();
            }
        }

        public void DisplayIgredientInventoryControl()
        {
            this.PanelMainContainer.Controls.Clear();
            var inventoryControlObj = new IngredientInventoryControl(_uOMConverter);
            inventoryControlObj.Location = new Point(this.ClientSize.Width / 2 - inventoryControlObj.Size.Width / 2, this.ClientSize.Height / 2 - inventoryControlObj.Size.Height / 2);
            inventoryControlObj.Anchor = AnchorStyles.None;

            inventoryControlObj.IngredientCategories = _ingredientCategoryData.GetAllNotDeleted();
            inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();

            inventoryControlObj.IngredientCategorySaved += HandleIngredientCategorySaved;
            inventoryControlObj.SelectCategoryToUpdate += HandleSelectedCategoryToUpdate;
            inventoryControlObj.SelectCategoryToDelete += HandleSelectedCategoryToDelete;

            inventoryControlObj.IngredientSaved += HandleSaveIngredient;
            inventoryControlObj.IngredientDelete += HandleSelectIngredientToDelete;

            inventoryControlObj.IngredientGetInventories += HandleIngredientGetInventories;
            inventoryControlObj.IngredientInventorySave += HandleIngredientInventorySave;

            this.PanelMainContainer.Controls.Add(inventoryControlObj);
        }

        private void HandleIngredientCategorySaved(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;

            var newCategory = inventoryControlObj.CategoryToAddUpdate;
            bool isNew = inventoryControlObj.IsSaveNew;

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
                    inventoryControlObj.ResetForm();
                    inventoryControlObj.IngredientCategories = _ingredientCategoryData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientCategoriesInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save category details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void HandleSelectedCategoryToUpdate(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedCategoryId = inventoryControlObj.SelectedCategoryId;

            inventoryControlObj.CategoryToAddUpdate = _ingredientCategoryData.Get(selectedCategoryId);
            inventoryControlObj.DisplaySelectedCategoryDetails();
        }

        private void HandleSelectedCategoryToDelete(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedCategoryId = inventoryControlObj.SelectedCategoryId;

            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                DialogResult deleteIngredietns = MessageBox.Show("Do you want to delete ingredients belongs to this category?", "Delete confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                bool continueToDeleteCategory = false;
                bool continueToDeleteIngredientsUnderThisCategory = false;

                if (deleteIngredietns == DialogResult.Yes)
                {
                    // Delete all ingredients
                    DialogResult continueToDeleteIngredients = MessageBox.Show("You are going to delete ingredients under this category, do you want to continue?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    continueToDeleteCategory = (continueToDeleteIngredients == DialogResult.Yes);
                    continueToDeleteIngredientsUnderThisCategory = (continueToDeleteIngredients == DialogResult.Yes);

                }
                else if (deleteIngredietns == DialogResult.No)
                {
                    // Reassign to other category

                    FrmReassignIngredientsToOtherCategory frmReassignCategory = new FrmReassignIngredientsToOtherCategory(_ingredientData, _ingredientCategoryData, selectedCategoryId);

                    frmReassignCategory.ShowDialog();

                    continueToDeleteCategory = (frmReassignCategory.IsDone == true && frmReassignCategory.IsCancelled == false);
                }
                else
                {
                    continueToDeleteCategory = false;
                }

                if (continueToDeleteCategory)
                {
                    var deleteResults = _ingredientCategoryController.Delete(selectedCategoryId);

                    string resultMessages = "";
                    foreach (var msg in deleteResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (deleteResults.IsSuccess)
                    {
                        _ingredientData.MassDeleteIngredientsByCategory(selectedCategoryId);

                        MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inventoryControlObj.ResetForm();
                        inventoryControlObj.IngredientCategories = _ingredientCategoryData.GetAllNotDeleted();
                        inventoryControlObj.DisplayIngredientCategoriesInDGV();

                        inventoryControlObj.ResetIngredientForm();
                        inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                        inventoryControlObj.DisplayIngredientInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

        }


        private void HandleSaveIngredient(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            var ingredient = inventoryControlObj.IngredientToAddUpdate;
            var isNew = inventoryControlObj.IsNewIngredient;

            if (ingredient != null)
            {
                var saveResults = _ingredientController.Save(ingredient, isNew);
                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save ingredient details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    inventoryControlObj.ResetIngredientForm();
                    inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save ingredient details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }


        private void HandleSelectIngredientToDelete(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedIngredientId = inventoryControlObj.SelectedIngredientId;

            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                var deleteResults = _ingredientController.Delete(selectedIngredientId);

                string resultMessages = "";
                foreach (var msg in deleteResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (deleteResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Delete ingredients", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    inventoryControlObj.ResetIngredientForm();
                    inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void HandleIngredientGetInventories(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedIngredientId = inventoryControlObj.SelectedIngredientId;
            inventoryControlObj.SelectedIngredientInventories = _ingredientInventoryData.GetAllByIngredient(selectedIngredientId);
        }

        private void HandleIngredientInventorySave(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            var ingredientInventory = inventoryControlObj.IngredientInventoryToAddUpdate;
            bool isNew = inventoryControlObj.IsNewIngredientInventory;
            string remarks = inventoryControlObj.Remarks;

            if (ingredientInventory != null)
            {
                var saveResults = _ingredientInventoryController.Save(ingredientInventory, isNew, remarks);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int selectedIngredientId = inventoryControlObj.SelectedIngredientId;
                    inventoryControlObj.SelectedIngredientInventories = _ingredientInventoryData.GetAllByIngredient(selectedIngredientId);
                    inventoryControlObj.DisplayIngredientInventories();
                    inventoryControlObj.ResetNewUpdateIngredeintInventoryForm();

                    inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientInDGV();
                    //inventoryControlObj.SelectedIngredientInventory = _ingredientInventoryData
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
