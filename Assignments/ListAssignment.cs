using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkApp.Assignment
{
    class Book
    {
        public double Price { get; set; }  
        public string Author { get; set; }
        public string Title { get; set; }
        public int BookID { get; set; }
    }
    interface IListBookStore
    {
        void AddNewBook(Book bk);
        void UpdateBook(Book bk);
        void DeleteBook(int id);
        Book[] FindBooksByTitle(string title);
        Book[] FindBooksByAuthor(string authorName);
    }

    class BookStoreException : ApplicationException
    {
        public BookStoreException() { }
        public BookStoreException(string msg) : base(msg) { }
        public BookStoreException(string msg, Exception ex) : base(msg, ex) { }
    }
    class BookDepositore : IListBookStore
    {
        List<Book> _books = new List<Book>();
        public void AddNewBook(Book bk)
        {
            if (bk == null) throw new BookStoreException("Book Details are not set, so U cannot store the details");
            _books.Add(bk);
            
        }

        public void DeleteBook(int id)
        {
            //var selectedBook = _books.Find((bk) => bk.BookID == id);
            for(int i = 0; i < _books.Count; i++) //Iterate thro the _books..
            {
                if(_books[i].BookID == id)//Find the matching book
                {
                    _books.RemoveAt(i); //Delete the Book
                    return;//Exit the fn
                }
            }
            throw new BookStoreException("Book not found to delete");
            //If no book is found raise an Exception.
        }

        public Book[] FindBooksByAuthor(string authorName)
        {
            var temp = new List<Book>();//Create a Temp List with 0 elements in it..
           foreach(var bk in _books)//Use foreach loop to search thro the collection
           {
                if(bk.Author == authorName)//Use if condition to find the matching book with author
                {
                    temp.Add(bk);//Add this matching book to this temp List...
                }
           }
            if (temp.Count == 0) throw new BookStoreException($"No Book is found written by {authorName}");
            //if the Temp List Count is 0, throw the exception....
            return temp.ToArray();//return Temp List converted to an array
          
        }

        public Book[] FindBooksByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book bk)
        {
            throw new NotImplementedException();
        }
    }

    class AssignmentUI
    {
        static void Main(string[] args)
        {
            IListBookStore store = new BookDepositore();
            store.AddNewBook(new Book {  Author ="TstGuy", Title ="TstMe", BookID = 123, Price = 670});
            //store.AddNewBook(null);
            //store.AddNewBook(null);
            //store.AddNewBook(null);
            var array = store.FindBooksByAuthor(null);
            foreach (var book in array) Console.WriteLine( book.Title);
        }
    }
}
