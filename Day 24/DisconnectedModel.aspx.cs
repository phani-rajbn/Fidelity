using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Xml.Linq;

namespace SampleWebApp
{
    public partial class DisconnectedModel : System.Web.UI.Page
    {
        private DataSet ds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                rpEmployees.DataSource = getEmployeeRecords();
                Session["data"] = ds.Tables[0];
                rpEmployees.DataBind();
            }
        }

        private DataTable getEmployeeRecords()
        {
            const string query = "SELECT EmpID, EmpName, EmpAddress, EmpSalary, DeptName as Dept from Employee inner join Dept on Employee.DeptId = Dept.DeptId";
            const string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FidelityDB;Integrated Security=True";
            if(ds == null)
            {
                ds = new DataSet("MyExamples");
                SqlDataAdapter ada = new SqlDataAdapter(query, connectionString);
                ada.Fill(ds, "MyFirstTable");
            }
            return ds.Tables[0];
        }
        private void deleteRecord(int id)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FidelityDB;Integrated Security=True";
            var query = $"delete from employee where empid = {id}";
            var con = new SqlConnection(connectionString);
            var cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("DisconnectedModel.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Dispose();
            }
        }
        protected void rpEmployees_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    Response.Redirect("EditEmployee.aspx?EmpId=" + e.CommandArgument.ToString());
                    break;
                case "Delete":
                    var id = e.CommandArgument.ToString();
                    deleteRecord(int.Parse(id));
                    break;
            }
        }
    }
}