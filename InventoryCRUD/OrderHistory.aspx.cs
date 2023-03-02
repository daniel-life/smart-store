using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace SmartStore
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        private ArrivedBLL arrivedBLL = new ArrivedBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Arrived> arriveds = arrivedBLL.GetAllArrived();

            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        protected void gvHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowNumber = int.Parse(e.CommandArgument.ToString());

            GridViewRow gridViewRow = gvOrderHistory.Rows[rowNumber];

            String orderID = gridViewRow.Cells[0].Text;

            if (e.CommandName == "Select")
            {
                Response.Redirect(String.Format("HistoryDetails.aspx?id={0}", orderID));
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
    }
}