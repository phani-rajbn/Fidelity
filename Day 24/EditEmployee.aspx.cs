using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace SampleWebApp
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var selectedId = Request.QueryString["EmpId"];
                var table = Session["data"] as DataTable;
                foreach (DataRow row in table.Rows)
                {
                    if (row[0].ToString() == selectedId)
                    {
                        lblEmpId.Text = row[0].ToString();
                        txtName.Text = row[1].ToString();
                        txtAddress.Text = row[2].ToString();
                        txtSalary.Text = row[3].ToString();
                    }
                }
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FidelityDB;Integrated Security=True";
            var query = $"Update Employee set EmpName='{txtName.Text}', EmpAddress='{txtAddress.Text}', EmpSalary='{txtSalary.Text}' where EmpId = '{lblEmpId.Text}'";
            var con = new SqlConnection(connectionString);
            var cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("DisconnectedModel.aspx");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}