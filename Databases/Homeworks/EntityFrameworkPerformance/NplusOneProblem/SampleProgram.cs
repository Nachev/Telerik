namespace NplusOneProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TelerikAcademyDb;

    /*Using Entity Framework write a SQL query to select all employees from the Telerik 
     * Academy database and later print their name, department and town. Try the both 
     * variants: with and without .Include(…). Compare the number of executed SQL 
     * statements and the performance.*/
    public static class SampleProgram
    {
        private static void Main()
        {
            using (var context = new TelerikAcademyEntities())
            {
                StringBuilder container = new StringBuilder();

                AnonymusVariable(context, container);
                SeparateCalls(context, container);
                IncludeUsing(context, container);
            }
        }
 
        private static void IncludeUsing(TelerikAcademyEntities context, StringBuilder container)
        {
            Console.WriteLine("Include:");

            var employeesWithTown = context.Employees.Include("Department").Include("Address.Town");
            foreach (var includedEmployee in employeesWithTown)
            {
                container.Append("Name: ").Append(includedEmployee.FirstName).Append(' ').Append(includedEmployee.MiddleName).Append(' ').AppendLine(includedEmployee.LastName);
                container.Append("Department: ").AppendLine(includedEmployee.Department.Name);
                container.Append("Town: ").AppendLine(includedEmployee.Address.Town.Name);
                container.AppendLine(new string('-', 50));
            }

            Console.WriteLine(container);
            container.Clear();
        }
 
        private static void SeparateCalls(TelerikAcademyEntities context, StringBuilder container)
        {
            Console.WriteLine("Separate: ");

            foreach (var separateEmployee in context.Employees)
            {
                container.Append("Name: ").Append(separateEmployee.FirstName).Append(' ').Append(separateEmployee.MiddleName).Append(' ').AppendLine(separateEmployee.LastName);
                container.Append("Department: ").AppendLine(separateEmployee.Department.Name);
                container.Append("Town: ").AppendLine(separateEmployee.Address.Town.Name);
                container.AppendLine(new string('-', 50));
            }

            Console.WriteLine(container);
            container.Clear();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
 
        private static void AnonymusVariable(TelerikAcademyEntities context, StringBuilder container)
        {
            var extractedEmployees = context.Employees.Select(employee => new
            {
                Name = employee.FirstName + " " + (employee.MiddleName == null ? string.Empty : employee.MiddleName) + " " + employee.LastName,
                Department = employee.Department.Name,
                Town = employee.Address.Town.Name
            });

            foreach (var extractedEmployee in extractedEmployees)
            {
                container.Append("Name: ").AppendLine(extractedEmployee.Name);
                container.Append("Department: ").AppendLine(extractedEmployee.Department);
                container.Append("Town: ").AppendLine(extractedEmployee.Town);
                container.AppendLine(new string('-', 50));
            }

            Console.WriteLine(container);
            container.Clear();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}