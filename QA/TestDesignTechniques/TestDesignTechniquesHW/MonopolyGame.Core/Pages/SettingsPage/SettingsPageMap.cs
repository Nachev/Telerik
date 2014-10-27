namespace MonopolyGame.Core.Pages.SettingsPage
{
    using System.Collections.Generic;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Telerik.WebAii.Controls.Html;
    using TestFramework.Core.Base;
    using TestFramework.Core.Extensions;

    public class SettingsPageMap : BaseElementsMap
    {
        public HtmlSpan SettingsButton 
        { 
            get
            {
                return this.Find.ByContent<HtmlSpan>("Settings");
            }
        }

        public RadInput PlayerCountRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerCount_wrapper");
            }
        }

        public HtmlInputText PlayerCountField 
        { 
            get
            {
                return this.Find.ById<HtmlInputText>("PlayerCount");
            }
        }

        public RadInput PlayerOneNameRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerName1_wrapper");
            }
        }

        public RadInput PlayerTwoNameRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerName2_wrapper");
            }
        }

        public RadInput PlayerThreeNameRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerName3_wrapper");
            }
        }

        public RadInput PlayerFourNameRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerName4_wrapper");
            }
        }

        public RadInput PlayerFiveNameRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerName5_wrapper");
            }
        }

        public RadInput PlayerSixNameRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("PlayerName6_wrapper");
            }
        }

        public HtmlInputText PlayerOneNameField 
        {
            get
            {
                return this.Find.ById<HtmlInputText>("PlayerName1");
            }
        }

        public ICollection<RadInput> NamesOfThePlayersInputs
        {
            get
            {
                return this.Find.AllByTitleContent<RadInput>("PlayerName");
            }
        }

        public RadInput MoneyForPlayerRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("MoneyPerPlayer_wrapper");
            }
        }

        public HtmlInputText MoneyForPlayerField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("MoneyPerPlayer");
            }
        }

        public RadInput MoneyInTheBankRadInput
        {
            get
            {
                return this.Find.ById<RadInput>("BankMoney_wrapper");
            }
        }

        public HtmlInputText MoneyInTheBankField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("BankMoney");
            }
        }

        public HtmlDiv DiceCube
        {
            get
            {
                return this.Find.ByClassName<HtmlDiv>("cube");
            }
        }

        public HtmlDiv DiceSideSix
        {
            get
            {
                return this.DiceCube.Find.ByClassName<HtmlDiv>("side back");
            }
        }

        public HtmlDiv RollButton
        {
            get
            {
                return this.Find.ByClassName<HtmlDiv>("btn roll");
            }
        }

        public HtmlSpan NameValidationMessageArea
        {
            get
            {
                return this.Find.ById<HtmlSpan>("ValidationResult");
            }
        }

        public HtmlDiv StartGameMessageArea
        {
            get
            {
                return this.Find.ById<HtmlDiv>("StartGame_popup");
            }
        }
    }
}