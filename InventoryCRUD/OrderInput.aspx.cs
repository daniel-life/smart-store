using BusinessLogicLayer;
using System;

namespace SmartStore
{
    public partial class OrderInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderBLL orderBLL = new OrderBLL();

            String message =
                orderBLL.CreateOrder(tbOrderID.Text,
                                 tbProductID.Text,
                                 ddlProduct.SelectedValue,
                                 tbQuantity.Text,
                                 ddlSupplier.SelectedValue,
                                 rblUrgency.SelectedValue);
            lbMessage.Text = message;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbOrderID.Text = String.Empty;
            tbProductID.Text = String.Empty;
            ddlProduct.SelectedIndex = 0;
            tbQuantity.Text = String.Empty;
            ddlSupplier.SelectedIndex = 0;
            rblUrgency.SelectedIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderView.aspx");
        }
    }
}