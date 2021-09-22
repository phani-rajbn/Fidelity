using System;
using System.Reflection;
using System.Collections.Generic;
/*Sometimes, U need programs that will read the metadata of the Assembly and using it take inputs from the user and create the objects of it instead of a simple object creation.
 * objects created using new operator where we know the type and its information at the time of compilation is called as Early binding.
 * U may have to create an object based on the inputs given by the user and fill the data accordingly. In this case, the type of object U create will not be known at Compile time, it will be known only at runtime. The object used will be boxed data and for every operation, U may have to unbox it, and then extract/set the data for the object. This is called Late binding. The object is bound to the type only at the later point of execution, hense the name late binding. 
 */
//Visual Studio Shell
namespace SampleFrameworkApp.Day13
{
    class MathReflectionExample
    {
        public double AddFunc(double v1, double v2) => v1 + v2;
        public double SubFunc(double v1, double v2) => v1 - v2;
        public double MulFunc(double v1, double v2) => v1 * v2;
        public double DivFunc(double v1, double v2) => v1 / v2;
    }

    class ReflectionDemo
    {
        //INvoke a method thru runtime binding.
        private static void lateBindingDemo()
        {
            Type type = selectClassFromAssembly();
            invokeMethod(type);
        }

        private static Type selectClassFromAssembly()
        {
            string className = MyConsole.GetString("Enter the Full Name of the class that U want to see");
            Type type = Type.GetType(className);
            MethodInfo[] methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name}-Return Type: {method.ReturnType.Name}");
                if (method.GetParameters().Length != 0)
                {
                    foreach (var pm in method.GetParameters())
                    {
                        Console.WriteLine($"{pm.Name} - Its DataType:{pm.ParameterType.Name}");
                    }
                }
            }
            return type;
        }

        private static void invokeMethod(Type type)
        {
            string methodName = MyConsole.GetString("Enter the method name from the list above");
            MethodInfo selectedMethod = type.GetMethod(methodName);//Get the Method U want to invoke
            object objInstance = Activator.CreateInstance(type);//Create the instance of the selected Type
            ParameterInfo[] allParameters = selectedMethod.GetParameters();//Get the parameters
            object[] parameters = new object[allParameters.Length]; //createa variables to hold values for the parameters
            for (int i = 0; i < allParameters.Length; i++)//Iterate thru the parameters
            {
                Console.WriteLine("Enter the value for {0} of the type {1}", allParameters[i].Name, allParameters[i].ParameterType.Name);
                //Get the value and convert it into the parameter type
                parameters[i] = Convert.ChangeType(Console.ReadLine(), allParameters[i].ParameterType);
            }
            object result = selectedMethod.Invoke(objInstance, parameters);
            Console.WriteLine("The value is " + result);
        }

        static void Main(string[] args)
        {
            readFromExternalAssembly();
            //lateBindingDemo();
            //displayAllTypes();
        }
        private static void readFromExternalAssembly()
        {
            var assembly = Assembly.LoadFile(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\mscorlib.dll");
            var types = assembly.GetTypes();
            foreach(var type in types)
            {
                if (type.IsValueType)
                {
                    if (type.IsEnum) Console.WriteLine($"{type.Name} is Enum");
                    else
                    Console.WriteLine(type.Name);
                }
            }
        }



        //Display all the classes that are created in this project..
        private static void displayAllTypes()
        {
            
            Assembly currentExe = Assembly.GetExecutingAssembly();//Get the reference of current exe
            var classes = currentExe.GetTypes();//Gets all the User defined types of the assembly
            HashSet<string> namespaces = new HashSet<string>();//To store namespaces of the Assembly
            foreach (var cls in classes)//iterate thro all classes
            {
                namespaces.Add(cls.Namespace);//Add the namespace to the set
                if (cls.IsInterface) Console.WriteLine($"{cls.Name} is an interface");//Check for interface
                else if (cls.IsGenericType) Console.WriteLine($"{cls.Name} is an Generic Type");//Check for Generic Type
                else Console.WriteLine(cls.Name);//Display the name of the class.
            }
            Console.WriteLine("The list of Namespaces with Us:");
            foreach (var nms in namespaces) Console.WriteLine(nms);//Display all the namespaces in the assembly.
        }
    }
}
