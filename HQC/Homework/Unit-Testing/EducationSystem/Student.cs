namespace School
{
    using System;

    public class Student : IStudent
    {
        private const int UniqueNumberMinValue = 10000;
        private const int UniqueNumberMaxValue = 99999;
        private const string NameNullExceptionMessage = "Name value cannot be null.";
        private const string NameEmptyExceptionMessage = "Name value cannot be empty";
        private readonly string uniqueNumberExceptionMessage = 
            "Unique number value must be in range " + 
            UniqueNumberMinValue + 
            " - " + 
            UniqueNumberMaxValue;

        private string name;
        private int uniqueNumber;

        public Student(int initialUniqueNumber, string initialName)
        {
            this.UniqueNumber = initialUniqueNumber;
            this.Name = initialName;
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }

            private set
            {
                if (value < UniqueNumberMinValue || value > UniqueNumberMaxValue)
                {
                    throw new ArgumentOutOfRangeException(uniqueNumberExceptionMessage);
                }

                this.uniqueNumber = value;
            }
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

        public void AttendCourse(ICourse courseToAttend)
        {
            courseToAttend.InsertStudent(this);
        }

        public void LeaveCourse(ICourse courseToAttend)
        {
            courseToAttend.RemoveStudent(this);
        }
    }
}
