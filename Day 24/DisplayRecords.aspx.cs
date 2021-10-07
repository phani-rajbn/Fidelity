using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//When a Page is loaded thro a get method of the form, then the IsPostBack property of the Page class will be false. 
//When U submit a page, or Post a page to the server, then the IsPostBack property will be true.
//We can use this property to determine whether the page is rendered as POST or GET. WHen the page is sent to the server for processing, it is POST method and when U request from the URL, it is GET method. 
//HTTP is a stateless protocol...
namespace SampleWebApp
{
    public partial class DisplayRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var list = getAllNames();
                foreach (var name in list)
                    lstNames.Items.Add(name);
            }
        }
    
        private List<string> getAllNames()
        {
            var context = new EmpDataDataContext();
            var names = context.Employees.Select((e) => e.EmpName).ToList();
            return names;
        }
        //This event will occur when a selection happens or changes in the listbox. Enable AutoPostBack so that U dont need a button to click after selection.  
        protected void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedName = lstNames.SelectedValue;
            var context = new EmpDataDataContext();
            var selectedEmp = context.Employees.FirstOrDefault((emp) => emp.EmpName == selectedName);
            txtId.Text = selectedEmp.EmpID.ToString();
            txtName.Text = selectedEmp.EmpName;
            txtAddress.Text = selectedEmp.EmpAddress;
            txtSalary.Text = selectedEmp.EmpSalary.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            var context = new EmpDataDataContext();
            var empId = int.Parse(txtId.Text);
            var selected = context.Employees.SingleOrDefault((emp) => emp.EmpID == empId);
            if (selected == null)
                throw new Exception("Employee not found to update");
            selected.EmpName = txtName.Text;
            selected.EmpAddress = txtAddress.Text;
            selected.EmpSalary = int.Parse(txtSalary.Text);
            context.SubmitChanges();
            Response.Redirect("DisplayRecords.aspx");//Reload this page.
        }
    }
}