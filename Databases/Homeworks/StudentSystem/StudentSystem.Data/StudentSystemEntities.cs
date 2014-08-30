namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /*Using c0de first approach, create database for student system with the following tables:
    Students (with Id, Name, Number, etc.)
    Courses (Name, Description, Materials, etc.)
    StudentsInCourses (many-to-many relationship)
    Homework (one-to-many relationship with students and courses), fields: Content, TimeSent
    Annotate the data models with the appropriate attributes and enable code first migrations*/
    public class StudentSystemEntities : DbContext
    {
        public StudentSystemEntities() : base("name=StudentSystemEntities")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasMany(c => c.Students).WithMany(s => s.Courses).
            Map(
                m =>
                {
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("StudentId");
                    m.ToTable("StudentsInCourses");
                });
        }
    }
}