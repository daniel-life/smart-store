using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Inv_ProductBLL
    {
        public List<Inv_Product> GetAllProduct()
        {
            Inv_Product productDAL = new Inv_Product();
            List<Inv_Product> products = productDAL.GetAllProduct();

            return products;
        }

        public String CreateProduct(String prodID,
                                    String prodName,
                                    String description,
                                    String price,
                                    String RFIDtag,
                                    String quantity,
                                    String threshold)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(prodID) || prodID.Length > 20)
                messageBuilder.Append("Product ID exceeds 20 chars!<br/>");

            if (String.IsNullOrEmpty(prodID) || prodID.Length == 0)
                messageBuilder.Append("ID cannot be blank!<br/>");

            if (prodName.Length > 30)
                messageBuilder.Append("Product Names exceed 30 chars!<br/>");

            if (prodName.Length == 0)
                messageBuilder.Append("Product Names cannot be blank!<br/>");

            if (description.Length == 0)
                messageBuilder.Append("Description cannot be blank!<br/>");

            if (price.Length > 10)
                messageBuilder.Append("Price exceeds 10 chars!<br/>");

            if (price.Length == 0)
                messageBuilder.Append("Price cannot be blank!<br/>");

            if (RFIDtag.Length > 10)
                messageBuilder.Append("RFID tag exceeds 30 chars!<br/>");

            if (RFIDtag.Length == 0)
                messageBuilder.Append("RFID tag cannot be blank!<br/>");

            if (quantity.Length == 0)
                messageBuilder.Append("Quantity cannot be blank!<br/>");

            if (Int32.Parse(quantity) < 0)
                messageBuilder.Append("Quantity cannot be negative!<br/>");

            if (threshold.Length == 0)
                messageBuilder.Append("Threshold cannot be blank!<br/>");

            if (messageBuilder.Length == 0)
            {
                // No error; proceed
                Inv_Product product = new Inv_Product(prodID, prodName, description, price, RFIDtag, quantity, threshold);

                int numberOfRows = 0;
                numberOfRows = product.InsertProduct();

                if (numberOfRows > 0)
                {
                    messageBuilder.AppendFormat("{0} product is saved successfully.", prodName);
                }
                else
                {
                    messageBuilder.AppendFormat("Failed to save {0} product. Please try again.", prodName);
                }
            }

            return messageBuilder.ToString();
        }

        private String ValidateInput(String prodID,
                                    String prodName,
                                    String description,
                                    String price,
                                    String RFIDtag, 
                                    String quantity,
                                    String threshold)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(prodID) || prodID.Length > 20)
                messageBuilder.Append("Product ID exceeds 20 chars!<br/>");

            if (String.IsNullOrEmpty(prodID) || prodID.Length == 0)
                messageBuilder.Append("ID cannot be blank!<br/>");

            if (prodName.Length > 30)
                messageBuilder.Append("Product Names exceed 30 chars!<br/>");

            if (prodName.Length == 0)
                messageBuilder.Append("Product Names cannot be blank!<br/>");

            if (description.Length == 0)
                messageBuilder.Append("Description cannot be blank!<br/>");

            if (price.Length > 10)
                messageBuilder.Append("Price exceeds 10 chars!<br/>");

            if (price.Length == 0)
                messageBuilder.Append("Price cannot be blank!<br/>");

            if (RFIDtag.Length > 10)
                messageBuilder.Append("RFID tag exceeds 30 chars!<br/>");

            if (RFIDtag.Length == 0)
                messageBuilder.Append("RFID tag cannot be blank!<br/>");

            if (quantity.Length == 0)
                messageBuilder.Append("Quantity cannot be blank!<br/>");

            if (Int32.Parse(quantity) < 0)
                messageBuilder.Append("Quantity cannot be negative!<br/>");

            if (threshold.Length == 0)
                messageBuilder.Append("Description cannot be blank!<br/>");

            return messageBuilder.ToString();
        }

        public String UpdateProduct(String prodID,
                                    String prodName,
                                    String description,
                                    String price,
                                    String RFIDtag,
                                    String quantity, 
                                    String threshold)
        {
            //Invoke a method to validate data
            String message =
                ValidateInput( prodID,
                               prodName,
                               description,
                               price,
                               RFIDtag,
                               quantity,
                               threshold);

            if (message.Length == 0)
            {
                // No error; proceed 
                Inv_Product product =
                    new Inv_Product(prodID,
                                prodName,
                                description,
                                price,
                                RFIDtag,
                                quantity,
                                threshold);

                int numberOfRows = 0;
                numberOfRows = product.UpdateProduct();

                if (numberOfRows > 0)
                    message = "Product record updated successfully.";
                else
                    message = "Error! Please try again.";
            }

            return message;
        }

        public int ProductDelete(String prodID)
        {
            string msg = null;
            int result = 0;

            Inv_Product PDAL = new Inv_Product();
            result = PDAL.ProductDelete(prodID);

            if (result == 1)
            {
                msg = "Product has been insert successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return result;
        }

        public Inv_Product GetProduct(String prodID)
        {
            Inv_Product productIndv = new Inv_Product();

            return productIndv.GetProduct(prodID);
        }
    }
}
