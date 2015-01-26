namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage.FilterUsersPopup
{
    using QA.Framework.Core.Base;

    public class FilterUsersPopup : BasePage
    {
        public FilterUsersPopup()
        {
            this.Elements = new FilterUsersPopupElements();
            this.Validator = new FilterUsersPopupValidators(this);
            
        }

        public FilterUsersPopupElements Elements { get; private set; }

        public FilterUsersPopupValidators Validator { get; private set; }

        public void FilterUsersByUsername(string username)
        {
            string criteria = "име";
            this.Elements.SelectCategoryDropDownExpandButton.Click();
            this.Elements.CategoryByNameSelect.Wait.ForVisible();
            this.Elements.CategoryByNameSelect.Click();
            this.Validator.CorrectCriteriaIsSelected(criteria);
            this.Elements.CriteriaValueTextArea.Text = username;
            this.Elements.PopupSubmitButton.Click();
        }

        public void FilterUsersById(string id)
        {
            string criteria = "ID";
            this.Elements.SelectCategoryDropDownExpandButton.Click();
            this.Elements.CategoryByIdSelect.Wait.ForVisible();
            this.Elements.CategoryByIdSelect.Click();
            this.Validator.CorrectCriteriaIsSelected(criteria);
            this.Elements.CriteriaValueTextArea.Text = id;
            this.Elements.PopupSubmitButton.Click();
        }

        public void FilterUsersByEmail(string email)
        {
            string criteria = "имейл";
            this.Elements.SelectCategoryDropDownExpandButton.Click();
            this.Elements.CategoryByEmailSelect.Wait.ForVisible();
            this.Elements.CategoryByEmailSelect.Click();
            this.Validator.CorrectCriteriaIsSelected(criteria);
            this.Elements.CriteriaValueTextArea.Text = email;
            this.Elements.PopupSubmitButton.Click();
        }
    }
}
