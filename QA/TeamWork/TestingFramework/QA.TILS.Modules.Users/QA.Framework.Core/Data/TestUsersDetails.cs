namespace QA.Framework.Core.Data
{
    using System;
    using Templates;
    using QA.Framework.Core.Helpers;

    public class TestUsersDetails
    {
        private const int ValidUsernameLength = 8;
        private const int EmailLength = 8;
        private const string EmailDomain = "@mail.com";
        private const string ValidFirstNameInBulgarian = "Редактиран";
        private const string ValidLastNameInBulgarian = "Редактиран";
        private const string ValidFirstNameInEnglish = "FirstName";
        private const string ValidLastNameInEnglish = "LastName";
        private const string ValidGender = "True";
        private const string ValidAccessCard = "00123456ABCDEF";
        private const string ValidAbout = "Information for user";
        private const string ValidOccupation = "Друго";
        private const string ValidMobilePhone = "0888123456";
        private static readonly DateTime validBirthDate = new DateTime(1999, 05, 06);
        private const string ValidCity = "Друг";
        private const string ValidUniversity = "Не уча (и не съм учил/а) в университет";
        private const string ValidFaculty = "Факултет";
        private const string ValidSpecialty = "Специалност";
        private const string ValidFacultyNumber = "123-ФН";
        private const string ValidSchool = "Училище";
        private const string ValidWebSite = "www.web-site.com";
        private const string ValidSkype = "skype_name";
        private const string ValidFacebook = "www.facebook.com/username";
        private const string ValidGooglePlus = "www.plus.google.com/username";
        private const string ValidLinkedIn = "www.linkedin.com/username";
        private const string ValidTwitter = "www.twitter.com/username";
        private const double ValidForumPoints = 3.00D;

        public static UserDetails GetValidDetails()
        {
            string genderAssert = ValidGender == "True" ? "Мъж" : (ValidGender == "False" ? "Жена" : "null");
            return new UserDetails
            {
                Username = RandomDataGenerator.GenerateUniqueRandomUsername(ValidUsernameLength),
                Email = RandomDataGenerator.GenerateUniqueRandomUsername(EmailLength) + EmailDomain,
                FirstNameInBulgarian = ValidFirstNameInBulgarian,
                LastNameInBulgarian = ValidLastNameInBulgarian,
                FirstNameInEnglish = ValidFirstNameInEnglish,
                LastNameInEnglish = ValidLastNameInEnglish,
                Gender = ValidGender,
                GenderAssert = genderAssert,
                AccessCard = ValidAccessCard,
                About = ValidAbout,
                Occupation = ValidOccupation,
                MobilePhone = ValidMobilePhone,
                BirthDate = validBirthDate,
                City = ValidCity,
                University = ValidUniversity,
                Faculty = ValidFaculty,
                Specialty = ValidSpecialty,
                FacultyNumber = ValidFacultyNumber,
                School = ValidSchool,
                WebSite = ValidWebSite,
                Skype = ValidSkype,
                Facebook = ValidFacebook,
                GooglePlus = ValidGooglePlus,
                LinkedIn = ValidLinkedIn,
                Twitter = ValidTwitter,
                ForumPoints = ValidForumPoints
            };
        }
    }
}