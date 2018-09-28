<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SecureWebsitePractices.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
  <h3>You searched for <strong><asp:Label runat="server" ID="SearchTerm" /></strong></h3>

  <asp:GridView runat="server" ID="SearchGrid" AutoGenerateColumns="False" Width="100%">
    <EmptyDataTemplate>
      No results were found
    </EmptyDataTemplate>
    <Columns>
      <asp:HyperLinkField DataTextField="ProductName" HeaderText="Product name" />
    </Columns>
  </asp:GridView>
</asp:Content>
