//st10081881
//15/05/2023

using Antlr.Runtime.Tree;
using JPPROG7311POEPart2.EntityFramework;
using JPPROG7311POEPart2.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Xml.Linq;

namespace JPPROG7311POEPart2.Classes
{
   public class DBHandler
   {
      //ensure only one instance is created, thus keeping the data
      private static readonly DBHandler instance = new DBHandler();
      public static DBHandler Instance => instance;

      /// <summary>
      /// connection string
      /// </summary>
      private string ConnectionString = ConfigurationManager.ConnectionStrings["ConnStringSQL"].ConnectionString;

      /// <summary>
      ///     SQL Command
      /// </summary>
      private SqlCommand command;

      /// <summary>
      ///     SQL Connection
      /// </summary>
      private SqlConnection connection;

      /// <summary>
      ///     Object For Using Entity Framework;
      /// </summary>
      private ST10081881PROG7311POETask2Entities1 entity;



      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// connection and command set up here
      /// </summary>
      private void ConnectDB()
      {
         this.connection = new SqlConnection();
         this.command = new SqlCommand();

         // this.Connection.ConnectionString =
         //     "data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=|DataDirectory|\\ST10081881PROG7311POETask2.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

         this.connection.ConnectionString = ConnectionString;

         this.command.Connection = this.connection;
         this.command.CommandType = CommandType.Text;
      }



      //-------------------------------------------------------------------------------------------
      /// <summary>
      ///     Method Returns a Customer Object Based on the Customer ID
      ///     - Primary Key in the Table
      /// </summary>
      /// <param name="customerID"></param>
      /// <returns></returns>
      public LoginCredential GetUserLogin(string UserEmail)
      {
         var login = new LoginCredential();
         var employee = new Employee();
         var farmer = new Farmer();

         try
         {
            using (this.entity = new ST10081881PROG7311POETask2Entities1())
            {
               //check if employee
               Employee EmployeeCheck = entity.Employees.FirstOrDefault(e => e.Email.Equals(UserEmail, StringComparison.OrdinalIgnoreCase));

               //if employee save logincredentials
               if (EmployeeCheck != null)
                  login = this.entity.LoginCredentials.Find(EmployeeCheck.LoginID);

               //check if farmer
               Farmer FarmerCheck = entity.Farmers.FirstOrDefault(f => f.Email.Equals(UserEmail, StringComparison.OrdinalIgnoreCase));

               //if farmer save logincredentials
               if (FarmerCheck != null)
                  login = this.entity.LoginCredentials.Find(FarmerCheck.LoginID);

               return login;
            }
         }
         catch (Exception e)
         {
            return login;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// get user id and type
      /// </summary>
      /// <param name="UserEmail"></param>
      /// <returns></returns>
      public ActiveUserClass GetUserInfo(string UserEmail)
      {
         var activeuser = new ActiveUserClass();
         var employee = new Employee();
         var farmer = new Farmer();

         try
         {
            using (this.entity = new ST10081881PROG7311POETask2Entities1())
            {
               //check if emplyee
               Employee EmployeeCheck = entity.Employees.FirstOrDefault(e => e.Email.Equals(UserEmail, StringComparison.OrdinalIgnoreCase));

               if (EmployeeCheck != null)
               {
                  activeuser.UserID1 = EmployeeCheck.EmplyeeId;
                  activeuser.UserType1 = "Employee";
               }

               //check if farmer
               Farmer FarmerCheck = entity.Farmers.FirstOrDefault(f => f.Email.Equals(UserEmail, StringComparison.OrdinalIgnoreCase));

               if (FarmerCheck != null)
               {
                  activeuser.UserID1 = FarmerCheck.FarmerId;
                  activeuser.UserType1 = "Farmer";
               }

               return activeuser;
            }
         }
         catch (Exception e)
         {
            return activeuser;
         }

      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// tried to find an email, true = it exists, false = does not exist 
      /// </summary>
      /// <param name="UserEmail"></param>
      /// <returns></returns>
      public bool DoesEmailExist(string UserEmail)
      {
         try
         {
            using (this.entity = new ST10081881PROG7311POETask2Entities1())
            {
               Employee EmployeeCheck = entity.Employees.FirstOrDefault(e => e.Email.Equals(UserEmail, StringComparison.OrdinalIgnoreCase));

               if (EmployeeCheck != null)
                  return true;

               Farmer FarmerCheck = entity.Farmers.FirstOrDefault(f => f.Email.Equals(UserEmail, StringComparison.OrdinalIgnoreCase));

               if (FarmerCheck != null)
                  return true;

               return false;
            }
         }
         catch (Exception e)
         {
            return true;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to add new login details for a farmer, return the location of new login, -1 means unsucsessful
      /// </summary>
      /// <param name="newFarmerLogin"></param>
      /// <returns></returns>
      public int AddFarmerLogin(LoginCredential newFarmerLogin)
      {
         try
         {
            using (var context = new ST10081881PROG7311POETask2Entities1())
            {
               var newLogin = new LoginCredential
               {
                  Hash = newFarmerLogin.Hash,
                  Salt = newFarmerLogin.Salt
               };

               context.LoginCredentials.Add(newLogin);
               context.SaveChanges();

               var newPersonId = newLogin.LoginId;
               return newPersonId;
            }
         }
         catch (Exception ex)
         {
            return -1;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to add new farmer, returns bool
      /// </summary>
      /// <param name="newFarmer"></param>
      /// <returns></returns>
      public bool AddFarmer(Farmer newFarmer)
      {
         try
         {
            using (var context = new ST10081881PROG7311POETask2Entities1())
            {
               context.Farmers.Add(newFarmer);
               context.SaveChanges();
               return true;
            }
         }
         catch (Exception ex)
         {
            return false;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to add new farmer, returns int = new entry id
      /// </summary>
      /// <param name="newFarmer"></param>
      /// <returns></returns>
      public int AddProduct(Product newProduct)
      {
         try
         {
            using (var context = new ST10081881PROG7311POETask2Entities1())
            {
               context.Products.Add(newProduct);
               context.SaveChanges();

               var newEntryId = newProduct.ProductID;
               return newEntryId;
            }
         }
         catch (Exception ex)
         {
            return -1;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// adds farmer and product ids to FarmerProductList
      /// </summary>
      /// <param name="farmerProductList"></param>
      /// <returns></returns>
      public bool AddFarmerProduct(FarmerProductList farmerProductList)
      {
         try
         {
            using (var context = new ST10081881PROG7311POETask2Entities1())
            {
               context.FarmerProductLists.Add(farmerProductList);
               context.SaveChanges();

               return true;
            }
         }
         catch (Exception ex)
         {
            return false;
         }
      }



      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method gets all records form the product table and joins them with the correct farmers details
      /// </summary>
      /// <returns></returns>
      public DataTable ViewAllProducts()
      {
         this.ConnectDB();

         try
         {
            var sqlCmd = new SqlCommand
            {
               Connection = this.connection,
               CommandType = CommandType.Text,
               CommandText = "SELECT P.ProductName, P.ProductDescription, p.DateAdded, p.QauntityAdded, (f.FName + ' ' + f.SName) \"Full Name\", f.PhoneNumber, f.\"Location\" FROM Farmer F, Product P, FarmerProductList FP WHERE (FP.FarmerID = F.FarmerId) AND (FP.ProductID = P.ProductID)"
            };

            var adapter = new SqlDataAdapter(sqlCmd);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
         }
         catch (Exception e)
         {
            return null;
         }

         finally
         {
            this.connection.Close();
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to build the sql query string
      /// </summary>
      /// <param name="startDate"></param>
      /// <param name="EndDate"></param>
      /// <param name="farmerName"></param>
      /// <param name="productName"></param>
      /// <param name="Farmer"></param>
      /// <param name="Product"></param>
      /// <param name="Start"></param>
      /// <param name="End"></param>
      /// <returns></returns>
      public DataTable StringBuilder(bool startDate, bool EndDate, bool farmerName, bool productName, string Farmer, string Product, string Start, string End)
      {
         string Query = "SELECT P.ProductName, P.ProductDescription, p.DateAdded, p.QauntityAdded, (f.FName + ' ' + f.SName) \"Full Name\", f.PhoneNumber, f.\"Location\" " +
            "FROM Farmer F, Product P, FarmerProductList FP " +
            "WHERE (FP.FarmerID = F.FarmerId) AND (FP.ProductID = P.ProductID) ";

         if (farmerName)
            Query = Query + " AND (F.FName LIKE '%" + Farmer + "%' OR F.SName LIKE '%" + Farmer + "%')";

         if (productName)
            Query = Query + " AND (P.ProductName LIKE '%" + Product + "%')";

         if (startDate && EndDate)
            Query = Query + " AND P.DateAdded >= '" + Start + "' AND P.DateAdded <='" + End + "'";

         return FilterProducts(Query);

      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method filtyers the tables to just show records where the farmers names contain a string
      /// </summary>
      /// <param name="Name"></param>
      /// <returns></returns>
      public DataTable FilterProducts(string query)
      {
         this.ConnectDB();

         try
         {
            var sqlCmd = new SqlCommand
            {
               Connection = this.connection,
               CommandType = CommandType.Text,
               CommandText = query
            };

            var adapter = new SqlDataAdapter(sqlCmd);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
         }
         catch (Exception e)
         {
            return null;
         }

         finally
         {
            this.connection.Close();
         }
      }



   }
}
//==========================================END OF FILE============================================