using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FoodAppDemo.Models;

namespace FoodAppDemo
{
    public class Global : System.Web.HttpApplication
    {
        //This event is triggered when the Application starts..
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["FoodItems"] = FoodData.AllItems;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["cart"] = new List<FoodItem>();
        }
    }
}