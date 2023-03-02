using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class AccountBLL
    {
        public List<Account> GetAllAccounts()
        {
            Account account = new Account();
            List<Account> accounts = account.GetAllAccounts();

            return accounts;
        }
        public Account GetAccount(String accID)
        {
            Account accountIndv = new Account();

            return accountIndv.GetAccount(accID);
        }
        public String CreateAccount(String accountID,
                                    String name,
                                    String password,
                                    String email,
                                    String address)
        {
            // Invoke a method to validate data
            String message = ValidateInput(accountID, name, password, email, address);

            if (message.Length == 0)
            {
                // No error; proceed
                Account account = new Account(accountID, name, password, email, address);

                int numberOfRows = 0;
                numberOfRows = account.InsertAccount(); ;

                if (numberOfRows > 0)
                {
                    message = "Account record inserted successfully.";
                }
                else
                {
                    message = "Error! Please try again.";
                }
            }

            return message;
        }
        private String ValidateInput(String accountID,
                                     String name,
                                     String password,
                                     String email,
                                     String address)
        {
            StringBuilder messageBuilder = new StringBuilder();
            if (password == "test")
            {
                messageBuilder.Append("test if it works" + System.Environment.NewLine);
            }
            if (!password.Any(char.IsUpper) && password.Any(char.IsLower))
            {
                messageBuilder.Append("Password must contain Upper and Lower characters." + System.Environment.NewLine);
            }
            if (!password.Any(char.IsDigit))
            {
                messageBuilder.Append("Password must contain Numbers." + System.Environment.NewLine);
            }
            if (password.Length <= 6)
            {
                messageBuilder.Append("Password must be longer than 6 characters." + System.Environment.NewLine);
            }

            return messageBuilder.ToString();
        }
        public int DeleteAccount(String accountID)
        {
            string msg = null;
            int result = 0;

            Account account = new Account();
            result = account.DeleteAccount(accountID);

            if (result == 1)
            {
                msg = "Product has been insert successfully";
            }
            else
            {
                msg = "Error! Please try again.";
            }

            return result;
        } //End  Delete
        public String UpdateAccount(String accountID,
                                     String name,
                                     String password,
                                     String email,
                                     String address)
        {
            // Invoke a method to validate data
            String message = ValidateInput(accountID, name, password, email, address);

            if (message.Length == 0)
            {
                // No error; proceed
                Account account = new Account(accountID, name, password, email, address);

                int numberOfRows = 0;
                numberOfRows = account.UpdateAccount();

                if (numberOfRows > 0)
                {
                    message = "Account record updated successfully.";
                }
                else
                {
                    message = "Error! Please try again.";
                }
            }

            return message;
        }
    }
}
