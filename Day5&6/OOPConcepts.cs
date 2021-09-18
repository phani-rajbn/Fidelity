using System;
using System.Collections.Generic;

namespace SampleTestApp
{
    //Inheritance is a feature of OOP where a class can extend itself to another. The class that does the extention is called as Derived Class/Child class/Sub Class. The class that is to be extended is called as Base Class/Parent Class/Super class.
    //C# supports single inheritance. not multiple inheritance.  
    class Person
    {
        public string Name { get; set; }
    }

    //Inheritance syntax in C#. There is no access specifier while U extend the class. All the access of the base class is retained in the derived class. 
    class Student : Person
    {
        public int CurrentClass { get; set; }
    }
    /*
     * Access specifiers help in achieving the Encapsulation(Data Hiding feature).
     * public: accessible anywhere in the app
     * private: accessible only within the class.(Helper functions within the class for frequent usage within the class). If U dont specify the acccess specifier, it will be private.
     * protected: accessible within the class and its derived classes. 
     * internal: accessible within the project/assembly.
     * protected internal: either within the project or the assesmbly. 
     */
    class SampleClass
    {
        public void publicFunction()
        {
            Console.WriteLine("Accessible anywhere");
            privateFunction();
        }
        private void privateFunction() => Console.WriteLine("Accessible within the class");
        protected void protectedFunction() => Console.WriteLine("Accessible within family");
        public void internalFunction() => Console.WriteLine("Accessible within Project");
        public void procInternalFunction() => Console.WriteLine("Accessible within Project or within the Family");
    }
    class DerivedClass : SampleClass
    {
        public void CallMyFunctions()
        {
            protectedFunction();//Accessible because the current class is derived from the SampleClass.
        }
    }
    /*************************Method Overriding***************************************
     * If a method is defined in the base class, and U want to change its functionality in the derived class, U can do that with a feature called Method overriding.
     * The base class method should be virtual. The derived class will redefine the method with the matching signature(Name, parameters as well as the return type) using a modifier called override. 
     * Only functions that are declared as virtual in the base class can be overriden in the derived class.
     */
    class Parent
    {
        public void NonVFunc() => Console.WriteLine("Dont expect to be modified");
        public virtual void TestFunc() => Console.WriteLine("Test Func from Base");//It can be modifiable in the derived class.
    }
    
    class Child : Parent
    {
        public override void TestFunc()
        {
            Console.WriteLine("Test Func modified in the derived");//Adds new things...
        }
    }

    static class ParentFactory
    {
        public static Parent GetObject(string name)
        {
            Parent obj = null;
            if (name.ToLower() == "parent")
                obj = new Parent();
            else
                obj = new Child();
            return obj;
        }
    }
    /***********************Assignment Code*********************************************/
    class Account
    {
        public double Balance { get; private set; }//U can set the Balance within the class...
        public string Name { get; set; }
        public int AccountNo { get; set; }
        //Add to the balance.
        public void Credit(double amount)
        {
            //It would create a Transaction object which would contain additional details like date of Transaction, method of transaction, amount to be transacted and few more details. 
            Balance += amount;
        }

        public void Debit(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }
            Balance -= amount;
        }
    }

    class SBAccount : Account { }
    class RDAccount : Account { }
    class FDAccount : Account { }

    static class AccountManager
    {
        public static Account CreateAccount(string type)
        {
            Account acc = null;
            switch (type)
            {
                case "SB":
                    acc = new SBAccount();
                    break;
                case "RD":
                    acc = new RDAccount();
                    break;
                case "FD":
                    acc = new FDAccount();
                    break;
                default:
                    Console.WriteLine("Not a valid account type");
                    break;
            }
            return acc;
        }
    }
    /************************Abstract classes*************************************
    Base class does have a method but no implementation in them is what a typical abstract class would be.
    The method with no implementation is provided with a modifier called abstract. 
    A class with atleast one abstract method must be declared as abstract class and will make the class non-instantiatable. This is because the class is incomplete. Until the class has definitions for all its methods, U cannot create objects from it. 
    If a class inherits from the abstract class, it must implement all the abstract methods of the its base class, which in this case will be abstract class.
    Abstract methods are implemented in the derived class using override keyword. With override, U tell the system that this method is not owned by the current class and will ensure that the fn is not modifying the signature of the method declared in the base class. 
    */
    abstract class SuperBaseClass//abstract also implies that this class must be inherited to be used.
    {
        //U can have normal and virtual methods also in this class....
        public void NormalFunc() => Console.WriteLine("Normal method of the abstract class");
        public virtual void VirtualFunc() => Console.WriteLine("Virtual method of the abstract class, could be modified by the derived using override");
        public abstract void SuperFunc();//This is now an abstract method...
    }

    class SuperImplementor : SuperBaseClass
    {
        public override void SuperFunc()
        {
            Console.WriteLine("U will implement the func in the derived class");
        }
    }
    /******************************Main Program*********************************************/
    class OOPConcepts
    {
        //Helper fn for creating Account object based on User input
        static Account createUserAccount()
        {
            Console.WriteLine("Enter the type of acc as SB, RD or FD\nPS:Anything other is considered as invalid");
            string accType = Console.ReadLine();
            Account ac1 = AccountManager.CreateAccount(accType);
           
            return ac1;
        }

        //helper function to set details for individual Account object. 
        static Account setDetails()
        {
            Account ac = createUserAccount();
            Console.WriteLine("Enter the Account no");
            ac.AccountNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            ac.Name = Console.ReadLine();
            Console.WriteLine("Enter the Amount to open the account");
            ac.Credit(int.Parse(Console.ReadLine()));
            return ac;
        }
        static void Main(string[] args)
        {
            /////////////////Abstract class Demo/////////////////////////////
            //SuperBaseClass cls = new SuperBaseClass();//This wont work as abstract classes cannot be instantiated....
            SuperBaseClass cls = new SuperImplementor();
            cls.NormalFunc();
            cls.VirtualFunc();
            cls.SuperFunc();

            /*/////////////////////////Assignment code///////////////////////////
            Create a class called Account with properties: AccountNo, Name, Balance; 
            And methods: Credit and Debit. 
            Create 3 Derived classes SBAccount, FDAcount and RDAccount.
            Create a Factory class called AccountManager that has a static fn called CreateAccount. 
            It takes a parameter of accountType and returns the appropriate Subclass as its return value.
            Take inputs from the User and create 5 Account objects.
            Let it be an interactive program that takes inputs for the account and displays the data.
            *******************************************************************************/
            //Account ac1 = setDetails();//returns a valid Account object based on inputs given....
            //Account ac2 = setDetails();
            //Account ac3 = setDetails();
            //Account ac4 = setDetails();
            //Account ac5 = setDetails();

            ////////////////////////////Method overriding///////////////////////////////
            //Parent obj = new Parent();//object memory is allocated here. 
            //obj.TestFunc();//Base class version...

            //obj = new Child();//Luskov's substitution principle.
            //obj.TestFunc();//Derived class version will be called....
            //This is called as RUNTIME POLYMORPHISM..........

            //Console.WriteLine("Tell me which class U want Parent or Child");
            //string className = Console.ReadLine();

            //Parent obj = ParentFactory.GetObject(className);
            //obj.TestFunc();


            ///////////////////Example on Access specifier///////////////////////////////
            //SampleClass cls = new SampleClass();
            //cls.publicFunction();
            ////cls.privateFunction();hidden to the outside world!!!!!
            ////cls.protectedFunction();hidden within the class and its derived class. 
            //cls = new DerivedClass();

            //((DerivedClass)cls).CallMyFunctions();//typecast to get the new method which is not there in the base class.....
            //cls.procInternalFunction();
            //cls.internalFunction();
            /////////////////Example of Inheritance///////////////////////////////////
            //Student student = new Student { Name = "Ramesh", CurrentClass = 10 };
            //Console.WriteLine("The Name of the student is {0}", student.Name);
            //Console.WriteLine("The Currect Accademic position of the student is Class: {0}", student.CurrentClass);

        }
    }
}