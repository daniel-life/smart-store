using BusinessLogicLayer;
using DataAccessLayer;
using System.Collections.Generic;
using System.Web;

namespace Enterprise_project_CRUD.Shopping_Cart
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; }
        public static ShoppingCart Instance;

        // The static constructor is called as soon as the class is loaded into memory
        static ShoppingCart()
        {
            // If the cart is not in the session, create one and put it there
            // Otherwise, get it from the session
            if (HttpContext.Current.Session["UserShoppingCart"] == null)
            {
                Instance = new ShoppingCart();
                Instance.Items = new List<CartItem>();
                HttpContext.Current.Session["UserShoppingCart"] = Instance;
            }
            else
            {
                Instance = (ShoppingCart)HttpContext.Current.Session["UserShoppingCart"];
            }
        }

        // A protected constructor ensures that an object can't be created from outside
        protected ShoppingCart()
        { }

        public void AddItem(int ProductID, Store_Product prod)
        {
            // Create a new item to add to the cart
            CartItem newItem = new CartItem(ProductID, prod);

            // If this item already exists in our list of items, increase the quantity
            // Otherwise, add the new item to the list
            if (Items.Contains(newItem))
            {
                foreach (CartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }

        public void SetItemQuantity(int ProductID, int quantity)
        {
            // If we are setting the quantity to 0, remove the item entirely
            if (quantity == 0)
            {
                RemoveItem(ProductID);
                return;
            }

            // Find the item and update the quantity
            CartItem updatedItem = new CartItem(ProductID);

            foreach (CartItem item in Items)
            {
                if (item.Equals(updatedItem))
                {
                    item.Quantity = quantity;
                    return;
                }
            }
        }

        public void RemoveItem(int ProductID)
        {
            Store_ProductBLL prodBLL = new Store_ProductBLL();
            Store_Product prod = null;
            prod = prodBLL.GetProdDetail(ProductID);
            CartItem removedItem = new CartItem(ProductID, prod);
            Items.Remove(removedItem);
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CartItem item in Items)
            {
                subTotal += item.TotalPrice;
            }
            return subTotal;
        }
    }
}