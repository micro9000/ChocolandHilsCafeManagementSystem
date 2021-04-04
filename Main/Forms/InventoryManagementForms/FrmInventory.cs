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
using Main.Controllers.InventoryControllers;
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
        private readonly IProductCategoryController _productCategoryController;
        private readonly IProductController _productController;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;

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
                            IIngredientInventoryController ingredientInventoryController,
                            IProductCategoryController productCategoryController,
                            IProductController productController,
                            IIngredientInventoryManager ingredientInventoryManager)
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
            _productCategoryController = productCategoryController;
            _productController = productController;
            _ingredientInventoryManager = ingredientInventoryManager;
        }



        private void ContextMenuIngredient_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "TSItemIngredientInventory")
            {
                DisplayIgredientInventoryControl();
            }
        }


        private void ContextMenuProducts_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;
            if (clickedItem != null && clickedItem.Name == "TSItemProductInventory")
            {
                DisplayProductInventoryControl();
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
            inventoryControlObj.IngredientInventoryDelete += HandleIngredientInventoryDelete;
            inventoryControlObj.FilterTransactionHistory += HandleFilterTransactionHistory;
            inventoryControlObj.IncreaseInventoryQtyValueSave += HandleSaveInventoryIncreaseQtyValue;
            inventoryControlObj.DecreaseInventoryQtyValueSave += HandleSaveInventoryDecreaseQtyValue;

            inventoryControlObj.IngredientCalculateProductsCanMake += HandleIngredientCalculateProductsCanMake;

            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(5);
            inventoryControlObj.InventoriesNearOnExpirationDate = _ingredientInventoryData.GetAllByExpirationDateRange(startDate, endDate);

            inventoryControlObj.FilterInventoryByExpirationDate += HandleFilterInventoryByExpirationDate;

            this.PanelMainContainer.Controls.Add(inventoryControlObj);
        }

        private void HandleIngredientCalculateProductsCanMake(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int ingredientId = inventoryControlObj.SelectedIngredientId;

            inventoryControlObj.ProductIngredientsToCalculate = _productIngredientData.GetAllByIngredient(ingredientId);
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
                DialogResult deleteIngredietns = MessageBox.Show("Do you want to delete ingredients under in this category?", "Delete confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                bool continueToDeleteCategory = false;
                bool continueToDeleteIngredientsUnderThisCategory = false;

                if (deleteIngredietns == DialogResult.Yes)
                {
                    // Delete all ingredients
                    DialogResult continueToDeleteIngredients = MessageBox.Show("You are going to delete ingredients under in this category, do you want to continue?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        if (continueToDeleteIngredientsUnderThisCategory)
                            _ingredientData.MassDeleteIngredientsByCategory(selectedCategoryId); // delete ingredients under in this category

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

            int year = DateTime.Now.Year;
            DateTime Jan1 = new DateTime(year, 1, 1);
            DateTime today = DateTime.Now;

            inventoryControlObj.InventoryTransactionHistory = _ingInventoryTransactionData.GetAllByIngredientAndDateRange(selectedIngredientId, Jan1, today);
            inventoryControlObj.DisplayInventoryTransactionHistory();
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

        private void HandleIngredientInventoryDelete(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int ingredientId = inventoryControlObj.SelectedIngredientId;
            long inventoryId = inventoryControlObj.SelectedInventoryId;
            string remarks = inventoryControlObj.Remarks;

            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                var deleteResults = _ingredientInventoryController.Delete(ingredientId, inventoryId, remarks);

                string resultMessages = "";
                foreach (var msg in deleteResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (deleteResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Delete inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    inventoryControlObj.SelectedIngredientInventories = _ingredientInventoryData.GetAllByIngredient(ingredientId);
                    inventoryControlObj.DisplayIngredientInventories();
                    inventoryControlObj.ResetNewUpdateIngredeintInventoryForm();

                    inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Delete inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void HandleFilterTransactionHistory(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedIngredientId = inventoryControlObj.SelectedIngredientId;
            DateTime startDate = inventoryControlObj.FilterTransactionStartDate;
            DateTime endDate = inventoryControlObj.FilterTransactionEndDate;

            inventoryControlObj.InventoryTransactionHistory = _ingInventoryTransactionData.GetAllByIngredientAndDateRange(selectedIngredientId, startDate, endDate);
            inventoryControlObj.DisplayInventoryTransactionHistory();
        }


        private void HandleSaveInventoryIncreaseQtyValue(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedIngredientId = inventoryControlObj.SelectedIngredientId;
            long selectedInventoryId = inventoryControlObj.SelectedInventoryId;
            decimal increaseQtyValue = inventoryControlObj.IncreaseInventoryQtyValue;
            string remarks = inventoryControlObj.Remarks;

            DialogResult res = MessageBox.Show("Continue to increase the quantity value?", "Increase inventory confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var increaseResults = _ingredientInventoryController.IncreaseQtyValue(selectedIngredientId, selectedInventoryId, increaseQtyValue, remarks);

                string resultMessages = "";
                foreach (var msg in increaseResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (increaseResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Increase inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    inventoryControlObj.SelectedIngredientInventories = _ingredientInventoryData.GetAllByIngredient(selectedIngredientId);
                    inventoryControlObj.DisplayIngredientInventories();
                    inventoryControlObj.ResetNewUpdateIngredeintInventoryForm();

                    inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientInDGV();


                    int year = DateTime.Now.Year;
                    DateTime Jan1 = new DateTime(year, 1, 1);
                    DateTime today = DateTime.Now;

                    inventoryControlObj.InventoryTransactionHistory = _ingInventoryTransactionData.GetAllByIngredientAndDateRange(selectedIngredientId, Jan1, today);
                    inventoryControlObj.DisplayInventoryTransactionHistory();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Increase inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void HandleSaveInventoryDecreaseQtyValue(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            int selectedIngredientId = inventoryControlObj.SelectedIngredientId;
            long selectedInventoryId = inventoryControlObj.SelectedInventoryId;
            decimal decreaseQtyValue = inventoryControlObj.DecreaseInventoryQtyValue;
            string remarks = inventoryControlObj.Remarks;

            DialogResult res = MessageBox.Show("Continue to decrease the quantity value?", "Decrease inventory confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var decreaseResults = _ingredientInventoryController.DecreaseQtyValue(selectedIngredientId, selectedInventoryId, decreaseQtyValue, remarks);

                string resultMessages = "";
                foreach (var msg in decreaseResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (decreaseResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Decrease inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    inventoryControlObj.SelectedIngredientInventories = _ingredientInventoryData.GetAllByIngredient(selectedIngredientId);
                    inventoryControlObj.DisplayIngredientInventories();
                    inventoryControlObj.ResetNewUpdateIngredeintInventoryForm();

                    inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                    inventoryControlObj.DisplayIngredientInDGV();


                    int year = DateTime.Now.Year;
                    DateTime Jan1 = new DateTime(year, 1, 1);
                    DateTime today = DateTime.Now;

                    inventoryControlObj.InventoryTransactionHistory = _ingInventoryTransactionData.GetAllByIngredientAndDateRange(selectedIngredientId, Jan1, today);
                    inventoryControlObj.DisplayInventoryTransactionHistory();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Decrease inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        private void HandleFilterInventoryByExpirationDate(object sender, EventArgs e)
        {
            IngredientInventoryControl inventoryControlObj = (IngredientInventoryControl)sender;
            DateTime startDate = inventoryControlObj.FilterInventoryByExpirationStartDate;
            DateTime endDate = inventoryControlObj.FilterInventoryByExpirationEndDate;

            inventoryControlObj.InventoriesNearOnExpirationDate = _ingredientInventoryData.GetAllByExpirationDateRange(startDate, endDate);
            inventoryControlObj.DisplayIngredientInventoriesNearOnExpirationDate();
        }


        // ##########################################
        // Product inventory event handlers:
        // ##########################################


        public void DisplayProductInventoryControl()
        {
            this.PanelMainContainer.Controls.Clear();
            var inventoryControlObj = new ProductInventoryControl(_uOMConverter, _ingredientInventoryManager);
            inventoryControlObj.Location = new Point(this.ClientSize.Width / 2 - inventoryControlObj.Size.Width / 2, this.ClientSize.Height / 2 - inventoryControlObj.Size.Height / 2);
            inventoryControlObj.Anchor = AnchorStyles.None;

            inventoryControlObj.ProductCategories = _productCategoryData.GetAllNotDeleted();
            inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
            inventoryControlObj.ExistingProducts = _productData.GetAllNotDeleted();

            inventoryControlObj.ProductCategorySave += HandleProductCategorySaved;
            inventoryControlObj.SelectCategoryToDelete += HandleSelectedProductCategoryToDelete;
            inventoryControlObj.ProductSave += HandleProductSaved;
            inventoryControlObj.GetProductExistingIngredients += HandleGetProductExistingIngredients;
            inventoryControlObj.GetProductDetailsAndDispalyInForm += HandleGetProductDetailsAndDispalyInForm;
            inventoryControlObj.RefreshProductList += HandleRefreshProductList;

            this.PanelMainContainer.Controls.Add(inventoryControlObj);
        }

        private void HandleProductCategorySaved(object sender, EventArgs e)
        {
            ProductInventoryControl inventoryControlObj = (ProductInventoryControl)sender;

            var newCategory = inventoryControlObj.ProductCategoryToAddUpdate;
            bool isNew = inventoryControlObj.IsNewProductCategory;

            if (newCategory != null)
            {
                var saveResults = _productCategoryController.Save(newCategory, isNew);
                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save category details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    inventoryControlObj.ResetProductCategoryForm();
                    inventoryControlObj.ProductCategories = _productCategoryData.GetAllNotDeleted();
                    inventoryControlObj.DisplayProductCategoriesInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save category details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }


        private void HandleSelectedProductCategoryToDelete(object sender, EventArgs e)
        {
            ProductInventoryControl inventoryControlObj = (ProductInventoryControl)sender;
            int selectedCategoryId = inventoryControlObj.SelectedCategoryId;

            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                DialogResult deleteIngredietns = MessageBox.Show("Do you want to delete products under in this category?", "Delete confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                bool continueToDeleteCategory = false;
                bool continueToDeleteIngredientsUnderThisCategory = false;

                if (deleteIngredietns == DialogResult.Yes)
                {
                    // Delete all ingredients
                    DialogResult continueToDeleteIngredients = MessageBox.Show("You are going to delete products under in this category, do you want to continue?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    continueToDeleteCategory = (continueToDeleteIngredients == DialogResult.Yes);
                    continueToDeleteIngredientsUnderThisCategory = (continueToDeleteIngredients == DialogResult.Yes);

                }
                else if (deleteIngredietns == DialogResult.No)
                {
                    // Reassign to other category

                    FrmReassignProductsToOtherCategory frmReassignCategory = new FrmReassignProductsToOtherCategory(_productCategoryData, _productData, selectedCategoryId);

                    frmReassignCategory.ShowDialog();

                    continueToDeleteCategory = (frmReassignCategory.IsDone == true && frmReassignCategory.IsCancelled == false);
                }
                else
                {
                    continueToDeleteCategory = false;
                }

                if (continueToDeleteCategory)
                {
                    var deleteResults = _productCategoryController.Delete(selectedCategoryId);

                    string resultMessages = "";
                    foreach (var msg in deleteResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (deleteResults.IsSuccess)
                    {
                        
                        if (continueToDeleteIngredientsUnderThisCategory)
                            _productData.MassDeleteProductsByCategory(selectedCategoryId);// Delete all producta

                        MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inventoryControlObj.ResetProductCategoryForm();
                        inventoryControlObj.ProductCategories = _productCategoryData.GetAllNotDeleted();
                        inventoryControlObj.DisplayProductCategoriesInDGV();

                        inventoryControlObj.ExistingProducts = _productData.GetAllNotDeleted();
                        inventoryControlObj.DisplayExistingProductsInDGV(inventoryControlObj.ExistingProducts);

                        //inventoryControlObj.ResetIngredientForm();
                        //inventoryControlObj.Ingredients = _ingredientData.GetAllNotDeleted();
                        //inventoryControlObj.DisplayIngredientInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

        }


        private void HandleProductSaved(object sender, EventArgs e)
        {
            ProductInventoryControl inventoryControlObj = (ProductInventoryControl)sender;

            var productDetails = inventoryControlObj.ProductToAddUpdate;
            bool isNew = inventoryControlObj.IsNewProduct;
            var ingredients = inventoryControlObj.ProductSelectedIngredients;

            if (productDetails != null)
            {
                var saveResults = _productController.Save(ingredients, productDetails, isNew);
                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save product details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    inventoryControlObj.ClearProductDetailsForm();

                    inventoryControlObj.ExistingProducts = _productData.GetAllNotDeleted();
                    inventoryControlObj.DisplayExistingProductsInDGV(inventoryControlObj.ExistingProducts);
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save product details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        private void HandleGetProductExistingIngredients(object sender, EventArgs e)
        {
            ProductInventoryControl inventoryControlObj = (ProductInventoryControl)sender;
            int productId = inventoryControlObj.SelectedExistingProductId;
            inventoryControlObj.ExistingProductIngredients = _productIngredientData.GetAllByProduct(productId);
            inventoryControlObj.DisplayProductsExistingIngredientsInDGV();
        }

        private void HandleGetProductDetailsAndDispalyInForm(object sender, EventArgs e)
        {
            ProductInventoryControl inventoryControlObj = (ProductInventoryControl)sender;
            int productId = inventoryControlObj.SelectedExistingProductId;

            inventoryControlObj.ProductToAddUpdate = _productData.Get(productId);
            inventoryControlObj.ProductSelectedIngredients = _productIngredientData.GetAllByProduct(productId);
            inventoryControlObj.DisplayProductDetailsAndIngredientsInFormAndDGV();
        }

        private void HandleRefreshProductList(object sender, EventArgs e)
        {
            ProductInventoryControl inventoryControlObj = (ProductInventoryControl)sender;
            inventoryControlObj.ExistingProducts = _productData.GetAllNotDeleted();
            inventoryControlObj.DisplayExistingProductsInDGV(inventoryControlObj.ExistingProducts);
        }
    }
}
