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
    public class SalesInfoTier
    {
        private string connectionString { get; set; }
        private SqlCommand cmd { get; set; }
        private SqlConnection conn { get; set; }
        private SqlDataReader reader { get; set; }
        private bool success { get; set; }
        private string query { get; set; }
        private int rows { get; set; }

        public SalesInfoTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Minerva"].ToString();
            success = false;
        }

        public DataSet getSalesDataSet()
        {
            DataSet ds;
            SqlDataAdapter da;
            string query = "SELECT * FROM SalesInfo;";
            da = new SqlDataAdapter(query, connectionString);
            ds = new DataSet();
            try
            {
                da.Fill(ds, "ProductInfo");
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Filling DataSet" + ex.Message);
            }
            return ds;
        }
        
        public List<Sales> getAllSales()
        {
            List<Sales> theList = null;
            Sales theSale = null;

            query = "SELECT * FROM SalesInfo;";

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
                            theList = new List<Sales>();
                            while (reader.Read())
                            {
                                theSale = new Sales();

                                theSale.SalesID = (int)reader["SalesID"];
                                theSale.QuantitySold = (int)reader["QuantitySold"];
                                theSale.PaymentType = reader["PaymentType"].ToString();
                                theSale.TotalPrice = (int)reader["TotalPrice"];

                                theList.Add(theSale);
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

        public bool insertSale(Sales theSale)
        {
            query = "INSERT INTO SalesInfo (QuantitySold, PaymentType, TotalPrice) " +
                "VALUES (@QuantitySold, @PaymentType, @TotalPrice);";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@QuantitySold", SqlDbType.Int).Value = theSale.QuantitySold;
                cmd.Parameters.Add("@PaymentType", SqlDbType.VarChar, 50).Value = theSale.PaymentType;
                cmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = theSale.TotalPrice;
                
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

        public bool updateSale(Sales theSale)
        {
            query = "UPDATE SalesInfo SET QuantitySold = @QuantitySold, PaymentType = @PaymentType, TotalPrice = @TotalPrice " +
                "WHERE ProductID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@QuantitySold", SqlDbType.Int).Value = theSale.QuantitySold;
                cmd.Parameters.Add("@PaymentType", SqlDbType.VarChar, 50).Value = theSale.PaymentType;
                cmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = theSale.TotalPrice;

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

        public bool deleteSale(int SalesID)
        {
            query = "DELETE FROM SalesInfo WHERE SalesID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SalesID;

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