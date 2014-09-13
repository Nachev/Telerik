namespace StudentSystem.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("HomeworkId: ").Append(this.HomeworkId);
            result.Append(", StudentId: ").Append(this.StudentId);
            result.Append(", CourseId: ").Append(this.CourseId);
            result.AppendLine(";");
            return result.ToString();
        }
    }
}