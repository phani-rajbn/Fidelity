using System;

//U can use the sealed class in the form of association
namespace SampleTestApp.Day07
{
    //sealed class cannot be inherited. Similar to Java's final keyword.
    sealed class TestClass
    {
        public void TestFunc() => Console.WriteLine("Test Func");
    }
    //Sealed classes can be reused only in the form of association. 
    class TestClass2
    {
        private static TestClass cls = new TestClass();
        public void TestFunc()
        {
            cls.TestFunc();
            Console.WriteLine("Add some extra features in it");
        }
    }
    //class TestClass2 : TestClass
    //{

    //}//This will give an error as sealed classes are not inheritable. 

    class SealedClassesDemo
    {
        static void Main(string[] args)
        {
            TestClass2 cls = new TestClass2();
            cls.TestFunc();
        }
    }
}
/*
 * Classes and objects.
 * static and non-static.
 * fields, methods, properties. 
 * Program on creating, using the class in an App
 * Inheritance
 * Compile Time and Runtime Polymorphism.
 * Abstract classes
 * Interfaces
 * Sealed Classes.
 * Exceptions and its handling: System Exception(Exceptions raized by the system) and Application Exception(Custom)
 * try..catch..finally.
 * Custom Exceptions and its usage.
 */