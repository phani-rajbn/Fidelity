using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class CookiesDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //Cookies are created using a class called HttpCookie in ASP.NET.
            HttpCookie cookie = new HttpCookie("Info");
            cookie.Values.Add("Name", txtName.Text);
            cookie.Values.Add("Email", txtEmailAddress.Text);
            //U should add the cookie into the Response object to store the Cookie in the Response. 
            Response.Cookies.Add(cookie);
            Response.Redirect("Recipiant.aspx");
        }
    }
}