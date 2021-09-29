using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDBApp.Day19
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public int EmpSalary { get; set; }
    }
    static class FileData
    {
        const string filename = @"../../Day19/EmpData.csv";
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
            foreach(var emp in theList)
                Console.WriteLine(emp.EmpName);
        }
    }
}
