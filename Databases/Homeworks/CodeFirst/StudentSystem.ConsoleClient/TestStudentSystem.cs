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
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var pesho = AddStudent(context, "Pesho");
                        var goshoId = AddStudent(context, "Gosho").StudentId;
                        AddStudent(context, "Mariika");

                        var cSharp = AddCourse(context, "C#", "Fundamentals of C# programming language");
                        AddCourse(context, "JavaScript", "Fundamental of JavaScript programming language");
                        var gosho = FindStudentById(context, goshoId);
                        AddCourse(context, "JavaScript SPA", "Single page applications with JavaScript programming language", "Google", new HashSet<Student>() { pesho, gosho });

                        var js = FindCourseByName(context, "JavaScript");
                        Console.WriteLine("Gosho =? " + gosho.Name);

                        AddHomework(context, "xxxxxxxxxx", DateTime.Now, cSharp, pesho);
                        AddHomework(context, "Some homework", new DateTime(2014, 05, 05), js, gosho);

                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }

                    List<Student> students = context.Students.ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine(student);
                    }

                    foreach (var course in context.Courses)
                    {
                        Console.WriteLine(course);
                    }

                    foreach (var homework in context.Homeworks)
                    {
                        Console.WriteLine(homework);
                    }
                }
        }

        private static Student AddStudent(StudentSystemEntities context, string name, ICollection<Course> courses = null)
        {
            var newStudent = new Student()
            {
                Name = name,
            };

            if (courses != null)
            {
                newStudent.Courses = courses;
            }

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

            if (students != null)
            {
                newCourse.Students = students;  
            }

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

        private static Course FindCourseByName(StudentSystemEntities context, string name)
        {
            var foundStudent = context.Courses.FirstOrDefault(c => c.Name == name);
            return foundStudent;
        }
    }
}