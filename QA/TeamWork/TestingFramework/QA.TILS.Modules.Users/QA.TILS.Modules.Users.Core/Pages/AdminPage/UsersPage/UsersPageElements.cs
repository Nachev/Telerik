namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.UsersPage
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class UsersPageElements : BaseElementsMap
    {
        public HtmlAnchor NewUserRegistrationButton
        { 
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("/Users/Auth/Registration".ToLinkContainsExpression());
            }
        }

        public HtmlAnchor OpenAllButton
        {
            get
            {
                return this.Find.ByAttributes<HtmlAnchor>("k-button k-button-icontext k-grid-expandAll".ToClassIsExpression());
            }
        }

        public HtmlAnchor FilterUsersButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("getUsersData");
            }
        }

        public HtmlAnchor ExportToExcelButton
        {
            get
            {
                return this.Find.ById<HtmlAnchor>("export");
            }
        }

        public HtmlAnchor BackToAdministrationButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("/Administration/Navigation".ToLinkContainsExpression());
            }
        }

        public HtmlAnchor RefreshButton
        {
            get
            {
                return this.Find.ByAttributes<HtmlAnchor>("title=Refresh");
            }
        }

        public HtmlDiv LoadingMask
        {
            get
            {
                return this.Find.ByAttributes<HtmlDiv>("k-loading-mask".ToClassContainsExpression());
            }
        }

        public HtmlDiv Grid
        {
            get
            {
                return this.Find.ById<HtmlDiv>("DataGrid");
            }
        }

        public HtmlTableRow FirstGridRow
        {
            get
            {
                return this.Grid.Find.ByXPath<HtmlTableRow>("//table/tbody/tr");
            }
        }

        public HtmlTableRow GetGridRowByRowIndex(int rowIndex)
        {
            string searchXpath = string.Format("//table/tbody/tr[{0}]", rowIndex);
            var row = this.Grid.Find.ByXPath<HtmlTableRow>(searchXpath);
            return row;
        }

        public HtmlTableCell FirstUserId
        {
            get
            {
                return this.Grid.Find.ByXPath<HtmlTableCell>("//table/tbody/tr/td[2]");
            }
        }

        public ICollection<HtmlTableRow> GridRows
        {
            get
            {
                return this.Grid
                           .Find
                           .AllByExpression<HtmlTableRow>("tr".ToTagNameIsExpression(), "k-master-row".ToClassContainsExpression());
            }
        }
    }
}
