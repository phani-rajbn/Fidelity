<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="SampleWebApp.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <div>
        <p>Employee ID:<asp:Label Text="" ID="lblEmpId" runat="server" /></p>
        <p>Employee Name:<asp:TextBox runat="server" ID="txtName" /></p>
        <p>Employee Address:<asp:TextBox runat="server" ID="txtAddress" /></p>
        <p>Employee Salary:<asp:TextBox runat="server" ID="txtSalary" /></p>
        <asp:Button Text="Save Changes" runat="server" OnClick="Unnamed1_Click" />     
    </div>
</asp:Content>
