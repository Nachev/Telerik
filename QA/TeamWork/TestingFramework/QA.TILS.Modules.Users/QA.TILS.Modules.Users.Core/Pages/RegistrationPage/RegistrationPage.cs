namespace QA.TILS.Modules.Users.Core.Pages.RegistrationPage
{
    using System;

    using ArtOfTest.WebAii.Core;

    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.Pages.Common;

    public class RegistrationPage : BasePage
    {
        public RegistrationPage()
        {
            this.Validator = new RegistrationPageValidator(this);
            this.Elements = new RegistrationPageElements();
            this.UpperNavigation = new LoggedUsersUpperNavigationElements();
            this.Url = "/Users/Auth/Registration";
        }

        public RegistrationPageValidator Validator { get; private set; }

        public RegistrationPageElements Elements { get; private set; }

        public LoggedUsersUpperNavigationElements UpperNavigation { get; private set; }

        public void EnterUserCredentials(string username, string password, string passwordAgain, string firstNameBg, string lastNameBg, string email)
        {
            this.NavigateTo();

            this.Elements.UsernameField.Text = username;
            this.Elements.PasswordField.Text = password;
            this.Elements.PasswordAgainField.Text = passwordAgain;
            this.Elements.FirstNameInBulgarianField.Text = firstNameBg;
            this.Elements.LastNameInBulgarianField.Text = lastNameBg;
            this.Elements.EmailField.Text = email;
        }

        public void EnterUserCredentials(User user)
        {
            this.EnterUserCredentials(
                user.Username,
                user.Password,
                user.PasswordRepeat,
                user.FirstNameInBulgarian,
                user.LastNameInBulgarian,
                user.Email);
        }

        public void RegisterUser(string username, string password, string passwordAgain, string firstNameBg, string lastNameBg, string email)
        {
            this.EnterUserCredentials(username, password, passwordAgain, firstNameBg, lastNameBg, email);
            this.Elements.TermsAndConditionsCheckBox.Click();
            this.Elements.SubmitButton.Click();
        }

        public void RegisterUser(User user)
        {
            this.RegisterUser(user.Username, user.Password, user.PasswordRepeat, user.FirstNameInBulgarian, user.LastNameInBulgarian, user.Email);
        }

        public string RegisterUniqueUser(User user)
        {
            var dateTime = DateTime.Now;
            string uniqueAddition = dateTime.ToString("hhmmddMMyyyy");
            this.RegisterUser(user.Username + uniqueAddition, user.Password, user.PasswordRepeat, user.FirstNameInBulgarian, user.LastNameInBulgarian, uniqueAddition + user.Email);
            return user.Username + uniqueAddition;
        }

        public void NavigateToRegistrationPageManualy()
        {
            string baseUrl = "http://test.telerikacademy.com";
            QA.Framework.Core.Helpers.NavigateTo.Url(baseUrl);
            var notLoggedNavigationPanel = new NotLoggedUpperNavigationElements();
            notLoggedNavigationPanel.SignUpButton.Click();
            Manager.Current.ActiveBrowser.WaitForUrl(baseUrl + this.Url, false, 3000);
        }
    }
}
