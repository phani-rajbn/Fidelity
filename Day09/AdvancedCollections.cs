/*This example will explore concepts related to Collection interfaces, indexers etc.*/
using System;
using System.Collections;
using System.Collections.Generic;
/*
 * An object of a class can be used in a foreach statement only if it is a collection class. 
 * A class becomes a collection if it implements an interface called IEnumerable<T>. An ability to enumerate(Move forward one at a time within the bounds) is achieved using this interface. 
 */
namespace SampleFrameworkApp.Day09
{
    //A Class implements a IComparable<T> if it wants its objects to compared with other. This will help them in sorting the objects at run time...
    class Person : IComparable<Person>
    {
        public int Id, Salary;
        public string Name;

        public int CompareTo(Person other)
        {
            //-1(Current object is lower), 0(both are equal), 1 (Current object is higher)
            if (Salary < other.Salary)//the current object's salary is smaller than the other
                return -1;
            else if (Salary > other.Salary)//the current object's salary is greater than the other
                return 1;
            else
                return 0;//they are same
        }

        public override string ToString()
        {
            return $"Name:{Name} Salary:{Salary:C}";
        }
    }

    class PersonDB : IEnumerable<Person>
    {
        public IEnumerator<Person> GetEnumerator()//Implicit for IEnumerable<T>
        {
            return _persons.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()//Explicit implementation for IEnumerable 
        {
            foreach (var person in _persons)
                yield return person;//yeild is a keyword to return the iterator of the Person.
        }

        private List<Person> _persons = new List<Person>();
        public void AddPerson(int id, string name, int salary)
        {
            var person = new Person { Id = id, Name = name, Salary = salary };
            _persons.Add(person);
        }

        public int Total { get => _persons.Count; }//New in C# 7.0
        //Indexer is more like a property It will have get and set. Name will always be the instance.
        //name of the indexer will always be this operator(Current instance)
        public Person this[int index]
        {
            get
            {
                if (index < 0 || index >= _persons.Count)
                    throw new IndexOutOfRangeException("Index is out of Range");
                return _persons[index];
            }
        }
        //U can overload the indexer. 
        public Person this[string name]
        {
            get 
            {
                foreach(var p in _persons)
                {
                    if (p.Name == name) return p;
                }
                throw new IndexOutOfRangeException("Name not found");
            }
        }

        /// <summary>
        /// Gets a sorted list of persons based on default sorting. In this case, Salary.
        /// </summary>
        /// <returns>A New List of Person sorted by Salary</returns>
        /// <exception cref="System.Exception"/>
        public List<Person> Sort()
        {
            _persons.Sort();//Looks for comparing the objects and determine the status of it. 
            return _persons;
        }
       
    }

    class AdvancedConcepts
    {
        static void Main(string[] args)
        {
            //iteratorExample();
            PersonDB db = new PersonDB();
            db.AddPerson(123, "Phaniraj", 45000);
            db.AddPerson(124, "Ram", 35000);
            db.AddPerson(125, "Shiva", 40000);
            db.AddPerson(126, "Gowri", 55000);
            db.AddPerson(127, "Sita", 76000);
            //Need to sort the Persons in the collection based on Salary....
            var list = db.Sort();
            foreach (var item in list) Console.WriteLine(item);
        }

        private static void iteratorExample()
        {
            var db = new PersonDB();//I want db object to be used like an array using [] operator
            db.AddPerson(123, "Phaniraj", 45000);
            db.AddPerson(124, "Ram", 35000);
            db.AddPerson(125, "Shiva", 40000);
            db.AddPerson(126, "Gowri", 55000);
            db.AddPerson(127, "Sita", 76000);
            Console.WriteLine($"The no of people here: {db.Total}");
            for (int i = 0; i < db.Total; i++)
            {
                Console.WriteLine(db[i].Name);
            }
            Console.WriteLine("------------Using foreach----------------");
            foreach (var person in db) Console.WriteLine(person);
            Console.WriteLine("-------------Using Iterator------------");
            var iterator = db.GetEnumerator();
            while (iterator.MoveNext()) //Move to the next record at a time until it reaches the end.....
                Console.WriteLine(iterator.Current);//Current will give U the current record in the cursor....
        }
    }
}
/*
 * What is a collection and Generic collection
 * List vs HashSet
 * Dictionary
 * Stack vs Queue
 * Indexers for a class.
 * IEnumerable vs IEnumerator. 
 * IComparable vs. IComparer
 * Custom Collections.
 */