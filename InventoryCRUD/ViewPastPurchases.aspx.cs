using Enterprise_project_CRUD.Past_Purchases;
using System;

namespace Enterprise_project_CRUD
{
    public partial class ViewPastPurchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPurchase();
            }
        }

        protected void LoadPurchase()
        {
            gvPurchases.DataSource = PastPurchases.Instance.Orders;
            gvPurchases.DataBind();
        }

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewProducts.aspx");
        }
    }
}