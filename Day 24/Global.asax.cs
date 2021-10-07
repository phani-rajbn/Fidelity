using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using SampleWebApp.Models;
//Data Bound controls of ASP.NET with Application and SEssion together
namespace SampleWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["Products"] = ProductDB.AllProducts;//This will be created as soon as the App begins. 
        }
        //This event is triggered when the session with the user begins. 
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["myCart"] = new List<Product>();//cart is related to one user only...
            Session["recentList"] = new Queue<Product>();
        }
    }
}