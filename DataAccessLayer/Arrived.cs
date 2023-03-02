using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Arrived
    {
        private String connectionString = Properties.Settings.Default.AzureDBConnStr;

        private String orderID;
        private String productID;
        private String product;
        private String quantity;
        private String supplier;
        private String urgency;
        public Arrived(String orderID = "",
                       String productID = "",
                       String product = "",
                       String quantity = "",
                       String supplier = "",
                       String urgency = "")
        {
            this.orderID = orderID;
            this.productID = productID;
            this.product = product;
            this.quantity = quantity;
            this.supplier = supplier;
            this.urgency = urgency;
        }
        public String OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        public String ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public String Product
        {
            get { return product; }
            set { product = value; }
        }
        public String Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public String Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        public String Urgency
        {
            get { return urgency; }
            set { urgency = value; }
        }

        public int InsertArrived()
        {
            String query =
                String.Format("INSERT INTO Order_History (OrderID, ProductID, Product, Quantity, Supplier, Urgency) " +
                               "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                               this.orderID,
                               this.productID,
                               this.product,
                               this.quantity,
                               this.supplier,
                               this.urgency);

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
        public List<Arrived> GetAllArrived()
        {
            List<Arrived> arriveds = new List<Arrived>();
            String query = "SELECT * FROM Order_History Order By OrderID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            String orderID = dataReader["OrderID"].ToString();
                            String productID = dataReader["ProductID"].ToString();
                            String product = dataReader["Product"].ToString();
                            String quantity = dataReader["Quantity"].ToString();
                            String supplier = dataReader["Supplier"].ToString();
                            String urgency = dataReader["Urgency"].ToString();

                            arriveds.Add(new Arrived(orderID, productID, product, quantity, supplier, urgency));
                        }

                        connection.Close();
                        dataReader.Close();
                        dataReader.Dispose();
                    }
                }
            }

            return arriveds;
        }

        public Arrived GetArrived(String orderID)
        {
            Arrived arrived = null;
            String query = "SELECT * FROM Order_History WHERE OrderID = @orderID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@orderID", orderID);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        String productID = dataReader["ProductID"].ToString();
                        String product = dataReader["Product"].ToString();
                        String quantity = dataReader["Quantity"].ToString();
                        String supplier = dataReader["Supplier"].ToString();
                        String urgency = dataReader["Urgency"].ToString();

                        arrived = new Arrived(orderID, productID, product, quantity, supplier, urgency);
                    }
                    connection.Close();
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }
            return arrived;
        }

        public int ArrivedDelete(string ID)
        {
            string queryStr = "DELETE FROM Orders WHERE OrderID=@ID";
            //decimal ID_dec = Convert.ToDecimal(ID);

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Delete
    }
}
