using System;
using System.Linq;
using System.Xml.Linq;
//LINQ to SQL is a ORM framework for interacting with SQL server. Object relational mapping allows programmers to access the databases without a need of any SQL based language. they use object oriented classes to represent data and collections to store large amount of data. The ORM will have APIs to do all kinds of CRUD operations and query based functions. 
//2 ORM Frameworks in .NET: LINQ to SQL and Entity Framework(MVC). LINQ To SQL is used only if U have SQL server in Ur application and Entity framework is used all kinds of databases.
//DataContext class will be the name of the DBML file suffixed with DataContaxt. DataContext is the LINQ provided class that connects to the database and does all the operations. 
namespace SampleDBApp.Day20
{
    class LINQToSQLDemo
    {
        static DataManagerDataContext context = new DataManagerDataContext();
        static void Main(string[] args)
        {
            //firstDemo();
            //showEmployeesWithDept();
            //showEmployeesOfDept("Developement");
            //orderbyFirstLetter();
            //insertRecord();
            //insertBulkRecords();
            //deleteRecord();
            //updateRecords();
        }

        private static void updateRecords()
        {
            var empData = context.Employees.Where((e) => e.DeptId == 2).ToList();
            for (int i = 0; i < empData.Count; i++)
            {
                if (i % 3 == 0)
                    empData[i].DeptId = 3;
                else
                    empData[i].DeptId = 5;
            }
            context.SubmitChanges();
        }

        private static void deleteRecord()
        {
            /*
             * Take input for the Id to delete.
             * query to find the record with matching id.
             * call the deleting api of LINQ.
             * save the changes
             * take break after this
             */
            int id = 6;
            //var rec = (from emp in context.Employees
            //           where emp.EmpID == id
            //           select emp).SingleOrDefault();
            var rec = context.Employees.FirstOrDefault((e) => e.EmpID == id);
            if (rec == null) Console.WriteLine("This rec does not exist");
            else
            {
                context.Employees.DeleteOnSubmit(rec);
                context.SubmitChanges();
                Console.WriteLine("Employee deleted");
            }
            
        }

        /*
* Windows 10 with 8GB RAM and Admin Rights.
* Visual Studio Community 2019.
* SQL Server Express Edition. 
* VS Code
*/
        private static void insertBulkRecords()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            var records = (from element in doc.Descendants("Employee")
                           select new Employee
                           {
                               DeptId = 2,
                               EmpAddress = element.Element("EmpCity").Value,
                               EmpSalary = int.Parse(element.Element("EmpSalary").Value),
                               EmpName = element.Element("EmpName").Value
                           }).Take(20);
            context.Employees.InsertAllOnSubmit(records);
            context.SubmitChanges();
        }

        private static void insertRecord()
        {
            //create the employee object to add...
            var emp = new Employee { DeptId = 1, EmpAddress = "Mysore", EmpName = "Sudharshan", EmpSalary = 50000 };
            context.Employees.InsertOnSubmit(emp);//add the employee object to the employees collection of the context.
            context.SubmitChanges();//Commit the operation. 
        }

        private static void orderbyFirstLetter()
        {
            var groups = from emp in context.Employees
                         group emp by emp.EmpName[0] into g
                         orderby g.Key
                         select g;
            foreach(var gr in groups)
            {
                Console.WriteLine("Employee Names starting with letter: " + gr.Key);
                foreach (var emp in gr)
                {
                    Console.WriteLine($"{emp.EmpName} from {emp.EmpAddress}");
                }
            }
        }

        private static void showEmployeesOfDept(string deptName)
        {
            var result = (from dept in context.Depts
                         where dept.DeptName == deptName
                         select dept.Employees).FirstOrDefault();
            foreach(var emp in result)
                Console.WriteLine(emp.EmpName);
        }

        private static void showEmployeesWithDept()
        {
            var result = from emp in context.Employees
                         select new
                         {
                            Name = emp.EmpName,
                            Dept = emp.Dept.DeptName
                         };
            foreach (var res in result) Console.WriteLine(res);
        }

        private static void firstDemo()
        {
            var data = from cst in context.Customers
                       where cst.City == "Bangalore"
                       orderby cst.CustomerName descending
                       select cst.CustomerName;
            foreach (var name in data) Console.WriteLine(data);
        }
    }
}
