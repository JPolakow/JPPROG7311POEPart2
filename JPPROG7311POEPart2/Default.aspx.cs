//st10081881
//15/05/2023

using JPPROG7311POEPart2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JPPROG7311POEPart2
{
   public partial class _Default : Page
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
         if (_ToolBox._ActiveUserClass.UserID1 == -1 & _ToolBox.ForceLogin)
            Page.Response.Redirect("~/LoginPage");
      }
   }
}
//==========================================END OF FILE============================================