using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project1.DataModels;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Project1.DataTiers
{
    public class CustomerInfoTier
    {
        private string connectionString { get; set; }
        private SqlCommand cmd { get; set; }
        private SqlConnection conn { get; set; }
        private SqlDataReader reader { get; set; }
        private bool success { get; set; }
        private string query { get; set; }
        private int rows { get; set; }

        public CustomerInfoTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Minerva"].ToString();
            success = false;
        }

        public DataSet getCustomerDataSet()
        {
            DataSet ds;
            SqlDataAdapter da;
            string query = "SELECT * FROM CustomerInfo;";
            da = new SqlDataAdapter(query, connectionString);
            ds = new DataSet();
            try
            {
                da.Fill(ds, "CustomerInfo");
            }
            catch(SqlException ex)
            {
                throw new Exception("Error Filling DataSet" + ex.Message);
            }
            return ds;
        }

        /// <summary>
        ///This method will return a list of all customers in the CustomerInformation Table. 
        /// </summary>
        /// <returns>Returns a list of customers</returns>
        public List<Customer> getAllCustomers()
        {
            List<Customer> theList = null;
            Customer theCustomer = null;

            query = "SELECT * FROM CustomerInfo;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();

                    using (reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            theList = new List<Customer>();
                            while (reader.Read())
                            {
                                theCustomer = new Customer();

                                theCustomer.CustID = (int)reader["CustID"];
                                theCustomer.firstName = reader["FirstName"].ToString();
                                theCustomer.middleName = reader["MiddleName"].ToString();
                                theCustomer.lastName = reader["LastName"].ToString();
                                theCustomer.address = reader["Address"].ToString();
                                theCustomer.address2 = reader["Address2"].ToString();
                                theCustomer.city = reader["City"].ToString();
                                theCustomer.state = reader["State"].ToString();
                                theCustomer.zipCode = (int)reader["Zip"];

                                theList.Add(theCustomer);
                            }
                        }
                    }

                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }


            return theList;
        }


        /// <summary>
        /// This method will insert a customer into the CustomerInformation table.
        /// </summary>
        /// <param name="theCustomer">The customer to be inserted as Customer type.</param>
        /// <returns>Returns true on success.</returns>
        public bool insertCustomer(Customer theCustomer)
        {
            query = "INSERT INTO CustomerInfo (FirstName, MiddleName, LastName, Address, Address2, City, State, Zip) " +
                "VALUES (@FName, @MName, @LName, @Address, @Address2, @City, @State, @Zip);";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = theCustomer.firstName;
                cmd.Parameters.Add("@MName", SqlDbType.VarChar, 50).Value = theCustomer.middleName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = theCustomer.lastName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = theCustomer.address;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = theCustomer.address2;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = theCustomer.city;
                cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = theCustomer.state;
                cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = theCustomer.zipCode;

                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }

                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }


            return success;
        }

        /// <summary>
        /// This method will update a given customer in the CustomerInformation table.
        /// </summary>
        /// <param name="theCustomer">The customer as the Customer type.</param>
        /// <returns>Returns true on success.</returns>
        public bool updateCustomer(Customer theCustomer)
        {
            query = "UPDATE CustomerInfo SET FirstName = @FName, " +
                "MiddleName = @MName, LastName = @LName, Address = @Address, " +
                "Address2 = @Address2, City = @City, State = @State, Zip = @Zip " +
                "WHERE CustID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = theCustomer.CustID;
                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = theCustomer.firstName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = theCustomer.lastName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = theCustomer.address;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = theCustomer.address2;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = theCustomer.city;
                cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = theCustomer.state;
                cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = theCustomer.zipCode;

                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }

                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }

            return success;
        }

        /// <summary>
        /// This method will delete a customer from the CustomerInformation table.
        /// </summary>
        /// <param name="custID">The ID of the customer as an Integer.</param>
        /// <returns>Returns true on success.</returns>
        public bool deletCustomer(int custID)
        {
            query = "DELETE FROM CustomerInfo WHERE CustID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = custID;

                try
                {
                    conn.Open();
                    rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return success;
        }


    }
}