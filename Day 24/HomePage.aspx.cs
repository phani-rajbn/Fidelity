using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Event handler for the button class. OnClick
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var text = txtName.Text;
            lblInfo.Text = "The name entered: " + text;
        }
    }
}