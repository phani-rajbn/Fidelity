using System;
using System.Linq;
//After .NET 2.0, a major change occured in the Windows and .NET. From GDI, Windows moved to DirectX, a rich graphical User interface based on COM. WindowsXP to Windows 7 migration was on major step. Similarly in .NET, 3.0 and 4.0 were the major change that happened in .NET. It started with .NET 3.0, 3.4 and finally into .NET 4.0.
//With respect to C# language, many new features were added to adapt to the new OS and its powerfull features. 
namespace SampleDBApp.Day19
{
    static class MyExtensionMethods
    {
        public static int GetNoOfWords(this string arg)
        {
            string[] words = arg.Split(' ', '.');
            return words.Length;
        }
    }
    class NewFeatures
    {
        static void Main()
        {
            //varKeyword();
            //anonymousTypes();
            //lamdbaExpressions();
           //extensionMethods();
            //linqDemo();
        }

        private static void linqDemo()
        {
            var data = new string[]// A collection object
            {
                "Apples", "Mangos", "Oranges"
            };
            var results = from f in data //query based in C# language to get the data from the collection.
                          select f;
            foreach (var f in results) Console.WriteLine(f);
        }
        //mockaroo, download data for id, fullname, salary, city.
        //Read the CSV file and convert into List<Employee>. 
        //extension methods provides a mechanism of adding new methods to a class without breaking it. However it is not the part of any OOP features. It is not recommended to go for extension methods unless U have a valid reason to do so. In the example, string is a sealed class and I want a method to be added to all instances of the string within my project
        private static void extensionMethods()
        {
            string content = "The two submarines of the U-1";
            //Get the number of words for a given string. 
            var count = content.GetNoOfWords();
            Console.WriteLine("The no of words: " + count);
        }

        private static void lamdbaExpressions()
        {
            //lambda Expressions is a substitute for creating methods for delegate objects without a need of exclusive functions. 
            Action action = () => Console.WriteLine("Welcome to Lambda Expressions");
            Action<int> intAction = (i) => Console.WriteLine("The value passed is " + i);
            Func<double, double, double> addFunc = (v1, v2) => v2 + v1;
            action();
            intAction(123);
            var res = addFunc(123, 234);
            Console.WriteLine("The result is " + res);
        }

        private static void anonymousTypes()
        {
            //similar to Javascript objects we can create objects without a name.
            var empDetails = new
            {
                Empname = "Phaniraj", EmpAddress = "Bangalore", EmpSalary = 56000, JoinDate = DateTime.Now.AddDays(-895)
            };//created an object of an unknown type with only properties in it. They are like data carriers in OO Design patterns. The objective of this object is to carry data in it. Hense the name data carriers. 
            Console.WriteLine(empDetails);
            Console.WriteLine(empDetails.Empname);
            Console.WriteLine(empDetails.EmpAddress);
            Console.WriteLine(empDetails.EmpSalary);
            Console.WriteLine(empDetails.JoinDate.ToShortDateString());
        }

        private static void varKeyword()
        {
            //var is a keyword in C# to create local variables. It is also called Implicitly typed variables. var allows to declare local variables with strict typechecking. It works like object by storing any kind of data it wants, but without boxing and unboxing. Once the value is assigned to the var, it will hold that type and follows all the rules of type safety. 
            //var is used to create local variables only. it cannot be used as return type of a function, parameters for a function, fields of a class or any other kind. var variable declaration and the assignment to it should happen in the same statement. 
            //var provides a convinient way of creating local variables without a need to specify the type. 
            var fruit = "Apple";//string. Once created as string, it will be typed variable and follows all the rules of the string class. 
            fruit = 123.ToString();//int cannot be converted to string
            Console.WriteLine(fruit.GetType().Name);
        }
    }
}

