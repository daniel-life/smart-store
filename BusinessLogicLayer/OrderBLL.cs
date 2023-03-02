using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BusinessLogicLayer
{
    public class OrderBLL
    {
        public List<Order> GetAllOrder()
        {
            Order orderDAL = new Order();
            List<Order> orders = orderDAL.GetAllOrder();

            return orders;
        }

        public Order GetOrder(String orderID)
        {
            Order orderIndv = new Order();

            return orderIndv.GetOrder(orderID);
        }

        public String UpdateOrder(String orderID,
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
                Order order = new Order(orderID, productID, product, quantity, supplier, urgency);

                int numberOfRows = 0;
                numberOfRows = order.UpdateOrder();

                if (numberOfRows > 0)
                {
                    message = "Order updated successfully.";
                }
                else
                {
                    message = "Error! Please try again.";
                }
            }
            return message;
        }

        public String CreateOrder(String orderID,
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
                Order order = new Order(orderID, productID, product, quantity, supplier, urgency);

                int numberOfRows = 0;
                numberOfRows = order.InsertOrder();

                if (numberOfRows > 0)
                {
                    message = "Order inserted successfully.";

                    string to = "darrenleowboonsheng@gmail.com"; //To address    
                    string from = "204583G@mymail.nyp.edu.sg"; //From address    
                    MailMessage messages = new MailMessage(from, to);

                    string mailbody = "You have succesfully input an order. <br> Please check below if you have ordered the correct item. <br><br>" +
                                      "Order ID: " + orderID +
                                      "<br>Product ID: " + productID +
                                      "<br>Product: " + product +
                                      "<br>Quantity:  " + quantity +
                                      "<br>Supplier: " + supplier +
                                      "<br>Urgency: " + urgency +
                                      "<br><br>Thank you <br>Regards";

                    messages.Subject = "Order Succesfull";
                    messages.Body = mailbody;
                    messages.BodyEncoding = Encoding.UTF8;
                    messages.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Gmail smtp    
                    System.Net.NetworkCredential basicCredential1 = new
                    System.Net.NetworkCredential("204583G@mymail.nyp.edu.sg", "KKXJQilumgf1");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential1;
                    try
                    {
                        client.Send(messages);
                    }

                    catch (Exception)
                    {

                    }
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

        public int OrderDelete(String ID)
        {
            string msg = null;
            int result = 0;

            Order ODAL = new Order();
            result = ODAL.OrderDelete(ID);

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
