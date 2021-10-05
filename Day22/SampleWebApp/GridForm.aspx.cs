using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//DataSource property is used to set the source of the data to be associated to the grid.
//DataBind method is used to extract the data and fill into the grid. 
namespace SampleWebApp
{
    public partial class GridForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdDetails.DataSource = new EmpDataDataContext().Employees.ToList();
                grdDetails.DataBind();//gets the data and binds it to the grid...
            }
        }
    }
}
/*
 * Page Life Cycle
 * Client side State management: QueryString, Cookies, PreviousPage object.
 * Server side State Management: Sessions, Application and Cache. 
 */