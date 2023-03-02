using BusinessLogicLayer;
using System;

namespace InventoryCRUD
{
    public partial class ProductInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Inv_ProductBLL productBLL = new Inv_ProductBLL();

            String message =
                productBLL.CreateProduct(tbProdID.Text,
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
            tbProdID.Text = String.Empty;
            tbProdName.Text = String.Empty;
            tbDescription.Text = String.Empty;
            tbPrice.Text = String.Empty;
            tbRFIDTag.Text = String.Empty;
            lbMessage.Text = String.Empty;
            tbQuantity.Text = String.Empty;
            tbThreshold.Text = String.Empty;
        }
    }
}