namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage.EditUserPopup
{
    using QA.Framework.Core.Extensions;

    public class EditUserPopupValidator
    {
        private readonly EditUserPopup editUserPopup;

        public EditUserPopupValidator(EditUserPopup editUserPopup)
        {
            this.editUserPopup = editUserPopup;
        }

        public void EditUserPopupIsClosed()
        {
            this.editUserPopup.Elements.PopupTitle.AssertIsNotPresent();
        }

        public void EditUserPopupIsOpened(string username)
        {
            this.editUserPopup.Elements.UsernameField.AssertValueEquals(username);
            this.editUserPopup.Elements.PopupTitle.AssertTextEquals("Edit");
        }
    }
}
