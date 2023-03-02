using System;
using System.Web.UI;

namespace InventoryCRUD
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Remove("ID");
            Session.Remove("Name");
            Session.Remove("Auth");
            Response.Redirect("LoginTest.aspx");
        }
    }
}