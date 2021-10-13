using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class ValidationController : Controller
    {
        public ActionResult Register()
        {
            var model = new Customer(); 
            return View(model);
        }
    }
}