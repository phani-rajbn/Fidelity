using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleEntityLib;
namespace SampleMvcApp.Controllers
{
    public class EntityDemoController : Controller
    {
        // GET: EntityDemo
        public ActionResult Index()
        {
            IEmployeeDBComponent component = EmployeeDBFactory.GetComponent();
            var employees = component.GetEmployees("");
            return View(employees);
        }

        public ActionResult Update(string id)
        {
            var empId = int.Parse(id);
            IEmployeeDBComponent component = EmployeeDBFactory.GetComponent();
            var selected = component.GetEmployees("").FirstOrDefault((e) => e.EmpID == empId);
            var depts = component.GetAllDepts();
            var options = new List<SelectListItem>();
            foreach(var dept in depts)
            {
                options.Add(new SelectListItem { Text = dept.DeptName, Value = dept.DeptID.ToString() });
            }
            ViewBag.Depts = options;
            return View(selected);
        }
    }
}