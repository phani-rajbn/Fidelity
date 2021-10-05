using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class QuerystringDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Querystring is the easiest way of sharing info from one page to another. It is done using URL of the Page. The QueryString will be data in the form of key=value pairs each seperated by an &. The data is accessible using the Request object in the other page. 
        protected void btnSend_Click(object sender, EventArgs e)
        {
            var text = $"Recipiant.aspx?Name={txtName.Text}&Email={txtEmailAddress.Text}";
            Response.Redirect(text);//Response.Redirect is like asking the Server to move to the specific page mentioned in the arg.
        }
    }
}