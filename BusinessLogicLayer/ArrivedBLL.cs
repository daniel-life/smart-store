using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ArrivedBLL
    {
        public List<Arrived> GetAllArrived()
        {
            Arrived arrived = new Arrived();
            List<Arrived> arriveds = arrived.GetAllArrived();

            return arriveds;
        }
        public Arrived GetArrived(String orderID)
        {
            Arrived arrivedIndv = new Arrived();

            return arrivedIndv.GetArrived(orderID);
        }

        public String CreateArrived(String orderID,
                                    String productID,
                                    String product,
                                    String quantity,
                                    String supplier,
                                    String urgency)
        {
            // Invoke a method to validate data
            String message = ValidateInput(orderID, productID, product, quantity, supplier, urgency);

            if (message.Length == 0)
            {
                // No error; proceed
                Arrived arrived = new Arrived(orderID, productID, product, quantity, supplier, urgency);

                int numberOfRows = 0;
                numberOfRows = arrived.InsertArrived();

                if (numberOfRows > 0)
                {
                    message = "Order inserted successfully.";
                }
                else
                {
                    message = "Error! Please try again.";
                }
            }

            return message;
        }
        public String ValidateInput(String orderID,
                                    String productID,
                                    String product,
                                    String quantity,
                                    String supplier,
                                    String urgency)
        {
            StringBuilder messageBuilder = new StringBuilder();

            if (orderID.Length > 20)
                messageBuilder.Append("Order ID exceeds 20 chars!<br/>");

            if (orderID.Length == 0)
                messageBuilder.Append("Order ID cannot be blank!<br/>");

            if (quantity.Length > 10)
                messageBuilder.Append("Quantity exceeds 10 chars!<br/>");

            if (quantity.Length == 0)
                messageBuilder.Append("Quantity cannot be blank!<br/>");

            return messageBuilder.ToString();
        }

        public int ArrivedDelete(String ID)
        {
            string msg = null;
            int result = 0;

            Arrived ADAL = new Arrived();
            result = ADAL.ArrivedDelete(ID);

            if (result == 1)
            {
                msg = "Order has been insert successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return result;
        } //End  Delete
    }
}
