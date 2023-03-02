using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace SmartStore
{
    public partial class OrderView : System.Web.UI.Page
    {
        private OrderBLL orderBLL = new OrderBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Order> orders = orderBLL.GetAllOrder();

            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void gvOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = int.Parse(e.CommandArgument.ToString());

            GridViewRow gridViewRow = gvOrder.Rows[rowNumber];

            String orderID = gridViewRow.Cells[0].Text;

            if (e.CommandName == "Select")
            {
                Response.Redirect(String.Format("OrderDetails.aspx?id={0}", orderID));
            }
            else if (e.CommandName == "Update")
            {
                Response.Redirect(String.Format("OrderUpdate.aspx?id={0}", orderID));
            }
        }

        protected void gvOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm delete order ?", "Delete order", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                OrderBLL pBLL = new OrderBLL();
                string categoryID = (string)gvOrder.DataKeys[e.RowIndex].Value;
                pBLL.OrderDelete(categoryID);

                Response.Redirect("OrderView.aspx");
            }
            else
            {
                Response.Redirect("OrderView.aspx");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void gvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}