namespace GroupStudentsByField
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /*Create a program that extracts all students grouped by GroupName and then prints them to the console.*/

    public class SampleProgram
    {
        private static List<Student> students;

        private static void Main()
        {
            students = new List<Student>()
            { 
                new Student("Pesho", "Petrov", 96010535, "+35929745689", "p_petrov@mail.bg", 2, "Hardware"),
                new Student("Victoria", "Chausheva", 96010656, "0888598613", "baby86@abv.bg", 1, "Software"),
                new Student("Ditrich", "Muler", 96010635, "0535653", "uber.ales@reich.de", 1, "Hardware"),
                new Student("Adolf", "Meyer", 96010425, "0898587456", "adi@gote.com", 2, "Software"),
                new Student("Rusi", "Rusev", 96010544, "099896464", "rusi2001@abv.bg", 2, "Software"),
                new Student("Hristo", "Petrov", 96010336, "05296578", "icopetroff@gemini.bg", 1, "Hardware"),
                new Student("Onufri", "Draganoff", 96010726, "112", "muncho@abv.bg", 2, "Hardware"),
                new Student("Marina", "Georgieva", 96010722, "029765421", "marina_g@gmail.com", 1, "Software"),
                new Student("Marina", "Bankova", 96010521, "0878787878", "m.bankova@hotmail.com", 2, "Software")
            };

            var groupedBy = GroupByGroupName();
            PrintResult(groupedBy);

            Console.WriteLine();
            string magicWord = "Software";
            Console.WriteLine("Extracted by group name \"{0}\": ", magicWord);
            var extractBy = ExtractByGroupName(magicWord);
            PrintResult(extractBy);

            Console.WriteLine();
            magicWord = "Hardware";
            Console.WriteLine("Extracted by group name /Extensions/ \"{0}\": ", magicWord);
            var extractByExt = ExtractByGroupNameExt(magicWord);
            PrintResult(extractByExt);
        }

        private static void PrintResult(IEnumerable input)
        {
            foreach (var item in input)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable GroupByGroupName()
        {
            var result = from st in students
                         group st by st.GroupName into g
                         from gr in g
                         select new { Group = gr.GroupName, Name = gr.FirstName + ' ' + gr.LastName };

            return result;
        }

        // Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.
        private static IEnumerable ExtractByGroupName(string groupName)
        {
            var result = from st in students
                         group st by st.GroupName into g
                         from r in g
                         where r.GroupName == groupName
                         select r;
            return result;
        }

        // Rewrite the previous using extension methods.
        private static IEnumerable ExtractByGroupNameExt(string groupName)
        {
            var result = students.GroupBy(s => s.GroupName).Where(k => k.Key == groupName).SelectMany(r => r);
            return result;
        }
    }
}
