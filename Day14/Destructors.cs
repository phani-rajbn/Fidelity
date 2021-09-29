using System;
/*The purpose of this class is to understand the purpose of using memory management in .NET. GC, IDisposable interface will be discussed.
Destructor is very much the opposite of constructor. Their signature is very distinct. .NET does not support the feature of calling the destructor explicitly. However u may need to call the destructor on certain scenarios where U have a code that has to be released from memory which might work beyond the scope of .NET.
There is an interface called IDisposable that can be implemented in a way of executing a code that could free memory and callers can explicitly call them to do the job of what a typical destructor is expected to do.
Destructor will have the same name of the class like Constructor with a ~ prefixing it. It will not have any access specifier and will not have any arguments. C# does not allow callers to invoke the destructors explicitly like we do in C++(delete) and C(free). 
Objects in .NET are destroyed by GC, a component inside CLR that creates a new background thread and keeps track of all destroyable objects(Removable objects) and when in short of memory, it will destroy them. Finally when the program is about to terminate, the GC will destroy all the remaining memory, frees them and allow the App to terminate. 
GC comes into picture when U create an object using new operator. The new operator will allow the GC to check for memory for this object to be created, if not found, run it thro the heap area will delete all the unused objects. 
The list of the objects that are created in the CLR is maintained by the GC as  a Finalization Queue.
GC can be requested to run thro the finalization queue by calling GC.Collect.
If a class implements IDisposable Interface, then the object of this class must call the Dispose method before it is no longer used by the programmer.
Never call GC.Collect or its other counterparts unless U want to do some work with the GC. U should implement IDisposable interface only if U R interacting with any unmanaged code(Core C++, COM, MFC code) in ur .net App. In such cases, to delete the C++objects which are not controlled by the CLR, and U intend to destroy them thru' code, then U write the logic in the Dispose method. 
Developers who consume the classes that implements IDisposable interface are obligated to call the Dispose function once the work with their object is done!!!.
*/
namespace SampleFrameworkApp.Day14
{
    class SimpleClass : IDisposable
    {
        private int x;
        public SimpleClass(int x)
        {
            this.x = x;
            Console.WriteLine($"object by name {x} is created");
        }

        ~SimpleClass()
        {
            Console.WriteLine($"object by name {x} is destroyed");
        }

        public void Dispose()
        {
            Console.WriteLine($"object by name {x} is destroyed");
            GC.SuppressFinalize(this);//GC will not call the destructor of this instance. 
        }
    }
    class Destructors
    {
        static void createAndDestroyObjects()
        {
            for (int i = 0; i < 10; i++)
            {
                //SimpleClass cls = new SimpleClass(i+1);
                //cls.Dispose();//U must call this if the work with UR object is done!!!!!!
                //GC.Collect();//Tries to remove any unused memory in the Queue in a seperate background thread.
                //GC.WaitForPendingFinalizers();//The Main thread will wait till the unused memory is cleaned. Even this case, there is no way to tell the GC to destroy a specific object which is not allowed in C#
                //When U have objects that has to be called with Dispose method, U them under the using block, .NET will ensure to call the Dispose method implicitly after the scope is done. 
                using (SimpleClass cls = new SimpleClass(i))
                {

                }

            }
        }
        static void Main(string[] args)
        {
            createAndDestroyObjects();
        }
    }
}
