namespace QA.TILS.Modules.Users.Core.Pages.RegistrationPage
{
    using QA.Framework.Core.Extensions;

    public class RegistrationPageValidator
    {
        public RegistrationPageValidator(RegistrationPage initialRegistrationPage)
        {
            this.RegistrationPage = initialRegistrationPage;
        }

        public RegistrationPage RegistrationPage { get; private set; }

        public void UsernameErrorMessage(string errorMessage)
        {
            this.RegistrationPage.Elements.UsernameErrorMessage.AssertTextEquals(errorMessage);
        }

        public void PasswordErrorMessage(string errorMessage)
        {
            this.RegistrationPage.Elements.PasswordErrorMessage.AssertTextEquals(errorMessage);
        }

        public void PasswordAgainErrorMessage(string errorMessage)
        {
            this.RegistrationPage.Elements.PasswordAgainErrorMessage.AssertTextEquals(errorMessage);
        }

        public void FirstNameErrorMessage(string errorMessage)
        {
            this.RegistrationPage.Elements.FirstNameErrorMessage.AssertTextEquals(errorMessage);
        }

        public void LastNameErrorMessage(string errorMessage)
        {
            this.RegistrationPage.Elements.LastNameErrorMessage.AssertTextEquals(errorMessage);
        }

        public void EmailErrorMessage(string errorMessage)
        {
            this.RegistrationPage.Elements.EmailErrorMessage.AssertTextEquals(errorMessage);
        }

        public void ImmediateValidationErrorMessages(string forUserName, string forPassword, string forPasswordAgain, string forFirstName, string forLastName, string forEmail)
        {
            this.UsernameErrorMessage(forUserName);
            this.PasswordErrorMessage(forPassword);
            this.PasswordAgainErrorMessage(forPasswordAgain);
            this.FirstNameErrorMessage(forFirstName);
            this.LastNameErrorMessage(forLastName);
            this.EmailErrorMessage(forEmail);
        }

        public void SummaryValidationErrorMessages(params string[] errorMessages)
        {
            this.RegistrationPage.Elements.SummaryValidationErrors.Wait.ForExists();
            for (int index = 0; index < errorMessages.Length; index++)
            {
                this.RegistrationPage.Elements.SummaryValidationErrors.AssertTextIsContained(errorMessages[index]);
            }
        }

        public void EmptyFieldsImmediateErrorMessages()
        {
            this.ImmediateValidationErrorMessages(
                ErrorMessages.UserNameMissing,
                ErrorMessages.PasswordMissing,
                ErrorMessages.PasswordAgainMissing,
                ErrorMessages.FirstNameMissing,
                ErrorMessages.LastNameMissing,
                ErrorMessages.EmailMissing);
        }

        public void EmptyFieldsSummaryErrorMessages()
        {
            this.SummaryValidationErrorMessages(
                ErrorMessages.UserNameMissing,
                ErrorMessages.PasswordMissing,
                ErrorMessages.PasswordAgainMissing,
                ErrorMessages.FirstNameMissing,
                ErrorMessages.LastNameMissing,
                ErrorMessages.EmailMissing);
        }

        public void SuccessfulRegistration(string expectedUsername)
        {
            this.RegistrationPage.UpperNavigation.LoggedUserUsernameSpan.Wait.ForExists();
            this.RegistrationPage.UpperNavigation.LoggedUserUsernameSpan.AssertTextEquals(expectedUsername);
        }

        public void MainAreaContains(string expectedTextContent)
        {
            this.RegistrationPage.Elements.MainArea.AssertTextIsContained(expectedTextContent);
        }

        public void RegistrationPageOpened()
        {
            this.MainAreaContains("Регистрация");
        }
    }
}
