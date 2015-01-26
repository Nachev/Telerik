namespace QA.TILS.Modules.Users.Core.Pages.RegistrationPage
{
    public static class ErrorMessages
    {
        public const string UserNameMissing = "Потребителското име е задължително";
        public const string UserNameInvalidSymbol = "Потребителското име може да съдържа само малки и главни латински букви, цифри и знаците точка и долна черта. Потребителското име трябва да започва с буква и да завършва с буква или цифра.";
        public const string UserNameInvalidLength = "Потребителското име трябва да е между 5 и 32 символа";
        public const string PasswordMissing = "Паролата е задължителна";
        public const string PasswordShort = "Паролата трябва да е повече от 6 символа";
        public const string PasswordAgainMissing = "Паролата отново е задължителна";
        public const string PasswordAgainShort = "Паролата отново трябва да е повече от 6 символа";
        public const string PasswordAgainMismatch = "Паролите не съвпадат";
        public const string FirstNameMissing = "Името на български е задължително";
        public const string FirstNameInvalidLength = "Името трябва да е не по-дълго от 30 и не по-късо от 2 символа.";
        public const string FirstNameInvalidSymbol = "Името може да съдържа само букви от българската азбука и знака тире. Името трябва да започва и да завършва с буква.";
        public const string LastNameMissing = "Фамилията на български е задължителна";
        public const string LastNameInvalidSymbol = "Фамилията може да съдържа само букви от българската азбука и знака тире. Фамилията трябва да започва и да завършва с буква.";
        public const string LastNameInvalidLength = "Фамилията трябва да е не по-дълга от 30 и не по-къса от 2 символа.";
        public const string EmailMissing = "Имейлът е задължителен";
        public const string EmailInvalidSymbol = "Моля въведете валиден имейл адрес.";
        public const string EmailInvalidLength = "Имейлът трябва да е не по-дълъг от 50 символа";
        public const string TermsAndConditionsNotAccepted = "За да се регистрирате трябва да приемете условията и правилата на академията на Телерик";
    }
}