namespace StudentWithGroupProperty
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class SampleProgram
    {
        private static List<Student> students;
        private static Group[] groups;

        private static void Main()
        {
            students = new List<Student>()
            { 
                new Student("Pesho", "Petrov", 96010535, "+35929745689", "p_petrov@mail.bg", 1, new List<int>() { 2, 2, 3, 6, 4 }),
                new Student("Victoria", "Chausheva", 96010656, "0888598613", "baby86@abv.bg", 2, new List<int>() { 2, 3, 3, 3, 4 }),
                new Student("Ditrich", "Muler", 96010635, "0535653", "uber.ales@reich.de", 3, new List<int>() { 6, 5, 6, 6, 5 }),
                new Student("Adolf", "Meyer", 96010425, "0898587456", "adi@gote.com", 3, new List<int>() { 5, 4, 3, 6, 4 }),
                new Student("Rusi", "Rusev", 96010544, "099896464", "rusi2001@abv.bg", 1, new List<int>() { 3, 2, 3, 4, 4 }),
                new Student("Hristo", "Petrov", 96010336, "05296578", "icopetroff@gemini.bg", 4, new List<int>() { 4, 5, 3, 6, 4 }),
                new Student("Onufri", "Draganoff", 96010726, "112", "muncho@abv.bg", 3, new List<int>() { 2, 2, 2, 2, 4 }),
                new Student("Marina", "Georgieva", 96010722, "029765421", "marina_g@gmail.com", 4, new List<int>() { 6, 4, 5, 6, 4 }),
                new Student("Marina", "Bankova", 96010521, "0878787878", "m.bankova@hotmail.com", 4, new List<int>() { 6, 5, 4, 6, 4 })
            };

            groups = new Group[]
            {
                new Group(1, "Computer Science"),
                new Group(2, "Physics"),
                new Group(3, "Mathematics"),
                new Group(4, "Economics"),
            };

            Console.WriteLine("Students list: ");
            students.ForEach(s => Console.WriteLine(s));

            Console.WriteLine();
            Console.WriteLine("Groups: ");
            PrintIEnumerable(groups);

            Console.WriteLine();
            string magicWord = "Mathematics";
            Console.WriteLine("Extract by department name. Students in {0}:", magicWord);
            var extractByDepartment = ExtractByDepartment(magicWord);
            PrintIEnumerable(extractByDepartment);

            Console.WriteLine();
            Console.WriteLine("Find max length of string");
            string[] strArray = groups.Select(x => x.DepartmentName).ToArray();
            var maxLength = StringWithMaxLength(strArray);
            Console.WriteLine(maxLength);
        }

        private static void PrintIEnumerable(IEnumerable selectByGroup)
        {
            foreach (var item in selectByGroup)
            {
                Console.WriteLine(item);
            }
        }

        /* Create a class Group with properties GroupNumber and DepartmentName. Introduce a property Group 
         * in the Student class. Extract all students from "Mathematics" department. Use the Join operator.*/
        private static IEnumerable ExtractByDepartment(string matchDep)
        {
            var result = from g in groups
                         join s in students on g.GroupNumber equals s.GroupNumber
                         where g.DepartmentName == matchDep
                         select s;
            return result;
        }

        // Write a program to return the string with maximum length from an array of strings. Use LINQ.
        private static string StringWithMaxLength(IEnumerable<string> strings)
        {
            var result = from w in strings
                         orderby w.Length descending
                         select w;
            return result.First();
        }
    }
}
