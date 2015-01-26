namespace QA.Framework.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using QA.Framework.Core.Data.Templates;

    public class RegistrationUsers
    {
        private const string ValidUsername = "TestCloud";
        private const string ValidPassword = "123456";
        private const string ValidPasswordRepeat = "123456";
        private const string ValidFirstNameInBg = "Тестово-Име";
        private const string ValidLastNameInBg = "Тестова-Фамилия";
        private const string ValidEmail = "CB@test.com";

        public static User GetValidTemplate()
        {
            return new User 
            {
                Username = ValidUsername,
                Password = ValidPassword,
                PasswordRepeat = ValidPasswordRepeat,
                FirstNameInBulgarian = ValidFirstNameInBg,
                LastNameInBulgarian = ValidLastNameInBg,
                Email = ValidEmail
            };
        }
        
        public static User GetEmptyUsername()
        {
            var result = GetValidTemplate();
            result.Username = string.Empty;
            return result;
        }

        public static User GetEmptyPassword()
        {
            var result = GetValidTemplate();
            result.Password = string.Empty;
            return result;
        }

        public static User GetEmptyPasswordRepeat()
        {
            var result = GetValidTemplate();
            result.PasswordRepeat = string.Empty;
            return result;
        }

        public static User GetEmptyFirstNameInBg()
        {
            var result = GetValidTemplate();
            result.FirstNameInBulgarian = string.Empty;
            return result;
        }

        public static User GetEmptyLastNameInBg()
        {
            var result = GetValidTemplate();
            result.LastNameInBulgarian = string.Empty;
            return result;
        }

        public static User GetEmptyEmail()
        {
            var result = GetValidTemplate();
            result.Email = string.Empty;
            return result;
        }
    }
}