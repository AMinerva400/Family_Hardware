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
    public class EmployeeInfoTier
    {
        private string connectionString { get; set; }
        private SqlCommand cmd { get; set; }
        private SqlConnection conn { get; set; }
        private SqlDataReader reader { get; set; }
        private bool success { get; set; }
        private string query { get; set; }
        private int rows { get; set; }

        public EmployeeInfoTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Minerva"].ToString();
            success = false;
        }

        public DataSet getEmployeeDataSet()
        {
            DataSet ds;
            SqlDataAdapter da;
            string query = "SELECT * FROM EmployeeInfo;";
            da = new SqlDataAdapter(query, connectionString);
            ds = new DataSet();
            try
            {
                da.Fill(ds, "EmployeeInfo");
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Filling DataSet" + ex.Message);
            }
            return ds;
        }

        public List<Employee> getAllEmployees()
        {
            List<Employee> theList = null;
            Employee theEmployee = null;

            query = "SELECT * FROM EmployeeInfo;";

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
                            theList = new List<Employee>();
                            while (reader.Read())
                            {
                                theEmployee = new Employee();

                                theEmployee.EmployeeID = (int)reader["EmployeeID"];
                                theEmployee.firstName = reader["FirstName"].ToString();
                                theEmployee.middleName = reader["MiddleName"].ToString();
                                theEmployee.lastName = reader["LastName"].ToString();
                                theEmployee.address = reader["Address"].ToString();
                                theEmployee.address2 = reader["Address2"].ToString();
                                theEmployee.city = reader["City"].ToString();
                                theEmployee.state = reader["State"].ToString();
                                theEmployee.zipCode = (int)reader["Zip"];
                                theEmployee.DateHired = reader["DateHired"].ToString();
                                theEmployee.DateTerminated = reader["DateTerminated"].ToString();
                                theEmployee.TaxID = (int)reader["TaxID"];
                                theEmployee.ManagerID = (int)reader["ManagerID"];
                                theEmployee.DepartmentID = (int)reader["DepartmentID"];

                                theList.Add(theEmployee);
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
        
        public bool insertEmployee(Employee theEmployee)
        {
            query = "INSERT INTO EmployeeInfo (FirstName, MiddleName, LastName, Address, Address2, City, State, Zip, DateHired, DateTerminated, TaxID, ManagerID, DepartmentID) " +
                "VALUES (@FName, @MName, @LName, @Address, @Address2, @City, @State, @Zip, @DateHired, @DateTerminated, @TaxID, @ManagerID, @DepartmentID);";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = theEmployee.firstName;
                cmd.Parameters.Add("@MName", SqlDbType.VarChar, 50).Value = theEmployee.middleName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = theEmployee.lastName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = theEmployee.address;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = theEmployee.address2;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = theEmployee.city;
                cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = theEmployee.state;
                cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = theEmployee.zipCode;
                cmd.Parameters.Add("@DateHired", SqlDbType.VarChar, 50).Value = theEmployee.DateHired;
                cmd.Parameters.Add("@DateTerminated", SqlDbType.VarChar, 50).Value = theEmployee.DateTerminated;
                cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = theEmployee.TaxID;
                cmd.Parameters.Add("@ManagerID", SqlDbType.Int).Value = theEmployee.ManagerID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = theEmployee.DepartmentID;

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

        public bool updateEmployee(Employee theEmployee)
        {
            query = "UPDATE EmployeeInfo SET FirstName = @FName, " +
                "MiddleName = @MName, LastName = @LName, Address = @Address, " +
                "Address2 = @Address2, City = @City, State = @State, Zip = @Zip " +
                "DateHired = @DateHired, DateTerminated = @DateTerminated, TaxID = @TaxID" +
                "ManagerID = @ManagerID, DepartmentID = @DepartmentID" +
                "WHERE EmployeeID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = theEmployee.EmployeeID;
                cmd.Parameters.Add("@FName", SqlDbType.VarChar, 50).Value = theEmployee.firstName;
                cmd.Parameters.Add("@LName", SqlDbType.VarChar, 50).Value = theEmployee.lastName;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar, 50).Value = theEmployee.address;
                cmd.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = theEmployee.address2;
                cmd.Parameters.Add("@City", SqlDbType.VarChar, 50).Value = theEmployee.city;
                cmd.Parameters.Add("@State", SqlDbType.VarChar, 50).Value = theEmployee.state;
                cmd.Parameters.Add("@Zip", SqlDbType.Int).Value = theEmployee.zipCode;
                cmd.Parameters.Add("@DateHired", SqlDbType.VarChar, 50).Value = theEmployee.DateHired;
                cmd.Parameters.Add("@DateTerminated", SqlDbType.VarChar, 50).Value = theEmployee.DateTerminated;
                cmd.Parameters.Add("@TaxID", SqlDbType.Int).Value = theEmployee.TaxID;
                cmd.Parameters.Add("@ManagerID", SqlDbType.Int).Value = theEmployee.ManagerID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = theEmployee.DepartmentID;

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

        public bool deleteEmployee(int EmployeeID)
        {
            query = "DELETE FROM EmployeeInfo WHERE EmployeeID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = EmployeeID;

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