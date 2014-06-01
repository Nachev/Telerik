namespace SoftwareAcademy
{
    using System;
    using System.Linq;
    using System.Text;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string initialName, ITeacher initialTeacher, string initialTown)
            : base(initialName, initialTeacher)
        {
            this.Town = initialTown;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Town name for offsite course cannot be null or empty.");
                }

                this.town = value;
            }
        }
         
        public override string ToString()
        {
            var result = new StringBuilder(base.ToString());
            result.Append(string.Format("Town={0}", this.town));
            return result.ToString();
        }
    }
}
