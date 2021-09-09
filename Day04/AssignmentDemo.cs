using System;
using SampleConApp.Day02;

namespace SampleConApp.Day04
{
    class Employee
    {
        public DateTime EmpDateOfBirth { get; set; }
        public string EmpAddress { get; set; }
        public string EmpName { get; set; }
        public int EmpID { get; set; }
    }

    class AssignmentDemo
    {
        static Employee createEmployee()
        {
            var empId = MyConsole.GetNumber("Enter the ID for the Employee");
            var empName = MyConsole.GetString("Enter the Name");
            var empAddress = MyConsole.GetString("Enter the Address for the Employee");
            var dob = MyConsole.GetDate("Enter the date");
            var empObj = new Employee
            {
                EmpAddress = empAddress,
                EmpDateOfBirth = dob,
                EmpID = empId,
                EmpName = empName
            };
            return empObj;
        }
        static void Main(string[] args)
        {
            //var empObj = createEmployee();            
            //Console.WriteLine($"The name of the Employee entered is {empObj.EmpName} from {empObj.EmpAddress} whose date of birth is {empObj.EmpDateOfBirth.ToLongDateString()} and has his Employee ID as {empObj.EmpID}");

            //Employee[] employees = new Employee[2];
            //for (int i = 0; i < 2; i++)
            //{
            //    employees[i] = createEmployee();
            //}
            ////for and foreach loop to read the data.
            //foreach(var emp in employees)
            //    Console.WriteLine(emp.EmpName);

            //To Do: Find the si of a principal: p t r/100
            double principal = MyConsole.GetDouble("Enter the Principal Amount");
            double term = MyConsole.GetDouble("Enter the Term as 0.5 for half yearly and so forth");
            double rate = MyConsole.GetDouble("Enter the rate of interest");
            double interest = principal * term * rate;
            Console.WriteLine("The SI is " + interest);
        }
    }
}
