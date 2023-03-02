namespace Enterprise_project_CRUD.Past_Purchases
{
    public class PurchaseSet
    {
        private string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        private decimal _Quantity;

        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private decimal _ProductPrice;

        public decimal ProductPrice
        {
            get { return _ProductPrice; }
            set { _ProductPrice = value; }
        }

        private decimal _TotalPrice;

        public decimal TotalPrice
        {
            get { return _TotalPrice; }
            set { _TotalPrice = value; }
        }

        public PurchaseSet(string prodName, int quantity, decimal prodPrice, decimal totalPrice)
        {
            this.ProductName = prodName;
            this.Quantity = quantity;
            this.ProductPrice = prodPrice;
            this.TotalPrice = totalPrice;
        }
    }
}