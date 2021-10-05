using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class PreviousPageDemo : System.Web.UI.Page
    {
        public string UserName => txtName.Text;
        
        public string EmailAddress => txtEmailAddress.Text;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Server.Transfer("Recipiant.aspx");//Response.Redirect is more like a Hyperlink of HTML. So to send Server side info to the Next page, we will use the HttpServer object to move to the page. 
        }
    }
}