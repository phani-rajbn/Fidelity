﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleWebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }
        //This event is triggered when the session with the user begins. 
        protected void Session_Start(object sender, EventArgs e)
        {
            
        }
    }
}