namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;

    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class LoggedUsersUpperNavigationElements : BaseElementsMap
    {
        public HtmlSpan LoggedUserUsernameSpan
        {
            get
            {
                return this.Find.ByAttributes<HtmlSpan>("username".ToClassIsExpression());
            }
        }

        public HtmlAnchor ProfileLink
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("UserProfile");
            }
        }

        public HtmlAnchor SettingsButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("SettingMI");
            }
        }

        public HtmlAnchor LogoutButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("ExitMI");
            }
        }

        public HtmlAnchor FriendsButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("FriendsMI");
            }
        }

        public HtmlAnchor MessagesButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("MessagesMI");
            }
        }

        public HtmlInputText SearchField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("SearchTerm");
            }
        }
    }
}
