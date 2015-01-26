namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage.EditUserPopup
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Telerik.WebAii.Controls.Html;

    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;
    using Telerik.TestingFramework.Controls.KendoUI;
    using ArtOfTest.WebAii.ObjectModel;

    public class EditUserPopupElements : BaseElementsMap
    {
        public HtmlSpan PopupTitle
        { 
            get 
            {
                return this.Find.ByAttributes<HtmlSpan>("k-window-title".ToClassIsExpression());
            }
        }

        public HtmlInputText AcademyNumberField
        { 
            get 
            {
                return this.Find.ById<HtmlInputText>("AcademyNumber");
            }
        }

        public HtmlInputText UsernameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Username");
            }
        }

        public KendoInput UsernameKendoInput
        {
            get
            {
                return this.Find.ById<KendoInput>("Username");
            }
        }

        public HtmlDiv UsernameValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("Username_validationMessage");
            }
        }

        public HtmlInputText EmailField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Email");
            }
        }

        public HtmlDiv EmailValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("Email_validationMessage");
            }
        }

        public HtmlInputText FirstNameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("FirstName");
            }
        }

        public HtmlDiv FirstNameValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("FirstName_validationMessage");
            }
        }

        public HtmlInputText LastNameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("LastName");
            }
        }

        public HtmlDiv LastNameValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("LastName_validationMessage");
            }
        }

        public HtmlInputText FirstNameEnField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("FirstNameEn");
            }
        }

        public HtmlDiv FirstNameEnValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("FirstNameEn_validationMessage");
            }
        }

        public HtmlInputText LastNameEnField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("LastNameEn");
            }
        }

        public HtmlDiv LastNameEnValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("LastNameEn_validationMessage");
            }
        }

        public HtmlSpan SelectGenderButton
        {
            get
            {
                return this.Find
                           .ByAttributes<HtmlSpan>("aria-owns=Gender_listbox")
                           .Find
                           .ByAttributes<HtmlSpan>("k-select".ToClassIsExpression());
            }
        }

        public HtmlUnorderedList GenderSelectionList
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("Gender_listbox");
            }
        }

        public HtmlListItem MaleSelection
        {
            get
            {
                return this.GenderSelectionList
                           .Find
                           .ByContent<HtmlListItem>("True", ArtOfTest.WebAii.ObjectModel.FindContentType.InnerText);
            }
        }

        public HtmlInputText AccessCardNumberField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("AccessCardNumber");
            }
        }

        public HtmlDiv AccessCardNumberValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("AccessCardNumber_validationMessage");
            }
        }

        public HtmlTextArea AboutField
        {
            get
            {
                return this.Find.ById<HtmlTextArea>("About");
            }
        }

        public HtmlSpan SelectOccupationButton
        {
            get
            {
                return this.Find
                           .ByAttributes<HtmlSpan>("aria-owns=WorkEducationStatusId_listbox")
                           .Find
                           .ByAttributes<HtmlSpan>("k-select".ToClassIsExpression());
            }
        }

        public HtmlUnorderedList OccupationSelectionList
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("WorkEducationStatusId_listbox");
            }
        }

        public HtmlListItem OtherOccupationSelection
        {
            get
            {
                return this.OccupationSelectionList
                           .Find
                           .ByContent<HtmlListItem>("Друго", ArtOfTest.WebAii.ObjectModel.FindContentType.InnerText);
            }
        }

        public HtmlInputText PhoneField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Phone");
            }
        }

        public HtmlInputText BirthDayField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("BirthDay");
            }
        }

        public KendoInput BirthDatePicker
        {
            get
            {
                return this.Find
                           .ByExpression<KendoInput>(
                                "k-picker-wrap".ToClassContainsExpression()
                                );
            }
        }

        public KendoCalendar BirthDateCalendar
        {
            get
            {
                return this.Find
                           .ByExpression<KendoCalendar>(
                                "k-widget k-calendar".ToClassContainsExpression()
                                );
            }
        }

        public HtmlSpan CitySelectButton
        {
            get
            {
                return this.Find
                           .ByAttributes<HtmlSpan>("aria-owns=CityId_listbox")
                           .Find
                           .ByAttributes<HtmlSpan>("k-select".ToClassIsExpression());
            }
        }

        public HtmlUnorderedList CitySelectionList
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("CityId_listbox");
            }
        }

        public HtmlListItem OtherCitySelection
        {
            get
            {
                return this.CitySelectionList
                           .Find
                           .ByContent<HtmlListItem>("Друг", ArtOfTest.WebAii.ObjectModel.FindContentType.InnerText);
            }
        }

        public HtmlSpan UniversitySelectButton
        {
            get
            {
                return this.Find
                           .ByAttributes<HtmlSpan>("aria-owns=UniversityId_listbox")
                           .Find
                           .ByAttributes<HtmlSpan>("k-select".ToClassIsExpression());
            }
        }

        public HtmlUnorderedList UniversitySelectionList
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("UniversityId_listbox");
            }
        }

        public HtmlListItem NoUniversitySelection
        {
            get
            {
                return this.UniversitySelectionList
                           .Find
                           .ByContent<HtmlListItem>("Не уча (и не съм учил/а) в университет", ArtOfTest.WebAii.ObjectModel.FindContentType.TextContent);
            }
        }

        public HtmlInputText FacultyNameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("FacultyName");
            }
        }

        public HtmlInputText UniversitySpecialityField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("UniversitySpeciality");
            }
        }

        public HtmlInputText FacultyNumberField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("FacultyNumber");
            }
        }

        public HtmlInputText SchoolNameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("SchoolName");
            }
        }

        public HtmlInputText WebsiteField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Website");
            }
        }

        public HtmlDiv WebsiteValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("Website_validationMessage");
            }
        }

        public HtmlInputText SkypeUsernameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("SkypeUsername");
            }
        }

        public HtmlDiv SkypeUsernameValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("SkypeUsername_validationMessage");
            }
        }

        public HtmlInputText FacebookUrlField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("FacebookUrl");
            }
        }

        public HtmlDiv FacebookUrlValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("FacebookUrl_validationMessage");
            }
        }

        public HtmlInputText GooglePlusUrlField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("GooglePlusUrl");
            }
        }

        public HtmlDiv GooglePlusUrlValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("GooglePlusUrl_validationMessage");
            }
        }

        public HtmlInputText LinkedInUrlField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("LinkedInUrl");
            }
        }

        public HtmlDiv LinkedInUrlValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("LinkedInUrl_validationMessage");
            }
        }

        public HtmlInputText TwiterUrlField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("TwiterUrl");
            }
        }

        public HtmlDiv TwiterUrlValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("TwiterUrl_validationMessage");
            }
        }

        public HtmlInputText ForumPointsField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("ForumPoints");
            }
        }

        public HtmlSpan ForumPointsIncrease
        {
            get
            {
                return this.Find.ByAttributes<HtmlSpan>("Increase value".ToTitleIsExpression());
            }
        }

        public HtmlSpan ForumPointsDecrease
        {
            get
            {
                return this.Find.ByAttributes<HtmlSpan>("Decrease value".ToTitleIsExpression());
            }
        }

        public HtmlAnchor UpdateButton
        {
            get
            {
                return this.Find.ByAttributes<HtmlAnchor>("k-grid-update".ToClassContainsExpression(), "k-button".ToClassContainsExpression());
            }
        }

        public HtmlAnchor CancelButton
        {
            get
            {
                return this.Find.ByAttributes<HtmlAnchor>("k-button k-button-icontext k-grid-cancel".ToClassIsExpression());
            }
        }

        public HtmlAnchor CloseButton
        {
            get
            {
                return this.Find
                           .ByAttributes<HtmlAnchor>("button".ToRoleIsExpression(), "k-window-action k-link".ToClassIsExpression());
            }
        }
    }
}