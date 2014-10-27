namespace MonopolyGame.Core.Pages.SettingsPage
{
    using System;
    using System.Linq;
    using TestFramework.Core.Extensions;

    public class SettingsPageValidator
    {
        private readonly SettingsPage settingsPage;

        public SettingsPageValidator(SettingsPage settingsPage)
        {
            this.settingsPage = settingsPage;
        }

        public void PlayersCount(int count)
        {
            this.settingsPage.Elements.PlayerCountField.AssertValueEquals(count.ToString());
            this.settingsPage.Elements.NamesOfThePlayersInputs.AssertElementsCount(count);
        }

        public void FirstPlayerNameValidationError()
        {
            this.settingsPage.Elements.NameValidationMessageArea.AssertTextIsContained("INVALID");
            this.settingsPage.Elements.NameValidationMessageArea.AssertTextIsContained("PlayerName1");
        }

        public void NoPlayerNameValidationError()
        {
            this.settingsPage.Elements.NameValidationMessageArea.AssertTextEquals("VALID");
        }

        public void FirstPlayerNameIs(string name)
        {
            this.settingsPage.Elements.PlayerOneNameField.AssertValueEquals(name);
        }

        public void MoneyPerPlayer(double moneyPerPlayer)
        {
            this.settingsPage.Elements.MoneyForPlayerField.AssertValueEquals(string.Format("{0:C}", moneyPerPlayer));
        }

        public void MoneyInTheBank(double moneyInTheBank)
        {
            this.settingsPage.Elements.MoneyInTheBankField.AssertValueEquals(string.Format("{0:C}", moneyInTheBank));
        }

        public void GameStartAreaPresent()
        {
            this.settingsPage.Elements.DiceSideSix.AssertIsPresent();
            this.settingsPage.Elements.StartGameMessageArea.AssertIsPresent();
        }

        public void GameStartAreaNotPresent()
        {
            this.settingsPage.Elements.DiceSideSix.AssertIsNotVisible();
            this.settingsPage.Elements.StartGameMessageArea.AssertIsNotVisible();
        }
    }
}