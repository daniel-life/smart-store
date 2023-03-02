using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Drawing;
using System.Web.UI.WebControls;

namespace InventoryCRUD
{
    public partial class ProductView : System.Web.UI.Page
    {
        private Inv_ProductBLL productBLL = new Inv_ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
        }

        public void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Inv_ProductBLL productBLL = new Inv_ProductBLL();
            Inv_Product product = productBLL.GetProduct(e.Row.Cells[0].Text);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int quantity = int.Parse(e.Row.Cells[2].Text);

                if (quantity <= int.Parse(product.Threshold))
                {
                    e.Row.ForeColor = Color.Red;
                }

                if (quantity > int.Parse(product.Threshold) && quantity < int.Parse(product.Threshold) + 50)
                {
                    e.Row.ForeColor = Color.Orange;
                }
            }
        }

        protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = int.Parse(e.CommandArgument.ToString());

            GridViewRow gridViewRow = gvProduct.Rows[rowNumber];

            String prodID = gridViewRow.Cells[0].Text;
            String prodName = gridViewRow.Cells[1].Text;

            if (e.CommandName == "Select")
            {
                Response.Redirect(String.Format("InvProductDetails.aspx?id={0}", prodID));
            }
            else if (e.CommandName == "Update")
            {
                Response.Redirect(String.Format("InvProductUpdate.aspx?id={0}", prodID));
            }
            else if (e.CommandName == "Order")
            {
                Response.Redirect(String.Format("OrderInput2.aspx?id={0}&name={1}", Server.UrlEncode(prodID), Server.UrlEncode(prodName)));
            }
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Inv_ProductBLL pBLL = new Inv_ProductBLL();
            String ProdID = (String)gvProduct.DataKeys[e.RowIndex].Value;
            pBLL.ProductDelete(ProdID);

            Response.Redirect("InvProductView.aspx");
        }

        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProduct.PageIndex = e.NewPageIndex;
        }
    }
}