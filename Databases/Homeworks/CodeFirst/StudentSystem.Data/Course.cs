namespace StudentSystem.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
            this.Homeworks = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Materials { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Homework> Homeworks { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("ID: ").Append(this.CourseId);
            result.AppendLine(", ");
            result.Append("Name: ").Append(this.Name);
            result.AppendLine(", ");
            result.Append("Description: ").Append(this.Description);
            result.AppendLine(", ");
            result.Append("Students in course: ");
            if (this.Students.Count > 0)
            {
                result.Append(string.Join(", ", this.Students.Select(s => s.Name)));
            }
            
            result.AppendLine(";");

            return result.ToString();
        }
    }
}