namespace PrintEmployeesFromSofia
{
    using System;
    using System.Linq;
    using TelerikAcademyDb;

    /*Using Entity Framework write a query that selects all employees from the Telerik Academy database, 
     * then invokes ToList(), then selects their addresses, then invokes ToList(), then selects their 
     * towns, then invokes ToList() and finally checks whether the town is "Sofia". Rewrite the same 
     * in more optimized way and compare the performance.*/
    internal class SampleProgram
    {
        private static void Main(string[] args)
        {
            using(var context = new TelerikAcademyEntities())
            {
                NonOptimizedEmployeeQuery(context);
                OptimizedEmployeeQuery(context);
            }
        }

        private static void NonOptimizedEmployeeQuery(TelerikAcademyEntities context)
        {
            var employees = context.Employees.ToList();
            var addresses = employees.Select(e => e.Address).ToList();
            var towns = addresses.Select(a => a.Town).ToList();
            var sofiaTownId = towns.Where(t => t.Name.ToLowerInvariant() == "Sofia".ToLowerInvariant()).First().TownID;

            Console.WriteLine("Employees:");
            foreach (var employee in employees.Where(e => e.Address.TownID == sofiaTownId).Select(e => e.FirstName + " " + e.MiddleName + " " + e.LastName))
            {
                Console.WriteLine("{0}", string.Join(", ",employee));
            }
        }

        private static void OptimizedEmployeeQuery(TelerikAcademyEntities context)
        {
            Console.WriteLine("Employees:");
            var employeesInSofia = context.Employees
                .Where(e => e.Address.Town.Name == "Sofia")
                .Select(e => e.FirstName + " " + e.MiddleName + " " + e.LastName);
            foreach (var employee in employeesInSofia)
            {
                Console.WriteLine("{0}", string.Join(", ", employee));
            }
        }
    }
}
