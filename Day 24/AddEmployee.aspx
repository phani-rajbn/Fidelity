<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="SampleWebApp.AddEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>New Employee Registration Form</h1>
    <hr />
    <form id="form1" runat="server">
        <div>
        <h2>Details of the New Employee</h2>
        <p>
            Employee Name: <asp:TextBox runat="server" ID="txtName"/>
        </p>
        <p>
            Employee Address: <asp:TextBox runat="server" ID="txtAddress"/>
        </p>
        <p>
            Employee Salary: <asp:TextBox runat="server" ID="txtSalary"/>
        </p>
        <p>
            Dept: <asp:DropDownList runat="server" ID="dpList">
            </asp:DropDownList>
        </p>
        <p>
            <asp:Button Text="Add Employee" runat="server" ID="btnAddNew" OnClick="btnAddNew_Click"/>
        </p>
        </div>
    </form>
</body>
</html>
