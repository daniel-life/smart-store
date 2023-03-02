using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace Enterprise_project_CRUD
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        private Store_ProductBLL prodBLL = new Store_ProductBLL();

        private Store_Product prod = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Get Product ID from querystring
            string prodID = Request.QueryString["ProdID"].ToString();

            // Convert Product Id to Decimal
            decimal dProdID = decimal.Parse(prodID);

            // Call getProdDetail() method
            prod = prodBLL.GetProdDetail(dProdID);

            lblProdName.Text = prod.ProdName;
            lblProdDesc.Text = prod.ProdDescription;
            lblProdCategory.Text = prod.ProdCategory;
            lblPrice.Text = "$ " + prod.ProdPrice.ToString("c");
            imgProduct.ImageUrl = "~\\Images\\" + prod.ProdImage;

            // store price in an invisible field
            lblPrice.Text = "$ " + prod.ProdPrice.ToString();
            lblProdID.Text = prodID.ToString();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("StoreViewProducts.aspx");
        }

        protected void btn_Add_To_Cart_Click(object sender, EventArgs e)
        {
            int iProductID = Convert.ToInt32(lblProdID.Text.ToString());
            Shopping_Cart.ShoppingCart.Instance.AddItem(iProductID, prod);
        }
    }
}