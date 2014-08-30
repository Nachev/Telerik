namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;
    using System.Collections.Generic;

    internal class TestStudentSystem
    {
        private static void Main()
        {
            using (var context = new StudentSystemEntities())
            {
                var pesho = AddStudent(context, "Pesho");
                var goshoId = AddStudent(context, "Gosho").StudentId;
                AddStudent(context, "Mariika");

                var cSharp = AddCourse(context, "C#", "Fundamentals of C# programming language");
                AddCourse(context, "JavaScript", "Fundamental of JavaScript programming language");
                AddCourse(context, "JavaScript SPA", "Single page applications with JavaScript programming language");

                var gosho = FindStudentById(context, goshoId);
                var js = FindCourseById(context, 2);
                Console.WriteLine("Gosho =? " + gosho.Name);

                AddHomework(context, "xxxxxxxxxx", DateTime.Now, cSharp, pesho);
                AddHomework(context, "Some homework", new DateTime(2014, 05, 05), js, gosho);
            }
        }

        private static Student AddStudent(StudentSystemEntities context, string name, ICollection<Course> courses = null)
        {
            var newStudent = new Student()
            {
                Name = name,
                Courses = courses
            };

            context.Students.Add(newStudent);
            context.SaveChanges();

            return newStudent;
        }

        private static Course AddCourse(
            StudentSystemEntities context, 
            string name, 
            string description = null, 
            string materials = null, 
            ICollection<Student> students = null)
        {
            var newCourse = new Course()
            {
                Name = name,
                Description = description,
                Materials = materials
            };

            context.Courses.Add(newCourse);
            context.SaveChanges();

            return newCourse;
        }

        private static void AddHomework(StudentSystemEntities context, string content, DateTime sentDate, Course course, Student student)
        {
            var newHomework = new Homework()
            {
                Content = content,
                TimeSent = sentDate,
                Course = course,
                Student = student
            };

            course.Homeworks.Add(newHomework);
            student.Homeworks.Add(newHomework);
            context.Homeworks.Add(newHomework);
            context.SaveChanges();
        }

        private static Student FindStudentById(StudentSystemEntities context, int studentId)
        {
            var foundStudent = context.Students.FirstOrDefault(s => s.StudentId == studentId);
            return foundStudent;
        }

        private static Student FindStudentByNumber(StudentSystemEntities context, Guid number)
        {
            var foundStudent = context.Students.FirstOrDefault(s => s.Number == number);
            return foundStudent;
        }

        private static Course FindCourseById(StudentSystemEntities context, int courseId)
        {
            var foundStudent = context.Courses.FirstOrDefault(c => c.CourseId == courseId);
            return foundStudent;
        }
    }
}