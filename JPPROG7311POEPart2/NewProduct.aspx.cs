//st10081881
//15/05/2023

using JPPROG7311POEPart2.Classes;
using JPPROG7311POEPart2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JPPROG7311POEPart2
{
   public partial class NewProduct : System.Web.UI.Page
   {
      public ToolBox _ToolBox = ToolBox.Instance;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// page load, checks if user is logged in
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void Page_Load(object sender, EventArgs e)
      {
         //if not logged redirect to loginpage
         if (_ToolBox._ActiveUserClass.UserID1 == -1 & _ToolBox.ForceLogin)
            Page.Response.Redirect("~/LoginPage");
         //if not correct usre type redirect to home page
         if (_ToolBox._ActiveUserClass.UserType1 != "Farmer" & _ToolBox.ForceLogin)
            Page.Response.Redirect("~/");
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// button
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void btnAddProduct_Click(object sender, EventArgs e)
      {
         AddProduct();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// handel the add product logic
      /// </summary>
      private void AddProduct()
      {
         try
         {
            Product newProduct = new Product();
            DateTime dateAndTime = DateTime.Now;
            DateTime date = dateAndTime.Date;

            newProduct.ProductName = txtProductName.Text;
            newProduct.ProductDescription = txtDescription.Text;
            newProduct.QauntityAdded = txtQauntity.Text;
            newProduct.DateAdded = date.ToString();

            int ProductAdded = _ToolBox._DBHandler.AddProduct(newProduct);

            //if product added
            if (ProductAdded != -1)
            {
               //create link between farmer and product
               FarmerProductList farmerProductList = new FarmerProductList();
               farmerProductList.ProductID = ProductAdded;
               farmerProductList.FarmerID = _ToolBox._ActiveUserClass.UserID1;

               _ToolBox._DBHandler.AddFarmerProduct(farmerProductList);

               
               popupFailure.Visible = false;
               popupSuccess.InnerText = "Success! Product added successfully.";
               popupSuccess.Visible = true;
            }
            else
            {
               ErrorMessage();
            }

         }
         catch (Exception ex)
         {
            ErrorMessage();
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to display error message, as its called many times
      /// </summary>
      private void ErrorMessage()
      {
         popupFailure.Visible = true;
         popupFailure.InnerText = "Oh no! Something has gone wrong, please try again or contact an administrator";
      }
   }
}
//==========================================END OF FILE============================================