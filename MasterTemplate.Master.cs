using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*
 * Most of the web pages do share a common connect among themselves. Many pages of a given website will have common content like menu, footer, headings, links common in all their pages. So we can create a page called master page and provide all the common content into it and make the web pages adapt the master page in them. The Master page is more like a template which all other regular pages will adhere to it. With master pages, u can create a common look and feel pages for the website without recreating them in all the pages. 
 * Master pages are saved as .master. They are predefined layouts, so viewers cannot request to this page. U cannot access this page thru' a browser. Instead, web pages will attach this master page in them and users will request for the web pages that hold master content. 
 */
namespace SampleWebApp
{
    public partial class MasterTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}