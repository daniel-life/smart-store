using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace SmartStore
{
    public partial class HistoryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String orderID = Request.QueryString["id"];

                ArrivedBLL arrivedBLL = new ArrivedBLL();
                Arrived arrived = arrivedBLL.GetArrived(orderID);

                if (arrived == null)
                {
                    this.lbMessage.Text = "Error in getting Order details!";
                }
                else
                {
                    tbOrderID.Text = arrived.OrderID;
                    tbProductID.Text = arrived.ProductID;
                    tbProduct.Text = arrived.Product;
                    tbQuantity.Text = arrived.Quantity;
                    tbSupplier.Text = arrived.Supplier;
                    rblUrgency.Text = arrived.Urgency;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderHistory.aspx");
        }
    }
}