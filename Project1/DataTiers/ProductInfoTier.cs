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
    public class ProductInfoTier
    {
        private string connectionString { get; set; }
        private SqlCommand cmd { get; set; }
        private SqlConnection conn { get; set; }
        private SqlDataReader reader { get; set; }
        private bool success { get; set; }
        private string query { get; set; }
        private int rows { get; set; }

        public ProductInfoTier()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Minerva"].ToString();
            success = false;
        }

        public DataSet getProductDataSet()
        {
            DataSet ds;
            SqlDataAdapter da;
            string query = "SELECT * FROM ProductInfo;";
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

        public Product getProductByID(int ID)
        {
            Product theProduct = null;

            query = "SELECT * FROM ProductInfo WHERE ProductID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                try
                {
                    conn.Open();

                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        theProduct = new Product();
                        theProduct.ProductDescription = reader["ProductDescription"].ToString();
                        theProduct.ProductName = reader["ProductName"].ToString();
                        theProduct.ProductPrice = int.Parse(reader["ProductPrice"].ToString());
                        theProduct.QuantityOnHand = int.Parse(reader["QuantityOnHand"].ToString());
                        theProduct.DepartmentID = int.Parse(reader["DepartmentID"].ToString());
                        theProduct.CategoryID = int.Parse(reader["CategoryID"].ToString());
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
            return theProduct;
        }

        public List<Product> getAllProducts()
        {
            List<Product> theList = null;
            Product theProduct = null;

            query = "SELECT * FROM ProductInfo;";

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
                            theList = new List<Product>();
                            while (reader.Read())
                            {
                                theProduct = new Product();

                                theProduct.ProductID = (int)reader["ProductID"];
                                theProduct.ProductDescription = reader["ProductDescription"].ToString();
                                theProduct.ProductName = reader["ProductName"].ToString();
                                theProduct.ProductPrice = int.Parse(reader["ProductPrice"].ToString());
                                theProduct.QuantityOnHand = int.Parse(reader["QuantityOnHand"].ToString());
                                theProduct.DepartmentID = int.Parse(reader["DepartmentID"].ToString());
                                theProduct.CategoryID = int.Parse(reader["CategoryID"].ToString());

                                theList.Add(theProduct);
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

        public bool insertProduct(Product theProduct)
        {
            query = "INSERT INTO ProductInfo (ProductDescription, ProductName, ProductPrice, QuantityOnHand, DepartmentID, CategoryID) " +
                "VALUES (@ProductDescription, @ProductName, @ProductPrice, @QuantityOnHand, @DepartmentID, @CategoryID);";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = theProduct.ProductDescription;
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = theProduct.ProductName;
                cmd.Parameters.Add("@ProductPrice", SqlDbType.Int).Value = theProduct.ProductPrice;
                cmd.Parameters.Add("@QuantityOnHand", SqlDbType.Int).Value = theProduct.QuantityOnHand;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = theProduct.DepartmentID;
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = theProduct.CategoryID;

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

        public bool updateProduct(Product theProduct)
        {
            query = "UPDATE ProductInfo SET ProductDescription = @ProductDescription, " +
                "ProductName = @ProductName, ProductPrice = @ProductPrice, QuantityOnHand = @QuantityOnHand, " +
                "DepartmentID = @DepartmentID, CategoryID = @CategoryID" +
                "WHERE ProductID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = theProduct.ProductID;
                cmd.Parameters.Add("@ProductDescription", SqlDbType.VarChar, 50).Value = theProduct.ProductDescription;
                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 50).Value = theProduct.ProductName;
                cmd.Parameters.Add("@ProductPrice", SqlDbType.Int).Value = theProduct.ProductPrice;
                cmd.Parameters.Add("@QuantityOnHand", SqlDbType.Int).Value = theProduct.QuantityOnHand;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = theProduct.DepartmentID;
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = theProduct.CategoryID;

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

        public bool deleteProduct(int ProductID)
        {
            query = "DELETE FROM ProductInfo WHERE ProductID = @ID;";

            using (conn = new SqlConnection(connectionString))
            using (cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ProductID;

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