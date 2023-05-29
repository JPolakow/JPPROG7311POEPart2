<%@ Page Title="View Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="JPPROG7311POEPart2.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="Styles/ViewProducts.css">
   <link rel="stylesheet" href="Styles/filter-row.css">

   <div class="form-container">
      <h1>View Products</h1>

      <h4></h4>

      <div class="filter-container">
         <div class="filter-row">
            <label for="txtTimeFilter">Filter by Time:</label>
            <asp:TextBox ID="txtTimeFilter" runat="server" CssClass="auto-style1" Width="350px" placeholder="Filter by Time"></asp:TextBox>
         </div>
         <div class="filter-row">
            <label for="txtUserFilter">Filter by User:</label>
            <asp:TextBox ID="txtUserFilter" runat="server" CssClass="auto-style1" Width="350px" placeholder="Filter by User"></asp:TextBox>
         </div>

         <div class="filter-row">
            <label for="txtUserFilter" class="invisible-label">hidden</label>
            <asp:Button ID="btnFilter" runat="server" Text="Apply Filters" OnClick="btnAddFilters_Click" CssClass="btn btn-primary" CausesValidation="true" Height="40px" Width="115px" />
         </div>
         <div class="filter-row">
            <label for="txtUserFilter" class="invisible-label">hidden</label>
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

