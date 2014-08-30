namespace StudentSystem.Data
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
    }
}