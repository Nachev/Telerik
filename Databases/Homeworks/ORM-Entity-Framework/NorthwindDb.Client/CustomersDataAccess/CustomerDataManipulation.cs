namespace NorthwindDb.Client.CustomersDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NorthwindDbContext;
    using System.Data.Entity;

    public class CustomerDataManipulation
    {
        /*Create a DAO class with static methods which 
        provide functionality for inserting, modifying and 
        deleting customers. Write a testing class.*/
        public static string InsertCustomer(
            string companyName,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            var northwindEntities = new NorthwindEntities();
            int indexOfWordSeparator = companyName.IndexOf(' ');
            indexOfWordSeparator = indexOfWordSeparator > 0 ? indexOfWordSeparator + 1 : 4;
            string customerId = (companyName.Substring(0, 4) + companyName.Substring(indexOfWordSeparator, 1)).ToUpperInvariant();
            var newCustomer = new Customer()
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax,
            };

            northwindEntities.Customers.Add(newCustomer);
            northwindEntities.SaveChanges();

            return newCustomer.CustomerID;
        }

        public static void ModifyCustomer(string customerId, CustomerProperty property, string newValue)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var customerToModify = FindCustomerById(northwindEntities, customerId);
                switch (property)
                {
                    case CustomerProperty.CompanyName:
                        customerToModify.CompanyName = newValue;
                        break;
                    case CustomerProperty.ContactName:
                        customerToModify.ContactName = newValue;
                        break;
                    case CustomerProperty.ContactTitle:
                        customerToModify.ContactTitle = newValue;
                        break;
                    case CustomerProperty.Address:
                        customerToModify.Address = newValue;
                        break;
                    case CustomerProperty.City:
                        customerToModify.City = newValue;
                        break;
                    case CustomerProperty.Region:
                        customerToModify.Region = newValue;
                        break;
                    case CustomerProperty.PostalCode:
                        customerToModify.PostalCode = newValue;
                        break;
                    case CustomerProperty.Country:
                        customerToModify.Country = newValue;
                        break;
                    case CustomerProperty.Phone:
                        customerToModify.Phone = newValue;
                        break;
                    case CustomerProperty.Fax:
                        customerToModify.Fax = newValue;
                        break;
                    default:
                        throw new ApplicationException(string.Format("No such property found: {0}", property.ToString()));
                }

                northwindEntities.SaveChanges();
            }
        }

        public static IEnumerable<Customer> GetCustomersToList()
        {
            var result = new List<Customer>();
            using (var northwindEntities = new NorthwindEntities())
            {
                result = northwindEntities.Customers.ToList();
            }

            return result;
        }

        public static void DeleteCustomer(string customerId)
        {
            using (var northwindEntities = new NorthwindEntities())
            {
                var customerToDelete = FindCustomerById(northwindEntities, customerId);
                northwindEntities.Customers.Remove(customerToDelete);
                northwindEntities.SaveChanges();
            }
        }

        private static Customer FindCustomerById(NorthwindEntities entities, string customerId)
        {
            Customer foundCustomer = entities.Customers.FirstOrDefault(
                c => c.CustomerID == customerId);
            return foundCustomer;
        }

        /*Write a method that finds all customers who have 
        orders made in 1997 and shipped to Canada.*/
        public static IEnumerable<Customer> GetCustomersByOrderMadeIn1997SShippedToCanada()
        {
            var result = new List<Customer>();
            using (var northwindEntities = new NorthwindEntities())
            {
                result = northwindEntities.Customers.Where(c => c.Orders.Any(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")).ToList();
            }

            return result;
        }

        /*Implement previous by using native SQL query and 
        executing it through the DbContext.*/
        public static IEnumerable<Customer> GetCustomersByOrderMadeIn1997SShippedToCanadaSqlQuery()
        {
            IEnumerable<Customer> result;
            using (var northwindEntities = new NorthwindEntities())
            {
                string sqlQuery = "SELECT DISTINCT c.* FROM Customers c " +
                                  "INNER JOIN Orders o " +
                                  "ON c.CustomerID = o.CustomerID " +
                                  "WHERE (1997 = (DATEPART (year, o.OrderDate)))" +
                                  "AND (o.ShipCountry = 'Canada')";
                result = northwindEntities.Customers.SqlQuery(sqlQuery).ToList();
            }

            return result;
        }

        /*Write a method that finds all the sales by specified 
        region and period (start / end dates). */
        public static IEnumerable<Order> SalesByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            var result = new List<Order>();
            using (var northwindEntities = new NorthwindEntities())
            {
                result = northwindEntities
                    .Orders
                    .Where(
                        o =>
                            (o.ShippedDate.Value >= startDate && o.ShippedDate.Value <= endDate) &&
                            (o.ShipRegion == region)
                    ).ToList();
            }

            return result;
        }
    }
}