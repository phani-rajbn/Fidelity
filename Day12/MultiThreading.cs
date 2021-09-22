using System;
using System.Threading;//Namespace for all classes related to multi threading.
/*
 * Multi threading is a feature of OS to allow multiple paths of execution concurrently. The Program will be executed within a private address space called as PROCESS. A process is a part of the OS that is responsible for the execution of UR program. Within the process, the path of execution is defined by an unit called Thread. A Process is an instance of an EXE and the sequence of the execution is called a Thread. For any process to stay alive, there should be atleast one thread. The actual execution happens with the thread and the process is only a container which defines the boundary and scope of UR app data. 
 * Every program by default needs a thread to execute, this will be called as Main thread. By default, all programs are single threaded apps. If this main thread is spending a long time on doing a task, it would be nice to create another path of execution to do smaller tasks without wasting the CPU time. The child threads will do their tasks without dependencies on the Main thread. This is the purpose behind creating multiple threads within an Application. 
 * A Thread in .NET is implemented using a class called Thread. The Thread object looks for a delegate called ThreadStart which will represent the function that defines what this thread should do when it runs. 
 * When 2 threads try to access the same resource at the same time, U might have a chance of data corruption and might lead to unexpected results. To avoid this, U can synchronize the code to allow only one thread to access the resource/code at any given time. Similar to Critical Section of OS, we can use a .NET class called Monitor or a keyword called lock to allow only one thread to access it at any given point.
 * .NET has 2 kinds of threads: Foreground threads and background Threads. By default all threads are foreground threads. The Parent thread(Main) will wait for the foreground thread to complete its task even if the Parent(Main) has completed its tasks. U can make a thread a background thread, where in this case, if the Main thread completes its tasks, it will simply exit the app without waiting for the threads to complete. So they are called as background threads. 
 * U can stop the thread execution and resume it later by using APIs called Suspend() and Resume(); However, .NET does not recommend to use these APIs, instead rely on sychronization techiques like Mutex, Semaphore, Event. (REFER MSDN).
 * Join is a method of the Thread class that can be used to make the next thread to wait till the curren thread completes its operation without a need to lock the Code. Use lock if U want synchronization to happen at app level, use join if U have a series of threads to execute one after the other. In this case, 2 threads need not point to the same function.  
 */
namespace SampleFrameworkApp.Day12
{
    class MultiThreading
    {
        static void bigTaskFunc()
        {
            string name = Thread.CurrentThread.Name;//Get the name of the current thread.
            /*************U could replace Monitor.Enter with lock***************************
            lock (typeof(MultiThreading))
            {

            }
            ****************************************************************************/
            //Monitor.Enter(typeof(MultiThreading));//expect only one thread to use it at a time..
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"Task Func of {name} with Lot of work!");
                    Thread.Sleep(1000);
                }
            }
            //Monitor.Exit(typeof(MultiThreading));
        }

        static void smallTaskFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Small Task Func with some work!");
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            parameterbasedThreadDemo();
            //singleThreadedAppDemo();
            //multiThreadedAppDemo();
            //callingMultipleThreads();
            //backgroundThreads();
        }

        private static void ThreadFunc(object arg)
        {
            if (arg is Array)
            {
                Array temp = arg as Array;
                foreach (var item in temp)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(item);
                }
            }else
                Console.WriteLine("Not a valid input");
        }
        private static void parameterbasedThreadDemo()
        {
            Thread th = new Thread(ThreadFunc);
            th.Start(new string[] { "Apple 123" });
            smallTaskFunc();
        }

        private static void backgroundThreads()
        {
            
            Thread t1 = new Thread(bigTaskFunc);
            t1.IsBackground = true;
            t1.Start();
            smallTaskFunc();
        }

        private static void callingMultipleThreads()
        {
            //In this case 2 threads created are calling the same function...
            Thread t1 = new Thread(bigTaskFunc);
            t1.Name = "Thread 1";//U can provide a name to UR thread for better readability purpose.
            Thread t2 = new Thread(bigTaskFunc);
            t2.Name = "Thread 2";
            t1.Start();
            t1.Join();//Main thread will pause till the t1 completes its job, so that the next line of statement executes.
            t2.Start();
            t2.Join();
        }

        private static void multiThreadedAppDemo()
        {
            //In this case, the first method must be invoked asynchronously. The app should not wait for the function to complete, rather it should continue its execution without waiting for the function to return.
            Thread t1 = new Thread(bigTaskFunc);
            t1.Start();//This will start executing the thread functionality.....
            smallTaskFunc();//This does not need a thread....

        }

        private static void singleThreadedAppDemo()
        {
            bigTaskFunc();
            smallTaskFunc();
        }
    }
}
