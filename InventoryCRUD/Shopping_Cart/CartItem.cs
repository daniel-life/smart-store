using DataAccessLayer;
using System;

namespace Enterprise_project_CRUD.Shopping_Cart
{
    public class CartItem : IEquatable<CartItem>
    {
        public int Quantity { get; set; }

        private decimal _ProdID;

        public decimal ProdID
        {
            get { return _ProdID; }
            set { _ProdID = value; }
        }

        private string _prodImage;

        public string ProdImage
        {
            get { return _prodImage; }
            set { _prodImage = value; }
        }

        private string _prodName;

        public string ProdName
        {
            get { return _prodName; }
            set { _prodName = value; }
        }

        private string _prodDesc;

        public string ProdDescription
        {
            get { return _prodDesc; }
            set { _prodDesc = value; }
        }

        private decimal _prodPrice;

        public decimal ProdPrice
        {
            get { return _prodPrice; }
            set { _prodPrice = value; }
        }

        public decimal TotalPrice
        {
            get { return ProdPrice * Quantity; }
        }

        public CartItem(int productID)
        {
            this.ProdID = productID;
        }

        public CartItem(int productID, Store_Product prod)
        {
            this.ProdID = productID;
            this.ProdImage = prod.ProdImage;
            this.ProdName = prod.ProdName;
            this.ProdDescription = prod.ProdDescription;
            this.ProdPrice = prod.ProdPrice;
        }

        public CartItem(int productID, string productImage, string productName, string productDescription, decimal productPrice)
        {
            this.ProdID = productID;
            this.ProdImage = productImage;
            this.ProdName = productName;
            this.ProdDescription = productDescription;
            this.ProdPrice = productPrice;
        }

        /*
            Equals() - Needed to implement the IEquatable interface
            Tests whether or not this item is equal to the parameter
            This method is called by the Contains() method in the List class
            We used this Contains() method in the ShoppingCart AddItem() method
        */

        public bool Equals(CartItem anItem)
        {
            return anItem.ProdID == this.ProdID;
        }
    }
}