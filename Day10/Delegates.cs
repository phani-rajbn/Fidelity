using System;
/*
 * It is a reference data type that has a method signature with which U can create variables like a typical data type and use it to refer any method with the same signature. It is similar to Function pointers of C++.
 * A delegate is an object which refers to a method or in other words, It is a reference type variable that can hold references of other methods with the matching signature. 
 * It is used as a scenario where U wish to pass a method as an argument to a function. This is used in callback functions, event handling and many more.
 * In C# U can invoke a method in 3 different ways:
 * Call the method by creating an object of the class if it is a non static function or invoke it using classname if it is a static method. 
 * Create a delegate with the matching signature and call the method thru' the delegate instance. 
 * Using Reflection, where U invoke a method at runtime using Runtime Type Information.
 */
namespace SampleFrameworkApp.Day10
{
    class Arithematic
    {
        public double AddFunc(double v1, double v2) => v1 + v2;
        public double SubFunc(double v1, double v2) => v1 - v2;
        public double MulFunc(double v1, double v2) => v1 * v2;
        public double DivFunc(double v1, double v2) => v1 / v2;
    }

    delegate double MathFunc(double v1, double v2); //2002..
    delegate void StringFunc(string arg);
    class Delegates
    {
        static void DisplayText(string arg)
        {
            Console.WriteLine(arg.ToUpper());
        }
        //To invoke the function U ask to call...
        static void InvokeArithematicFunc(MathFunc func)
        {
            var num1 = MyConsole.GetDouble("Enter the First Value");
            var num2 = MyConsole.GetDouble("Enter the Second Value");
            var result = func(num1, num2);//U R not aware of the actual function when U call it.
            Console.WriteLine("The Result: " + result);
        }

        static void Main(string[] args)
        {
            Arithematic comp = new Arithematic();//Create the instance of Arithematic
            MathFunc func = new MathFunc(comp.MulFunc);//Create the instance of Delegate and point to the function U want to call, in this case, the MulFunc of the Arithematic
            InvokeArithematicFunc(func);//CallBack functions scenario
            InvokeArithematicFunc(comp.AddFunc);//New syntax does not need to create an instace of the delegate, rather U can pass the function directly. 

            StringFunc fn = new StringFunc(DisplayText);
            fn("Sample Test");//Invoking the method thru' the reference. 

            fn = new StringFunc(splitFunc);
            fn("Create a delegate that returns void and takes a string as an arg");

          
        }

        static void splitFunc(string arg)
        {
            var words = arg.Split(' ');
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
/*
 * Assignment: 
 * Create a delegate that returns void and takes a string as an arg.
 * Create a target func for the matching delegate.(Function that matches the signature of the delegate) Let the function display the string arg in Upper case. 
 * Create the instance of the delegate and pass the target function as arg to its constructor.
 * Call the delegate instance by passing a string as arg: "Sample Text" and see the output.
 * Create another target function that splits the string and displays the words of the string line by line. 
 * Invoke the target function thro delegate object.
 */