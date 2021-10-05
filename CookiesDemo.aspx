<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="CookiesDemo.aspx.cs" Inherits="SampleWebApp.CookiesDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h1>Cookies Example</h1>
    <p>
        Cookies are small text based info stored in the client's machine. They are harmless. It is made available in the client machines browser settings. It is typically used to store user info pertained to that individual user like Usernames, Passwords, City, ContactNo, Themes and things that are very customized to that User. Cookies are a concept that is available in all Web centric Applications and Technologies. 
        <br />
        Cookies in ASP.NET are objects of a class called HttpCookie. They store the data in the form of key-value pairs. Both Request and Response objects have Cookies collection as property in them. Use this Cookies property to set, get cookies from the application. 
        <br />  
        <b>Limitations:</b> Cookies are controlled by the User Machine, Clients can disable the cookies if they intend to do so. It is recommended to notify UR customers that U R using Cookies to store their personal information. 
    </p>
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
    </div>
</asp:Content>
