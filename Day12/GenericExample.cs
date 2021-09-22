using System;
using System.IO;
using System.Collections.Generic;
//Generic class in .NET is similar to templates of C++. It allows to create classes that can work on multiple datatypes in mind. Generic means generic form that can be applied on different kinds of data. U can have generic classes, methods, interfaces, delegates and even operators. 
//U define a Generic Type using <T> where T stands for TypeName.
//Allows high end of reusability. They are type safe. U get compile errors if the data types dont match and avoid lot of exception handling. As no conversion is involved, performance will be high as no BOXING and UNBOXING is required. 
namespace SampleFrameworkApp.Day12
{
    class DataStore<T> where T : class//Custom class created to work any kind of data. T represents any kind of data type <T> means data type. very similar to C++ templates.
    {
        List<T> data = new List<T>();
        public void Add(T a)
        {
            data.Add(a);
            File.AppendAllText("Data.txt", (a.ToString() +"\n"));
        }

        public void Delete(T a)
        {
            data.Remove(a);
            //ToDo: delete the record the file also....
        }

        public T Find(T a)
        {
            return data.Find((obj) => obj.Equals(a));
        }
        public List<T> GetAll()
        {
            var lines = File.ReadAllLines("Data.txt");
            List<T> temp = new List<T>();
            foreach(var line in lines)
            {
                temp.Add((T)Convert.ChangeType(line, typeof(T)));
            }
            return temp;
        }
    }
    class GenericExample
    {
        static void Main(string[] args)
        {
            DataStore<string> fruits = new DataStore<string>();
            //fruits.Add("Apples" + "\n");
            //fruits.Add("Mangoes" + "\n");
            //fruits.Add("Oranges" + "\n");
            //fruits.Add("Bananas" + "\n");
            //fruits.Add("Grapes(G)" + "\n");
            //fruits.Add("Grapes(P)" + "\n");
            //fruits.Add("Kiwi" + "\n");
            var data = fruits.GetAll();
            foreach (var item in data) Console.WriteLine(item);
        }
    }
}
