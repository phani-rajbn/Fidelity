using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        //Helper function for getting depts.
        private List<Dept> getAllDepts()
        {
            var ctx = new EmpDataDataContext();
            return ctx.Depts.ToList();
        }
        //Event for loading the page. Good for initialization of data into the controls.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var depts = getAllDepts();
                foreach (var dept in depts)
                {
                    dpList.Items.Add(new ListItem { Text = dept.DeptName, Value = dept.DeptID.ToString() });
                }
            }
        }
        //Handler for click event of the AddNew Button.
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            //get the values from the imputs and create an Employee object
            var emp = new Employee
            {
                DeptId = int.Parse(dpList.SelectedValue),
                EmpAddress = txtAddress.Text,
                EmpName = txtName.Text,
                EmpSalary = int.Parse(txtSalary.Text)
            };
            //Using context, add the EmployeeObject
            var ctx = new EmpDataDataContext();
            ctx.Employees.InsertOnSubmit(emp);
            //Submit the changes
            ctx.SubmitChanges();
            //redirect to the DisplayRecords.aspx
            Response.Redirect("DisplayRecords.aspx");
        }
    }
}