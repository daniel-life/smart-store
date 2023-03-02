using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace AccountCRUD
{
    public partial class AccountDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string accID = Request.QueryString["accID"].ToString();

            AccountBLL accountBLL = new AccountBLL();
            Account account = accountBLL.GetAccount(accID);

            if (account == null)
            {
                this.lbMessage.Text = "Error in getting Account details!";
            }
            else
            {
                tbAccountID.Text = account.AccountID;
                tbName.Text = account.Name;
                tbPassword.Text = account.Password;
                tbEmail.Text = account.Email;
                tbAddress.Text = account.Address;
            }
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            string accID = Request.QueryString["accID"].ToString();
            Response.Redirect(String.Format("UpdateAccount.aspx?accID=" + accID));
        }

        protected void btn_login(object sender, EventArgs e)
        {
            Response.Redirect("LoginTest.aspx");
        }
    }
}