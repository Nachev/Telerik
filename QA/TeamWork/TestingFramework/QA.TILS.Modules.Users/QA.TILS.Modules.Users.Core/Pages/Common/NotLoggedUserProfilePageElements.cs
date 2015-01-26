namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class NotLoggedUserProfilePageElements : BaseElementsMap
    {
        public HtmlAnchor SendMessageButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("generalButtonStyles smallButton greenButton buttonSendMessageToUser".ToClassIsExpression());
            }
        }

        public HtmlAnchor UnfriendButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("UnfriendButton");
            }
        }

        public HtmlAnchor AddAsFriendButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("AddFriendButton");
            }
        }
    }
}
