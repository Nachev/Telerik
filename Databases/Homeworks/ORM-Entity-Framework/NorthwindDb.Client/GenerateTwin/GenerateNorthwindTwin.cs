namespace NorthwindDb.Client.GenerateTwin
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using NorthwindDbContext;

    public class GenerateNorthwindTwin
    {
        public static void GenerateTwinDb()
        {
            var northwindEntities = new NorthwindEntities();
            string connectionString = northwindEntities.Database.Connection.ConnectionString;
            connectionString = connectionString.Replace("Northwind", "NorthwindTwin");
            //Console.WriteLine(connectionString);
            DbContext context = new DbContext(connectionString);
            var dbScript = CreateDatabaseScript(northwindEntities);
            dbScript = RenameDb(dbScript);
            //Console.WriteLine(dbScript);
            context.Database.ExecuteSqlCommand(dbScript);
        }
 
        private static string CreateDatabaseScript(DbContext context)
        {
            return ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
        }

        private static string RenameDb(string dbScript)
        {
            string result = dbScript;
            while (result.Contains(" Northwind "))
            {
                result = result.Replace(" Northwind ", " NorthwindTwin ");
            }

            return result;
        }
    }
}