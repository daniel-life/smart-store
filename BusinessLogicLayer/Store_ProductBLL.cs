using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Store_ProductBLL
    {
        public Store_Product GetProdDetail(decimal prodID)
        {
            Store_Product prodDetail = new Store_Product();

            return prodDetail.GetProduct(prodID);
        }
        public List<Store_Product> GetAllProduct()
        {
            Store_Product product = new Store_Product();
            List<Store_Product> allProduct = new List<Store_Product>();

            allProduct = product.GetAllProduct();
            return allProduct;
        }

        public int ProductDelete(decimal ID)
        {
            string msg = null;
            int result = 0;

            Store_Product PDAL = new Store_Product();
            result = PDAL.ProductDelete(ID);

            if (result == 1)
            {
                msg = "Product has been Deleted successfully";
            }
            else
            {
                msg = "Error! Please try again!";
            }

            return result;
        }

        public string ProductUpdate(string _ProductID, string _ProductName, string _UnitPrice)
        {
            string msg = null;
            int result = 0;

            Store_Product prod = new Store_Product();

            result = prod.ProductUpdate(_ProductID, _ProductName, Convert.ToDecimal(_UnitPrice));
            
            if (result == 1)
            {
                msg = "Product has been update successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return msg;
        }

        /*public String CreateProduct(String prodID,
                                    String prodName,
                                    String prodDescription,
                                    String prodPrice,
                                    String prodCategory,
                                    String prodImage)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(prodID) || prodID.Length > 20)
                messageBuilder.Append("Product ID exceeds 20 chars!<br/>");
            if (String.IsNullOrEmpty(prodID) || prodID.Length == 0)
                messageBuilder.Append("ID cannot be blank!<br/>");

            if (prodName.Length > 30)
                messageBuilder.Append("Product name cannot exceed 30 chars!<br/>");
            if (prodName.Length == 0)
                messageBuilder.Append("Product name cannot be empty!<br/>");

            if (prodDescription.Length > 50)
                messageBuilder.Append("Product description cannot exceed 50 chars!<br/>");

            if (prodPrice.Length > 10)
                messageBuilder.Append("Product price cannot exceed 10 chars!<br/>");
            if (prodPrice.Length == 0)
                messageBuilder.Append("Product price cannot be empty!</br>");


            if (prodCategory.Length > 20)
                messageBuilder.Append("Product category cannot be more than 20 chars!<br/>");
            if (prodCategory.Length == 0)
                messageBuilder.Append("Product categoty cannot be empty!<br/>");

            if (messageBuilder.Length == 0)
            {
                Product product = new Product(prodID, prodName, prodDescription, prodPrice, prodCategory, prodImage);

                int numberOfRows = 0;
                numberOfRows = product.InsertProduct();

                if (numberOfRows > 0)
                {
                    messageBuilder.AppendFormat("{0}'s record is saved successfully.", prodName);
                }
                else
                {
                    messageBuilder.AppendFormat("Failed to save {0}. Please try again.", prodName);
                }
            }
            return messageBuilder.ToString();
        } */

    }
}
