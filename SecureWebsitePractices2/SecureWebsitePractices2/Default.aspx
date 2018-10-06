<%@ Page Title="Search by Name" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SecureWebsitePractices2.Default" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>--%>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
  <hgroup class="title">
    <h2>Product Search</h2>    
  </hgroup>
  <fieldset>
      <hr />
      <h3>Search for Product Names</h3>
      <br />
        <h4>Product Name:</h4>
      <br />
  
        <asp:Label ID="Label1" runat="server" AssociatedControlID="SearchTerm">Search term :</asp:Label>
        
          <asp:TextBox runat="server" ID="SearchTerm" />
      <br /><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
  </fieldset>
    <br /><br />
</asp:Content>
