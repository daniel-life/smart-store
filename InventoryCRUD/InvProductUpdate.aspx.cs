using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace InventoryCRUD
{
    public partial class ProductUpdate : System.Web.UI.Page
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
                    tbProdName.Text = product.ProdName;
                    tbDescription.Text = product.Description;
                    tbPrice.Text = product.Price;
                    tbRFIDTag.Text = product.RFIDTag;
                    tbQuantity.Text = product.Quantity;
                    tbThreshold.Text = product.Threshold;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Inv_ProductBLL productBLL = new Inv_ProductBLL();
            String message = productBLL.UpdateProduct(lbProdID.Text,
                                                      tbProdName.Text,
                                                      tbDescription.Text,
                                                      tbPrice.Text,
                                                      tbRFIDTag.Text,
                                                      tbQuantity.Text,
                                                      tbThreshold.Text);

            lbMessage.Text = message;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("InvProductView.aspx");
        }
    }
}