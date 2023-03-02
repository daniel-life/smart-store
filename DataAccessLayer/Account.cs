using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Account
    {
        private readonly String connectionString = Properties.Settings.Default.AzureDBConnStr;
        private String accountID;
        private String name;
        private String password;
        private String email;
        private String address;
        public Account(String accountID = "",
                       String name = "",
                       String password = "",
                       String email = "",
                       String address = "")
        {
            this.accountID = accountID;
            this.name = name;
            this.password = password;
            this.email = email;
            this.address = address;
        }
        public String AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        public String Address
        {
            get { return address; }
            set { address = value; }
        }
        public int InsertAccount()
        {
            String query = String.Format("INSERT INTO AccountsTable (AccountID, Name, Password, Email, Address) " +
                                         "VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
                                         this.accountID,
                                         this.name,
                                         this.password,
                                         this.email,
                                         this.address);
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return result;

        }
        public List<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            String query = "SELECT * FROM AccountsTable";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            String accountID = dataReader["AccountID"].ToString();
                            String name = dataReader["Name"].ToString();
                            String password = dataReader["Password"].ToString();
                            String email = dataReader["Email"].ToString();
                            String address = dataReader["Address"].ToString();

                            accounts.Add(new Account(accountID, name, password, email, address));
                        }

                        connection.Close();
                        dataReader.Close();
                        dataReader.Dispose();
                    }
                }
            }
            return accounts;
        }
        public Account GetAccount(String accID)
        {
            Account account = null;
            String query = "SELECT * FROM AccountsTable WHERE AccountID = @accountID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountID", accID);

                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        String name = dataReader["Name"].ToString();
                        String password = dataReader["Password"].ToString();
                        String email = dataReader["Email"].ToString();
                        String address = dataReader["Address"].ToString();

                        account = new Account(accID, name, password, email, address);
                    }

                    connection.Close();
                    dataReader.Close();
                    dataReader.Dispose();
                }
            }

            return account;
        }
        public int UpdateAccount()
        {
            String query =
                " UPDATE AccountsTable SET Name = @name, " +
                " Password =  @password, Email = @email, Address = @address " +
                " WHERE AccountID = @accountID";

            int numberOfRows = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountID", this.accountID);
                    command.Parameters.AddWithValue("@name", this.name);
                    command.Parameters.AddWithValue("@password", this.password);
                    command.Parameters.AddWithValue("@email", this.email);
                    command.Parameters.AddWithValue("@address", this.address);

                    connection.Open();
                    numberOfRows = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return numberOfRows;

        }
        public int DeleteAccount(String accID)
        {
            string queryStr = "DELETE FROM AccountsTable WHERE AccountID=@accID";
            //decimal ID_dec = Convert.ToDecimal(ID);

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@accID", accID);
            conn.Open();
            int nofRow = 0;
            nofRow = cmd.ExecuteNonQuery();

            conn.Close();

            return nofRow;
        }//end Delete
    }
}
