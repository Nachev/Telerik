namespace NorthwindDb.Client.CreateStoredProcedure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NorthwindDbContext;

    public static class StoredProcedureCreator
    {
        public static void CreateFindIncomesForSupplierInPeriod()
        {
            string storedProcedure = "CREATE PROCEDURE [dbo].[uspTotalIncomesForSupplierInPeriod] (@supplierName nvarchar(50), @startDate date, @endDate date) " +
                                     "AS " +
                                     "BEGIN " +
                                     "SELECT SUM(o.Freight) FROM [dbo].[Orders] o " +
                                     "INNER JOIN [dbo].[Order Details] od " +
                                     "ON o.OrderID = od.OrderID " +
                                     "INNER JOIN [dbo].[Products] p " +
                                     "ON od.ProductID = p.ProductID " +
                                     "INNER JOIN [dbo].[Suppliers] s " +
                                     "ON p.SupplierID = s.SupplierID " +
                                     "WHERE @supplierName = s.[CompanyName] " +
                                     "AND o.ShippedDate BETWEEN " +
                                     "CAST(@startDate AS datetime) AND CAST(@endDate AS datetime)" +
                                     "END;";

            using (var dbContext = new NorthwindEntities())
            {
                dbContext.Database.ExecuteSqlCommand(storedProcedure);
                dbContext.SaveChanges();
            }
        }

        public static decimal? UseFindIncomesForSupplierInPeriod()
        {
            decimal? income;
            using (var dbContext = new NorthwindEntities())
            {
                income = dbContext.uspTotalIncomesForSupplierInPeriod("Tokyo Traders", new DateTime(1994, 01, 01), new DateTime(2014, 09, 09)).First();
            }

            return income;
        }
    }
}