namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class SchoolClass : ICommentable
    {
        private string schoolId;

        public SchoolClass(string schoolId, IEnumerable<Student> students, IEnumerable<Teacher> teachers, string comment = null)
        {
            this.SchoolID = schoolId;
            this.Students = students;
            this.Teachers = teachers;
            this.Comment = comment;
        }

        public IEnumerable<Student> Students { get; private set; }

        public IEnumerable<Teacher> Teachers { get; private set; }

        public string SchoolID 
        {
            get
            {
                return this.schoolId;
            }

            private set
            {
                string regex = @"\b[1-9]{1}[0-9]?\s?\-\s?[A-Za-z]\b";
                if (Regex.IsMatch(value, regex))
                {
                    this.schoolId = value;
                }
                else
                {
                    throw new FormatException("Format of school ID is not correct.");
                }
            }
        }

        public string Comment { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("School ID: {0}", this.SchoolID);
            if (this.Comment != null)
            {
                result.AppendFormat(" comment: {0}", this.Comment);
            }

            result.AppendLine();
            result.AppendLine("Students: ");
            result.Append(string.Join("\n", this.Students.Select(s => s)));
            result.AppendLine();
            result.AppendLine("Teachers: ");
            result.Append(string.Join("\n", this.Teachers.Select(t => t)));
            return result.ToString();
        }
    }
}
