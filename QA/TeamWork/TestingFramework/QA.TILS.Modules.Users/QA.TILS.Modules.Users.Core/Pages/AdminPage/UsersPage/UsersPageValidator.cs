namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Data.Templates;
    using QA.Framework.Core.Extensions;

    public class UsersPageValidator
    {
        public UsersPageValidator(UsersPage usersPage)
        {
            this.UsersPage = usersPage;
        }

        public UsersPage UsersPage { get; private set; }

        public void UserIsDeleted(string username)
        {
            this.UsersPage.Elements.RefreshButton.Click();
            this.UsersPage
                .Elements
                .Grid
                .Find
                .ByExpression<HtmlAnchor>("TagName=a", string.Concat("data-username=", username))
                .AssertIsNotPresent();
        }

        public void OnlyOneRowInTheGrid()
        {
            var dataRows = this.UsersPage
                .Elements
                .GridRows;
            dataRows.AssertCountIs(1);
        }

        public void UsersPresentdById(string id)
        {
            this.OnlyOneRowInTheGrid();
            this.UsersPage.GetFirstUserGridElements().MasterId.AssertTextEquals(id);
        }

        public void UsersPresentByUsername(string username)
        {
            this.OnlyOneRowInTheGrid();
            this.UsersPage.GetFirstUserGridElements().MasterUsername.AssertTextEquals(username);
        }

        public void UsersPresentByEmail(string email)
        {
            this.OnlyOneRowInTheGrid();
            this.UsersPage.GetFirstUserGridElements().MasterEmail.AssertTextEquals(email);
        }

        public void UserHasDetails(UserGridElements elements, UserDetails details)
        {
            elements.MasterToggleDetailsButton.Click();
            Manager.Current.ActiveBrowser.WaitForElement(2500, "CandidateInformation".ToClassIsExpression());
            elements.DetailsUsername.AssertTextEquals(details.Username);
            elements.DetailsName.AssertTextIsContained(details.FirstNameInBulgarian);
            elements.DetailsName.AssertTextIsContained(details.LastNameInBulgarian);
            elements.DetailsBirthDate.AssertTextEquals(details.BirthDate.ToString("dd-MM-yyyy"));
            elements.DetailsGender.AssertTextEquals(details.GenderAssert);
            elements.DetailsOccupation.AssertTextEquals(details.Occupation);
            elements.DetailsCity.AssertTextEquals(details.City);
            elements.DetailsPhone.AssertTextEquals(details.MobilePhone);
            elements.DetailsEmail.AssertTextEquals(details.Email);
            elements.DetailsSkypeName.AssertTextEquals(details.Skype);
            elements.DetailsForumPoints.AssertTextEquals(details.ForumPoints.ToString("F0"));
            elements.DetailsUniversity.AssertTextEquals(details.University);
            elements.DetailsFaculty.AssertTextEquals(details.Faculty);
            elements.DetailsFacultyNumber.AssertTextEquals(details.FacultyNumber);
            elements.DetailsSpecialty.AssertTextEquals(details.Specialty);
            elements.DetailsSchool.AssertTextEquals(details.School);
            elements.DetailsWebsite.AssertTextEquals(details.WebSite);
            elements.DetailsGooglePlus.AssertTextEquals(details.GooglePlus);
            elements.DetailsLinkedIn.AssertTextEquals(details.LinkedIn);
            elements.DetailsTwitter.AssertTextEquals(details.Twitter);
            elements.DetailsFacebook.AssertTextEquals(details.Facebook);
        }
    }
}