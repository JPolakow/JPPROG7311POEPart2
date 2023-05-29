//st10081881
//15/05/2023

using JPPROG7311POEPart2.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace JPPROG7311POEPart2
{
   public partial class ViewProducts : System.Web.UI.Page
   {
      public ToolBox _ToolBox = ToolBox.Instance;

      //stores the filtering options
      bool startDate, EndDate, farmerName, productName = false;

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

         LoadUI(_ToolBox._DBHandler.ViewAllProducts());
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// button
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void btnAddFilters_Click(object sender, EventArgs e)
      {
         LoadFilters();
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// button to reset filters
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void btnClearFilters_Click(object sender, EventArgs e)
      {
         DataTable dataTable = _ToolBox._DBHandler.ViewAllProducts();
         LoadUI(dataTable);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to check which filters are active then send data to db handler
      /// </summary>
      private void LoadFilters()
      {
         //setting vars to enable filtering
         if (txtStartDate.Text != string.Empty)
            startDate = true;
         if (txtEndDate.Text != string.Empty)
            EndDate = true;
         if (txtFarmerFilter.Text != string.Empty)
            farmerName = true;
         if (txtProductFilter.Text != string.Empty)
            productName = true;

         string FormattedStartDate = "";
         string FormattedEndDate = "";
         DateTime PlainStartDate;
         DateTime PlainEndDate;

         //parse date pickers to right format then back to string
         if (startDate && EndDate)
         {
            if (DateTime.TryParseExact(txtStartDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out PlainStartDate))
               FormattedStartDate = PlainStartDate.ToString("yyyy/MM/dd");
            else
               startDate = false;

            if (DateTime.TryParseExact(txtEndDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out PlainEndDate))
               FormattedEndDate = PlainEndDate.ToString("yyyy/MM/dd");
            else
               EndDate = false;
         }

         DataTable dataTable = _ToolBox._DBHandler.StringBuilder(startDate, EndDate, farmerName, productName,
            txtFarmerFilter.Text, txtProductFilter.Text,
            FormattedStartDate, FormattedEndDate);

         LoadUI(dataTable);
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to load a DataTable into the grid view
      /// </summary>
      /// <param name="dataTable"></param>
      private void LoadUI(DataTable dataTable)
      {
         try
         {
            var myTable = (GridView)FindControl("myGridView");

            myGridView.DataSource = dataTable;
            myGridView.DataBind();
         }
         catch (Exception ex)
         {
            int a = 0;
         }
      }

   }
}
//==========================================END OF FILE============================================