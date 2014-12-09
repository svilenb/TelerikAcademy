using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Acessingcustomers
{
    class DAOTest
    {
        static void Main(string[] args)
        {            
            while (true)
            {
                Console.WriteLine("Enter 1 to add customer, 2 to modify, 3 to delete and exit to stop the program");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Write("Enter customer id: ");
                        string addCustomerID = Console.ReadLine();
                        Console.Write("Enter company name: ");
                        string addCompanyName = Console.ReadLine();
                        Console.WriteLine("Inserted new customer with ID: {0}", DAO.InsertNewCustomer(addCustomerID, addCompanyName));
                        break;
                    case "2":
                        Console.Write("Enter the cutomer Id: ");
                        string modifyCustomerId = Console.ReadLine();
                        Console.Write("Enter new company name: ");
                        string modifyCompanyName = Console.ReadLine();
                        Console.WriteLine("Modifying the inserted customer company name.");
                        DAO.ModifyCustomerName(modifyCustomerId, modifyCompanyName);
                        break;
                    case "3":
                        Console.Write("Enter the cutomer Id: ");
                        string deleteCustomerId = Console.ReadLine();
                        Console.WriteLine("Deleting customer.");
                        DAO.DeleteCustomer(deleteCustomerId);
                        break;
                    case "exit":
                        Console.WriteLine("Goodbye");
                        return;                        
                    default:
                        Console.WriteLine("Unknown command!");
                        break;
                }
            }
        }
    }
}
