<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="QuerystringDemo.aspx.cs" Inherits="SampleWebApp.QuerystringDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h1>Query String Example</h1>
    <hr />
    <div>
        <p>
            Enter the Name: <asp:TextBox runat="server" Id="txtName"/>
            <asp:RequiredFieldValidator ErrorMessage="Name is mandatory" ForeColor="IndianRed" ControlToValidate="txtName" runat="server" />
        </p>
        <p>
            Enter the Email Address: <asp:TextBox runat="server" Id="txtEmailAddress"/>
            <asp:RegularExpressionValidator ErrorMessage="Email is not in a proper format" ForeColor="IndianRed" ControlToValidate="txtEmailAddress" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" runat="server" />
        </p>
        <p>
            <asp:Button Text="Send Info" runat="server" ID="btnSend" OnClick="btnSend_Click" />
        </p>
        <p>
            <asp:ValidationSummary runat="server" ShowMessageBox="true" ForeColor="IndianRed" />
    </div>
</asp:Content>
