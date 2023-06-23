<%@ Page Title="New Product" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProduct.aspx.cs" Inherits="JPPROG7311POEPart2.NewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="Styles/NewProduct.css">

   <div class="form-container">
      <h2>Add New Product</h2>

      <h4></h4>

      <div class="form-group">
         <label for="productName">Product Name:</label>
         <asp:TextBox ID="txtProductName" runat="server" CssClass="auto-style1" Width="350px" placeholder="Product Name"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ControlToValidate="txtProductName" ErrorMessage="Product Name is required" CssClass="validation-error" Display="Dynamic" />
      </div>

      <div class="form-group">
         <label for="description">Description:</label>
         <asp:TextBox ID="txtDescription" runat="server" CssClass="auto-style1" TextMode="MultiLine" Width="350px" placeholder="Description"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description is required" CssClass="validation-error" Display="Dynamic" />
      </div>

      <div class="form-group">
         <label for="quantity">Quantity:</label>
         <asp:TextBox ID="txtQauntity" runat="server" type="number" CssClass="auto-style1" Width="350px" placeholder="Quantity"></asp:TextBox>
         <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQauntity" ErrorMessage="Quantity is required" CssClass="validation-error" Display="Dynamic" />
         <asp:RegularExpressionValidator ID="revQuantity" CssClass="validation-error"  runat="server" ControlToValidate="txtQauntity" ErrorMessage="Quantity must be a whole number"  ValidationExpression="^\d+$" Display="Dynamic" />
      </div>

      <h4></h4>

      <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="btnAddProduct_Click" CausesValidation="true" />

      <h4></h4>

      <div id="popupSuccess" class="alert alert-dismissible alert-success" runat="server" visible="false">
         <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
      </div>

      <div id="popupFailure" class="alert alert-dismissible alert-danger" runat="server" visible="false">
         <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
      </div>

        <style>
         body {
            background-image: url('Resources/farm1.png');
            background-repeat: no-repeat;
            background-size: cover;
         }
      </style>

   </div>
</asp:Content>

