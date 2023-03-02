using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace AccountCRUD
{
    public partial class ViewAccount : System.Web.UI.Page
    {
        private AccountBLL accountBLL = new AccountBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Account> accounts = accountBLL.GetAllAccounts();

            gvAccounts.DataSource = accounts;
            gvAccounts.DataBind();
        }

        /**
        protected void gvAccounts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = int.Parse(e.CommandArgument.ToString());

            GridViewRow gridViewRow = gvAccounts.Rows[rowNumber];

            String accID = gridViewRow.Cells[0].Text;

            if (e.CommandName == "Update")
            {
                Response.Redirect(String.Format("UpdateAccount.aspx?accID=" + accID));
            }
            else if (e.CommandName == "Update")
            {
                Response.Redirect(String.Format("UpdateAccount.aspx?accID=" + accID));
            }
        }
        **/

        protected void gvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvAccounts.SelectedRow;
            string accID = row.Cells[0].Text;
            Response.Redirect("AccountDetails.aspx?accID=" + accID);
        }

        protected void gvAccounts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AccountBLL aBLL = new AccountBLL();
            String accID = (String)gvAccounts.DataKeys[e.RowIndex].Value;
            aBLL.DeleteAccount(accID);

            Response.Redirect("ViewAccount.aspx");
        }

        protected void gvAccounts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAccounts.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void bind()
        {
            List<Account> accountAll = new List<Account>();
            accountAll = accountBLL.GetAllAccounts();

            gvAccounts.DataSource = accountAll;
            gvAccounts.DataBind();
        }
    }
}