using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace SmartStore
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String orderID = Request.QueryString["id"];

                OrderBLL orderBLL = new OrderBLL();
                Order order = orderBLL.GetOrder(orderID);

                if (order == null)
                {
                    this.lbMessage.Text = "Error in getting Order details!";
                }
                else
                {
                    tbOrderID.Text = order.OrderID;
                    tbProductID.Text = order.ProductID;
                    tbProduct.Text = order.Product;
                    tbQuantity.Text = order.Quantity;
                    tbSupplier.Text = order.Supplier;
                    rblUrgency.Text = order.Urgency;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderView.aspx");
        }
    }
}