using System;
using System.Data;
using System.Data.SqlClient;//Namespace for accessing SQL Server Database. 
//ADO.NET is a universal data Access model, U choose the database, .NET provides APIs for accessing the specific DBs. 
//All Data Providers will implement the Common interfaces that .NET Exposes. They will create classes implementing those interfaces which .NET programmers will consume. 
//This way of connecting to the datasource and exclusively opening and closing the connection while the operation is happening is called as CONNECTED MODEL of ADO.NET. 
namespace SampleFrameworkApp.Day14
{
    using System.Collections.Generic;
    using SampleFrameworkApp.Day11;
    class SqlDBEmployee : IEmpDatabase
    {
        public void AddEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Find(int id)
        {
            string query = $"SELECT * FROM EMPTABLE WHERE EMPID = {id}";
            SqlConnection con = new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = SampleDatabase; Integrated Security = True");
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No Record found for this Employee");
                while (reader.Read()) 
                {
                    var emp = new Employee();
                    emp.EmpID = Convert.ToInt32(reader[0]);
                    emp.EmpName = reader[1].ToString();
                    emp.EmpAddress = reader["EmpAddress"].ToString();
                    emp.EmpSalary = Convert.ToDouble(reader[3]);
                    return emp;
                }
                throw new Exception("Employee not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public List<Employee> Find(string name)
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindByAddress(string address)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }
    }
    class DataAccessDemo
    {
        const string SELECT = "Select * from EmpTable";
        const string STRCONNECTION = @"Data Source=.\SQLEXPRESS;Initial Catalog=SampleDatabase;Integrated Security=True";//ConnectionString is a string info about the database that UR app has to connect. It will have the server name, database name, usename, password, provider name.
        static void Main(string[] args)
        {
            //directDBConnection();
            IEmpDatabase db = new SqlDBEmployee();
            var emp = db.Find((int)MyConsole.GetNumber("Enter the ID of the Employee to search"));
            Console.WriteLine(emp.ToString());
        }

        private static void directDBConnection()
        {
            using (SqlConnection con = new SqlConnection(STRCONNECTION))
            {
                con.Open();//Opens an exclusive connection to the specified database whose details are mentioned in the ConnectionString. 
                SqlCommand cmd = new SqlCommand(SELECT, con);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[1]} from {reader[2]}");
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { con.Close(); }
            }
        }
    }
}
