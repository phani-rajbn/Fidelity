using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
namespace SampleFrameworkApp.Day13
{
using System.Xml.Linq;
    using SampleFrameworkApp.Day11;
    class EmpComponent : IEmpDatabase
    {
        private string filename = "Employees.bin";
        private List<Day11.Employee> _list = new List<Day11.Employee>();
        //constructor to serialize the data first....
        public EmpComponent()
        {
            if (File.Exists(filename))
                deserialize();
            else
                serialize();
        }
        private void serialize()
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter fm = new BinaryFormatter();
            fm.Serialize(fs, _list);//data is boxed and serialized..
            fs.Close();
        }

        private void deserialize()
        {
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter fm = new BinaryFormatter();
            _list = fm.Deserialize(fs) as List<Day11.Employee>;//Unbox the Deserialized data....
            fs.Close();
        }
        //We also have Employee in Day13, so specifically we tell that its Day11.Employee. 
        public void AddEmployee(Day11.Employee emp)
        {
            _list.Add(emp);
            serialize();
        }

        public void DeleteEmployee(int id)
        {
            deserialize();
            var rec = _list.Find((e) => e.EmpID == id);
            _list.Remove(rec);
            serialize();
        }

        public Day11.Employee Find(int id)
        {
            deserialize();
            var rec = _list.Find((e) => e.EmpID == id);
            return rec;
        }

        public List<Day11.Employee> Find(string name)
        {
            deserialize();
            if (string.IsNullOrEmpty(name)) return _list;
            return _list.FindAll((e) => e.EmpName.Contains(name));
        }

        public List<Day11.Employee> FindByAddress(string address)
        {
            deserialize();
            return _list.FindAll((e) => e.EmpAddress.Contains(address));
        }

        public void UpdateEmployee(Day11.Employee emp)
        {
            deserialize();
            var rec = Find(emp.EmpID);
            rec.EmpName = emp.EmpName;
            rec.EmpAddress = emp.EmpAddress;
            rec.EmpSalary = emp.EmpSalary;
            serialize();
        }
    }
    class Assignment
    {
        static void Main(string[] args)
        {
            var com = new EmpComponent();
            //com.AddEmployee(new Day11.Employee { EmpAddress = "Bangalore", EmpID = 123, EmpSalary = 56000, EmpName = "Gopal" });
            //com.AddEmployee(new Day11.Employee { EmpAddress = "Mysore", EmpID = 124, EmpSalary = 40000, EmpName = "Ramesh" });
            //com.AddEmployee(new Day11.Employee { EmpAddress = "Bangalore", EmpID = 125, EmpSalary = 30000, EmpName = "Sunder" });
            //com.AddEmployee(new Day11.Employee { EmpAddress = "Chennai", EmpID = 126, EmpSalary = 67000, EmpName ="Swetha" });
            var recs = com.Find("eth");
            foreach (var rec in recs) Console.WriteLine(rec);
        }
    }
}
