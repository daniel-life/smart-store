using System;
using System.Data.SqlClient;

using System.Net;
using System.Net.Mail;

namespace InventoryCRUD
{
    public partial class ForgetPassword : System.Web.UI.Page
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
                   " WHERE AccountID = @accountID";

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
                    command.Parameters.AddWithValue("@accountID", tbID.Text);
                    connection.Open();
                    result = (int)command.ExecuteScalar();
                    connection.Close();
                }
                using (SqlCommand command = new SqlCommand(nquery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@accountID", tbID.Text);
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
                var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var Charsarr = new char[6];
                var random = new Random();

                for (int i = 0; i < Charsarr.Length; i++)
                {
                    Charsarr[i] = characters[random.Next(characters.Length)];
                }

                Session["CODE"] = new String(Charsarr);

                Session["ID"] = tbID.Text;
                Session["Name"] = name;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("isprojtest@gmail.com");
                    mail.To.Add("muhdfirdausag@gmail.com");
                    mail.Subject = "test";
                    mail.Body = $"Code to change password {Session["CODE"]}";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("isprojtest@gmail.com", "itiszwetugexcwzx");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                Response.Redirect("CodeInput.aspx");
            }
            else
            {
                lbMessage.Text = "Error! Please try again.";
            }
        }
    }
}