namespace NorthwindDb.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NorthwindDb.Client.CustomersDataAccess;
    using NorthwindDbContext;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    internal class TestCustomerManipulation
    {
        private static void Main()
        {
            try
            {
                /*
                var bugsId = NorthwindDb.Client.CustomersDataAccess.CustomerDataManipulation.InsertCustomer(
                    "ACME Inc", "Bugs Bunny", "Rabbit", "Hole in the ground", "Cartoon city", "West", "0000", "USA", "555-555-555", "same as phone"
                    );*/
                var bugsId = "ACMEI";
                Console.WriteLine("Added customer with Id: {0}", bugsId);
                CustomerDataManipulation.ModifyCustomer(bugsId, CustomerProperty.Region, "Bulgaria");
                CustomerDataManipulation.ModifyCustomer(bugsId, CustomerProperty.ContactName, "Pesho");
                var customers = CustomerDataManipulation.GetCustomersToList();
                PrintCustomers(customers);

                Console.WriteLine("Task 03");
                var customersOrderedIn1997ToCanada = CustomerDataManipulation.GetCustomersByOrderMadeIn1997SShippedToCanada();
                PrintCustomers(customersOrderedIn1997ToCanada);

                Console.WriteLine("Task 04");
                var customersOrderedIn1997ToCanadaSqlQuery = CustomerDataManipulation.GetCustomersByOrderMadeIn1997SShippedToCanadaSqlQuery();
                PrintCustomers(customersOrderedIn1997ToCanada);

                Console.WriteLine("Task 05");
                var salesByRegionAndPeriod = CustomerDataManipulation.SalesByRegionAndPeriod(
                    "WA", new DateTime(1994, 01, 01), new DateTime(2001, 02, 03));
                foreach (var sale in salesByRegionAndPeriod)
                {
                    Console.WriteLine("Ship name: {0}, region: {1}, date: {2}", sale.ShipName, sale.ShipRegion, sale.ShippedDate);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }

                Trace.Flush();
            }
        }
 
        private static void PrintCustomers(IEnumerable<Customer> customers)
        {
            Console.WriteLine(new string('-', 45));
            foreach (var customer in customers)
            {
                Console.WriteLine("company: {0}, contact name: {1}, country: {2}", customer.CompanyName, customer.ContactName, customer.Country);
            }

            Console.WriteLine(new string('-', 45));
        }
    }
}