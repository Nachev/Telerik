namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage.EditUserPopup
{
    using System;
    using System.Linq;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.Framework.Core.Extensions;

    public class EditUserPopup
    {
        public EditUserPopup()
        {
            this.Validator = new EditUserPopupValidator(this);
            this.Elements = new EditUserPopupElements();
        }

        public EditUserPopupElements Elements { get; private set; }

        public EditUserPopupValidator Validator { get; private set; }

        public void EnterUserDetails(UserDetails details)
        {
            this.Elements.UsernameField.EnterValueWithChangeEvent(details.Username);
            this.Elements.EmailField.EnterValueWithChangeEvent(details.Email);
            this.Elements.FirstNameField.EnterValueWithChangeEvent(details.FirstNameInBulgarian);
            this.Elements.LastNameField.EnterValueWithChangeEvent(details.LastNameInBulgarian);
            this.Elements.FirstNameEnField.EnterValueWithChangeEvent(details.FirstNameInEnglish);
            this.Elements.LastNameEnField.EnterValueWithChangeEvent(details.LastNameInEnglish);
            this.SelectByText(
                this.Elements.SelectGenderButton,
                this.Elements.GenderSelectionList,
                details.Gender);
            this.Elements.AccessCardNumberField.EnterValueWithChangeEvent(details.AccessCard);
            this.Elements.AboutField.AsTextAreaEnterValue(details.About);
            this.SelectByText(
                this.Elements.SelectOccupationButton,
                this.Elements.OccupationSelectionList,
                details.Occupation);
            this.Elements.PhoneField.EnterValueWithChangeEvent(details.MobilePhone);
            this.Elements.BirthDayField.AsKendoDatePickerSetDate(details.BirthDate);
            this.SelectByText(
                this.Elements.CitySelectButton,
                this.Elements.CitySelectionList,
                details.City);
            this.SelectByText(
                this.Elements.UniversitySelectButton,
                this.Elements.UniversitySelectionList,
                details.University);
            this.Elements.FacultyNameField.EnterValueWithChangeEvent(details.Faculty);
            this.Elements.UniversitySpecialityField.EnterValueWithChangeEvent(details.Specialty);
            this.Elements.FacultyNumberField.EnterValueWithChangeEvent(details.FacultyNumber);
            this.Elements.SchoolNameField.EnterValueWithChangeEvent(details.School);
            this.Elements.WebsiteField.EnterValueWithChangeEvent(details.WebSite);
            this.Elements.SkypeUsernameField.EnterValueWithChangeEvent(details.Skype);
            this.Elements.FacebookUrlField.EnterValueWithChangeEvent(details.Facebook);
            this.Elements.GooglePlusUrlField.EnterValueWithChangeEvent(details.GooglePlus);
            this.Elements.LinkedInUrlField.EnterValueWithChangeEvent(details.LinkedIn);
            this.Elements.TwiterUrlField.EnterValueWithChangeEvent(details.Twitter);
            ForumPointsInput(details.ForumPoints);
        }

        public void SelectByText(HtmlControl expandListButton, HtmlUnorderedList selectionList, string text)
        {
            expandListButton.Click();
            selectionList.Find
                         .ByContent<HtmlListItem>(text, ArtOfTest.WebAii.ObjectModel.FindContentType.InnerText)
                         .Click();
        }

        private void ForumPointsInput(double value)
        {
            this.Elements.ForumPointsField.AsKendoNumericBoxSetData(value);
            this.Elements.ForumPointsIncrease.MouseClick();
        }
    }
}