namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course : ICourse
    {
        private const string NameNullExceptionMessage = "Name value cannot be null";
        private const string NameEmptyExceptionMessage = "Name value cannot be empty string";
        private IList<IStudent> students = new List<IStudent>();
        private string name;

        public Course(string initialName, IList<IStudent> studentsList = null)
        {
            this.Name = initialName;
            this.Students = studentsList;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException(NameNullExceptionMessage);
                    }

                    throw new ArgumentException(NameEmptyExceptionMessage);
                }

                this.name = value;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                return DeepCopyList(this.students);
            }

            private set
            {
                if (value == null)
                {
                    this.students = new List<IStudent>();
                }
                else
                {
                    this.students = value;
                }
            }
        }

        public void InsertStudent(IStudent studentTobeInserted)
        {
            this.students.Add(studentTobeInserted);
        }

        public void RemoveStudent(IStudent studentTobeInserted)
        {
            this.students.Remove(studentTobeInserted);
        }

        private static IList<IStudent> DeepCopyList(IList<IStudent> list)
        {
            IList<IStudent> listCopy = new List<IStudent>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                var studentCopy = new Student(list[i].UniqueNumber, list[i].Name);
                listCopy.Add(studentCopy);
            }

            return listCopy;
        }
    }
}
