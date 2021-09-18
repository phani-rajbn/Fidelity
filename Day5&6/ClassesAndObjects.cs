using System;
namespace SampleTestApp
{
    /*
     * Class is a UDT to represent data of the real world in ur code.
     * The UDT has to be used like we use variables for the data types. 
     * The variables of a class is called as OBJECT in OOP.
     * The class definition will tell to the system about  the class. But it will not have any memory allocation as such. 
     * 
     */

    class Employee
    {
        //properties are accessors to the hidden data of UR class. set accessor is used internally to set the value and the get is used to read the value
        public int EmpID { get; set; } = 123;
        public string EmpName { get; set; } = "Govinda";
        public string EmpAddress { get; set; } = "Hunsur Road, Mysore";
        public long PhoneNo { get; set; } = 9945205677;
    }
    class ClassDemo
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();//syntax for creating objects in C#...
            emp.EmpAddress = "Bangalore"; //set block
            Console.WriteLine("The Name is " + emp.EmpName);//get block  
            //Try to create 2 or more employee objects...
            //Try the object initialization syntax using {}
            Employee temp = new Employee
            {
                EmpID = 111, 
                EmpName ="Shreyas", 
                EmpAddress ="Hebbal, Bangalore", 
                PhoneNo = 55523434 
            };
            //Console.WriteLine($"The name of the Employee is {temp.EmpName} from {temp.EmpAddress} and can be reached out on {temp.PhoneNo}");
            Console.WriteLine("The name of the Employee is {0} and {0} stays in {1} and can be reached out on {2}", temp.EmpName, temp.EmpAddress, temp.PhoneNo);
        }
        /*
         * Create a class called Book, with properties as BookTitle, BookAuthor, BookPrice and BookID.
         * Create the object of the Book class and take inputs from the user and display the details of the Book on Console using the $ syntax.. 
         * Create 5 such book objects and display them one after the other.
         * 2 States, A Suitable Boy, Romeo and Juliet, King Lear, Oliver Twist. 
         * Join by 11:45 AM
         * 
         */
    }
}