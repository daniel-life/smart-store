using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace InventoryCRUD
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String prodID = Request.QueryString["id"];

                Inv_ProductBLL productBLL = new Inv_ProductBLL();
                Inv_Product product = productBLL.GetProduct(prodID);

                if (product == null)
                {
                    this.lbMessage.Text = "Error in getting Product details!";
                }
                else
                {
                    lbProdID.Text = product.ProdID;
                    lbProdName.Text = product.ProdName;
                    lbDescription.Text = product.Description;
                    lbPrice.Text = product.Price;
                    lbRFIDTag.Text = product.RFIDTag;
                    lbQuantity.Text = product.Quantity;
                    lbThreshold.Text = product.Threshold;
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvProductView.aspx");
        }
    }
}