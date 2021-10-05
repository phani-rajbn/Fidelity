using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Session is a collection object in asp.net for storing data in the scope of a session. session is an unique interaction b/w a perticular User and the Application. For a given machine and a given browser, there will be one unique session id created. This id will be maintained till the user closes the browser. 
//Session is lost in any one of the following conditions: The browser is idle for more than a speculated interval of time(Session Timed Out). U have moved to another application thru an hyper link and tried to come back to this Application. U accidentlly close down the browser, the session is lost. Programmers can abandon the session thru' code. 

namespace SampleWebApp
{
    public partial class SessionDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Words"] == null)
                Session.Add("Words", new List<string>());
            else
            {
                if (!IsPostBack)
                {
                    lstWords.DataSource = Session["Words"] as List<string>;
                    lstWords.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var list = Session["Words"] as List<String>;
            list.Add(txtWord.Text);
            Response.Redirect("SessionDemo.aspx");
        }
    }
}