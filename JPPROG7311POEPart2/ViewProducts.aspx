<%@ Page Title="View Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="JPPROG7311POEPart2.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="Styles/ViewProducts.css">
   <link rel="stylesheet" href="Styles/filter-row.css">

   <div class="form-container">
      <h1>View Products</h1>

      <h4></h4>

      <div class="filter-container">
         <div class="filter-row">
            <label for="txtStartDate">Start Date:</label>
            <asp:TextBox ID="txtStartDate" TextMode="Date" runat="server" CssClass="auto-style1" Width="250px" placeholder="Start Date"></asp:TextBox>
         </div>
         <div class="filter-row">
            <label for="txtEndDate">End Date:</label>
            <asp:TextBox ID="txtEndDate" TextMode="Date" runat="server" CssClass="auto-style1" Width="250px" placeholder="End Date"></asp:TextBox>
         </div>
         <div class="filter-row">
            <label for="txtFarmerFilter">Filter by Farmer:</label>
            <asp:TextBox ID="txtFarmerFilter" runat="server" CssClass="auto-style1" Width="250px" placeholder="Filter by Farmer"></asp:TextBox>
         </div>
         <div class="filter-row">
            <label for="txtProductFilter">Filter by Product:</label>
            <asp:TextBox ID="txtProductFilter" runat="server" CssClass="auto-style1" Width="250px" placeholder="Filter by product"></asp:TextBox>
         </div>

         <div class="filter-row">
            <label for="btnFilter" class="invisible-label">hidden</label>
            <asp:Button ID="btnFilter" runat="server" Text="Apply Filters" OnClick="btnAddFilters_Click" CssClass="btn btn-primary" CausesValidation="true" Height="40px" Width="115px" />
         </div>
         <div class="filter-row">
            <label for="btnClear" class="invisible-label">hidden</label>
            <asp:Button ID="btnClear" runat="server" Text="Clear Filters" OnClick="btnClearFilters_Click" CssClass="btn btn-primary" CausesValidation="true" Height="40px" Width="115px" />
         </div>
      </div>

      <h3></h3>

      <asp:GridView ID="myGridView" runat="server" AutoGenerateColumns="true" CssClass="custom-gridview">
      </asp:GridView>

      <style>
         .invisible-label {
            color: transparent;
         }

         .custom-gridview {
            border-collapse: collapse;
            width: 100%;
         }

            .custom-gridview th, .custom-gridview td {
               padding: 8px;
               border: 1px solid #ddd;
            }

            .custom-gridview th {
               background-color: #f2f2f2;
            }

            .custom-gridview tr:nth-child(even) {
               background-color: #f9f9f9;
            }

            .custom-gridview tr:hover {
               background-color: #eaeaea;
            }

            .custom-gridview caption {
               font-weight: bold;
               margin-bottom: 10px;
            }
      </style>
   </div>
</asp:Content>

