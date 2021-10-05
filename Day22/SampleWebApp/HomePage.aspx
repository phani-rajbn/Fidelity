<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterTemplate.Master" CodeBehind="HomePage.aspx.cs" Inherits="SampleWebApp.HomePage" %>
<asp:Content ContentPlaceHolderID="childContent" runat="server" ID="content1">
    <script>
        function testMe() {
            alert("Test me")
        }
    </script>
    <h1>Welcome to ASP.NET Training</h1>
        <div style="vertical-align:central">
            <h1>
                <asp:Label Text="Enter Name" runat="server" />
                <asp:TextBox runat="server" ID="txtName" />
                <asp:Button ID="btnSave" Text="Server Side Click Me" runat="server" OnClick="btnSave_Click" />
                <button onclick ="testMe()">Client Side Test me</button>
            </h1>
        </div>
        <div>
            <asp:Label Text="" ID="lblInfo" runat="server" />
        </div>
</asp:Content>       
