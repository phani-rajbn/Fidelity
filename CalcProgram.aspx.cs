using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SampleWebApp
{
    public partial class CalcProgram : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Event handler for the action done by the user.
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            //take the values entered by the user..
            var firstValue = double.Parse(txtFirst.Text);
            var secondValue = double.Parse(txtSecond.Text);
            var operation = dpList.SelectedValue;
            var result = getResult(firstValue, secondValue, operation);
            lblDisplay.Text = result.ToString();
        }
        //helper function to get the computed value based on the selected operation
        private double getResult(double firstValue, double secondValue, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstValue + secondValue;
                case "-":
                    return firstValue - secondValue;
                case "X":
                    return firstValue * secondValue;
                case "/":
                    return firstValue / secondValue;
            }
            return 0;
        }
    }
}
/*
 Create a new aspx page to display all the Names from the employees table using linq to sql. 
  HINT: Write the code in the Page_Load event.
    Create a helper function that returns a List<String> that contain the nams of the employees from the database using LINQ to SQL or Connected ADO.NET Data Access model.
    The data should be displayed on the listbox.
*/