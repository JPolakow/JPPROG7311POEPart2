<%@ Page Title="New Farmer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewFarmer.aspx.cs" Inherits="JPPROG7311POEPart2.NewFarmer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="Styles/NewFarmer.css">

   <div class="form-container">
      <h2>Add New Farmer</h2>

      <h4></h4>

      <div class="form-group">
         <label for="txtFName">First Name:</label>
         <asp:TextBox ID="txtFName" runat="server" CssClass="auto-style1" Width="350px" placeholder="First Name"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valFName" CssClass="validation-error" runat="server" ControlToValidate="txtFName" ErrorMessage="First Name is required" Display="Dynamic"></asp:RequiredFieldValidator>
      </div>

      <div class="form-group">
         <label for="txtSurname">Surname:</label>
         <asp:TextBox ID="txtSurname" runat="server" CssClass="auto-style1" Width="350px" placeholder="Surname"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valSurname" CssClass="validation-error" runat="server" ControlToValidate="txtSurname" ErrorMessage="Surname is required" Display="Dynamic"></asp:RequiredFieldValidator>
      </div>

      <div class="form-group">
         <label for="txtEmail">Email:</label>
         <asp:TextBox ID="txtEmail" runat="server" CssClass="auto-style1" Width="350px" placeholder="Email"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valEmail" CssClass="validation-error" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" Display="Dynamic"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="rvalEmail" CssClass="validation-error" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:RegularExpressionValidator>
      </div>

      <div class="form-group">
         <label for="txtPhoneNumber">Phone Number:</label>
         <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="auto-style1" Width="350px" placeholder="Phone Number"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valPhoneNumber" CssClass="validation-error" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is required" Display="Dynamic"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="rvalPhoneNumber" CssClass="validation-error" runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Invalid phone number format" ValidationExpression="^\d{10}$" Display="Dynamic"></asp:RegularExpressionValidator>
      </div>

      <div class="form-group">
         <label for="txtLocation">Location:</label>
         <asp:TextBox ID="txtLocation" runat="server" CssClass="auto-style1" Width="350px" placeholder="Location"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valLocation" CssClass="validation-error" runat="server" ControlToValidate="txtLocation" ErrorMessage="Street Address is required" Display="Dynamic"></asp:RequiredFieldValidator>
      </div>

      <div class="form-group">
         <label for="txtPassword">Password:</label>
         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" Width="350px" placeholder="Password"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valPassword" runat="server" CssClass="validation-error" ControlToValidate="txtPassword" ErrorMessage="Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="rvalPassword" runat="server" CssClass="validation-error" ControlToValidate="txtPassword" ErrorMessage="Password must be at least 8 characters long" ValidationExpression="^.{8,}$" Display="Dynamic"></asp:RegularExpressionValidator>
      </div>

      <div class="form-group">
         <label for="txtConfirmPassword">Confirm Password:</label>
         <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" Width="350px" placeholder="Confirm Password"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valConfirmPassword" runat="server" CssClass="validation-error" ControlToValidate="txtConfirmPassword" ErrorMessage="Confirm Password is required" Display="Dynamic"></asp:RequiredFieldValidator>
         <asp:CompareValidator ID="cvPasswordMatch" runat="server" CssClass="validation-error" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match" Display="Dynamic"></asp:CompareValidator>
      </div>

      <h4></h4>

      <asp:Button ID="btnAddFarmer" runat="server" Text="Add Farmer" CssClass="btn btn-primary" OnClick="btnAddProduct_Click" CausesValidation="true" />

      <h4></h4>

      <div id="popupSuccess" class="alert alert-dismissible alert-success" runat="server" visible="false">
         <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
      </div>

      <div id="popupFailure" class="alert alert-dismissible alert-danger" runat="server" visible="false">
         <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
      </div>

        <style>
         body {
            background-image: url('Resources/farm2.png');
            background-repeat: no-repeat;
            background-size: cover;
         }
      </style>

   </div>
</asp:Content>
