namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;

    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
            this.Number = Guid.NewGuid();
        }

        [Key]
        public int StudentId { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        public Guid Number { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("ID: ").Append(this.StudentId);
            result.AppendLine(", ");
            result.Append("Number: ").Append(this.Number);
            result.AppendLine(", ");
            result.Append("Name: ").Append(this.Name);
            result.AppendLine(", ");
            result.Append("Courses attended: ");
            if (this.Courses.Count > 0)
            {
                result.Append(string.Join(", ", this.Courses.Select(c => c.Name)));
            }

            result.AppendLine(";");

            return result.ToString();
        }
    }
}