using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp.Day02
{
    class ObjectsDemo
    {
        static void Main(string[] args)
        {
            //Type Initializer in C# 4.0
            Employee emp = new Employee { EmpID = 111, EmpAddress ="Bangalore", EmpName ="Phaniraj" };//creating object in C#....
            
            Console.WriteLine(emp.EmpID);//get
            Console.WriteLine(emp.EmpName);//get
            Console.WriteLine(emp.EmpAddress);//get
        }
    }
}
//Leaning assignment: SOLID Principles of OOP.
