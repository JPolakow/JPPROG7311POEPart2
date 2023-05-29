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
   public partial class NewFarmer : System.Web.UI.Page
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
         if (_ToolBox._ActiveUserClass.UserType1 != "Employee" & _ToolBox.ForceLogin)
            Page.Response.Redirect("~/");
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// add farmer button
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void btnAddProduct_Click(object sender, EventArgs e)
      {
         AddFarmer();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to handel the add farmer logic
      /// </summary>
      private void AddFarmer()
      {
         try
         {
            //if the email exists prevent adding of the account
            if (_ToolBox._DBHandler.DoesEmailExist(txtEmail.Text))
            {
               popupFailure.Visible = true;
               popupFailure.InnerText = "That email already exists, please enter a new one";
               return;
            }

            //create LoginCredential entry using hash and salt
            LoginCredential newUserLogin = _ToolBox._PasswordHandler.CreateNewPassword(txtPassword.Text);
            int loginAdded = _ToolBox._DBHandler.AddFarmerLogin(newUserLogin);

            //if login added then create object and send to be added
            if (loginAdded != -1)
            {
               Farmer newFarmer = new Farmer();

               newFarmer.FName = txtFName.Text;
               newFarmer.SName = txtSurname.Text;
               newFarmer.Email = txtEmail.Text;
               newFarmer.PhoneNumber = txtPhoneNumber.Text;
               newFarmer.Location = txtLocation.Text;
               newFarmer.LoginID = loginAdded;

               _ToolBox._DBHandler.AddFarmer(newFarmer);
               popupFailure.Visible = false;
               popupSuccess.InnerText = "Success! Account added successfully.";
               popupSuccess.Visible = true;
            }
            else
            {
               popupFailure.Visible = true;
               popupFailure.InnerText = "Oh no! Something has gone wrong, please try again or contact an administrator";
            }
         }
         catch (Exception ex)
         {
            popupFailure.Visible = true;
            popupFailure.InnerText = "Oh no! Something has gone wrong, please try again or contact an administrator";
         }
      }
   }
}
//==========================================END OF FILE============================================