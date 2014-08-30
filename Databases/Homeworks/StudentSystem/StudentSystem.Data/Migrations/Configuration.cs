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
            context.Students.AddOrUpdate(s => s.Name, new Student() { Name = "Fake Student" });
            context.Courses.AddOrUpdate(c => c.Name, new Course() { Name = "Fake Course"});
        }
    }
}