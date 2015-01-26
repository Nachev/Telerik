namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.Framework.Core.Extensions;

    public class UsersPage : BasePage
    {
        public UsersPage()
        {
            this.Validator = new UsersPageValidator(this);
            this.Elements = new UsersPageElements();
            this.FilterPopup = new FilterUsersPopup.FilterUsersPopup();
            this.EditPopup = new EditUserPopup.EditUserPopup();
            this.Url = "/Administration_Users/Users";
        }

        public UsersPageValidator Validator { get; private set; }

        public UsersPageElements Elements { get; private set; }

        public EditUserPopup.EditUserPopup EditPopup { get; private set; }

        public FilterUsersPopup.FilterUsersPopup FilterPopup { get; private set; }

        public void OpenFilteringPopUp()
        {
            this.Elements.FilterUsersButton.Click();
        }

        public void OpenEditPopUp(string username)
        {
            this.WaitForGridToLoad();
            var userRow = new UserGridElements(username);
            userRow.MasterEditUser.Click();
        }

        public void OpenFirstUserEditPopUp()
        {
            this.WaitForGridToLoad();
            UserGridElements userRow = this.GetFirstUserGridElements();
            userRow.MasterEditUser.Click();
        }

        public void WaitForGridToLoad()
        {
            int timeout = 15000;
            Manager.Current.ActiveBrowser.WaitForElement(timeout, "tr".ToTagNameIsExpression(), "row".ToRoleIsExpression());
            Manager.Current.ActiveBrowser.WaitForElement(timeout, "k-button k-button-icontext k-grid-edit".ToClassIsExpression());
        }

        public void DeleteUser(string username)
        {
            Manager.Current.DialogMonitor.AddDialog(new AlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK));
            Manager.Current.DialogMonitor.Start();
            this.WaitForGridToLoad();
            var userRow = new UserGridElements(username);
            userRow.MasterDeleteUser.Click();
        }

        public UserGridElements GetFirstUserGridElements()
        {
            this.WaitForGridToLoad();
            var userRow = new UserGridElements(this.Elements.GetGridRowByRowIndex(1));
            return userRow;
        }

        public string GetFirstUserId()
        {
            UserGridElements userRow = this.GetFirstUserGridElements();
            string id = userRow.MasterId.InnerText;
            return id;
        }

        public string GetFirstUserUsername()
        {
            UserGridElements userRow = this.GetFirstUserGridElements();
            string username = userRow.MasterUsername.InnerText;
            return username;
        }

        public string GetFirstUserEmail()
        {
            UserGridElements userRow = this.GetFirstUserGridElements();
            string email = userRow.MasterEmail.InnerText;
            return email;
        }

        public void FilterUsersById(string id)
        {
            this.Elements.FilterUsersButton.Click();
            this.FilterPopup.FilterUsersById(id);
            this.FilterPopup.Elements.FilterBodyArea.Wait.ForVisibleNot();
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }

        public void FilterUsersByUsername(string username)
        {
            this.Elements.FilterUsersButton.Click();
            this.FilterPopup.FilterUsersByUsername(username);
            this.FilterPopup.Elements.FilterBodyArea.Wait.ForVisibleNot();
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }

        public void FilterUsersByEmail(string email)
        {
            this.Elements.FilterUsersButton.Click();
            this.FilterPopup.FilterUsersByEmail(email);
            this.FilterPopup.Elements.FilterBodyArea.Wait.ForVisibleNot();
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }

        public void EditFirstUser(UserDetails userDetails)
        {
            this.OpenFirstUserEditPopUp();
            string username = this.GetFirstUserUsername();
            this.EditPopup.Validator.EditUserPopupIsOpened(username);
            this.EditPopup.EnterUserDetails(userDetails);
            this.EditPopup.Elements.UpdateButton.Click();
            UserGridElements userGridElements = this.GetFirstUserGridElements();
            userDetails.ForumPoints += 1;
            this.Validator.UserHasDetails(userGridElements, userDetails);
        }
    }
}