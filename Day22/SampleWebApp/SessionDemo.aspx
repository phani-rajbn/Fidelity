<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="SessionDemo.aspx.cs" Inherits="SampleWebApp.SessionDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
      <div>
        <h3>My own set of words</h3>
        <p>
            Enter the Word: <asp:TextBox runat="server" ID="txtWord"/>
            <asp:Button Text="Save" runat="server" ID="btnSave" OnClick="btnSave_Click" />
        </p>
        <p>
            List of Words:<br />    
            <asp:ListBox runat="server" ID="lstWords" Height="358px" Width="258px">            </asp:ListBox>
        </p>
    </div>
</asp:Content>
