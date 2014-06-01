namespace StudentsList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /*Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber. 
     * Create a List<Student> with sample students. Use LINQ query. */

    public class SampleProgram
    {
        private static List<Student> students;

        private static void Main()
        {
            students = new List<Student>()
            { 
                new Student("Pesho", "Petrov", 96010535, "+35929745689", "p_petrov@mail.bg", 2, new List<int>() { 2, 2, 3, 6, 4 }),
                new Student("Victoria", "Chausheva", 96010656, "0888598613", "baby86@abv.bg", 1, new List<int>() { 2, 3, 3, 3, 4 }),
                new Student("Ditrich", "Muler", 96010635, "0535653", "uber.ales@reich.de", 1, new List<int>() { 6, 5, 6, 6, 5 }),
                new Student("Adolf", "Meyer", 96010425, "0898587456", "adi@gote.com", 2, new List<int>() { 5, 4, 3, 6, 4 }),
                new Student("Rusi", "Rusev", 96010544, "099896464", "rusi2001@abv.bg", 2, new List<int>() { 3, 2, 3, 4, 4 }),
                new Student("Hristo", "Petrov", 96010336, "05296578", "icopetroff@gemini.bg", 1, new List<int>() { 4, 5, 3, 6, 4 }),
                new Student("Onufri", "Draganoff", 96010726, "112", "muncho@abv.bg", 2, new List<int>() { 2, 2, 2, 2, 4 }),
                new Student("Marina", "Georgieva", 96010722, "029765421", "marina_g@gmail.com", 1, new List<int>() { 6, 4, 5, 6, 4 }),
                new Student("Marina", "Bankova", 96010521, "0878787878", "m.bankova@hotmail.com", 2, new List<int>() { 6, 5, 4, 6, 4 })
            };

            Console.WriteLine("Selected by group number: ");
            var selectByGroup = SelectByGroupLINQ();
            PrintIEnumerable(selectByGroup);

            Console.WriteLine();
            Console.WriteLine("Ordered by first name: ");
            selectByGroup = OrderByFirstNameLINQ(selectByGroup);
            PrintIEnumerable(selectByGroup);

            Console.WriteLine();
            Console.WriteLine("Selected by group number with extention method: ");
            var selectByGroupExt = SelectByGroupExt();
            PrintIEnumerable(selectByGroupExt);

            Console.WriteLine();
            Console.WriteLine("Ordered by first name with extention method: ");
            selectByGroupExt = OrderByFirstNameExt(selectByGroupExt);
            PrintIEnumerable(selectByGroup);

            Console.WriteLine();
            Console.WriteLine("Selected by email using LINQ: ");
            var selectByEmail = SelectByMail("abv.bg");
            PrintIEnumerable(selectByEmail);

            Console.WriteLine();
            Console.WriteLine("Selected by phone number using LINQ: ");
            var selectByPhone = SelectByPhoneNumber("2");
            PrintIEnumerable(selectByPhone);

            Console.WriteLine();
            Console.WriteLine("Selected by exelent mark: ");
            var selectByMark = SelectInAnonymousByMark(6);
            PrintIEnumerable(selectByMark);

            Console.WriteLine();
            Console.WriteLine("Selected by at least two bad mark: ");
            var selectByTwoMarks = SelectInAnonymousByTwoMarks(2);
            PrintIEnumerable(selectByTwoMarks);

            Console.WriteLine();
            Console.WriteLine("Extract marks for students enrolled in 2006");
            var extractByYearEnrolled = ExtractMarksByEnrolled(2006);
            PrintIEnumerable(extractByYearEnrolled);
        }

        private static void PrintIEnumerable(IEnumerable selectByGroup)
        {
            foreach (var item in selectByGroup)
            {
                Console.WriteLine(item);
            }
        }

        // Select only the students that are from group number 2.
        private static IEnumerable SelectByGroupLINQ()
        {
            var result =
                from student in students
                where student.GroupNumber == 2
                select student;

            return result;
        }

        // Order the students by FirstName.
        private static IEnumerable OrderByFirstNameLINQ(IEnumerable inputArray)
        {
            var result = from Student student in inputArray
                         orderby student.FirstName
                         select student;
            return result;
        }

        // Implement the previous using the same query expressed with extension methods.
        private static IEnumerable SelectByGroupExt()
        {
            var result = students.Where(x => x.GroupNumber == 2);
            return result;
        }

        private static IEnumerable OrderByFirstNameExt(IEnumerable selectByGroupExt)
        {
            var result = students.OrderBy(x => x.FirstName);
            return result;
        }

        // ----------------------------------------------------------------------------

        // Extract all students that have email in abv.bg. Use string methods and LINQ.
        private static IEnumerable SelectByMail(string match)
        {
            var result = from student in students
                         where student.Email.Contains(match)
                         select student;
            return result;
        }

        // Extract all students with phones in Sofia. Use LINQ.
        private static IEnumerable SelectByPhoneNumber(string match)
        {
            string regex = @"((\+359){1}|0{1})\s?" + match + @"\s?\d+";
            var result = from student in students
                         where Regex.IsMatch(student.PhoneNumber, regex)
                         select student;
            return result;
        }

        // Select all students that have at least one mark Excellent (6) into a new anonymous 
        // class that has properties – FullName and Marks. Use LINQ.
        private static IEnumerable SelectInAnonymousByMark(int matchMark)
        {
            var result = from student in students
                         where student.Marks.Contains(matchMark)
                         select new { FullName = student.FirstName + ' ' + student.LastName, Marks = string.Join(", ", student.Marks) };
            return result;
        }

        // Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
        private static IEnumerable SelectInAnonymousByTwoMarks(int matchMark)
        {
            var result = students.Where(x => x.Marks.Count(a => a == matchMark) >= 2)
                .Select(a => new { FullName = a.FirstName + ' ' + a.LastName, Marks = string.Join(", ", a.Marks) });
            return result;
        }

        // Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        private static IEnumerable ExtractMarksByEnrolled(int matchYear)
        {
            var result = students.Where(s => ((s.FacultyNumber % 10000) / 100).Equals(matchYear % 100))
                .Select(x => new { studentMarks = string.Join(",", x.Marks) });
            return result;
        }
    }
}
