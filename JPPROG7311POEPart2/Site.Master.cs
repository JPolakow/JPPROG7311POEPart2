using JPPROG7311POEPart2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JPPROG7311POEPart2
{
   public partial class SiteMaster : MasterPage
   {
      public ToolBox _ToolBox = ToolBox.Instance;

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// page laod of the masterpage, thus its called whenver the nav menu or a child page is called/opened
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void Page_Load(object sender, EventArgs e)
      {
         //hides the nav elements depending on the user type
         if (_ToolBox._ActiveUserClass.UserType1 == "Farmer")
         {
            navHome.Visible = false;
            navNewFarmer.Visible = false;
            navViewProduct.Visible = false;
            navNewProduct.Visible = true;
         }
         else if (_ToolBox._ActiveUserClass.UserType1 == "Employee")
         {
            navHome.Visible = false;
            navNewFarmer.Visible = true;
            navViewProduct.Visible = true;
            navNewProduct.Visible = false;
         }
         else
         {
            navHome.Visible = false;
            navNewFarmer.Visible = false;
            navViewProduct.Visible = false;
            navNewProduct.Visible = false;
         }
      }
   }
}
//==========================================END OF FILE============================================