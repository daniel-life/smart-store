using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Enterprise_project_CRUD
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        private Store_ProductBLL prodBLL = new Store_ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Store_Product> prodAll = new List<Store_Product>();

                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
                this.SearchCustomers();
            }
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gets cuurently selected row
            GridViewRow row = gvProducts.SelectedRow;

            // get product ID from the first row, which is the selected row (index 0)
            string prodID = row.Cells[0].Text;

            // redirect to next page, with product id added to URL
            Response.Redirect("StoreProductDetails.aspx?ProdID=" + prodID);
        }

        protected void gvSearchProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gets cuurently selected row
            GridViewRow row = gvSearchProduct.SelectedRow;

            //get product ID from the first row, which is the selected row(index 0)
            string prodID = row.Cells[0].Text;

            //redirect to next page, with product id added to URL
            Response.Redirect("StoreProductDetails.aspx?ProdID=" + prodID);
        }

        protected void gvSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gets cuurently selected row
            GridViewRow row = gvSearchCategory.SelectedRow;

            // get product ID from the first row, which is the selected row (index 0)
            string prodID = row.Cells[0].Text;

            // redirect to next page, with product id added to URL
            Response.Redirect("StoreProductDetails.aspx?ProdID=" + prodID);
        }

        protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProducts.EditIndex = e.NewEditIndex;
        }

        protected void gvProducts_RowCancellingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProducts.EditIndex = -1;
        }

        protected void gvProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Store_ProductBLL pBLL = new Store_ProductBLL();

            GridViewRow row = (GridViewRow)gvProducts.Rows[e.RowIndex];
            decimal id = decimal.Parse(gvProducts.DataKeys[e.RowIndex].Value.ToString());
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string tname = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tprice = ((TextBox)row.Cells[3].Controls[0]).Text;

            pBLL.ProductUpdate(tid, tname, tprice);
        }

        protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Store_ProductBLL productBLL = new Store_ProductBLL();
            decimal categoryID = (decimal)gvProducts.DataKeys[e.RowIndex].Value;
            productBLL.ProductDelete(categoryID);
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;
        }

        protected void gvSearchProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSearchProduct.PageIndex = e.NewPageIndex;
            this.SearchCustomers();
        }

        protected void gvSearchCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSearchCategory.PageIndex = e.NewPageIndex;
        }

        protected void btn_Refresh_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = true;
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            this.SearchCustomers();
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }

        private void SearchCustomers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AzureDBConnString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Product";
                    if (!string.IsNullOrEmpty(tb_SearchProduct.Text.Trim()))
                    {
                        query += " WHERE ProdName LIKE '%' + @ProdName + '%'";
                        cmd.Parameters.AddWithValue("@ProdName", tb_SearchProduct.Text.Trim());
                    }
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        gvSearchProduct.DataSource = dt;
                        gvSearchProduct.DataBind();
                    }
                }
            }
        }
    }
}