namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage.FilterUsersPopup
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class FilterUsersPopupElements : BaseElementsMap
    {
        public HtmlSpan TitleArea
        {
            get
            {
                return this.Find.ById<HtmlSpan>("UsersDataPopup_wnd_title");
            }
        }

        public HtmlDiv FilterBodyArea
        {
            get
            {
                return this.Find.ById<HtmlDiv>("UsersDataPopup");
            }
        }

        public HtmlSpan FilterCriteriaSelectedArea
        {
            get
            {
                return this.FilterBodyArea.Find.ByAttributes<HtmlSpan>("aria-activedescendant=dropdown-search-options_option_selected");
            }
        }

        public HtmlSpan SelectCategoryDropDownExpandButton
        {
            get
            {
                return this.FilterBodyArea.Find.ByAttributes<HtmlSpan>("k-select".ToClassIsExpression());
            }
        }

        public HtmlUnorderedList SelectCategoryListContainer
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("dropdown-search-options_listbox");
            }
        }

        public HtmlListItem CategoryByIdSelect
        {
            get
            {
                return this.SelectCategoryListContainer.Find.ByXPath<HtmlListItem>("//li[2]");
            }
        }

        public HtmlListItem CategoryByNameSelect
        {
            get
            {
                return this.SelectCategoryListContainer.Find.ByXPath<HtmlListItem>("//li[3]");
            }
        }

        public HtmlListItem CategoryByEmailSelect
        {
            get
            {
                return this.SelectCategoryListContainer.Find.ByXPath<HtmlListItem>("//li[4]");
            }
        }

        public HtmlDiv SelectCategoryRemainderMessageArea
        {
            get
            {
                return this.FilterBodyArea.Find.ById<HtmlDiv>("criteria-dropdown-validation");
            }
        }

        public HtmlTextArea CriteriaValueTextArea
        {
            get
            {
                return this.FilterBodyArea.Find.ById<HtmlTextArea>("tb-search-values");
            }
        }

        public HtmlAnchor PopupSubmitButton
        {
            get
            {
                return this.FilterBodyArea.Find.ById<HtmlAnchor>("UsersDataPopupOk");
            }
        }

        public HtmlAnchor PopupCancelButton
        {
            get
            {
                return this.FilterBodyArea.Find.ById<HtmlAnchor>("UsersDataPopupCancel");
            }
        }
    }
}