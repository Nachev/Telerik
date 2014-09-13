namespace NorthwindDb.Client.ConcurentDbContexts
{
    using System;
    using System.Linq;
    using NorthwindDbContext;

    /*Try to open two different data contexts and perform 
    concurrent changes on the same records. What will 
    happen at SaveChanges()? How to deal with it?*/
    public static class ConcurentContexts
    {
        public static void Process()
        {
            using(var firstContext = new NorthwindEntities())
            using (var secondContext = new NorthwindEntities())
            {
                var firstProdToModify = firstContext.Products.FirstOrDefault(pr => pr.ProductName == "Pavlova");
                var secondProdToModify = secondContext.Products.FirstOrDefault(pr => pr.ProductName == "Pavlova");

                firstProdToModify.ProductName = "Petrova";
                secondProdToModify.ProductName = "Georgieva";

                firstContext.SaveChanges();
                secondContext.SaveChanges();
            }

            // To ensure smooth operation Async Query & Save could be used.
        }
    }
}