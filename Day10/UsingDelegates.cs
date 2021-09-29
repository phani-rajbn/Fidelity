using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//How to use the builtin delegates provided by .NET
/*
 * Predicate is a predefined Generic delegate of .NET that takes an input parameter of the Generic Type and returns a bool. It is widely used in Collection classes for defining the criteria of finding the elements. It is also used in scenarios where U need to check if the passed parameter meets the criteria, if so returns true, else false. 
 */
namespace SampleFrameworkApp.Day10
{
    class UsingDelegates
    {
        //static List<string> FindFruits(string name)
        //{
        //    List<string> fruits = new List<string> { "Apples", "Mangoes", "Banana", "Pineapple" };
        //    List<string> temp = new List<string>();
        //    foreach (var fruit in fruits)
        //    {
        //        if (fruit.Contains(name)) temp.Add(fruit);
        //    }
        //    return temp;
        //}
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the fruitName to search");
            var name = Console.ReadLine();
            var found = FindFruits(name);
            foreach (var fr in found) Console.WriteLine( fr);
        }
        /////////////////////////////Anonymous Methods/////////////////////////////////////////
        //static List<string> FindFruits(string name)
        //{
        //    List<string> fruits = new List<string> { "Apples", "Mangoes", "Banana", "Pineapple" };
        //    Predicate<string> predicate = delegate (string fruitName)
        //    {
        //        return fruitName.Contains(name);
        //    };//Anonymous method in C# 4.0.....
        //    var temp = fruits.FindAll(predicate);
        //    return temp;
        //}
        //////////////////////////Lambda Expression/////////////////////////////////
        static List<string> FindFruits(string name)
        {
            var fruits = new List<string> { "Apple", "Mango", "Orange", "Banana", "Grapes", "Kiwi" };
            var selected = fruits.FindAll((f) => f.Contains(name));
            return selected;
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
