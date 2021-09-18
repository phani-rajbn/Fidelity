using System;
using System.Data;
/*
* Create an interface called IBookStore: Add, Delete, Find and Update functions to perform the operations. 
* Create a class that represents a book: ID, Title, Author, Price as properties.
* Create a class that implements this interface and the internal data structure will be Book array. 
* Create a UI Component that will have functions to perform all the operations using a menu driven program.  
*/

namespace OOPAssignment
{
using System.Diagnostics;
    using SampleTestApp;
    class Author
    {
        public int NoOfBooks { get; set; }
        public string AuthorName { get; set; }
        public int AuthorID { get; set; }
    }

    interface IAuthorInfo//plan where U dont need to worry about its implementation currently
    {
        void AddAuthor(Author author);
        void DeleteAuthor(int authorId);
        void UpdateAuthor(Author author);
        Author[] FindAuthors(string name);
    }

    class AuthorInfo : IAuthorInfo
    {
        private DataTable table = new DataTable();
        //dependencies of UR object so that it could be used at its best
        public AuthorInfo()
        {
            table.Columns.Add("AuthorID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("BookCount", typeof(int));
        }
        public void AddAuthor(Author author)
        {
            DataRow row = table.NewRow();//Create a blank row with the schema of the table.
            row[0] = author.AuthorID;//data is boxed here..
            row[1] = author.AuthorName;
            row[2] = author.NoOfBooks;
            table.Rows.Add(row);
            table.AcceptChanges();
        }

        public void DeleteAuthor(int authorId)
        {
            foreach(DataRow row in table.Rows)
            {
                //if (Convert.ToInt32(row[0]) == authorId)//More appropriate
                if ((int)(row[0]) == authorId)//C Style casting(UNBOXING)
                {
                    row.Delete();
                    return;
                } 
            }
            throw new Exception("Author not found to delete");
        }

        public Author[] FindAuthors(string name)
        {
            DataTable copy = table.Copy();//copies the schema and the data
            foreach(DataRow row in copy.Rows)
            {
                if (!row[1].ToString().Contains(name))
                {
                    row.Delete();//remove those rows that U dont want
                }
            }
            Author[] array = new Author[copy.Rows.Count];
            int index = 0;
            foreach(DataRow row in copy.Rows)
            {
                var author = new Author
                {
                    AuthorID = Convert.ToInt32(row[0]),
                    AuthorName = row[1].ToString(),
                    NoOfBooks = Convert.ToInt32(row[2])
                };
                array[index] = author;
                index++;
            }
            return array;
            //return copy;//return table with valid rows...
        }

        public void UpdateAuthor(Author author)
        {
            foreach (DataRow row in table.Rows)
            {
                if(Convert.ToInt32(row[0]) == author.AuthorID)//AuthorID should not be modified
                {
                    row[1] = author.AuthorName;
                    row[2] = author.NoOfBooks;
                    table.AcceptChanges();
                    return;
                }
            }
            throw new Exception("Author not found to update!!");
        }
    }

    class AuthorInfoService
    {
        static IAuthorInfo info = new AuthorInfo();//Runtime polymorphism
        const string menu = "~~~~~~~~~~~~~~~~~~~~~~~~~AUTHOR INFO SYSTEM~~~~~~~~~~~~~~~~~~~~~~~~~~\nNEW AUTHOR REGISTRATION------------>PRESS 1\nDELETE AUTHOR INFORMATION---------->PRESS 2\nUPDATE AUTHOR INFORMATION---------->PRESS 3\nFIND AUTHOR BY NAME---------------->PRESS 4\nPS: PRESS ANY OTHER KEY TO EXIT\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                uint choice = MyConsole.GetNumber(menu);
                processing = processMenu(choice);
            } while (processing);
        }

        private static bool processMenu(uint choice)
        {
            switch (choice)
            {
                case 1:
                    return true;
                case 2:
                case 3:
                case 4:
                    return true;
                default:
                    return false;
            }
        }  
    }
}