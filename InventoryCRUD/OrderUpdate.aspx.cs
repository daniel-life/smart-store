using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace SmartStore
{
    public partial class OrderUpdate : System.Web.UI.Page
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
                    ddlProduct.Text = order.Product;
                    tbQuantity.Text = order.Quantity;
                    ddlSupplier.Text = order.Supplier;
                    rblUrgency.Text = order.Urgency;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            OrderBLL orderBLL = new OrderBLL();

            String message =
                orderBLL.UpdateOrder(tbOrderID.Text,
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

        protected void btnArrived_Click(object sender, EventArgs e)
        {
            //Create Order History
            ArrivedBLL arrivedBLL = new ArrivedBLL();

            String message =
                arrivedBLL.CreateArrived(tbOrderID.Text,
                                         tbProductID.Text,
                                         ddlProduct.SelectedValue,
                                         tbQuantity.Text,
                                         ddlSupplier.SelectedValue,
                                         rblUrgency.SelectedValue);
            lbMessage.Text = message;

            //Update Product Quantity in Inventory
            Inv_ProductBLL productBLL = new Inv_ProductBLL();
            Inv_Product product = productBLL.GetProduct(tbProductID.Text);
            var NewQuantity = Convert.ToInt32(product.Quantity) + Convert.ToInt32(tbQuantity.Text);
            String message2 =
                productBLL.UpdateProduct(product.ProdID,
                                         product.ProdName,
                                         product.Description,
                                         product.Price,
                                         product.RFIDTag,
                                         NewQuantity.ToString(),
                                         product.Threshold);
            lbMessage.Text = message2;

            //Delete Order from Order View
            ArrivedBLL aBLL = new ArrivedBLL();
            string categoryID = (string)tbOrderID.Text;
            aBLL.ArrivedDelete(categoryID);

            //Response.Redirect("OrderView.aspx");
        }
    }
}