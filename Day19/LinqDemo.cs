using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
//Traditional LINQ does not have APIs to  insert, delete or update. All LINQ operations are done on IEnumerable objects which are forward only and read only. LINQ is used mainly to query the data, not to perform the Data manipulation. 
//In .NET 3.5, LINQ was extended on XML and SQL. With these new extensions, we can perform all kinds of operations including data manipulations. 

namespace SampleDBApp.Day19
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }
        public int DeptID { get; set; }
    }
    class Dept
    {
        public string DeptName { get; set; }
        public int DeptId { get; set; }
    }


    static class FileData
    {
        const string filename = @"C:\Users\phani\source\repos\Fidelity Training\SampleDBApp\bin\Debug\EmpData.csv";
        public static List<Employee> GetAllEmployees()
        {
            if (!File.Exists(filename))
                throw new FileNotFoundException("DataSource not found");
            var list = new List<Employee>();
            var lines = File.ReadAllLines(filename);
            foreach(var line in lines)
            {
                var words = line.Split(',');
                var emp = new Employee
                {
                    EmpID = int.Parse(words[0]),
                    EmpName = words[1],
                    EmpSalary = int.Parse(words[3]),
                    EmpCity = words[2]
                };
                list.Add(emp);
            }
            return list;
        }
    }
    class LinqDemo
    {
        static List<Employee> theList = FileData.GetAllEmployees();
        static void Main(string[] args)
        {
            //readOnlyNames();
            //readNamesWithCity();
            //whereClauseExample();
            //orderByClause();
            //groupByClause();
        }

        private static void groupByClause()
        {
            var groups = from emp in theList
                         group emp.EmpName by emp.EmpCity into gr
                         orderby gr.Key
                         select gr;
            //nested loop iterate thro the groups and in each group another iteration
            foreach(var gr in groups)
            {
                Console.WriteLine("The City: " + gr.Key);
                foreach(var name in gr)
                    Console.WriteLine(name);
                Console.WriteLine("------------------------------------");
            }
        }

        private static void orderByClause()
        {
            var results = from emp in theList
                          orderby emp.EmpCity descending
                          select emp.EmpCity;
            foreach (var item in results.Distinct())//Display only distinct Cities in the collection. 
            {
                Console.WriteLine(item);
            }
        }

        private static void whereClauseExample()
        {
            var data = from emp in theList
                       where emp.EmpCity == "Chennai" && emp.EmpName.StartsWith("C")
                       select emp.EmpName;
            foreach (var name in data) Console.WriteLine(name);
        }

        private static void readNamesWithCity()
        {
            var data = from emp in theList
                        select new { Name = emp.EmpName, Address = emp.EmpCity };
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Name} from {item.Address}");
            }
        }

        private static void readOnlyNames()
        {
            var names = from emp in theList
                        select emp.EmpName;  //SELECT EMPNAME FROM THELIST...
            //LINQ query will always result a IEnumerable object which when iterated, will read the data.
            foreach (var name in names) Console.WriteLine(name);
        }
    }
}
