using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class Recipiant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*****************************QueryString Demo******************************************************
            if(Request.QueryString.Count == 0)
            {
                lblInfo.Text = "NO DATA IS SHARED!!!";
            }
            else
            {
                var name = Request.QueryString["Name"];
                var email = Request.QueryString["Email"];
                lblInfo.Text = $"The Name: {name}<br/>The Email Address: {email}";
            }
            QueryString can be easily seen by all users. Any sensitive info can be compromized. However for the text based content to be transfered, U can use QueryStirng. U could encrypt the text and send it thru' the URL. Text size should not be more than 255 charecters. QueryString is the most popular way of sharing the data from one Page to another in any Web Environment/Technology. 
            *********************************Cookies Demo*******************************
            var cookie = Request.Cookies["Info"];
            if(cookie == null)
            {
                lblInfo.Text = "No Cookie info is stored by the Application";
            }
            else
            {
                var name = cookie.Values["Name"];
                var email = cookie.Values["Email"];
                lblInfo.Text = $"The Name: {name}<br/>The Email Address: {email}";
            }
            //Cookies are always created only if the User gives permission to save the information. Cookies store the data as TEXT only, U cannot store objects like Employee, Customer. Clients can delete the cookies at any given point of time. 
            //Dont Use cookies when there is a high level of dependency of it in UR Application. These dependencies include programmic logical working of the code. 
            **************************PreviousPage demo**********************************/
            if (PreviousPage == null)
            {
                lblInfo.Text = "This Page is viewed directly without visiting any other page";
                return;
            }
            var name = PreviousPage.UserName;
            var email = PreviousPage.EmailAddress;
            lblInfo.Text = $"The Name: {name}<br/>The Email Address: {email}";
        }
    }
}