using System;
namespace SampleConApp
{
    class DataConversionDemo
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter the Date of Birth as dd/MM/yyyy");
            //string dob = Console.ReadLine();

            //DateTime dt = DateTime.Parse(dob);//Function used to Convert string to a valid Date
            //int age = DateTime.Now.Year - dt.Year;//Difference in Years of 2 given Dates
            //Console.WriteLine("UR age is currently " + age + " Years");


            //---------------------using TryParse--------------------------------------------------
        //    int age;
        //RETRY:
        //    Console.WriteLine("Enter the Age");
        //    if(!int.TryParse(Console.ReadLine(), out age))
        //    {
        //        Console.WriteLine($"U R supposed to enter a whole number ranging from {int.MinValue} and {int.MaxValue}");
        //        goto RETRY;
        //    }
        //    Console.WriteLine($"The age is {age}");//New in C# 5.0
            //---------------------using Compare method-------------------------------
            int value1 = 234;
            int value2 = 555;
            int comparison = value1.CompareTo(value2);
            if (comparison == 0)
            {
                Console.WriteLine("They are equal");
            }else if(comparison < 0)
                Console.WriteLine("value 1 is lesser than value 2");
            else
                Console.WriteLine("value 1 is greater than value 2");
            
        }//Try creating the same program using string and try to find the reason of using specific data types. 
        //Try an example that displays the range of all Integral and Floating types. byte, short, int, long, float, double, decimal

    }
}
//mailto:phani.blrtraining@gmail.com
/*
 * Intro to .NET Framework
 * Architecture of .NET
 * CLR vs CLS cs. FCL.
 * Intro to VS.
 * How to create Solutions/Projects.
 * C# Basics
 * Data types and Data Type Conversions.
 * System.object: Boxing and Unboxing. 
 */
/*Tomorrow's topics
 * Functions in a class.
 * Arrays. 
 * Enums.
 * DateTime.
 * Strings
 * Intro to Classes and Objects.
 */