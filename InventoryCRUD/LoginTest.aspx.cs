using System;
using System.Data.SqlClient;

namespace InventoryCRUD
{
    public partial class LoginTest : System.Web.UI.Page
    {
        private readonly String connectionString = Properties.Settings.Default.AzureDBConnStr;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String query =
                "SELECT COUNT(*)" +
                " FROM AccountsTable" +
                " WHERE AccountID = @accountID AND Password = @password";

            String nquery =
                "SELECT Name" +
                " FROM AccountsTable" +
                " WHERE AccountID = @accountID";

            int result = 0;
            string name = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@accountID", tbAccountID.Text);
                    command.Parameters.AddWithValue("@password", tbPassword.Text);
                    connection.Open();
                    result = (int)command.ExecuteScalar();
                    connection.Close();
                }
                using (SqlCommand command = new SqlCommand(nquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@accountID", tbAccountID.Text);
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            name = dataReader["Name"].ToString();
                        }
                        connection.Close();
                        dataReader.Close();
                        dataReader.Dispose();
                    }
                }
            }
            if (result > 0)
            {
                lbMessage.Text = "Account logged in.";
                Session["ID"] = tbAccountID.Text;
                Session["Name"] = name;
                if (name.StartsWith("ADMIN_"))
                {
                    Session["Auth"] = "Admin";
                    Response.Redirect("Admin.aspx");
                }
                if (name.StartsWith("EMPLOYEE_"))
                {
                    Session["Auth"] = "Employee";
                    Response.Redirect("Employee.aspx");
                }
                else
                {
                    Session["Auth"] = "Customer";
                    Response.Redirect("Customer.aspx");
                }
            }
            else
            {
                lbMessage.Text = "Error! Please try again.";
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbAccountID.Text = "";
            tbPassword.Text = "";
        }

        protected void Forget_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgetPassword.aspx");
        }
    }
}