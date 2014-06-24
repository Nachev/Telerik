namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private const string DuplicateNumberMessageFormat = "Student number {0} exists in this school";
        private const string DuplicateCourseNameMessageFormat = "Course name {0} already exists in this school";
        private const string NameNullExceptionMessage = "School name cannot be null";
        private const string NameEmptyExceptionMessage = "School name cannot be empty.";
        private IList<ICourse> listOfCourses = new List<ICourse>();
        private IList<IStudent> listOfStudents = new List<IStudent>();
        private string name;

        public School(string name)
        {
            this.Name = name;
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
                    if (value == null)
                    {
                        throw new ArgumentNullException(NameNullExceptionMessage);
                    }

                    throw new ArgumentException(NameEmptyExceptionMessage);
                }

                this.name = value;
            }
        }

        public IList<IStudent> ListOfStudents
        {
            get
            {
                return DeepCopyList(this.listOfStudents);
            }
        }

        public IList<ICourse> ListOfCourses
        {
            get
            {
                return DeepCopyList(this.listOfCourses);
            }
        }

        public void GenerateStudent(string name, int uniqueNumber)
        {
            bool numberExists = this.ListOfStudents.Any(st => st.UniqueNumber == uniqueNumber);
            if (numberExists)
            {
                throw new ApplicationException(string.Format(DuplicateNumberMessageFormat, uniqueNumber));
            }

            var student = new Student(uniqueNumber, name);
            this.listOfStudents.Add(student);
        }

        public void GenerateCourse(string name)
        {
            bool courseExists = this.listOfCourses.Any(c => c.Name == name);
            if (courseExists)
            {
                throw new ApplicationException(string.Format(DuplicateCourseNameMessageFormat, name));
            }

            var course = new Course(name);
            this.listOfCourses.Add(course);
        }

        private static IList<ICourse> DeepCopyList(IList<ICourse> list)
        {
            IList<ICourse> listCopy = new List<ICourse>(list.Count);
            for (int i = 0; i < list.Count; i++)
            {
                var courseCopy = new Course(list[i].Name, list[i].Students);
                listCopy.Add(courseCopy);
            }

            return listCopy;
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