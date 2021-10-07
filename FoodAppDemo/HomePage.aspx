<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FoodAppDemo.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .foodItem{
            border:1px solid blue;
            margin:2px;
            padding:2px;
            width:220px;
            background-color:lightblue
        }
        img{
            width:190px;
            height:200px;
            padding:5px;
        }
    </style>
</head>
<body>
    <h1>Nitya Sandharshini</h1>
    <hr />  
    <form id="form1" runat="server">
        <div>
            <h2>Please select the food Item here!</h2>
            <asp:DataList runat="server" RepeatDirection="Horizontal" ID="dtList" OnItemCommand="dtList_ItemCommand">
                <ItemTemplate>
                    <div class="foodItem">
                    <h2><%#Eval("ItemName") %></h2>
                    <hr />
                    <p><%#Eval("ItemName")%></p>
                    <p>
                        <img src='<%#Eval("ItemImage")%>'/>
                    </p>
                    <p>Cost: <%#Eval("ItemCost")%></p> 
                        <asp:Button CommandName="Select" Text="Select" runat="server" />
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div>
            <asp:Label Text="Items Basket Count: " ID="lblItemCount" runat="server" />
        </div>
        <div>
            <asp:Button Text="Generate Bill" runat="server" ID="btnBill" OnClick="btnBill_Click"/>
        </div>
    </form>
</body>
</html>
