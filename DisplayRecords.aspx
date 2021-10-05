<%@ Page Language="C#" Trace="true" AutoEventWireup="true" CodeBehind="DisplayRecords.aspx.cs" Inherits="SampleWebApp.DisplayRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .auto-style1 {
            width: 15%;
            height: 396px;
            display:inline-block;
        }
        .auto-style2 {
            width: 23%;
            height: 396px;
            display: inline-block;
        }
    </style>
</head>
<body>
    <h1>Displaying our Employee Team!!!</h1>
    <hr />  
        <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:ListBox runat="server" ID="lstNames" Height="400px" AutoPostBack="True" OnSelectedIndexChanged="lstNames_SelectedIndexChanged" Width="138px">
            </asp:ListBox>
        </div>
        <div class="auto-style2">
        <h2>Details of the selected Employee</h2>
        <p>
            Employee ID: <asp:TextBox runat="server" ID="txtId"/>
        </p>
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
            <asp:Button Text="Save Changes" runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" />
        </p>
        </div>
        </form>
    <a href="./AddEmployee.aspx">Register New Employee</a>
</body>
</html>
