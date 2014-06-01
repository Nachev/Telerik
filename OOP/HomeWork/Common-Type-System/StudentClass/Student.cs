namespace StudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Student : ICloneable, IComparable
    {
        public Student()
        {
        }

        public Student(
            string firstName, 
            string middleName, 
            string lastName, 
            int socialSN, 
            string permanentAddress, 
            string mobilePhone, 
            string eMail, 
            string course, 
            string speciality, 
            string university, 
            string faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSN = socialSN;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.EMail = eMail;
            this.Course = course;
            this.Speciality = speciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName { get; private set; }

        public string MiddleName { get; private set; }

        public string LastName { get; private set; }

        public int SocialSN { get; private set; }

        public string PermanentAddress { get; private set; }

        public string MobilePhone { get; private set; }

        public string EMail { get; private set; }

        public string Course { get; private set; }

        public string Speciality { get; private set; }

        public string University { get; private set; }

        public string Faculty { get; private set; }

        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                if (this.GetHashCode() == obj.GetHashCode())
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            int result = 17;

            // Multyply every non null property value to 23 and it to the result
            foreach (var prop in typeof(Student).GetProperties())
            {
                if (prop.GetValue(this) != null)
                {
                    result += 23 * prop.GetValue(this).GetHashCode();
                }
            }

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            // Append property names and values to result
            foreach (var prop in this.GetType().GetProperties())
            {
                result.Append(prop.Name).Append(": ").Append(prop.GetValue(this) ?? "N/A").AppendLine();
            }

            return result.ToString();
        }

        /// <summary>
        /// Deep cloning of Student type instance
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Student result = new Student();

            // Collects all values of all properties
            var queue = new Queue<object>();
            foreach (var prop in this.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(int))
                {
                    queue.Enqueue(prop.GetValue(this));
                }
                else
                {
                    queue.Enqueue((prop.GetValue(this) as string).Clone());
                }
            }

            // Save all data to the new object
            foreach (var prop in result.GetType().GetProperties())
            {
                prop.SetValue(result, queue.Dequeue());
            }

            return result;
        }

        public int CompareTo(object obj)
        {
            if (this.FirstName.CompareTo((obj as Student).FirstName) != 0)
            {
                return this.FirstName.CompareTo((obj as Student).FirstName);
            }
            else if (this.MiddleName.CompareTo((obj as Student).MiddleName) != 0)
            {
                return this.MiddleName.CompareTo((obj as Student).MiddleName);
            }
            else if (this.LastName.CompareTo((obj as Student).LastName) != 0)
            {
                return this.LastName.CompareTo((obj as Student).LastName);
            }
            else if (this.SocialSN.CompareTo((obj as Student).SocialSN) != 0)
            {
                return this.SocialSN.CompareTo((obj as Student).SocialSN);
            }

            return 0;
        }
    }
}
