<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="Recipiant.aspx.cs" Inherits="SampleWebApp.Recipiant" %>
<%@ PreviousPageType VirtualPath="~/PreviousPageDemo.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h2>Data sent by the User</h2>
    <asp:Label ID="lblInfo" runat="server" BorderColor="Black" BorderStyle="Dotted" Height="200px" Width="850px" />
</asp:Content>
