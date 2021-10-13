using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class MyFirstController : Controller
    {
        public string HelloWorld()//Method of a controller in MVC is called as Action
        {
            return "Welcome to MVC Training";
        }
        //Action Result should be a string representation.
        //public Employee Current()
        //{
        //    return new Employee { EmpID = 111, EmpAddress = "Bangalore", EmpName = "Phaniraj", EmpSalary = 56000 };
        //    //Display of this action will be the string representation of the object that U R Returning. 
        //}

        public ViewResult Current()
        {
            var emp = new EmpClass { EmpID = 111, EmpAddress = "Bangalore", EmpName = "Phaniraj", EmpSalary = 56000 };
            return View(emp);//This action will return a View with the model called emp
        }
    }
}