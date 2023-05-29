//st10081881
//14/05/2023

using JPPROG7311POEPart2.Classes;
using JPPROG7311POEPart2.Objects;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JPPROG7311POEPart2
{
   public partial class LoginPage : System.Web.UI.Page
   {
      public ToolBox _ToolBox = ToolBox.Instance;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// page load
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void Page_Load(object sender, EventArgs e)
      {

      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// button
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void btnLogin_Click(object sender, EventArgs e)
      {
         LogUserIn();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// Method to handel the login logic
      /// </summary>
      private void LogUserIn()
      {
         try
         {
            //used to shuttle the users deatisl around
            UserLoginShuttle userLogin = new UserLoginShuttle();
            userLogin.UserEmail1 = txtEmail.Text;
            userLogin.UserPlainPword1 = txtPassword.Text;

            //get their has and salt is email exist
            EntityFramework.LoginCredential login = _ToolBox._DBHandler.GetUserLogin(userLogin.UserEmail1);

            //if no email was found there will be no hash
            if (login.Hash == null)
            {
               ErrorMessage();
               return;
            }

            //add hash and salt to userLogin
            userLogin.UserHashedPword1 = login.Hash;
            userLogin.UserSalt1 = login.Salt;

            //if password correct
            if (_ToolBox._PasswordHandler.CheckOldPassword(userLogin))
            {

               _ToolBox._ActiveUserClass = _ToolBox._DBHandler.GetUserInfo(userLogin.UserEmail1);
               Page.Response.Redirect("~/");
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
      /// shows error message to clean up code
      /// </summary>
      private void ErrorMessage() 
      {
         popupFailure.InnerText = "Incorrect email or password";
         popupFailure.Visible = true;
      }

   }
}
//==========================================END OF FILE============================================

/*TO DO
 * filters
 * home page
 */