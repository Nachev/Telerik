namespace Telerik.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class InvalidProfileSymbols
    {
        public const string Nick = "<>";
        public const string FirstName = "###__##";
        public const string LastName = "###__##";
        public const string CompanyName = "";
        public const string JobTitle = "<>";
        public const string Phone = "<>";
        public const string CompanyUrl = "###__##";
        public const string Interests = "<>";
        public const string BlogOrWebPage = "<##_##>";

        public const string NickErrorMessage = "Your Nick has special characters. Please remove them and try again.";
        public const string FirstNameErrorMessage = "Your First name has special characters. Please remove them and try again.";
        public const string LastNameErrorMessage = "Your Last Name has special characters. Please remove them and try again.";
        public const string CompanyNameErrorMessage = "Company name cannot be empty";
        public const string JobTitleErrorMessage = "Your Job title has special characters. Please remove them and try again.";
        public const string PhoneErrorMessage = "Your Phone number has special characters. Please remove them and try again.";
        public const string CompanyUrlErrorMessage = "Invalid URL. Please, start with 'http://' and use letters and numbers without empty spaces.";
        public const string InterestsErrorMessage = "Your Field has special characters. Please remove them and try again.";
        public const string BlogOrWebPageErrorMessage = "Invalid URL. Please, start with 'http://' and use letters and numbers without empty spaces.";
    }
}