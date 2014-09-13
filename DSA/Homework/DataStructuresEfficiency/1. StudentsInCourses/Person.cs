namespace _1.StudentsInCourses
{
    using System;

    public class Person : IComparable
    {
        private string firstName;
        private string lastName;

        public Person(string fname, string lname)
        {
            this.firstName = fname;
            this.lastName = lname;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("firstName", "First name cannot be null or whitespace!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("lastName", "Last name cannot be null or whitespace!");
                }

                this.lastName = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Person otherPerson = obj as Person;
            if (otherPerson != null)
            {
                if (this.LastName.CompareTo(otherPerson.LastName) == 0)
                {
                    return this.FirstName.CompareTo(otherPerson.FirstName);
                }
                else
                {
                    return this.LastName.CompareTo(otherPerson.LastName);
                }
            }
            else
            {
                throw new ArgumentException("Object is not a Temperature");
            }
        }

        public override string ToString()
        {
            return this.firstName + " " + this.lastName;
        }
    }
}
