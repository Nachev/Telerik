namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemEntities>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentSystemEntities context)
        {
            context.Students.AddOrUpdate(s => s.StudentId, new Student() { StudentId = 1, Name = "Fake Student" });
            context.Courses.AddOrUpdate(c => c.CourseId, new Course() { CourseId = 1, Name = "Fake Course"});
            context.Homeworks.AddOrUpdate(h => h.HomeworkId, new Homework() { StudentId = 1, CourseId = 1, TimeSent = DateTime.Now, Content = "Some content" });
        }
    }
}