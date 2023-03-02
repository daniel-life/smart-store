using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Inv_Product
    {
        private String connectionString = Properties.Settings.Default.AzureDBConnStr;

        private String prodID;
        private String prodName;
        private String description;
        private String price;
        private String RFIDtag;
        private String quantity;
        private String threshold;
        
        public Inv_Product(String prodID = "",
                        String prodName = "",
                        String description = "",
                        String price = "",
                        String RFIDtag = "",
                        String quantity = "",
                        String threshold = "")
        {
            this.prodID = prodID;
            this.prodName = prodName;
            this.description = description;
            this.price = price;
            this.RFIDtag = RFIDtag;
            this.quantity = quantity;
            this.threshold = threshold;
        }

        public string ProdID
        {
            get { return prodID; }
            set { prodID = value; }
        }

        public string ProdName
        {
            get { return prodName; }
            set { prodName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string RFIDTag
        {
            get { return RFIDtag; }
            set { RFIDtag = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Threshold
        {
            get { return threshold; }
            set { threshold = value; }
        }

        public int InsertProduct()
        {
            String query =
                String.Format("INSERT INTO Inventory (ProdID, ProdName, Description, Price, RFIDTag, Quantity, Threshold) " +
                                "VALUES('{0}','{1}','{2}','{3}','{4}', '{5}', '{6}')",
                                this.prodID,
                                this.prodName,
                                this.description,
                                this.price,
                                this.RFIDtag,
                                this.quantity,
                                this.threshold);

            int numberOfRows = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    numberOfRows = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return numberOfRows;
        }
        public List<Inv_Product> GetAllProduct()
        {
            List<Inv_Product> products = new List<Inv_Product>();
            String query = "SELECT * FROM Inventory Order By ProdID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            String prodID = dataReader["ProdID"].ToString();
                            String prodName = dataReader["ProdName"].ToString();
                            String description = dataReader["Description"].ToString();
                            String price = dataReader["Price"].ToString();
                            String RFIDtag = dataReader["RFIDTag"].ToString();
                            String quantity = dataReader["Quantity"].ToString();
                            String threshold = dataReader["Threshold"].ToString();

                            products.Add(new Inv_Product(prodID, prodName, description, price, RFIDtag, quantity, threshold));
                        }

                        connection.Close();
                        dataReader.Close();
                        dataReader.Dispose();
                    }
                }
            }

            return products;
        }

        public int UpdateProduct()
        {
            string query =
                " UPDATE Inventory SET ProdName = @prodName, " +
                " Description = @description, Price = @price, RFIDTag = @RFIDtag, Quantity = @quantity, Threshold = @threshold" +
                " WHERE ProdID = @prodID";

            int numberOfRows = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("prodID", this.prodID);
                    command.Parameters.AddWithValue("prodName", this.prodName);
                    command.Parameters.AddWithValue("description", this.description);
                    command.Parameters.AddWithValue("price", this.price);
                    command.Parameters.AddWithValue("RFIDtag", this.RFIDtag);
                    command.Parameters.AddWithValue("quantity", this.quantity);
                    command.Parameters.AddWithValue("threshold", this.threshold);

                    connection.Open();
                    numberOfRows = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return numberOfRows;
        }

        public int ProductDelete(String prodID)
        {
            string queryStr = "DELETE FROM Inventory WHERE ProdID=@prodID";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@prodID", prodID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }
        
        public Inv_Product GetProduct(String prodID)
        {
            Inv_Product product = null;
            String query = "SELECT * FROM Inventory WHERE ProdID = @prodID ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prodID", prodID);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        String prodName = dataReader["ProdName"].ToString();
                        String description = dataReader["Description"].ToString();
                        String price = dataReader["Price"].ToString();
                        String RFIDtag = dataReader["RFIDTag"].ToString();
                        String quantity = dataReader["Quantity"].ToString();
                        String threshold = dataReader["Threshold"].ToString();

                        product =
                            new Inv_Product(prodID,
                                        prodName,
                                        description,
                                        price,
                                        RFIDtag,
                                        quantity,
                                        threshold);
                    }

                    connection.Close();
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }

            return product;
        }
    }
}
