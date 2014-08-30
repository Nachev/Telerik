namespace NorthwindDb.Client.CreateOrderWithTransaction
{
    using System;
    using System.Linq;
    using System.Transactions;
    using NorthwindDbContext;

    public static class CreateOrder
    {
        public static void NewOrder(string customerId, int employeeId, DateTime orderDate, int shipVia, string shipName, string shipCity)
        {
            // using (TransactionScope scope = new TransactionScope())
            // {
            using (var dbContext = new NorthwindEntities())
            {
                using (var tran = dbContext.Database.BeginTransaction())
                {
                    var newOrder = new Order();
                    newOrder.CustomerID = customerId;
                    newOrder.EmployeeID = employeeId;
                    newOrder.OrderDate = orderDate;
                    newOrder.ShipVia = shipVia;
                    newOrder.ShipName = shipName;
                    newOrder.ShipCity = shipCity;

                    dbContext.Orders.Add(newOrder);
                    dbContext.SaveChanges();
                    tran.Commit();
                }
            }
            //scope.Complete();
            //}
        }
    }
}