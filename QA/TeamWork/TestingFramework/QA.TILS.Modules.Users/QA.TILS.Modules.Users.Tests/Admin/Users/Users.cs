namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Users
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage;
    using QA.TILS.Modules.Users.Core.Pages.RegistrationPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;
    using System.Threading;

    [TestClass]
    public class Users : BaseTest
    {
        private UsersPage usersPage;
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
            this.usersPage = new UsersPage();
            this.registrationPage = new RegistrationPage();
        }

        [TestMethod]
        [Priority(1)]
        public void DeleteUserFuction_ShouldDeleteUsersSuccessfully()
        {
            var username = this.registrationPage.RegisterUniqueUser(RegistrationUsers.GetValidTemplate());
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            this.usersPage.DeleteUser(username);
            this.usersPage.Validator.UserIsDeleted(username);
        }

        [TestMethod]
        [Priority(4)]
        public void FilterUsersById_ShouldProceedCorrectly()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            var id = this.usersPage.GetFirstUserId();
            this.usersPage.FilterUsersById(id);
            this.usersPage.Validator.UsersPresentdById(id);
        }

        [TestMethod]
        [Priority(4)]
        public void FilterUsersByUsername_ShouldProceedCorrectly()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            var username = this.usersPage.GetFirstUserUsername();
            this.usersPage.FilterUsersByUsername(username);
            this.usersPage.Validator.UsersPresentByUsername(username);
        }

        [TestMethod]
        [Priority(4)]
        public void FilterUsersByEmail_ShouldProceedCorrectly()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            var email = this.usersPage.GetFirstUserEmail();
            this.usersPage.FilterUsersByEmail(email);
            this.usersPage.Validator.UsersPresentByEmail(email);
        }

        [TestMethod]
        [Priority(4)]
        public void FilterUsersByInvalidId_ShouldResultAnError()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            var id = this.usersPage.GetFirstUserId();
            this.usersPage.FilterUsersById(id + 10);
            this.usersPage.FilterPopup.Validator.FilterUsersPopupIsOpened();
        }

        [TestMethod]
        [Priority(4)]
        public void FilterPopupCancelButton_ShouldCloseThePopup()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            this.usersPage.OpenFilteringPopUp();
            this.usersPage.FilterPopup.Elements.PopupCancelButton.Click();
            this.usersPage.FilterPopup.Validator.FilterUsersPopupIsClosed();
        }

        [TestMethod]
        [Priority(4)]
        public void EditUserButton_ShouldOpenEditFormCorrectly()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            this.usersPage.OpenFirstUserEditPopUp();
            string username = this.usersPage.GetFirstUserUsername();
            this.usersPage.EditPopup.Validator.EditUserPopupIsOpened(username);
        }

        [TestMethod]
        [Priority(4)]
        public void CancelEditUserButton_ShouldCloseEditFormCorrectly()
        {
            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            this.usersPage.OpenFirstUserEditPopUp();
            string username = this.usersPage.GetFirstUserUsername();
            this.usersPage.EditPopup.Validator.EditUserPopupIsOpened(username);
            this.usersPage.EditPopup.Elements.CancelButton.Click();
            this.usersPage.EditPopup.Validator.EditUserPopupIsClosed();
        }

        [TestMethod]
        [Priority(2)]
        public void EditUserWithValidDetails_ShouldProceedCorrectly()
        {

            LoginSteps.LoginAdmin();
            this.usersPage.NavigateTo();
            this.usersPage.EditFirstUser(TestUsersDetails.GetValidDetails());
        }
    }
}
