using System.Web.Mvc;
using System.Linq;
using SampleEntityLib;
using System;

namespace SampleMvcApp.Controllers
{
    public class AjaxDemoController : Controller
    {
        //Displays one DashBoard..
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Employees()
        {
            var dllComponent = EmployeeDBFactory.GetComponent();
            var employees = dllComponent.GetEmployees("");//Gives all employees;
            return PartialView(employees);
        }

        public ActionResult OnUpdate(string id)
        {
            var dllComponent = EmployeeDBFactory.GetComponent();
            int eId = int.Parse(id);
            try
            {
                var selected = dllComponent.GetEmployee(eId);
                var items = dllComponent.GetAllDepts().Select((d) => new SelectListItem { Text = d.DeptName, Value = d.DeptID.ToString() });
                ViewBag.Items = items;
                return PartialView(selected);//push the model into the view...
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult OnUpdate(Employee model)
        {
            var dllcomponent = EmployeeDBFactory.GetComponent();
            try
            {
                dllcomponent.UpdateEmployee(model);
                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index");
            }
        }
    }
}