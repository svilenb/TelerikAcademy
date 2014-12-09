namespace _02.Acessingcustomers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using EntityFrameworkDatabaseFirst;

    public class DAO
    {
        public static string InsertNewCustomer(string customerID, string companyName)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Customer newCustomer = new Customer
                {
                    CustomerID = customerID,
                    CompanyName = companyName
                };

                northwindEntities.Customers.Add(newCustomer);
                northwindEntities.SaveChanges();
                return newCustomer.CustomerID;
            }
        }

        public static void ModifyCustomerName(string customerID, string newCompanyName)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Customer customer = GetCustomerById(northwindEntities, customerID);
                customer.CompanyName = newCompanyName;
                northwindEntities.SaveChanges();
            }
        }

        public static void DeleteCustomer(string customerID)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Customer customer = GetCustomerById(northwindEntities, customerID);
                northwindEntities.Customers.Remove(customer);
                northwindEntities.SaveChanges();
            }
        }

        public static Customer GetCustomerById(NorthwindEntities northwindEntities, string customerID)
        {
            return northwindEntities.Customers.FirstOrDefault(c => c.CustomerID == customerID);
        }
    }
}
