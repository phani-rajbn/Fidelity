<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTemplate.Master" AutoEventWireup="true" CodeBehind="DisconnectedModel.aspx.cs" Inherits="SampleWebApp.DisconnectedModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="childContent" runat="server">
    <h1>What is Disconnected Data Access?</h1>
    <p>
        ADO.NET gave an innovative feature of accessing data in a Web based Application. This is called Disconnected Model. Here the data from the database can be stored into an in-memory object called DATASET. The dataset will store the data in the form of tables, U can have a collection of tables in it. DataSet can be filled with data coming from different sources of databases. Data gets filled into the dataset using a ADO.NET Class called DataAdapter. DataAdapter is a smart class that has methods like Fill and Update which opens a closed Connection, fills the data into the specific table of the dataset and immediately closes the Connection. All work related to UR app can be done thru' the dataset instead of LIVE Database. Finally U can update the data back to the database for any kind of changes like Insertion, deletion, updation.  
    </p>
    <hr />
    <div>
        <asp:Repeater runat="server" ID="rpEmployees" OnItemCommand="rpEmployees_ItemCommand">
            <headerTemplate>
                <table border="1">
                    <tr>
                        <th colspan="6">
                            List of Employees with Us!
                        </th>
                    </tr>
                    <tr>
                        <th>Employee ID</th>
                        <th>Employee Name</th>
                        <th>Employee Address</th>
                        <th>Employee Salary</th>
                        <th>Dept</th>
                        <th>Options</th>
                    </tr>
            </headerTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("EmpID") %></td>
                    <td><%#Eval("EmpName") %></td>
                    <td><%#Eval("EmpAddress") %></td>
                    <td><%#Eval("EmpID") %></td>
                    <td><%#Eval("Dept") %></td>
                    <td>
                        <asp:Button runat="server" CommandName="Select" Text="Edit" CommandArgument='<%#Eval("EmpID")%>'/>
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%#Eval("EmpID")%>'/>
                    </td>
                </tr>
            </ItemTemplate>
            <footerTemplate>
                </table>
            </footerTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
