namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage.FilterUsersPopup
{
    using QA.Framework.Core.Extensions;

    public class FilterUsersPopupValidators
    {
        private readonly FilterUsersPopup filterUsersPopup;

        public FilterUsersPopupValidators(FilterUsersPopup filterUsersPopUp)
        {
            this.filterUsersPopup = filterUsersPopUp;

        }

        public void FilterUsersPopupIsOpened()
        {
            this.filterUsersPopup.Elements.TitleArea.AssertTextIsContained("Филтриране на потребители по критерий");
        }

        public void FilterUsersPopupIsClosed()
        {
            this.filterUsersPopup.Elements.TitleArea.AssertIsNotVisible();
        }

        public void CorrectCriteriaIsSelected(string criteria)
        {
            this.filterUsersPopup.Elements.FilterCriteriaSelectedArea.AssertTextIsContained(criteria);
        }

        public void RemainderMessageAppeared()
        {
            this.filterUsersPopup.Elements.SelectCategoryRemainderMessageArea.AssertIsPresent();
        }
    }
}
