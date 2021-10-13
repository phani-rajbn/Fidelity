using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class EmpClass
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public int EmpSalary { get; set; }
        //Should not mix the html and C# code.
        //public override string ToString()
        //{
        //    return $"<h1>Name:{EmpName}</h1><hr/><p>{EmpName} is from {EmpAddress}</p><hr/><p><i>Powered by ASP.NET MVC-{DateTime.Now.Year}</i></p>";
        //}
    }
}