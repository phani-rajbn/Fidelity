using System;

namespace SampleTestApp
{
    /*
     Interface is a group of functions and properties that are only abstract.
     All interface members are public only. U cannot have any other access specifiers.
     The class that implements the interface must implement all the methods in the public scope.
    Interfaces is an improved version of abstract classes. It contains only abstract members in it.
    A Class can implement multiple interfaces at the same level which U cannot do it with class.
    U can implement the interface either explicitly or implicitly in C#
    All interfaces in .NET will have a prefix I which will determine it as an interface. 
     */

    interface ISimpleInterface
    {
        void SimpleFunc();
    }

    interface IExampleInterface
    {
        void ExampleFunc();
    }
    class SimpleClass : ISimpleInterface, IExampleInterface
    {
        public void ExampleFunc()
        {
            Console.WriteLine("Example Implementation");
        }

        public void SimpleFunc()
        {
            Console.WriteLine("Simple Implementation");
        }
        
    }
    //**************Explicit Demo****************************/
    interface IAccount
    {
        void Create();//To create the account...
    }

    interface ICustomer
    {
        void Create();//To create the Customer...
    }

    class CustomerAccount : IAccount, ICustomer
    {
        public void Create()
        {
            Console.WriteLine("Creating a Customer and Account");
        }
        //Explicit needs to be refered using the interfaceName.FuncName. U should not set the access specifier here.
        void IAccount.Create() 
        {
            Console.WriteLine("Creating an Account");
        }
        void ICustomer.Create() 
        {
            Console.WriteLine("Creating a Customer");
        }
    }
    class InterfaceDemo
    {
        static void Main(string[] args)
        {
            //SimpleClass cls = new SimpleClass();
            //cls.SimpleFunc();
            //cls.ExampleFunc();

            //IExampleInterface ex = new SimpleClass();
            //ex.ExampleFunc();

            //ISimpleInterface sim = (ISimpleInterface)ex;//U R not creating a new object
            //sim.SimpleFunc();

            CustomerAccount CAsc = new CustomerAccount();
            CAsc.Create();//public default implementation

            IAccount acc = new CustomerAccount();
            acc.Create();//explicit acc Impl

            ICustomer cst = new CustomerAccount();
            cst.Create();//explicit Cust Impl

        }
    }
}
