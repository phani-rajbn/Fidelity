using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;
namespace SampleMvcApp.Controllers
{
    public class EmpDBController : Controller
    {
        // GET: EmpDB
        public ActionResult Index()
        {
            var context = new EmpDBDataContext();//Get the data from LINQ to SQL
            var data = context.Employees.ToList();//Convert it to LIST, it will be UR model
            return View(data);//Inject the model into the View.
            //PS:In this Action, UR Model is List<Employee>
        }

        public ViewResult Change(string id)
        {
            //get the record for the matching id using LINQ to SQL
            var context = new EmpDBDataContext();
            int empId = int.Parse(id);
            var rec = context.Employees.FirstOrDefault((e) => e.EmpID == empId);
            return View(rec);
        }
        [HttpPost]//HTTPPOST is an attribute to tell the MVC that it should invoke this Action when the Form is posted to the Server. 
        public ActionResult Change(Employee model)
        {
            var context = new EmpDBDataContext();
            var rec = context.Employees.FirstOrDefault((e) => e.EmpID == model.EmpID);
            rec.EmpName = model.EmpName;
            rec.EmpAddress = model.EmpAddress;
            rec.EmpSalary = model.EmpSalary;
            context.SubmitChanges();
            return RedirectToAction("Index");//Response.Redirect
        }

        public ActionResult OnDelete(string id)
        {
            var context = new EmpDBDataContext();
            int empId = int.Parse(id);
            var rec = context.Employees.FirstOrDefault((e) => e.EmpID == empId);
            context.Employees.DeleteOnSubmit(rec);
            context.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}