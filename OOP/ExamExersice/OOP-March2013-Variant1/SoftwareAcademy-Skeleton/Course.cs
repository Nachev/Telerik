namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class Course : ICourse
    {
        private string name;
        private ITeacher teacher;
        private IList<string> topics;

        protected Course(string name, ITeacher teacher = null)
        {
            this.name = name;
            this.teacher = teacher;
            this.topics = new List<string>();
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
                    throw new ArgumentNullException("Course name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cannot assign null teacher to course.");
                }

                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            topics.Add(topic);
        }

        //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("{0}: Name={1}; ", this.GetType().Name, this.name));

            if (this.teacher != null)
            {
                result.Append(string.Format("Teacher={0}; ", this.teacher.Name));
            }

            if (this.topics.Count > 0)
            {
                result.Append(string.Format("Topics=[{0}]; ", string.Join(", ", this.topics)));
            }

            return result.ToString();
        }
    }
}
