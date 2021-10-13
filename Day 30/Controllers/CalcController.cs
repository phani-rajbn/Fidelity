using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/*Ways of transfering data from the controller to the View:
1. As a Model object. U can inject the model object into the View and send it. (Most Common way)
2. ViewBag is a dynamic object that will store the data and can be used in the View. With ViewBags U dont need to UNBOX or BOX
3. ViewData is a dictionary that will store the data as objects and can be accessed in the View. U need to BOX/UNBOX the data
4. TempData is also like Dictionary that can store the data as objects and can be accessed in the View.  This allows to retain the data for subsequent actions if we call KEEP() method. 
Ways of transfering data from the View to the Controller:
1. Posted Model object(Most Common way), but works only on Strongly typed Views.  Views that as model assigned to it. U assign a model to the View using @model directive of Razor syntax. 
2. FormCollection can be used to send the data from the View if the data is a part of the Form. The controls should be within the BeginForm block of the HTML Helper. Controller can have a Action method which takes the FormCollection as its argument and U can access them in the Action. 
3. Parameters of the Action can be used to access the data sent by the View to the controller. In this case, the names of the parameters of the Action method should match the names of the HTML Helpers in the View. 
4. QueryString can send the information to the controller only if the Router has specified the pattern. In our example, id was the expected value passed from the View to the Controller using new{}  of ActionLinks or any other commands. 

Over and above all, U can still use Application, Session objects which are not required/recommended. Try to avoid them as much as possible. 
*/
namespace SampleMvcApp.Controllers
{
    public class CalcController : Controller
    {
       
        public ActionResult Calc()
        {
            var options = new List<SelectListItem>
            {
                new SelectListItem{ Text ="Add", Value="+"},
                new SelectListItem{ Text ="Subtract", Value="-"},
                new SelectListItem{ Text ="Multiply", Value="*"},
                new SelectListItem{ Text ="Divide", Value="/"}
            };
            //3rd way of sending the data to the View is thru' TempData. TempData retains the value for subsequient actions when U ask the MVC to keep the data. Keep method ensures the data will be available for couple of action calls, but not for a very long time. In such cases, we suggest to use Session object(Not recommended). 
            TempData["options"] = options;
            TempData.Keep();//Keep retains the Keys of the TempData for couple of visits to the View. 
            return View();
        }
        //One of the ways where a View can pass the data into the controler is FormsCollection
        //public ActionResult ProcessFunc(FormCollection form)
        //{
        //    var first = double.Parse(form["firstValue"]);
        //    var option = form["dpOptions"];
        //    var second = double.Parse(form["secondValue"]);
        //    var res = getResult(first, second, option);
        //    //One of the ways to send data to View from the controller is ViewBag. ViewBag is a dynamic object that will store the data for a brief period of time scoped to the action to which it is created. ViewBag internally uses Dictionary, but unlike Dictionary, here U dont have to UNBOX the data. 
        //    ViewBag.Result = res;//ViewBag's scope is limited to the action to which it is declared.
        //    return View("Calc");
        //}

        //One more way of View sending the info to the Controller is in the form of Paramters. An Action can take the control names used in the View as paramters of the Action and get data thru' it
        public ActionResult ProcessFunc(double firstValue, double secondValue, string dpOptions)
        {
            var res = getResult(firstValue, secondValue, dpOptions);
            ViewData["Result"] = res;//IN this case, the data is boxed and stored in the Dictonary called ViewData.
            return View("Calc");
        }

        private double getResult(double v1, double v2, string option)
        {
            switch (option)
            {
                case "+":
                    return v1 + v2;
                case "-":
                    return v1 - v2;
                case "*":
                    return v1 * v2;
                case "/":
                    return v1 + v2;
            }
            return 0.0;
        }
    }
}