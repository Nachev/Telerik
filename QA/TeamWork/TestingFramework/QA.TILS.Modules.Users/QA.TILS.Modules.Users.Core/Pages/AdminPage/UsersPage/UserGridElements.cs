namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage
{
    using System.Collections.Generic;
    using System.Linq;
    using ArtOfTest.WebAii.Controls.HtmlControls;

    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Base;
    using System.Collections.ObjectModel;
    using QA.Framework.Core.Extensions;

    public class UserGridElements : BaseElementsMap
    {
        private ReadOnlyCollection<string> detailsTitles = new ReadOnlyCollection<string>(new List<string>()
        {
            "Потребител:",
            "Име и фамилия на български:",
            "Дата на раждане:",
            "Пол:",
            "Занимание:",
            "Град:",
            "Телефон:",
            "Имейл:",
            "За мен:",
            "Skype:",
            "Форум точки:",
            "Университет:",
            "Факултет:",
            "Факултетен номер:",
            "Специалност:",
            "Училище:",
            "Website:",
            "Google Plus:",
            "LinkedIn:",
            "Twiter:",
            "Facebook:"
        });

        private HtmlTableRow masterRow;

        public UserGridElements(string username)
        {
            this.masterRow = GetUserMasterRow(username);
        }

        public UserGridElements(HtmlTableRow masterRow)
        {
            this.masterRow = masterRow;
        }

        public HtmlDiv Grid
        {
            get
            {
                return this.Find.ById<HtmlDiv>("DataGrid");
            }
        }

        public HtmlTableRow MasterRow 
        { 
            get
            {
                return this.masterRow;
            }
        }

        public HtmlTableRow DetailsRow
        {
            get
            {
                return GetUserDetailsRow();
            }
        }

        public HtmlAnchor MasterToggleDetailsButton 
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlAnchor>("//td[1]/a");
            }
        }

        public HtmlTableCell MasterId
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlTableCell>("//td[2]");
            }
        }

        public HtmlAnchor MasterUsername
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlAnchor>("//td[3]/a");
            }
        }

        public HtmlTableCell MasterStudentNumber
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlTableCell>("//td[4]");
            }
        }

        public HtmlTableCell MasterFullName
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlTableCell>("//td[5]");
            }
        }

        public HtmlTableCell MasterBirthDate
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlTableCell>("//td[7]");
            }
        }

        public HtmlTableCell MasterSex
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlTableCell>("//td[8]");
            }
        }

        public HtmlTableCell MasterEmail
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlTableCell>("//td[9]");
            }
        }

        public HtmlAnchor MasterEditUser
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlAnchor>("//td[18]/a");
            }
        }

        public HtmlAnchor MasterDeleteUser
        {
            get
            {
                return this.MasterRow.Find.ByXPath<HtmlAnchor>("//td[19]/a");
            }
        }

        public HtmlContainerControl DetailsSection
        {
            get
            {
                return this.DetailsRow.Find.ByExpression<HtmlContainerControl>("CandidateInformation".ToClassIsExpression());
            }
        }

        public HtmlDiv PersonalInfoArea
        {
            get
            {
                return this.DetailsSection.Find.ByExpression<HtmlDiv>("//div[2]".ToXPathIsExpression(), "personalInformation".ToClassIsExpression());
            }
        }

        public HtmlSpan DetailsUsername
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[2]");
            }
        }

        public HtmlSpan DetailsName
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[4]");
            }
        }

        public HtmlSpan DetailsBirthDate
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[6]");
            }
        }

        public HtmlSpan DetailsGender
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[8]");
            }
        }

        public HtmlSpan DetailsOccupation
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[10]");
            }
        }

        public HtmlSpan DetailsCity
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[12]");
            }
        }

        public HtmlSpan DetailsPhone
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[14]");
            }
        }

        public HtmlSpan DetailsEmail
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[16]");
            }
        }

        public HtmlSpan DetailsAbout
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[18]");
            }
        }

        public HtmlSpan DetailsSkypeName
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[20]");
            }
        }

        public HtmlSpan DetailsForumPoints
        {
            get
            {
                return this.PersonalInfoArea.Find.ByXPath<HtmlSpan>("//span[26]");
            }
        }

        public HtmlDiv EducationInformation
        {
            get
            {
                return this.DetailsSection.Find.ByXPath<HtmlDiv>("//div[3]");
            }
        }

        public HtmlSpan DetailsUniversity
        {
            get
            {
                return this.EducationInformation.Find.ByXPath<HtmlSpan>("//span[2]");
            }
        }

        public HtmlSpan DetailsFaculty
        {
            get
            {
                return this.EducationInformation.Find.ByXPath<HtmlSpan>("//span[4]");
            }
        }

        public HtmlSpan DetailsFacultyNumber
        {
            get
            {
                return this.EducationInformation.Find.ByXPath<HtmlSpan>("//span[6]");
            }
        }

        public HtmlSpan DetailsSpecialty
        {
            get
            {
                return this.EducationInformation.Find.ByXPath<HtmlSpan>("//span[8]");
            }
        }

        public HtmlSpan DetailsSchool
        {
            get
            {
                return this.EducationInformation.Find.ByXPath<HtmlSpan>("//span[10]");
            }
        }

        public HtmlUnorderedList LinksToWeb
        {
            get
            {
                return this.DetailsSection.Find.ByXPath<HtmlUnorderedList>("//div[4]/ul");
            }
        }

        public HtmlAnchor DetailsWebsite
        {
            get
            {
                return this.LinksToWeb.Find.ByXPath<HtmlAnchor>("//li[1]/a");
            }
        }

        public HtmlAnchor DetailsGooglePlus
        {
            get
            {
                return this.LinksToWeb.Find.ByXPath<HtmlAnchor>("//li[2]/a");
            }
        }

        public HtmlAnchor DetailsLinkedIn
        {
            get
            {
                return this.LinksToWeb.Find.ByXPath<HtmlAnchor>("//li[3]/a");
            }
        }

        public HtmlAnchor DetailsTwitter
        {
            get
            {
                return this.LinksToWeb.Find.ByXPath<HtmlAnchor>("//li[4]/a");
            }
        }

        public HtmlAnchor DetailsFacebook
        {
            get
            {
                return this.LinksToWeb.Find.ByXPath<HtmlAnchor>("//li[5]/a");
            }
        }

        private HtmlTableRow GetUserMasterRow(string username)
        {
            var result = this.Grid.Find.AllByTagName<HtmlTableRow>("tr").FirstOrDefault(e =>
                e.Find.ByAttributes<HtmlAnchor>("data-username=" + username) != null
                );
            return result;
        }

        private HtmlTableRow GetUserDetailsRow()
        {
            var result = this.Grid.Find.ByAttributes<HtmlTableRow>("k-detail-row".ToClassIsExpression());
            return result;
        }
    }
}
