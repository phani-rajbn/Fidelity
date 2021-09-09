using System;
namespace SampleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //int id = 123;
            //string name = "Phaniraj";
            //Console.WriteLine("Hello world!!!");
            //Console.WriteLine("The Name is {0} and ID is {1}" , name ,id); //Old syntax... 
            //Console.WriteLine($"The Name is {name} and ID is {id}"); //New C# 5.0 
            //Console.WriteLine("The Name is {0} and {0}'s ID is {1}", name, id);//Reusing the index again with old syntax.

            //Console.WriteLine("Enter UR Name please!!!?");
            //string name = Console.ReadLine();

            //Console.WriteLine("Enter UR Address");
            //string address = Console.ReadLine();

            //Console.WriteLine("Enter the Salary");
            //string salary = Console.ReadLine();

            //Console.WriteLine("The Name is {0} from {1} whose salary is {2}", name, address, salary);

            //////////////Know the different kinds of data types available in C#/////////////////////////
            //Console.WriteLine("Enter UR Name please!!!?");
            //string name = Console.ReadLine();

            //Console.WriteLine("Enter the Salary");
            //double salary = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter the Date of Birth as dd/MM/yyyy");
            //DateTime dt = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("The name is {0} with salary of {1:C} and his DOB is {2}", name, salary, dt.ToString("dd MMM yy"));
            ///////////////////////////Data Operators//////////////////////////////////

            //var addedValue = 123.45 + 234.45;
            //addedValue -= 123;
            //addedValue += (123 * 45);
            //Console.WriteLine(addedValue);
            //Write a Calc Program that will take inputs from the user and displays the data based on the operator selected by the User...
            //////////////////////////////////statements and Expressions/////////////////////////////////////
            //if(true)
            //    Console.WriteLine("I was right");
            //else
            //    Console.WriteLine("I was wrong");
            //Console.WriteLine("Enter the choice");
            //switch (Console.ReadLine())
            //{
            //    case "Apple":
            //        Console.WriteLine("Nice Fruit");
            //        break;
            //    case "Orange":
            //        Console.WriteLine("Citrus Fruit");
            //        break;
            //    default:
            //        Console.WriteLine("Unknown Fruit");
            //        break;//C# does not allow fall thru' Even default should have break.....
            //}
            //////////////////////////////////Arrays//////////////////////////////////////////
            string[] fruits = new string[4];//No elements but only size is allocated.
            for (var i = 0; i < 4; i++)
            {
                RETRY:
                Console.WriteLine("Enter the name of the fruit to add");
                var value = Console.ReadLine();
                if (string.IsNullOrEmpty(value)) {
                    Console.WriteLine("U must set the fruit value");
                    goto RETRY;
                }
                fruits[i] = value;
            }
            int index = 1;
            foreach (var name in fruits)
            {
                if(index == 3)
                {
                    Console.WriteLine("No more reading!!!");
                    return;
                }
                index++;
                Console.WriteLine(name.ToUpper());
            }

            //int[] elements = { 456, 678, 234, 6345, 785, 522, 912, 567 };//Literal values are set, no need to mention the size...
            //Console.WriteLine(elements.Length);
            //for (int i = 0; i < elements.Length; i++)
            //{
            //    Console.WriteLine(elements[i]);
            //}
        }
    }
}
//Assignment: Display your details in multiple lines on the Console. 
//Assigment: Display the details by storing the data as variables and use string format to display them