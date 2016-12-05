using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ShoppingCart.DAL
{
    public class DataAccess
    {
        private static readonly string _connectionString = string.Empty;

        /// <summary>
        /// Selects all products from the database
        /// </summary>
        public List<Product> ProductSelectAll()
        {
            // Create Product collection
            List<Product> colProducts = new List<Product>();

            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT PRODUCT_ID, PRODUCT_NAME, DESC_SHORT, UNIT_PRICE, UNIT_PRICE_PER, " +
                "IMAGELOCLRG, IMAGELOCSML, AVAILABLE FROM PRODUCT ORDER BY PRODUCT_NAME ";

            // Execute command
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colProducts.Add(new Product(
                        (int)reader["PRODUCT_ID"],
                        (string)reader["PRODUCT_NAME"],
                        (string)reader["DESC_SHORT"],
                        (decimal)reader["UNIT_PRICE"],
                        (string)reader["UNIT_PRICE_PER"],
                        (string)reader["IMAGELOCLRG"],
                        (string)reader["IMAGELOCSML"],
                        (bool)reader["AVAILABLE"]));
                }
            }
            return colProducts;
        }


        /// <summary>
        /// Selects all active products from the database
        /// </summary>
        public List<Product> ProductSelectAllActive()
        {
            // Create Product collection
            List<Product> colProducts = new List<Product>();

            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT PRODUCT_ID, PRODUCT_NAME, DESC_SHORT, UNIT_PRICE, UNIT_PRICE_PER, " +
                "IMAGELOCLRG, IMAGELOCSML, AVAILABLE FROM PRODUCT " +
                "WHERE AVAILABLE=1 ORDER BY PRODUCT_NAME ";

            // Execute command
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colProducts.Add(new Product(
                        (int)reader["PRODUCT_ID"],
                        (string)reader["PRODUCT_NAME"],
                        (string)reader["DESC_SHORT"],
                        (decimal)reader["UNIT_PRICE"],
                        (string)reader["UNIT_PRICE_PER"],
                        (string)reader["IMAGELOCLRG"],
                        (string)reader["IMAGELOCSML"],
                        (bool)reader["AVAILABLE"]));
                }
            }
            return colProducts;
        }


        public void ProductUpdate(Product productToUpdate)
        {
            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE PRODUCT SET PRODUCT_NAME=@Name, DESC_SHORT=@Description, UNIT_PRICE=@Price, UNIT_PRICE_PER=@PricePer, " +
                "IMAGELOCLRG=@PicLg, IMAGELOCSML=@PicSm, AVAILABLE=@Available WHERE PRODUCT_ID=@Id";

            // Add parameters
            cmd.Parameters.AddWithValue("@Name", productToUpdate.Name);
            cmd.Parameters.AddWithValue("@Description", productToUpdate.Description);
            cmd.Parameters.AddWithValue("@Price", productToUpdate.Price);
            cmd.Parameters.AddWithValue("@PricePer", productToUpdate.PricePer);
            cmd.Parameters.AddWithValue("@PicLg", productToUpdate.PicLocLg);
            cmd.Parameters.AddWithValue("@PicSm", productToUpdate.PicLocSm);
            cmd.Parameters.AddWithValue("@Available", productToUpdate.Available);
            cmd.Parameters.AddWithValue("@Id", productToUpdate.Id);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void ProductInsert(Product productToInsert)
        {
            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT PRODUCT (PRODUCT_NAME, DESC_SHORT, UNIT_PRICE, UNIT_PRICE_PER, " +
               " IMAGELOCLRG, IMAGELOCSML) VALUES (@Name, @Description, @Price, @PricePer, @PicLg, @PicSm)";

            // Add parameters
            cmd.Parameters.AddWithValue("@Name", productToInsert.Name);
            cmd.Parameters.AddWithValue("@Description", productToInsert.Description);
            cmd.Parameters.AddWithValue("@Price", productToInsert.Price);
            cmd.Parameters.AddWithValue("@PricePer", productToInsert.PricePer);
            cmd.Parameters.AddWithValue("@PicLg", productToInsert.PicLocLg);
            cmd.Parameters.AddWithValue("@PicSm", productToInsert.PicLocSm);
            cmd.Parameters.AddWithValue("@Available", productToInsert.Available);
            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }



        public int InsertOrder()
        {
            int visitorId;

            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT VISITOR (LAST_VISIT) VALUES (@Date);SELECT CAST(scope_identity() AS int)";

            // Add parameters
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);



            // Execute command
            using (con)
            {
                con.Open();
                visitorId = (int)cmd.ExecuteScalar();

            }

            return visitorId;
        }

        public int InsertVisitor()
        {
            int visitorId;

            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT VISITOR (LAST_VISIT) VALUES (@Date);SELECT CAST(scope_identity() AS int)";

            // Add parameters
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);



            // Execute command
            using (con)
            {
                con.Open();
                visitorId = (int)cmd.ExecuteScalar();

            }

            return visitorId;
        }


        public void UpdateVisit(int visitorId)
        {
            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE VISITOR SET LAST_VISIT=@DATE WHERE VISITOR_ID=@Id";

            // Add parameters
            cmd.Parameters.AddWithValue("@Id", visitorId);
            cmd.Parameters.AddWithValue("@Date", DateTime.Now);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }


        }

        /// <summary>
        /// Initialize the data access layer by
        /// loading the database connection string from 
        /// the Web.Config file
        /// </summary>
        static DataAccess()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["fall16_g3ConnectionString2"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("No connection string configured in Web.Config file");
        }
    }
}