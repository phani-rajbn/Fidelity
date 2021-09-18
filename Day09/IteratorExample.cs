using System;
using System.Collections;
using System.Collections.Generic;

namespace SampleFrameworkApp.Day09
{
    class Test : IComparable<Test>
    {
        public int ID;
        public string Name;

        public int CompareTo(Test other)
        {
            if (ID == other.ID)
                return 0;
            else if (ID > other.ID)
                return 1;
            else
                return -1;
        }
    }

    class TestCollection : IEnumerable<Test>
    {
        private List<Test> tests = new List<Test>();
        public void AddTest(Test t) => tests.Add(t);

        public IEnumerator<Test> GetEnumerator()
        {
            return tests.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Count { get => tests.Count; }

        public Test this[int index] 
        {
            get
            {
                return tests[index];
            } 
        }

        public Test this[string name]
        {
            get
            {
                foreach (var test in tests)
                {
                    if (test.Name == name) return test;
                }
                throw new Exception("Test not found");
            }
        }

        public List<Test> Sort()
        {
            tests.Sort();
            return tests;
        }
    }

    class IteratorExample
    {
        static void Main(string[] args)
        {
            TestCollection tests = new TestCollection();
            tests.AddTest(new Test { ID = 125, Name = "Cobal Test" });
            tests.AddTest(new Test { ID = 126, Name = "C++ Test" });
            tests.AddTest(new Test { ID = 127, Name = "C Test" });
            tests.AddTest(new Test { ID = 123, Name = "C# Test" });
            tests.AddTest(new Test { ID = 124, Name = "Java Test" });
            Console.WriteLine("---------------Before Sorting---------------");
            for (int i = 0; i < tests.Count; i++)
            {
                Console.WriteLine(tests[i].Name);
            }
            var sortedData = tests.Sort();
            Console.WriteLine("---------------After Sorting---------------");

            foreach (var test in sortedData) Console.WriteLine($"TestID: {test.ID} and Name:{test.Name}");

            //List<int> integers = new List<int>(new int[] { 345,567,563,345,5345,24,35,56,76,768,678});
            //integers.Sort();
            //foreach (var no in integers) Console.WriteLine(no);
        }
    }
}
