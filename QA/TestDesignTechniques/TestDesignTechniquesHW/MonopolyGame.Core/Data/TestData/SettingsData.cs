namespace MonopolyGame.Core.Data.TestData
{
    using System;
    using MonopolyGame.Core.Data.Template;

    public static class SettingsData
    {
        private static readonly GameSettings valid = new GameSettings(6, "playerOne", "playerTwo", "playerThree", "playerFour", "playerFive", "playerSix", 1360.00D);

        public static GameSettings Valid
        {
            get { return valid; }
        }
 
    }
}
