<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="StateManagement.aspx.cs" Inherits="StateManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h1>Server Side State Management</h1>
    <hr />
    <div>
        <p style="font-size: medium">Server side statemanagement is used to hold data within the server and can be shared among all the users of the application. It is completely controlled by the server(IIS) and will be managed by the developer and the System Admin. Of the Server side State Management, Session, Application and Cache are said to be the objects used for managing the state within the Application</p>
        <ol>
            <li><strong>Session State:</strong> Uses Session, a unique interaction b/w the individual client and the server</li>
            <li><strong>Application State:</strong> A Singleton object which is common for the whole Application.</li>
            <li><strong>Cache</strong>: Data that is stored for a brief period of time.(Time bound State Management)</li>
        </ol>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="SessionDemo.aspx">Session</asp:LinkButton>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~\ApplicationDemo.aspx">Application</asp:HyperLink>
            <a href="~\CacheDemo.aspx">Cache</a>
        </p>
    </div>
</asp:Content>
