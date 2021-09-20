using System;
using System.IO;
//These examples will be on file handling in .NET. All Classes related to File handling is available under System.IO 
//C# uses streams for handling IO operations. All streams are based on an Abstract class called System.IO.Stream that provides std methods to transfer bytes to the source and vise-versa. ALl Classes that want to read/write bytes from a source must be derived from Stream class and implement methods in them.
//FileStream, MemoryStream, BufferedStream, NetworkStream, PipeStream, CyptoStream. 
//StreamReader and StreamWriter are helper classes for reading and writing a string to a stream which internally converts charecters to bytes . 
//BinaryReader and BinaryWriter are helper classes for reading/writing primitive data types to and from bytes.
//Binary and Stream readers internally the specific target streams like File, Memory, Buffer, network as sources. 
//For text based files, we have a static class called File that contain methods to perform basic reading and writing operations on Text based files. 
//File is a static class to read/write text based data from a physical file with limited lines of code. It has APIs to read/write, copy, move files, delete files from the FileSystem. 
//To work with Directories, U can use the Directory class that allows to create, copy, move, delete physical directories of the FileSystem. 
//Older versions of .NET used FileInfo and DirectoryInfo to do the same functionalities as static File and Directory classes.

//Main function can take a string [] as arguments. They are called as Command line arguments. U can pass string based data as arguement to the Main function which it will use for its app purpose. 
namespace SampleFrameworkApp.Day11
{
    class FileIO
    {
        /// <summary>
        /// Reads the contents of the file and returns the contents as string
        /// </summary>
        /// <param name="fileName">The Full Path of the file to read</param>
        /// <returns>The Contents of the File as string</returns>
        static string getMenu(string fileName)
        {
            if (File.Exists(fileName))
            {
                var contents = File.ReadAllText(fileName);
                return contents;
            }
            return string.Empty;//If the file is not found...
        }
        static void Main(string[] args)
        {
            //fileReading();
            //foreach (var arg in args) Console.WriteLine(arg);
            //menuReadingDemo(args);
            //WriteToFileDemo();
            //appendToFileDemo();
            //readFileasBytes();
            displayDetailsOfAllFiles();
        }

        private static void displayDetailsOfAllFiles()
        {
            var files = Directory.GetFiles(@"C:\Users\phani\source\repos\Fidelity Training\SampleFrameworkApp\Day11");
            foreach(var file in files)
            {
                Console.WriteLine("Details of File: " + file);
                var time =  File.GetCreationTime(file);
                Console.WriteLine("File Created on: " + time.ToString());
                time = File.GetLastAccessTime(file);
                Console.WriteLine("File last accessed on " + time.ToString());
                var attributes = File.GetAttributes(file);
                Console.WriteLine(attributes);
            }
            var drives = Directory.GetLogicalDrives();
            foreach (var drive in drives) Console.WriteLine(drive);
        }

        //Show how to read the file as byte []. Usefull for reading non text based files. 
        private static void readFileasBytes()
        {
            string filename = "../../Day11/SampleFile.txt";//filename where to write
            FileStream fs = File.Open(filename, FileMode.Open);
            while (fs.CanRead)
            {
                var byteVal = 0;        
                if((byteVal = fs.ReadByte()) != -1) 
                    Console.WriteLine((char)byteVal);
            }
        }

        private static void appendToFileDemo()
        {
            string filename = "../../Day11/SampleFile.txt";//filename where to write
            Console.WriteLine("Please write some text here to append and press ENTER");
            string content = Console.ReadLine(); //content to write to the file
            File.AppendAllText(filename, content + "\n");
        }

        private static void WriteToFileDemo()
        {
            Console.WriteLine("Please write some text here and press ENTER");
            string content = Console.ReadLine(); //content to write to the file
            string filename = "../../Day11/SampleFile.txt";//filename where to write
            File.WriteAllText(filename, content);//API to write the text in the specific filename. The API will replace the contents of the file with the new content, if the file does not exists, it creates a new file
            Console.WriteLine("File has been written");
            content = getMenu(filename);//Get the contents of the file to read
            Console.WriteLine("The contents are as follows:");
            Console.WriteLine(content);//Display the content.
        }

        private static void menuReadingDemo(string[] args)
        {
            string menu = getMenu(args[0]);
            if (string.IsNullOrEmpty(menu))
            {
                Console.WriteLine("No Menu found\nExiting the application......");
                return;
            }
            do
            {
                Console.WriteLine(menu);
                char choice = char.Parse(Console.ReadLine());
                Console.WriteLine("The selcted choice is " + choice);
            } while (true);
        }

        private static void fileReading()
        {
            string filename = @"C:\Users\phani\source\repos\Fidelity Training\SampleFrameworkApp\Day11\FileIO.cs";
            if (File.Exists(filename))
            {
                string contents = File.ReadAllText(filename);
                Console.WriteLine(contents);
            }
            else
                Console.WriteLine("File location is not valid");
        }
    }
}
