namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.Number = new Guid();
        }

        [Key]
        public int StudentId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        public Guid Number { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }
    }
}