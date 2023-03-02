using BusinessLogicLayer;
using DataAccessLayer;
using Enterprise_project_CRUD.Shopping_Cart;
using System;
using System.Web.UI.WebControls;

namespace Enterprise_project_CRUD
{
    public partial class ViewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Store_ProductBLL pBLL = new Store_ProductBLL();
            decimal categoryID = (decimal)gvCart.DataKeys[e.RowIndex].Value;
            pBLL.ProductDelete(categoryID);
        }

        protected void gvCartView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                lbl_Error.Text = "Message : " + e.CommandArgument.ToString();

                int productID = Convert.ToInt32(e.CommandArgument);
                ShoppingCart.Instance.RemoveItem(productID);
                LoadCart();
            }
        }

        protected void LoadCart()
        {
            gvCart.DataSource = ShoppingCart.Instance.Items;
            gvCart.DataBind();

            decimal total = 0.0m;
            foreach (CartItem item in ShoppingCart.Instance.Items)
            {
                total += item.TotalPrice;
            }
            lbl_TotalPrice.Text = "$" + total.ToString();
        }

        protected void btn_UpdateCart_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        int productID = Convert.ToInt32(gvCart.DataKeys[row.RowIndex].Value);
                        int quantity = int.Parse(((TextBox)row.Cells[3].FindControl("tb_Quantity")).Text);
                        ShoppingCart.Instance.SetItemQuantity(productID, quantity);
                    }
                    catch (FormatException formatException)
                    {
                        lbl_Error.Text = formatException.Message.ToString();
                    }
                }
            }
            LoadCart();
        }

        protected void btn_ClearCart_Click(object sender, EventArgs e)
        {
            ShoppingCart.Instance.Items.Clear();
            LoadCart();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProducts.aspx");
        }

        protected void btn_Purchase_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvCart.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string prodName = row.Cells[2].Text;
                    int quantity = int.Parse(((TextBox)row.Cells[3].FindControl("tb_Quantity")).Text);
                    decimal prodPrice = Convert.ToDecimal((row.Cells[5].Text).Remove(0, 1));
                    decimal totalPrice = Convert.ToDecimal((lbl_TotalPrice.Text).Remove(0, 1));
                    Past_Purchases.PastPurchases.Instance.DisplayPurchases(prodName, quantity, prodPrice, totalPrice);

                    //Update Product Quantity in Inventory
                    Inv_ProductBLL productBLL = new Inv_ProductBLL();
                    Inv_Product product = productBLL.GetProduct(row.Cells[0].Text);
                    var NewQuantity = Convert.ToInt32(product.Quantity) - quantity;
                    String message2 =
                        productBLL.UpdateProduct(product.ProdID,
                                                 product.ProdName,
                                                 product.Description,
                                                 product.Price,
                                                 product.RFIDTag,
                                                 NewQuantity.ToString(),
                                                 product.Threshold);
                }
            }
        }
    }
}