using System;
using System.Collections.Generic;
using System.IO;
namespace SampleFrameworkApp.Day11
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }

        public override string ToString()
        {
            return $"{EmpID},{EmpName},{EmpAddress},{EmpSalary}";
        }
    }

    interface IEmpDatabase
    {
        void AddEmployee(Employee emp);
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int id);
        Employee Find(int id);
        List<Employee> Find(string name);
        List<Employee> FindByAddress(string address);
    }

    class FileEmpDB : IEmpDatabase
    {
        private List<Employee> employees = null;
        private string fileName = "employees.csv";
        private void saveRecords()
        {
            string data = string.Empty;//create a string that is empty. 
            foreach (var emp in employees)//iterate thro the list and append the string with the data.
                data += emp.ToString() + "\n";
            File.WriteAllText(fileName, data); //Rewrite the whole file for the records.
        }
        public void loadRecords()
        {
            employees = new List<Employee>();
            var arrayOfLines = File.ReadAllLines(fileName);//Reads each line in the file and stores into an array.
            foreach(var line in arrayOfLines)//iterate thro each line
            {
                var words = line.Split(',');//split the line into words
                var emp = new Employee
                {
                    EmpID = int.Parse(words[0]),//1st word is EmpID
                    EmpName = words[1],//2nd Word is EmpName
                    EmpAddress = words[2],//3rd is EmpAddress
                    EmpSalary = double.Parse(words[3])//4th is EmpSalary
                };
                employees.Add(emp);//Add the created Employee into the collection object.
            }
        }
        public FileEmpDB()
        {
            employees = new List<Employee>();
        }
        public void AddEmployee(Employee emp)
        {
            if (emp == null) throw new Exception("Employee details must be set");
            File.AppendAllText(fileName, emp.ToString() +"\n"); //Creates a file if it does not exist.
        }

        public void DeleteEmployee(int id)
        {
            loadRecords();
            var rec = Find(id);
            employees.Remove(rec);
            saveRecords();
        }

        public Employee Find(int id)
        {
            loadRecords();
            var rec = employees.Find((e) => e.EmpID == id);
            if (rec == null) throw new Exception("Employee not found");
            return rec;
        }

        public List<Employee> Find(string name)
        {
            loadRecords();
            var records = employees.FindAll((e) => e.EmpName.Contains(name));
            return records;
        }

        public List<Employee> FindByAddress(string address)
        {
            loadRecords();
            var records = employees.FindAll((e) => e.EmpAddress.Contains(address));
            return records;
        }

        public void UpdateEmployee(Employee emp)
        {
            loadRecords();
            //code to update the specific record
            saveRecords();
        }
    }
    class FileAssignment
    {
        //Helper function to take inputs from the user and return a valid Employee object. 
        static Employee createEmployee()
        {
            var id = MyConsole.GetNumber("Enter the Emp ID");
            var name = MyConsole.GetString("Enter the name");
            var address = MyConsole.GetString("Enter the Address");
            var salary = MyConsole.GetDouble("Enter the Salary");
            return new Employee { EmpAddress = address, EmpID = (int)id, EmpName = name, EmpSalary = salary };
        }
        static void Main(string[] args)
        {
            Employee emp = createEmployee();
            IEmpDatabase db = new FileEmpDB();
            db.AddEmployee(emp);
        }
    }
}

//Create a BookStore application or reimplement the bookstore interface to store the data in the form of CSV file.
//Create a new class that implements IBookStore with the feature of file saving as CSV. The data should be stored in one single CSV file.  
//Data will be stored as CSV and read as object list. 
/*
 * Multi Threading.
 */