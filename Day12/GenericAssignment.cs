using System;
using System.IO;
using System.Collections.Generic;

namespace SampleFrameworkApp.Day12
{
    class Employee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public double EmpSalary { get; set; }

        public override string ToString()
        {
            return $"{EmpID}-{EmpName}-{EmpAddress}-{EmpSalary}";
        }
    }

    public class DataException : ApplicationException
    {
        public DataException() { }
        public DataException(string message) : base(message) { }
        public DataException(string message, Exception inner) : base(message, inner) { } 
    }
    //Using constraints so that U can avoid impratical types to be used while working with Generic classes. 
    class DataComponent<T> where T : Employee
    { 
        private List<T> _data = new List<T>();
        public void AddRecord(T element)
        {
            if (element == null)
                throw new DataException("No details found to insert");
            _data.Add(element);
            File.AppendAllText("Data.txt", element.ToString());
        }
        public void DeleteRecord(T element)
        {
            loadRecords();
            if(!_data.Remove(element)) throw new DataException("Record not found to delete");
            saveRecords();
        }

        public void UpdateRecord(T element)
        {
            loadRecords();
            var rec = _data.Find((e) => e.EmpID == element.EmpID);
            if (rec == null) throw new DataException("Record not found to update");
            rec.EmpName = element.EmpName;
            rec.EmpAddress = element.EmpAddress;
            rec.EmpSalary = element.EmpSalary;
            saveRecords();
        }

        public List<T> Find(string name)
        {
            loadRecords();
            return _data.FindAll((e) => e.EmpName.Contains(name));
        }

        private void saveRecords()
        {
            var content = string.Empty;
            foreach(var data in _data)
            {
                content += data + "\n";
            }
            File.WriteAllText("Data.txt", content);
        }

        private void loadRecords()
        {
            _data = new List<T>();//Make the existing collection empty.
            var lines = File.ReadAllLines("Data.txt");//Get the data from the text file as lines
            foreach(var line in lines)//iterate thro the lines to access each line
            {
                var words = line.Split('-');//Split each line based on -
                T info = (T)new Employee//Create the T object based in the words...
                {
                    EmpID = Convert.ToInt32(words[0]),
                    EmpAddress = words[2],
                    EmpName = words[1],
                    EmpSalary = Convert.ToDouble(words[3])
                };
                _data.Add(info);//Add the created T object into the collection
            }
        }
    }
    //Complete the other part of the assignment. 
    class GenericAssignment
    {
        static DataComponent<Employee> employees = new DataComponent<Employee>();
        static void Main(string[] args)
        {
            employees.AddRecord(new Employee { EmpID = 123, EmpAddress = "Bangalore", EmpName = "Phaniraj", EmpSalary = 67000 });
        }
    }
}
/**
 *Reflection
 *Serialization.
 *Recap of Frameworks
 *Thursday: SQL Server PreTest followed by SQL Server
**/
