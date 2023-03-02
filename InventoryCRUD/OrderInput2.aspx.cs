using BusinessLogicLayer;
using System;

namespace InventoryCRUD
{
    public partial class OrderInput2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String productID = Request.QueryString["id"];
            String productName = Request.QueryString["name"];

            tbProductID.Text = productID;
            tbProductName.Text = productName;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderBLL orderBLL = new OrderBLL();

            String message =
                orderBLL.CreateOrder(tbOrderID.Text,
                                 tbProductID.Text,
                                 tbProductName.Text,
                                 tbQuantity.Text,
                                 ddlSupplier.SelectedValue,
                                 rblUrgency.SelectedValue);
            lbMessage.Text = message;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbOrderID.Text = String.Empty;
            tbProductID.Text = String.Empty;
            tbProductName.Text = String.Empty;
            tbQuantity.Text = String.Empty;
            ddlSupplier.SelectedIndex = 0;
            rblUrgency.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvProductView.aspx");
        }
    }
}