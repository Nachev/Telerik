namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private const string NameExceptionMessage = "Name cannot be null or empty";
        private const string TeacherExceptionMessage = "Teacher's name cannot be empty";
        private const string StudentsExceptionMessage = "Students list cannot be null";
        private string name;

        private string teacherName;

        private IList<string> students;

        protected Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(NameExceptionMessage);
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException(TeacherExceptionMessage);
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                var output = new List<string>(this.students);

                return output; 
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(StudentsExceptionMessage);
                }

                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("OffsiteCourse { Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
