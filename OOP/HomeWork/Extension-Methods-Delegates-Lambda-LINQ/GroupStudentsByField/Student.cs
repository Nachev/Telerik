namespace GroupStudentsByField
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student
    {
        private string email;
        private string phoneNumber;

        public Student(string firstName, string familyName, long fn, string phoneNumber, string email, int groupNumber, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = familyName;
            this.FacultyNumber = fn;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public long FacultyNumber { get; private set; }

        public int GroupNumber { get; set; }

        public string GroupName { get; set; }

        public string PhoneNumber 
        {
            get
            {
                return this.phoneNumber;
            }
            
            private set
            {
                if (IsCorrectPhoneNumber(value))
                {
                    this.phoneNumber = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (IsCorrectMailAddress(value))
                {
                    this.email = value;
                }
                else
                {
                    throw new ArgumentException("Wrong value for email!");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Names: {0} ", this.FirstName);
            result.AppendFormat("{0} | ", this.LastName);
            result.AppendFormat("F.N: {0} | ", this.FacultyNumber);
            result.AppendFormat("Tel: {0} | ", this.PhoneNumber);
            result.AppendFormat("e-mail: {0} | ", this.Email);
            result.AppendFormat("Gr.N: {0}", this.GroupNumber);
            return result.ToString();
        }

        private static bool IsCorrectMailAddress(string inputMailAdd)
        {
            string regex = @"(\[([0-9]{1,3}\.){3}[0-9]{1,3}\.?\]([\.][a-zA-Z0-9]*)|[a-zA-Z0-9]+?[_\.|\-]?[a-zA-Z0-9]+)@(\[([0-9]{1,3}\.){3}[0-9]{1,3}\.?\]([\.][a-zA-Z0-9]*)*|[a-zA-Z0-9]+?[\-]?[a-zA-Z0-9]+([\.][a-zA-Z0-9]*)*)(\.[a-zA-z]+)";
            return Regex.IsMatch(inputMailAdd, regex);
        }

        private static bool IsCorrectPhoneNumber(string inputPhoneNumber)
        {
            string regex = @"\+?(\d{5,16}|(\d+\s+)|(\d+\-?)+)\d+";
            return Regex.IsMatch(inputPhoneNumber, regex);
        }
    }
}
