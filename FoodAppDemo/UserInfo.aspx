<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="FoodAppDemo.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome to the Billing System</h1>
        <hr />  
        <h2>The List of Items U Have Selected!</h2>
        <asp:Repeater runat="server">
            <ItemTemplate></ItemTemplate>
        </asp:Repeater>
        <div>
            <h1>We need info about U to deliver: </h1>
            Customer Name: <asp:TextBox runat="server" ID="txtName"/><br />
            Customer Address: <asp:TextBox runat="server" ID="txtAddress"/><br />
            Customer Contact: <asp:TextBox runat="server" ID="txtPhone"/><br />
            <asp:Button Text="Complete Order" ID="btnOrder" runat="server" OnClick="btnOrder_Click" />
        </div>
    </form>
</body>
</html>
