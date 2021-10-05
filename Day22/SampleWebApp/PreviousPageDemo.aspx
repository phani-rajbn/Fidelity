<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="PreviousPageDemo.aspx.cs" Inherits="SampleWebApp.PreviousPageDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h1>Sharing data using PreviousPage</h1>
    <hr />
    <p>One can access the controls and properties of the Previous page from which the current page is displayed. This is possible using the PreviousPage directive and providing public properties to the page so that it can be accessed. PreviousPage is a feature available in ASP,NET only. U can access the members of a Page class from another page if it is associated with the Page. </p>
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
    </div>
</asp:Content>
