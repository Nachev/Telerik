namespace SerarchInStudents
{
    using System;
    using System.Collections;
    using System.Linq;

    public class StudentLINQQuery
    {
        private static void Main()
        {
            Student[] students = 
            { 
                new Student("Pesho", "Petrov", 20),
                new Student("Victoria", "Chausheva", 26),
                new Student("Ditrich", "Muler", 19),
                new Student("Adolf", "Meyer", 25),
                new Student("Rusi", "Rusev", 44),
                new Student("Hristo", "Petrov", 36),
                new Student("Onufri", "Draganoff", 26),
                new Student("Marina", "Georgieva", 22),
                new Student("Marina", "Bankova", 21)
            };

            var result = SelectStudentsByNames(students);
            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var result2 = SelectStudentsByAge(students);
            foreach (var student in result2)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var resultOrderLinq = OrderByNameLINQ(students);
            foreach (var student in resultOrderLinq)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var resultOrderLambda = OrderByNameLambda(students);
            foreach (var student in resultOrderLambda)
            {
                Console.WriteLine(student);
            }
        }
        
        /*Write a method that from a given array of students finds all students whose 
         * first name is before its last name alphabetically. Use LINQ query operators.*/
        private static Student[] SelectStudentsByNames(Student[] students)
        {
            var result = 
                from student in students
                where student.FirstName.CompareTo(student.FamilyName) < 0
                select student;
            return result.ToArray();

            // return students.Where(x => (x.FirstName.CompareTo(x.FamilyName) < 0)).ToArray();
        }

        /*Write a LINQ query that finds the first name and last name of 
         * all students with age between 18 and 24.*/
        private static IEnumerable SelectStudentsByAge(Student[] students)
        {
            var result =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student.FirstName + ' ' + student.FamilyName;
            return result;

            // return students.Where(x => (x.Age >= 18 && x.Age <= 24)).Select(x => x.FirstName + ' ' + x.FamilyName);
        }

        /*Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the 
         * students by first name and last name in descending order. Rewrite the same with LINQ.
         ---------------------------------------------------------------------------------------------------------*/
        private static Student[] OrderByNameLINQ(Student[] students)
        {
            var result =
                from student in students
                orderby student.FirstName descending, student.FamilyName descending
                select student;
            return result.ToArray();
        }

        private static Student[] OrderByNameLambda(Student[] students)
        {
            return students.OrderByDescending(x => x.FirstName).ThenByDescending(y => y.FamilyName).ToArray();
        }

        //----------------------------------------------------------------------------------------------------------
    }
}
