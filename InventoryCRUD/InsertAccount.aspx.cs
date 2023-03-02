using BusinessLogicLayer;
using System;

namespace InventoryCRUD
{
    public partial class InsertAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbAccountID.Text = String.Empty;
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
                accountBLL.CreateAccount(tbAccountID.Text,
                                         tbName.Text,
                                         tbPassword.Text,
                                         tbEmail.Text,
                                         tbAddress.Text);

            lbMessage.Text = message;
        }
    }
}