<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridForm.aspx.cs" Inherits="SampleWebApp.GridForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Displaying Employees as Table</h1>
    <hr />
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="grdDetails" runat="server" BackColor="PowderBlue" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="DarkBlue" Height="268px" Width="699px">
             </asp:GridView>
        </div>
    </form>
</body>
</html>
