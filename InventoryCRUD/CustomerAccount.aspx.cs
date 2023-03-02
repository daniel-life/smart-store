using System;

namespace InventoryCRUD
{
    public partial class CustomerAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("AccountDetails.aspx?accID=" + Session["ID"]);
        }
    }
}