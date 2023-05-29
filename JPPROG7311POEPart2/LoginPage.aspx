<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/BlankMaster.Master" CodeBehind="LoginPage.aspx.cs" Inherits="JPPROG7311POEPart2.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link rel="stylesheet" href="Styles/Login.css">

   <div class="form-container">

      <h1>Login</h1>

      <h4></h4>

      <div>
         <asp:Label ID="lblEmail" for="txtPassword" runat="server" Text="Email"></asp:Label>
         <asp:TextBox ID="txtEmail" CssClass="auto-style1" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="valSurname" CssClass="validation-error" runat="server" ControlToValidate="txtEmail" ErrorMessage="Surname is required" Display="Dynamic"></asp:RequiredFieldValidator>
      </div>
      <div>
         <asp:Label ID="lblPassword" for="txtPassword" runat="server" Text="Password"></asp:Label>
         <asp:TextBox ID="txtPassword" CssClass="auto-style1" runat="server" TextMode="Password"></asp:TextBox>
         <asp:RequiredFieldValidator CssClass="validation-error" runat="server" ControlToValidate="txtPassword" ErrorMessage="Surname is required" Display="Dynamic"></asp:RequiredFieldValidator>
      </div>

      <h4></h4>

      <asp:Button ID="btnLogin" CssClass="btn btn-primary" runat="server" Text="Login" OnClick="btnLogin_Click" CausesValidation="true" />

      <h4></h4>

      <div id="popupFailure" class="alert alert-dismissible alert-danger" runat="server" visible="false">
         <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
      </div>
   </div>
</asp:Content>