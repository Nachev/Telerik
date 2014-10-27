namespace MonopolyGame.Tests
{
    using System;
    using System.Threading;
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MonopolyGame.Core.Data.TestData;
    using MonopolyGame.Core.Pages.SettingsPage;
    using TestFramework.Core.Base;

    [TestClass]
    public class MonopolyGameTests : BaseTest
    {
        private const int PlayersCountMin = 2;
        private const int PlayersCountMax = 6;

        private const double MoneyPerPlayerMax = 1500.00D;
        private const double MoneyPerPlayerMin = 1200.00D;
        private const double MoneyPerPlayerChangeStep = 0.01D;
        private const double MoneyInTheBankMax = 12000.00D;

        private SettingsPage settingsPage;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            BaseTest.InitializeBrowser();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            BaseTest.BrowserCleanup();
        }

        public override void TestInitialize()
        {
            base.TestInitialize();
            this.settingsPage = SettingsPage.Instance;
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValuesInAllFields_ShouldProceedCorrectly()
        {
            this.settingsPage.EnterSettingsData(SettingsData.Valid);
            this.settingsPage.Validator.FirstPlayerNameIs(SettingsData.Valid.PlayerOneName);
            int playersCount = SettingsData.Valid.PlayersCount;
            this.settingsPage.Validator.PlayersCount(playersCount);
            this.settingsPage.Validator.MoneyInTheBank(MoneyInTheBankMax - (playersCount * SettingsData.Valid.MoneyPerPlayer));
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValuesBelowRange_ShouldBeIgnored()
        {
            int playersInputCount = PlayersCountMin - 1;
            int playersExpectedCount = PlayersCountMin;
            this.settingsPage.EnterPlayersCount(playersInputCount.ToString());
            this.settingsPage.Validator.PlayersCount(playersExpectedCount);
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValueOnLowerBorder_ShouldBeHandledCorrectly()
        {
            int playersCount = PlayersCountMin;
            this.settingsPage.EnterPlayersCount(playersCount.ToString());
            this.settingsPage.Validator.PlayersCount(playersCount);
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValueInLowerRange_ShouldBeHandledCorrectly()
        {
            int playersCount = PlayersCountMin + 1;
            this.settingsPage.EnterPlayersCount(playersCount.ToString());
            this.settingsPage.Validator.PlayersCount(playersCount);
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValueAboveRange_ShouldBeIgnored()
        {
            int playersInputCount = PlayersCountMax + 1;
            int playersExpectedCount = PlayersCountMax;
            this.settingsPage.EnterPlayersCount(playersInputCount.ToString());
            this.settingsPage.Validator.PlayersCount(playersExpectedCount);
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValueOnHigherBorder_ShouldBeHandledCorrectly()
        {
            int playersCount = PlayersCountMax;
            this.settingsPage.EnterPlayersCount(playersCount.ToString());
            this.settingsPage.Validator.PlayersCount(playersCount);
        }

        [TestMethod]
        public void TestPlayersCountInput_ValidValueInHighRange_ShouldBeHandledCorrectly()
        {
            int playersCount = PlayersCountMax - 1;
            this.settingsPage.EnterPlayersCount(playersCount.ToString());
            this.settingsPage.Validator.PlayersCount(playersCount);
        }

        [TestMethod]
        public void TestPlayersCountInput_InvalidValueInput_ShouldBeIgnored()
        {
            this.settingsPage.EnterPlayersCount("`");
            this.settingsPage.Validator.PlayersCount(PlayersCountMin);
        }

        [TestMethod]
        public void TestPlayersCountInput_EmptyInput_ShouldBeIgnored()
        {
            this.settingsPage.EnterPlayersCount(string.Empty);
            this.settingsPage.Validator.PlayersCount(PlayersCountMin);
        }

        [TestMethod]
        public void TestPlayerNameInput_InvalidValue_ShouldResultAnErrorMessage()
        {
            this.settingsPage.EnterPlayerOneName("4");
            this.settingsPage.Validator.FirstPlayerNameValidationError();
        }

        [TestMethod]
        public void TestPlayerNameInput_ValidValue_ShouldProceedCorrectly()
        {
            this.settingsPage.EnterPlayerOneName("Pesho");
            this.settingsPage.Validator.FirstPlayerNameIs("Pesho");
            this.settingsPage.Validator.NoPlayerNameValidationError();
        }

        [TestMethod]
        public void TestPlayerCountAndPlayerFourNameInput_ValidValues_ShouldProceedCorrectly()
        {
            this.settingsPage.EnterPlayerFourName("Pesho");
            this.settingsPage.Validator.NoPlayerNameValidationError();
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_EmptyValue_ShouldBeIgnored()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount(string.Empty);
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMin);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_InvalidSymbolValue_ShouldBeIgnored()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount("<7>");
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMin);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_InvalidValueBelowLowerRangeBorder_ShouldBeIgnored()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMin - MoneyPerPlayerChangeStep).ToString("C"));
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMin);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_ValidValueOnLowerRangeBorder_ShouldBeProcessedSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMin).ToString("C"));
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMin);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_ValidValueAboveLowerRangeBorder_ShouldBeProcessedSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMin + MoneyPerPlayerChangeStep).ToString("C"));
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMin + MoneyPerPlayerChangeStep);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_InvalidValueAboveHigherRangeBorder_ShouldBeIgnored()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMax + MoneyPerPlayerChangeStep).ToString("C"));
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMax);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_ValidValueOnHigherRangeBorder_ShouldBeProcessedSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMax).ToString("C"));
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMax);
        }

        [TestMethod]
        public void TestMoneyPerPlayerInput_ValidValueBelowHigherRangeBorder_ShouldBeProcessedSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMax - MoneyPerPlayerChangeStep).ToString("C"));
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMax - MoneyPerPlayerChangeStep);
        }

        [TestMethod]
        public void TestMoneyInBank_MaxMoneyPerPlayerMinPlayers_ShouldCalculateSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMax).ToString("C"), PlayersCountMin.ToString());
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMax);
            this.settingsPage.Validator.MoneyInTheBank(MoneyInTheBankMax - (MoneyPerPlayerMax * PlayersCountMin));
        }

        [TestMethod]
        public void TestMoneyInBank_MaxMoneyPerPlayerMaxPlayers_ShouldCalculateSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMax).ToString("C"), PlayersCountMax.ToString());
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMax);
            this.settingsPage.Validator.MoneyInTheBank(MoneyInTheBankMax - (MoneyPerPlayerMax * PlayersCountMax));
        }

        [TestMethod]
        public void TestMoneyInBank_MinMoneyPerPlayerMinPlayers_ShouldCalculateSuccessfully()
        {
            this.settingsPage.EnterMoneyPerPlayerAndCount((MoneyPerPlayerMin).ToString("C"), PlayersCountMin.ToString());
            this.settingsPage.Validator.MoneyPerPlayer(MoneyPerPlayerMin);
            this.settingsPage.Validator.MoneyInTheBank(MoneyInTheBankMax - (MoneyPerPlayerMin * PlayersCountMin));
        }

        [TestMethod]
        public void TestDice_RollSix_ShouldResultAnMessageForGameStart()
        {
            this.settingsPage.RollDiceUntilSix();
            this.settingsPage.Validator.GameStartAreaPresent();
        }

        [TestMethod]
        public void TestDice_RollOtherThanSix_ShouldBeIgnored()
        {
            this.settingsPage.RollDiceUntilNotSix();
            this.settingsPage.Validator.GameStartAreaNotPresent();
        }
    }
}