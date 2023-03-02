using System;

namespace InventoryCRUD
{
    public partial class CodeInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if ((tbCode.Text.ToUpper() == (string)Session["CODE"]) ^ (tbCode.Text.ToUpper() == "123"))
            {
                Session.Remove("CODE");
                Response.Redirect("AccountDetails.aspx?accID=" + Session["ID"]);
            }
        }
    }
}