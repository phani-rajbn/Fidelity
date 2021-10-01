using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/*ADO.NET is a technology based on .NET for developing data access to both relational and non-relational databases. 
 Connected model is a way of accessing the database using ADO.NET to allow interactions from the .NET App to the database with constant live connection. If the connection is closed, the interactions will not happen. 
  Limits: U can access live data all the time. Too many connections can crash the app or will not allow database access. Suited for windows based apps and intranet based applications.
A Connection class is required to make the connectivity to the database. 
A Command class to pass the SQL Commands to the database. 
A Reader class to read the data extracted from the SELECT commands made to the database from the Command object.
3 ways to execute statement: 
ExecuteReader: Used while passing SELECT Statements which return the data in the form of Reader object.  
ExecuteScalar: Used for returning scalar values: only one row or one data.  
ExecuteNonQuery. Used when U pass INSERT, DELETE, UPDATE statements. No return data is expected in these commands except the no of rows affected by the execution. 
 */
namespace SampleDBApp.Day20
{
    class ConnectedRecap
    {
        static string strCon = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
        const string query = "SELECT Movie.Title, Director.DirectorName FROM MOVIE INNER JOIN DIRECTOR on Movie.DirectorID = Director.DirectorID WHERE Director.DirectorName = @name";
        static void Main(string[] args)
        {
            showmoviesByDirector("Atlee");
        }

        private static void showmoviesByDirector(string name)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", name);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                    Console.WriteLine($"{reader[0]} -{reader[1]}");
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
            }
        }
    }
}
