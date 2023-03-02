using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Store_Product
    {
        private string _connectionString = Properties.Settings.Default.AzureDBConnStr;

        private decimal _prodID = 0;
        private string _prodName = "";
        private string _prodDescription = "";
        private decimal _prodPrice = 0;
        private string _prodCategory = "";
        private string _prodImage = "";
        
        // Default constructor
        public Store_Product()
        {
        }

        public Store_Product(decimal prodID,
                        string prodName,
                        string prodDescription,
                        decimal prodPrice,
                        string prodCategory,
                        string prodImage)
        {
            _prodID = prodID;
            _prodName = prodName;
            _prodDescription = prodDescription;
            _prodPrice = prodPrice;
            _prodCategory = prodCategory;
            _prodImage = prodImage;
        }

        // Constructor that take in all except product ID
        public Store_Product(string prodName, string prodDescription,
               decimal prodPrice, string prodCategory, string prodImage)
            : this(0, prodName, prodDescription, prodPrice, prodCategory, prodImage)
        {
        }

        //public Product(string prodName, decimal prodPrice, string prodImage)
        //    : this(0, prodName, "", prodPrice, "", prodImage)
        //{
        //}

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public Store_Product(decimal prodID)
            : this(prodID, "", "", 0, "", "")
        {
        }



        public decimal ProdID
        {
            get { return _prodID; }
            set { _prodID = value; }
        }
        public string ProdName
        {
            get { return _prodName; }
            set { _prodName = value; }
        }
        public string ProdDescription
        {
            get { return _prodDescription; }
            set { _prodDescription = value; }
        }
        public decimal ProdPrice
        {
            get { return _prodPrice; }
            set { _prodPrice = value; }
        }
        public string ProdCategory
        {
            get { return _prodCategory; }
            set { _prodCategory = value; }
        }

        public string ProdImage
        {
            get { return _prodImage; }
            set { _prodImage = value; }
        }
        public Store_Product GetProduct(decimal prodID)
        {
            Store_Product prodDetail = null;

            string prod_Name, prod_Description, prod_Category, prod_Image;
            decimal prod_Price;

            string queryStr = "SELECT * FROM Product WHERE ProdID = @ProdID";

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ProdID", prodID);

            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                prod_Name = dr["ProdName"].ToString();
                prod_Description = dr["ProdDescription"].ToString();
                prod_Image = dr["ProdImage"].ToString();
                prod_Price = decimal.Parse(dr["ProdPrice"].ToString());
                prod_Category = dr["ProdCategory"].ToString();

                prodDetail = new Store_Product(prodID, prod_Name, prod_Description, prod_Price, prod_Category, prod_Image);
            }
            else
            {
                prodDetail = null;
            }

            conn.Close();
            dr.Close();
            dr.Dispose();

            return prodDetail;
        }
        public List<Store_Product> GetAllProduct()
        {
            List<Store_Product> prodAll = new List<Store_Product>();
            string prod_Name, prod_Description, prod_Category, prod_Image;
            decimal prod_ID, prod_Price;

            string query = "SELECT * FROM Product Order By ProdName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            prod_ID = decimal.Parse(dataReader["ProdID"].ToString());
                            prod_Name = dataReader["ProdName"].ToString();
                            prod_Description = dataReader["ProdDescription"].ToString();
                            prod_Price = decimal.Parse(dataReader["ProdPrice"].ToString());
                            prod_Category = dataReader["ProdCategory"].ToString();
                            prod_Image = dataReader["ProdImage"].ToString();

                            prodAll.Add(new Store_Product(prod_ID, prod_Name, prod_Description, prod_Price, prod_Category, prod_Image));
                        }
                        connection.Close();
                        dataReader.Close();
                        dataReader.Dispose();
                    }
                    
                }
            }
            
            return prodAll;
            
        }

        public int ProductDelete(decimal ID)
        {
            string querystr = "DELETE FROM Product WHERE ProdID=@ID";

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(querystr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int noOfRow = 0;
            noOfRow = cmd.ExecuteNonQuery();

            conn.Close();

            return noOfRow;
        }

        public int ProductUpdate(string pID, string pName, decimal pUnitPrice)
        {
            string queryStr = "UPDATE Product SET" +
            " ProdName = @productName, " +
            " ProdPrice = @unitPrice " +
            " WHERE ProdID = @productID";

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@productID", pID);
            cmd.Parameters.AddWithValue("@productName", pName);
            cmd.Parameters.AddWithValue("@unitPrice", pUnitPrice);

            conn.Open();
            int noOfRow = 0;
            noOfRow = cmd.ExecuteNonQuery();

            conn.Close();

            return noOfRow;

        }


    }
}
