using System;
using System.Collections.Generic;
using System.Data.SqlClient;//Classes for connecting to SQL server in an optimized manner. 
using System.Security.Policy;
using System.Xml.Linq;

//Use ADO.NET Connected Model to interact with the SQL server database. 
namespace SampleDBApp.Day18
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime Visit { get; set; }
        public long Contact { get; set; }
        public string City { get; set; }
        public override string ToString()
        {
            return $"{CustomerName} from {City} visited us on {Visit.ToShortDateString()} and give his contact as {Contact}";
        }
    }

    class Program
    {
        //ConnectionString is a string that contains the info required for a successfull connection to the specific database. This includes servername, dbname, username, password, additional components like drivername and many more. 

        const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=FidelityDB;Integrated Security=True";
        const string strSelect = "SELECT CustomerName from Customer";
        static void connectToDB()
        {
            SqlConnection connection = new SqlConnection(strConnection);
            try
            {
                connection.Open();
                Console.WriteLine("Test Connection Succeeded!");
                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
            }
        }

        static void readNamesOfCustomers()
        {
            SqlConnection connection = new SqlConnection(strConnection);
            SqlCommand command = new SqlCommand(strSelect, connection);
            try
            {
                connection.Open();//Open the connection
                SqlDataReader reader = command.ExecuteReader();//Execute the statement using Command object
                if (!reader.HasRows)
                {
                    Console.WriteLine("No Data in the table");
                    connection.Close();
                    connection.Dispose();
                    return;
                }
                while (reader.Read())//Start reading it.....
                {
                    Console.WriteLine(reader["CustomerName"]);
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Dispose();
                command.Dispose();
            }
        }

        static void displayAllDetails()
        {
            SqlConnection con = new SqlConnection(strConnection);
            SqlCommand cmd = new SqlCommand("SELECT * FROM CUSTOMER", con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    Console.WriteLine("No data found!!!");
                }
                else
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Details of {reader[1]}");
                        Console.WriteLine($"ID: {reader[0]}");
                        DateTime dt = Convert.ToDateTime(reader[2]);//Convert object to DateTime. 
                        Console.WriteLine($"VisitDate: {dt.ToShortDateString()}");
                        Console.WriteLine($"Phone No: {reader[3]}");
                        Console.WriteLine($"City: {reader[4]}");
                        Console.WriteLine("-----------------------------------------------------");
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Dispose();
                cmd.Dispose();
            }
        }

        static List<Customer> getAllCustomers()
        {
            //Create the connection
            SqlConnection connection = new SqlConnection(strConnection);
            //Create the Command
            SqlCommand cmd = new SqlCommand("SELECT * From Customer", connection);
            //Create a blank list of Customers
            List<Customer> customers = new List<Customer>();
            //execute the command to return a reader 
            try
            {
                connection.Open();
                var reader = cmd.ExecuteReader();
                //run thro the while loop
                while (reader.Read())
                {
                    //Convert the row of the reader into Customer object
                    var cst = new Customer();
                    cst.CustomerID = Convert.ToInt32(reader[0]);
                    cst.CustomerName = reader[1].ToString();
                    cst.Visit = Convert.ToDateTime(reader[2]);
                    cst.Contact = Convert.ToInt64(reader[3]);
                    cst.City = reader[4].ToString();
                    //add the customer object to the list
                    customers.Add(cst);
                }
                connection.Close();//close the connection
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally//finally dispose the object.
            {
                connection.Dispose();
                cmd.Dispose();
            }
            //return the list
            return customers;
        }

        private static Customer createCustomer(SqlDataReader reader)
        {
            var cst = new Customer
            {
                City = reader["City"].ToString(),
                CustomerName = reader["CustomerName"].ToString(),
                CustomerID = Convert.ToInt32(reader["CustomerID"]),
                Contact = Convert.ToInt64(reader["Contact"]),
                Visit = Convert.ToDateTime(reader["VisitTime"])
            };
            return cst;
        }
        static Customer findCustomer(int id)
        {
            SqlConnection con = new SqlConnection(strConnection);
            string query = $"Select * from customer where customerid = ${id}";
            var cmd = new SqlCommand(query, con);
            var cst = new Customer();
            try
            {
                con.Open();    
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        cst = new Customer
                        {
                            City = reader["City"].ToString(),
                            CustomerName = reader["CustomerName"].ToString(),
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            Contact = Convert.ToInt64(reader["Contact"]),
                            Visit = Convert.ToDateTime(reader["VisitTime"])
                        };
                        break;
                    }
                    return cst;
                }
                else
                    throw new Exception("No Customer found");
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
        static Customer findCustomer(string name)
        {
            throw new Exception("Not implemented");
        }
        static void updateCustomer(int id, string name, string city, long phone)
        {
            var query = "update customer set CustomerName = @name, city = @city, contactNo = @phone, visittime = @dt where customerid = @id";
            var connection = new SqlConnection(strConnection);
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@dt", DateTime.Now);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Dispose();
            }
        }
        static void deleteCustomer(int id)
        {
            var query = "Delete from Customer where CustomerID = @id";
            var connection = new SqlConnection(strConnection);
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Dispose();
            }
        }
        //Using Parameters to insert a record.
        static void addCustomer(int id, string name, string city, long phone)
        {
            //insertCode(name, city, phone);
            var query = "Insert into Customer values(@id, @name, @visit, @phone, @city)";
            var connection = new SqlConnection(strConnection);
            var cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@visit", DateTime.Now);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();       
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Dispose();
            }

        }

        private static void insertCode(int id, string name, string city, long phone)
        {
            var insertStatement = $"Insert into Customer values({id}', {name}','{DateTime.Now.ToShortTimeString()}',{phone},'{city}')";
            using (var connection = new SqlConnection(strConnection))
            {
                var cmd = new SqlCommand(insertStatement, connection);
                try
                {
                    connection.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();//use this function for insert, delete and update as U dont return any results
                    if (rowsAffected == 1)
                        Console.WriteLine("Added");
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            updateCustomer(513, "Lakshmi Devi", "Mysore", 4345456456);
        }
    }
}
