using System.Collections.Generic;
using System.Web;

namespace Enterprise_project_CRUD.Past_Purchases
{
    public class PastPurchases
    {
        public List<PurchaseSet> Orders { get; private set; }
        public static PastPurchases Instance;

        static PastPurchases()
        {
            if (HttpContext.Current.Session["UserPastPurchases"] == null)
            {
                Instance = new PastPurchases();
                Instance.Orders = new List<PurchaseSet>();
                HttpContext.Current.Session["UserPastPurchases"] = Instance;
            }
            else
            {
                Instance = (PastPurchases)HttpContext.Current.Session["UserPastPurchases"];
            }
        }

        protected PastPurchases()
        { }

        public void DisplayPurchases(string prodName, int quantity, decimal prodPrice, decimal totalPrice)
        {
            PurchaseSet newPurchase = new PurchaseSet(prodName, quantity, prodPrice, totalPrice);
            Orders.Add(newPurchase);
        }
    }
}