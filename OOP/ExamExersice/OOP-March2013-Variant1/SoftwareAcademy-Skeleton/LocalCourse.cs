namespace SoftwareAcademy
{
    using System;
    using System.Linq;
    using System.Text;

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string initialName, ITeacher initialTeacher, string initialLab)
            : base(initialName, initialTeacher)
        {
            this.lab = initialLab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lab value for course cannot be null or empty.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.Append(string.Format("Lab={0}", this.lab));
            return result.ToString();
        }
    }
}
