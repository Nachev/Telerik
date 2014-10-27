namespace MonopolyGame.Core.Pages.SettingsPage
{
    using ArtOfTest.WebAii.Core;
    using MonopolyGame.Core.Data.Template;
    using MonopolyGame.Core.Data.TestData;
    using TestFramework.Core.Base;

    public class SettingsPage : BasePage<SettingsPage>
    {
        public SettingsPage()
        {
            this.Validator = new SettingsPageValidator(this);
            this.Elements = new SettingsPageMap();
            this.Url = @"http://localhost:49573/Default.aspx";
        }

        public SettingsPageValidator Validator { get; private set; }

        public SettingsPageMap Elements { get; private set; }

        public void NavigateToThisPage()
        {
            Manager.Current.ActiveBrowser.NavigateTo(this.Url);
            this.Elements.SettingsButton.Click();
        }

        public void EnterPlayersCount(string count)
        {
            this.NavigateToThisPage();
            this.Elements.PlayerCountRadInput.InputValue = count;
            Manager.Current.ActiveBrowser.WaitForAjax(3000);
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }

        public void EnterPlayerOneName(string name)
        {
            this.NavigateToThisPage();
            this.Elements.PlayerOneNameRadInput.InputValue = name;
            this.Elements.PlayerOneNameRadInput.Blur();
        }

        public void EnterPlayerFourName(string name)
        {
            this.EnterPlayersCount("4");
            this.Elements.PlayerOneNameRadInput.InputValue = name;
            this.Elements.PlayerTwoNameRadInput.InputValue = name;
            this.Elements.PlayerThreeNameRadInput.InputValue = name;
            this.Elements.PlayerFourNameRadInput.InputValue = name;
            this.Elements.PlayerFourNameRadInput.Blur();
        }

        public void EnterMoneyPerPlayerAndCount(string moneyPerPlayer, string playerCount = "2")
        {
            this.EnterPlayersCount(playerCount);
            this.Elements.MoneyForPlayerRadInput.InputValue = "0";
            this.Elements.MoneyForPlayerRadInput.InputValue = moneyPerPlayer;
            this.Elements.MoneyForPlayerRadInput.Blur();
        }

        public void EnterValidInputData(
            string playersCount, 
            string playerOneName, 
            string playerTwoName, 
            string playerThreeName,
            string playerFourName,
            string playerFiveName,
            string playerSixName,
            string moneyPerPlayer)
        {
            this.EnterPlayersCount(playersCount);
            this.Elements.PlayerOneNameRadInput.InputValue = playerOneName;
            this.Elements.PlayerTwoNameRadInput.InputValue = playerTwoName;
            this.Elements.PlayerThreeNameRadInput.InputValue = playerThreeName;
            this.Elements.PlayerFourNameRadInput.InputValue = playerFourName;
            this.Elements.PlayerFiveNameRadInput.InputValue = playerFiveName;
            this.Elements.PlayerSixNameRadInput.InputValue = playerSixName;
            this.Elements.PlayerSixNameRadInput.Blur();
            this.Elements.MoneyForPlayerRadInput.InputValue = moneyPerPlayer;
            this.Elements.MoneyForPlayerRadInput.Blur();
        }
        
        public void EnterSettingsData(GameSettings settingsData)
        {
            this.EnterValidInputData(
                settingsData.PlayersCount.ToString(),
                settingsData.PlayerOneName,
                settingsData.PlayerTwoName,
                settingsData.PlayerThreeName,
                settingsData.PlayerFourName,
                settingsData.PlayerFiveName,
                settingsData.PlayerSixName,
                settingsData.MoneyPerPlayer.ToString("C")
                );
        }

        public void RollDiceUntilSix()
        {
            this.EnterSettingsData(SettingsData.Valid);
            bool diceResultSix = false;
            while (!diceResultSix)
            {
                this.Elements.RollButton.Click();
                diceResultSix = this.Elements.DiceSideSix.IsVisible();
            }
        }

        public void RollDiceUntilNotSix()
        {
            this.EnterSettingsData(SettingsData.Valid);
            bool diceResultSix = false;
            do
            {
                this.Elements.RollButton.Click();
                diceResultSix = this.Elements.DiceSideSix.IsVisible();
            }
            while (diceResultSix);
        }
    }
}