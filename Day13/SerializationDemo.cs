using System;
using System.IO;
using binary = System.Runtime.Serialization.Formatters.Binary;//For binary serialization
using System.Xml.Serialization;//For Xml serialization
/*
 * Serialization is a process of converting objects of a class to a bytestream so that it could be saved to a memory or a file. This will allow to save large collection objects in one go. The reverse process of serialization is called deserialization. 
 * Most of Inter Process Communication within the networks happen thru serialization only. 
 * object ==> byte [] ===>File(FileStream), Memory(MemoryStreams). 
 * object details include data as well the metadata info of the class and the assembly it belongs to. 
 * Attributes are sp properties that are added to a class or any type which provides some additional feature to the class. Unlike regular properties, these attributes will not be the part of the metadata untill U add it.
 * There are 3 ways U can serialize the data in C#. Binary, XML and Soap(Simple object access protocol).
 * There are 3 points for any kind of serialization to work:
 * 1. The object to serialize: Any object of a class that has attribute called serializable. 
 * 2. The format of serialization: Binary, SOAP or XML
 * 3. Location of serialization: File, Memory, Database 
 *  Objects saved as XML Files is done thru' XML Serialization. The class should be public in XML Serialization. Serializable is not required for Xml Serialization. 
 *  Limitations of serialization : Large data takes long time to serialize and deserialize. data is stored in memory or files where the chances of data corruption are maximum. Multiple users cannot access at the same time. 
 *  Due to these problems, it is good to store the data into sp. software whose job is to store. Databases are the right way to store data for longitivity, consistance, durability and isolation. 
 */
namespace SampleFrameworkApp.Day13
{
    [Serializable]//Makes the objects of this class serializable.   
    public class Employee
    {
        public override string ToString()
        {
            return $"{EmpID}-{EmpName}";
        }
        public string EmpName { get; set; }
        public int EmpID { get; set; }
    }
    class SerializationDemo
    {
        static void Main(string[] args)
        {
            if(args.Length != 1)
            {
                Console.WriteLine("Invalid choice");
                return;
            }
            else
            {
                if (args[0] == "Save")
                {
                    xmlSerialize();
                    //serialize();//take the inputs from the user and save it.
                }
                else
                {
                    xmlDeserialize();
                    //deserialize();//display the saved data.
                }
            }    
 
        }

        private static void xmlDeserialize()
        {
            XmlSerializer fm = new XmlSerializer(typeof(Employee));
            FileStream fs = new FileStream("Data.xml", FileMode.Open, FileAccess.Read);
            var emp = fm.Deserialize(fs) as Employee;
            Console.WriteLine(emp);
        }

        private static void xmlSerialize()
        {
            Employee emp = new Employee { EmpID = 111, EmpName = "Phaniraj" };
            XmlSerializer fm = new XmlSerializer(typeof(Employee));//Class for Xml serializing. 
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, emp);
            fs.Close();
        }

        private static void deserialize()
        {
            Employee emp;//the object
            binary.BinaryFormatter fm = new binary.BinaryFormatter();//format of serialization
            FileStream fs = new FileStream("Data.Bin", FileMode.Open, FileAccess.Read);
            object boxedData = fm.Deserialize(fs);
            if(boxedData is Employee)
            {
                emp = boxedData as Employee;
                Console.WriteLine(emp);
            }
            fs.Close();
        }

        private static void serialize()
        {
            Employee emp = new Employee { EmpID = 123, EmpName = "SampleName" };//the object
            binary.BinaryFormatter fm = new binary.BinaryFormatter();//format of serialization
            FileStream fs = new FileStream("Data.Bin", FileMode.OpenOrCreate, FileAccess.Write);
            fm.Serialize(fs, emp);
            fs.Close();
        }
    }
}
