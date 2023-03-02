using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace AccountCRUD
{
    public partial class UpdateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String accountID = Request.QueryString["accID"];

                AccountBLL accountBLL = new AccountBLL();
                Account account = accountBLL.GetAccount(accountID);

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
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = String.Empty;
            tbPassword.Text = String.Empty;
            tbEmail.Text = String.Empty;
            tbAddress.Text = String.Empty;
            lbMessage.Text = String.Empty;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AccountBLL accountBLL = new AccountBLL();

            String message =
                accountBLL.UpdateAccount(tbAccountID.Text,
                                         tbName.Text,
                                         tbPassword.Text,
                                         tbEmail.Text,
                                         tbAddress.Text);

            lbMessage.Text = message;
        }
    }
}