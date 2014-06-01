namespace School
{
    using System;
    using System.Collections.Generic;

    /*We are given a school. In the school there are classes of students. Each class has a set of teachers. 
     * Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have 
     * unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of 
     * exercises. Both teachers and students are people. Students, classes, teachers and disciplines could 
     * have optional comments (free text block).
     * Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate 
     * their fields, define the class hierarchy and create a class diagram with Visual Studio.*/

    public class TestProgram
    {
        private static void Main()
        {
            var discip = new[] 
            { 
                new Discipline("Math", 10, 5),
                new Discipline("History", 8, 2) 
            };
            var teacher1 = new Teacher("Pesho Petrov", discip, "Test comment");
            var teacher2 = new Teacher("Gandalf The Grey", discip);
            Console.WriteLine(teacher1);

            var student1 = new Student("Pesho Hristov", 13, "Tapak");
            var student2 = new Student("Foobar Foobarov", 54, "Genius");

            var test = new SchoolClass("12-g", new[] { student1, student2 }, new[] { teacher1, teacher2 });
            Console.WriteLine(test);
        }
    }
}
