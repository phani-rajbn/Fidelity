using System;
using System.Collections.Generic;//For new Collctions from .NET 2.0
using System.Linq;
//Collections in .NET help in resolving many of the issues raised by the Arrays. The collections contain ready to use classes as well as interfaces which provides APIs for performing operations on collections. These collections are designed to be dynamic and allow users to perform most of the operations like add, remove, insert, cloning, copying and many more. 
//Datastructures will be different for different kinds of requirements. 
//Old version of .NET 1.0(2002) and .NET 1.1v(2002) used a namespace called System.Collections and it had all the classes required for creating and managing collections. However, the elements inside the collections were stored as objects(BOXED Values). There was a performance issue when we retrieve the data from these collection objects as they were supposed to be UNBOXED while we read them. 
//From .NET 2.0(2005) we got a new verions of collections called System.Collections.Generic which provided template based APIs for storing the data in a typesafe manner. The typesafety ensured that the data was stored as its own data type instead of boxed values. So no more unboxing!!!

namespace SampleFrameworkApp
{
    class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        
        //To check the uniqueness of the object
        public override int GetHashCode()
        {
            return PersonID.GetHashCode();//Get the HashCode of the PersonID....
        }

        //Logical equivalence is tested here....
        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                var temp = obj as Person; //UNBOX the object to Person....
                return temp.PersonID == PersonID;//check if their ids are same!!!
            } else
                return false;
        }
        public override string ToString()
        {
            return $"Name:{Name} and ID:{PersonID}";
        }
    }

    class Program
    {
        private static void objectSetDemo()
        {
            HashSet<Person> myTeam = new HashSet<Person>();
            //Person p = new Person { Name = "Phaniraj", PersonID = 111 };
            //Person copy = p;//Same memory...
            //myTeam.Add(p);
            //if (!myTeam.Add(copy)) Console.WriteLine("This guy is there!!!!");
            myTeam.Add(new Person { Name = "Phaniraj", PersonID = 111 });
            myTeam.Add(new Person { Name = "Suresh", PersonID = 111 });
            myTeam.Add(new Person { Name = "Govinda", PersonID = 114 });
            myTeam.Add(new Person { Name = "Kumar", PersonID = 115 });
            myTeam.Add(new Person { Name = "Gopal", PersonID = 116 });
            foreach (var person in myTeam) Console.WriteLine(person);//Method of the System.Object
            //Console.WriteLine("The total members in my team: " + myTeam.Count);
        }
        static void Main(string[] args)
        {
            //dictionaryExample();
            //objectSetDemo();//hashset applied on objects...
            //HashSetExample();
            //listExample();
            //stackExample();
            //queueExample();
            sortedListExample();
        }

        private static void sortedListExample()
        {
            throw new NotImplementedException("Explore on this and try to create an Example test on this");
        }

        private static void queueExample()
        {
            /*
               Works like FIFO manner(First In First Out). 
               Element are added to the Queue using Enqueue method and retrieved using Dequeue method. Like Stack U cannot access it using [] operator. Contains and Clear methods are there even here....
             */
            Queue<string> items = new Queue<string>();
            do
            {
                if (items.Count == 3)
                    items.Dequeue();//Removes the first item in the Queue...
                items.Enqueue(MyConsole.GetString("What Do U want to see today?"));
                Console.WriteLine("UR Recent list:");
                var recentList = items.Reverse();
                foreach (var item in recentList) Console.WriteLine(item);
            } while (true);
        }

        private static void stackExample()
        {
            //Stack is used to store the data in the form of LIFO(Last In First Out). Elements are added from the top and fills the column. The first element added will be the last element to be pulled out. 
            //Push and Pop methods are used to add and retrieve the data from the Stack. U cannot use indexer in stack. 
            //Count, Contains(), Clear() 
            //Peek() vs Pop() methods
            Stack<string> pages = new Stack<string>();
            pages.Push("HomePage"); //Adds the item to the top of the stack
            pages.Push("ContactsPage");
            pages.Push("CallPage");
            pages.Push("MessagesPage");

            foreach(var page in pages)//Do the interation. U cannot do a for loop on this. 
            {
                Console.WriteLine(page);
            }
            Console.WriteLine("Now removing them");
            Console.WriteLine(pages.Pop() + " is moved out");
            Console.WriteLine(pages.Pop() + " is moved out");
            Console.WriteLine(pages.Pop() + " is moved out");
            Console.WriteLine(pages.Pop() + " is moved out");
        }

        private static void dictionaryExample()
        {
            //Dictionary is a DS that stores the data in the form of KEY-VALUE pairs. In this case, the Key is unique to the collection and value may or may not be unique. username-password, Dictionary of words: Word is unique, meaning may not be unique. Dictionary is very fast in iteration and reading the data. But it occupies a lot of memory for large size. 
            Dictionary<string, string> users = new Dictionary<string, string>();
            for (int i = 0; i < 4; i++)
            {
                string uname = MyConsole.GetString("Enter the UserName");
                string pwd = MyConsole.GetString("Enter the Password");
                if (users.ContainsKey(uname)) //Allow the user to retype the data again...
                    Console.WriteLine("User name already exists, Please enter other name");
                else
                {
                    users.Add(uname, pwd);
                }
            }
            string loginName = MyConsole.GetString("Enter UR login ID");
            string loginPwd = MyConsole.GetString("Enter the password");
            if (users.ContainsKey(loginName))
            {
                if(users[loginName] == loginPwd)
                    Console.WriteLine("Welcome to the user");
                else
                    Console.WriteLine("Invalid password");
            }else
            {
                Console.WriteLine("User Name is not valid");
            }
        }
        //Assignment:
        /*
         * Create this code in a seperate file and Main program in it which will have the functionalities of a Sign In and Sign Up feature. It should be menu driven and ask the users the choice of either registering or logging in. Let it be an infinite loop. U can close the Console Window when U want to terminate the App. 
         * Reimplement the interface of the Bookstore App to store the data into a List instead of Array or DataTable. BookStore app. Using RTP, use this class instance to see the change in the behavior of the project. 
         * U can create a static class called BookManager which has static method to return the interface object which will be used by the consumer of this application.
         */
        private static void listExample()
        {
            /* List is a Generic class that stores the data like an array. It is similar to Array. It has functions to add, remove, insert, removeAt and many more to manipulate the collection at runtime. 
              Unlike Arrays, U can change the size of the collection without breaking the existing data in it. 
              Internally List<T> implements an interface called IList<T>. IList has APIs to do all operations of a typical list. One can implement this interface to create their own customized List classes. 
              Limitations: List will allow duplicates.  
             */
            var list = new string[] { "Apple", "Mango", "Orange" };
            List<string> fruits = new List<string>(list);
            Console.WriteLine("The current items Count in this list is " + fruits.Count);
            foreach (var fruit in fruits) Console.WriteLine(fruit);
            //Try using Add method and Remove method and also find the size of the collection.
            //Where will Add method add the elemnt in the collection?
            var fewMoreFruits = new string[] { "Banana", "PineApple", "Kiwi fruit", "Cherry", "Grapes(Green)" };
            fruits.AddRange(fewMoreFruits);
            fruits.Add("Grapes(Blue)");
            int indexLoc = fruits.IndexOf("Cherry");
            if(indexLoc < 0)
                Console.WriteLine("No element found");
            else
                Console.WriteLine("Cherry is at the index " + indexLoc);
            foreach (var fruit in fruits) Console.WriteLine(fruit);
        }

        private static void HashSetExample()
        {
            //HashSet is very similar to List<T> except that it stores only unique values in it. It is basically a Set, Sets are supposed to store only unique values in them. It uses HashCode of the object to determine the uniquness of it. HashCode is a hexadecimal value to identify an object in the CLR. 
            //HashSet implements ICollection<T> and ISet<T> to facilitate the collection concept and Set Concept(Uniqueness). 
            HashSet<string> myBasket = new HashSet<string>();
            myBasket.Add("Apple");
            myBasket.Add("PineApple");
            if (!myBasket.Add("Apple")) Console.WriteLine("Already inserted"); 
            Console.WriteLine("The size: " + myBasket.Count);
            
        }
    }
}
/*
 * Reading assignment:
 * Array has APIs called Clone, Copy, CopyTo. Find the differences of all these methods in the array class. 
 */
