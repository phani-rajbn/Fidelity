<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterTemplate.Master" CodeBehind="CalcProgram.aspx.cs" Inherits="SampleWebApp.CalcProgram" %>
<asp:Content ContentPlaceHolderID="childContent" runat="server" ID="content1">
    <div>
        <h1>Welcome to calc Program</h1>
        <hr />
        <p>
            Enter the First Value:
            <asp:TextBox ID="txtFirst" runat="server">
            </asp:TextBox>
        </p>
        <p>
            Enter the Second Value:
            <asp:TextBox ID="txtSecond" runat="server">
            </asp:TextBox>
        </p>
        <p>
            Select the operation:
                <asp:DropDownList ID="dpList" runat="server">
                    <asp:ListItem Text="+">
                    </asp:ListItem>
                    <asp:ListItem Text="-">
                    </asp:ListItem>
                    <asp:ListItem Text="X">
                    </asp:ListItem>
                    <asp:ListItem Text="/">
                    </asp:ListItem>
                </asp:DropDownList>
        </p>
        <p>
            <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Get Result" />
        </p>
        <p>
            The Result:
            <asp:Label ID="lblDisplay" runat="server"></asp:Label>
        </p>
    </div>
</asp:Content>            
