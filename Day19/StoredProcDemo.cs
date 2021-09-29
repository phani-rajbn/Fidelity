using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//Stored procedures are created in databases to optimize the SQL statements that are used very frequently in ur app..
//Create stored Procs and call them in ur code. 
//good practice to store the connection string in the config file and access it thru' code using the dll System.Configuration. Should add the reference of this dll and use it's namespace.
namespace SampleDBApp.Day19
{
    class StoredProcDemo
    {
        static string strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        
        static void callingInsertProc()
        {
            string query = "InsertCustomer";
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;//Tell the system that it is a stored proc.
            cmd.Parameters.AddWithValue("@id", 501);
            cmd.Parameters.AddWithValue("@name", "Sachin");
            cmd.Parameters.AddWithValue("@contact", 9944223123);
            cmd.Parameters.AddWithValue("@city", "Mysore");
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }

        static void insertStudent()
        {
            string query = "InsertStudent";
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;//Tell the system that it is a stored proc.
            int studentID = 0;
            cmd.Parameters.AddWithValue("@name", "Sachin");
            cmd.Parameters.AddWithValue("@marks", 78);
            cmd.Parameters.AddWithValue("@age", 23);
            cmd.Parameters.AddWithValue("id", studentID);
            cmd.Parameters[3].Direction = ParameterDirection.Output;//Important for output parameters. 
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                studentID = Convert.ToInt32(cmd.Parameters[3].Value);
                Console.WriteLine("The id of the new student is " + studentID);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }
        static void Main(string[] args)
        {
            insertStudent();
            //callingInsertProc();
        }
    }
}
