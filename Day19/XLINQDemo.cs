using System;
using System.Linq;
using System.Xml.Linq;

namespace SampleDBApp.Day19
{
    class XLINQDemo
    {
        static void Main()
        {
            //convertListToXml();
            //displayNamesFromFile();
            //displayNamesAndSalaryFromFile();
            //insertEmployeeToXml();
            //insertEmployeeToXmlById();
            //deleteEmployeeInXmlById();
        }

        private static void deleteEmployeeInXmlById()
        {
            Console.WriteLine("Enter the ID of the Employee to delete");
            string id = Console.ReadLine();
            XDocument doc = XDocument.Load("Employees.xml");
            var foundElement = (from element in doc.Descendants("Employee")
                                where element.Element("EmpID").Value == id
                                select element).SingleOrDefault();
            foundElement.Remove();//Delete the Element. 
            doc.Save("Employees.xml");
        }

        private static void insertEmployeeToXmlById()
        {
            Console.WriteLine("Enter the ID of the Employee where U want to add");
            string id = Console.ReadLine();
            XDocument doc = XDocument.Load("Employees.xml");
            var selectedElement = (from element in doc.Descendants("Employee")
                          where element.Element("EmpID").Value == id
                          select element).FirstOrDefault();
            if(selectedElement == null)
            {
                Console.WriteLine("No element found");
            }
            else
            {
                var newElement = new XElement("Employee",
                        new XElement("EmpID", 502),
                        new XElement("EmpName", "Rahul"),
                        new XElement("EmpCity", "Bangalore"),
                        new XElement("EmpSalary", 75000)
                    );
                selectedElement.AddAfterSelf(newElement);
                doc.Save("Employees.xml");
            }
        }

        private static void insertEmployeeToXml()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            //where to insert: At the last..
            var last = doc.Descendants("Employee").Last();
            //data to insert
            var element = new XElement("Employee",
                        new XElement("EmpID", 501),
                        new XElement("EmpName", "Sachin"),
                        new XElement("EmpCity", "Mumbai"),
                        new XElement("EmpSalary", 65000)
                        );
            //insert the record
            last.AddAfterSelf(element);//adds the element after the last
            //save to the file.
            doc.Save("Employees.xml");
            //try to insert the record based in the id.
        }

        private static void displayNamesAndSalaryFromFile()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            var results = from element in doc.Descendants("Employee")
                          select new
                          {
                              Name = element.Element("EmpName").Value,
                              Salary = element.Element("EmpSalary").Value
                          };
            foreach (var emp in results) Console.WriteLine(emp);
        }

        private static void displayNamesFromFile()
        {
            XDocument doc = XDocument.Load("Employees.xml");
            var elements = from element in doc.Descendants("Employee")
                           select element.Element("EmpName");
            foreach (var element in elements) Console.WriteLine(element.Value);
        }

        //Example to convert List<Employee> to Xml data using XLINQ. 
        private static void convertListToXml()
        {
            var data = FileData.GetAllEmployees();//List of Employee objects.
            var root = new XElement("ListOfEmployees", from emp in data
                                                       select new XElement("Employee",
                                                       new XElement("EmpID", emp.EmpID),
                                                       new XElement("EmpName", emp.EmpName),
                                                       new XElement("EmpCity", emp.EmpCity),
                                                       new XElement("EmpSalary", emp.EmpSalary)
                                                       ));
            root.Save("Employees.xml");
        }
    }
}
