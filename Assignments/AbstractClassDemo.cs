using System;
using SampleTestApp.Day07;
namespace SampleTestApp.Assignments
{
    //Create a class called Account and add the previous Account class definitions here...
    abstract class Account
    {
        public override string ToString()
        {
            return $"The Name:{Name}\nThe Balance: {Balance:C}\n\n";
        }
        public double Balance { get; private set; } = 5000;//U can set the Balance within the class...
        public string Name { get; set; }
        public int AccountNo { get; set; }
        //Add to the balance.
        public void Credit(double amount) => Balance += amount;
        
        public void Debit(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }
            Balance -= amount;
        }

        public abstract void CalculateInterest();//Dont know what formula to use!!!
    }

    class SBAccount : Account
    {
        public override void CalculateInterest()
        {
            double principal = Balance;
            double rate = 7 / 100;
            double term = 0.25;
            double interest = principal * rate * term;//Quaterly Interest calculation...
            Credit(interest);//Call the base class method here...
        }
    }
    class RDAccount : Account
    {
        public override void CalculateInterest()
        {
            int term = 5 * 12;
            double rate = 7.5 / 100;
            double monthPayment = 5000;
            //Find the RD's interest calculation...
        }
    }
    class FDAccount : Account
    {
        public override void CalculateInterest()
        {
            int term = 5;//years
            double rate = 8.5 / 100; //rate of Interest
            double fixedAmount = Balance;//Current balance...
            //Find the RD's interest calculation...            
        }
    }

    enum AccountType
    {
        SB, RD, FD
    }

    static class AccountManager
    {
        public static Account CreateAccount(AccountType type)
        {
            Account acc = null;
            switch (type)
            {
                case AccountType.SB:
                    acc = new SBAccount();
                    break;
                case AccountType.RD:
                    acc = new RDAccount();
                    break;
                case AccountType.FD:
                    acc = new FDAccount();
                    break;
            }
            return acc;
        }
    }


    [Serializable]
    public class AccountCreationFailedException : ApplicationException
    {
        public AccountCreationFailedException() { }
        public AccountCreationFailedException(string message) : base(message) { }
        public AccountCreationFailedException(string message, Exception inner) : base(message, inner) { }
        protected AccountCreationFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    class BankingApp
    {
        const byte size = 10;
        Account[] accounts = new Account[size];//limitation of Arrays, we are fixing the size.

        public virtual void AddNewAccount(Account acc)
        {
            for (int i = 0; i < size; i++)
            {
                if (accounts[i] == null)
                {
                    accounts[i] = acc;
                    return;
                }
                else continue;
            }
            throw new AccountCreationFailedException("No more accounts could be created");
        }

        public virtual void DeleteAccount(int id)
        {
            for (int i = 0; i < size; i++)
            {
                if((accounts[i] != null) && (accounts[i].AccountNo == id))
                {
                    accounts[i] = null;//there is no delete operator in C#...
                    return;
                }
            }
            throw new AccountNotFoundException($"Account with ID {id} not found to delete");
        }

        public virtual void UpdateAccount(Account acc)
        {
            for (int i = 0; i < size; i++)
            {
                if ((accounts[i] != null) && (accounts[i].AccountNo == acc.AccountNo))
                {
                    accounts[i] = acc;//there is no delete operator in C#...
                    return;
                }
            }
            throw new AccountNotFoundException("Account not found to update");
        }
        public virtual Account [] GetAllAccounts()
        {
            return accounts;
        }
    }

    class UIApp
    {
        const string menu = "----------BANKING APP--------------------\nTO ADD ACCOUNT--------->PRESS 1\nTO DELETE ACCOUNT------------->PRESS 2\nTO UPDATE ACCOUNT-------->PRESS 3\nTO FIND ACCOUNT DETAILS---->PRESS 4\n";
        static BankingApp app = new BankingApp();//Create the object for interaction...

        static void initialize()
        {
            ////////////For testing update and delete fns//////////////////////////
            app.AddNewAccount(new SBAccount { AccountNo = 12323, Name = "Rajesh" });
            app.AddNewAccount(new FDAccount { AccountNo = 54366, Name = "Ramesh" });
            app.AddNewAccount(new RDAccount { AccountNo = 56778, Name = "Gopal" });
            app.AddNewAccount(new SBAccount { AccountNo = 87654, Name = "Shruthi" });
            /////////////////////////////////////////////////////////////////////////
        }
        static void Main()
        {
            initialize();
            bool processing = true;
            do
            {
                var choice = MyConsole.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(uint choice)
        {
            switch (choice)
            {
                case 1:
                    addAccountDetails();
                    return true;
                case 2:
                    deletingFunc();
                    return true;
                case 3:
                    Console.WriteLine("To be implemented in the next Version!!!!");
                    return true;
                case 4:
                    findingAccountFunc();
                    return true;
            }
            return false;//default value
        }

        private static void findingAccountFunc()
        {
            //Get all records from the BankingApp object.
            var records = app.GetAllAccounts();
            //Ask the user the name or partial name to find.
            var name = MyConsole.GetString("Enter the name or partial name to find in our accounts");
            //Display the list of all the matching accounts with the name.
            foreach(var acc in records)
            {
                if(acc != null && acc.Name.Contains(name))
                {
                    Console.WriteLine(acc);//Implicitly calls the ToString method of the object..
                }
            }
        }

        private static void deletingFunc()
        {
            int id = (int)MyConsole.GetNumber("Enter the ID of the Account to remove");
            try
            {
                app.DeleteAccount(id);
                Console.WriteLine("The Account with ID {0} is deleted from the database", id);
            }
            catch (AccountNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void addAccountDetails()
        {
            //Create the type of account requested by the user...
            Console.WriteLine("Enter the Type of account U Want to create as SB, RD or FD");
            //Enum.Parse is a function used to convert a string to the enum type. 
            var type = (AccountType)Enum.Parse(typeof(AccountType), Console.ReadLine());
            var acc = AccountManager.CreateAccount(type);
            //set the details for the account....
            acc.AccountNo = (int)MyConsole.GetNumber("Enter the Account no for this Customer");
            acc.Name = MyConsole.GetString("Enter the Name");
            double amount = MyConsole.GetDouble("Enter the initial amount for deposit");
            acc.Credit(amount);
            //call the AddNewAccount function and pass the object into the BankingApp repository..
            try
            {
                app.AddNewAccount(acc);
                Console.WriteLine("The Account of the type {0} is added to the database", type);
            }
            catch (AccountCreationFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}