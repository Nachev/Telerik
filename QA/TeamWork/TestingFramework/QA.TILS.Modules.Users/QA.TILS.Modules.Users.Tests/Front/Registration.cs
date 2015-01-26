namespace QA.TILS.Modules.Users.Tests.Functional.Front
{

    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.TILS.Modules.Users.Core.Pages.RegistrationPage;

    /// <summary>
    /// Registration page tests
    /// </summary>
    [TestClass]
    public class Registration : BaseTest
    {
        private RegistrationPage registrationPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BaseClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseClassCleanup();
        }

        public override void TestInitialize()
        {
            this.registrationPage = new RegistrationPage();
        }

        [TestMethod]
        [Priority(1)]
        public void RegistrationLink_ShouldNavigateCorrectly()
        {
            this.registrationPage.NavigateToRegistrationPageManualy();
            this.registrationPage.Validator.RegistrationPageOpened();
        }

        [TestMethod]
        [Priority(1)]
        public void RegisterValidUser_ShouldProceedWithoutErrors()
        {
            var username = this.registrationPage.RegisterUniqueUser(RegistrationUsers.GetValidTemplate());
            this.registrationPage.Validator.SuccessfulRegistration(username);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithEmptyUsernameField_ShouldResultAnErrorMessages()
        {
            this.registrationPage.RegisterUser(RegistrationUsers.GetEmptyUsername());
            this.registrationPage.Validator.UsernameErrorMessage(ErrorMessages.UserNameMissing);
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.UserNameMissing);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithEmptyPasswordField_ShouldResultAnErrorMessages()
        {
            this.registrationPage.RegisterUser(RegistrationUsers.GetEmptyPassword());
            this.registrationPage.Validator.PasswordErrorMessage(ErrorMessages.PasswordMissing);
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.PasswordMissing);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithEmptyPasswordAgainField_ShouldResultAnErrorMessages()
        {
            this.registrationPage.RegisterUser(RegistrationUsers.GetEmptyPasswordRepeat());
            this.registrationPage.Validator.PasswordAgainErrorMessage(ErrorMessages.PasswordAgainMissing);
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.PasswordAgainMissing);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithEmptyFirstNameField_ShouldResultAnErrorMessages()
        {
            this.registrationPage.RegisterUser(RegistrationUsers.GetEmptyFirstNameInBg());
            this.registrationPage.Validator.FirstNameErrorMessage(ErrorMessages.FirstNameMissing);
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.FirstNameMissing);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithEmptyLastNameField_ShouldResultAnErrorMessages()
        {
            this.registrationPage.RegisterUser(RegistrationUsers.GetEmptyLastNameInBg());
            Thread.Sleep(5000);
            this.registrationPage.Validator.LastNameErrorMessage(ErrorMessages.LastNameMissing);
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.LastNameMissing);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithEmptyEmailField_ShouldResultAnErrorMessages()
        {
            this.registrationPage.RegisterUser(RegistrationUsers.GetEmptyEmail());
            this.registrationPage.Validator.EmailErrorMessage(ErrorMessages.EmailMissing);
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.EmailMissing);
        }

        [TestMethod]
        [Priority(2)]
        public void RegisterUserWithoutAcceptingTerms_ShouldResultAnErrorMessages()
        {
            this.registrationPage.EnterUserCredentials(RegistrationUsers.GetValidTemplate());
            this.registrationPage.Elements.SubmitButton.Click();
            this.registrationPage.Validator.SummaryValidationErrorMessages(ErrorMessages.TermsAndConditionsNotAccepted);
        }
    }
}
