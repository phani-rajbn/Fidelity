using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodAppDemo.Models;
using System.Diagnostics;
namespace FoodAppDemo
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = Application["FoodItems"] as FoodItem[];
                dtList.DataSource = data;
                dtList.DataBind();
            }
        }

        protected void dtList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            dtList.SelectedIndex = e.Item.ItemIndex;//get the index of the selected item in the datalist
            var cart = Session["cart"] as List<FoodItem>;//get the current session data.
            var allItems = Application["FoodItems"] as FoodItem[];//get the allfood items
            cart.Add(allItems[dtList.SelectedIndex]);//Add the item with the selected index
            foreach (var item in cart)//test if the item is added to the cart, remove it after testing.
            {
                Debug.WriteLine(item.ItemName);
            }
            Session["cart"] = cart;//update the session object
            lblItemCount.Text = "Items Basket Count: " + cart.Count;//Display the count in the label.
        }

        protected void btnBill_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserInfo.aspx");
        }
    }
}