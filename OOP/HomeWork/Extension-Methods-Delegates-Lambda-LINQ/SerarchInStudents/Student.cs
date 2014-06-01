namespace SerarchInStudents
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student(string firstName, string familyName, int age = 0)
        {
            this.FirstName = firstName;
            this.FamilyName = familyName;
            this.Age = age;
        }

        public string FirstName { get; set; }

        public string FamilyName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.FamilyName;
        }
    }
}
