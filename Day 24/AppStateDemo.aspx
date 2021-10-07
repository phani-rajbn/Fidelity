<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="AppStateDemo.aspx.cs" Inherits="SampleWebApp.AppStateDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h1>Application object</h1>
    <p>
        Application State is one similar to Session but is available at the scope of the Application. It is like shared data to all the users of the application. This will be used when U want info that has to be consumed by all the users of the application, Application object is available as a part of the Page class. Application stores the data in the form of Key-Value Pairs, very similar to Sessions. 
        Data for the Application can also be added at the Application_Start event handler provided by the global.asax file. This would be the ideal place to create App objects as they are called once and only once during the Application instantiation.
    </p>
</asp:Content>
