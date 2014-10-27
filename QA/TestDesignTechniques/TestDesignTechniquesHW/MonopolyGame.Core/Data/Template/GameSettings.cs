namespace MonopolyGame.Core.Data.Template
{
    public class GameSettings
    {
        public GameSettings()
        {
        }

        public GameSettings(
            int playersCount, 
            string playerOneName, 
            string playerTwoName, 
            string playerThreeName, 
            string playerFourName, 
            string playerFiveName, 
            string playerSixName, 
            double moneyPerPlayer)
        {
            this.PlayersCount = playersCount;
            this.PlayerOneName = playerOneName;
            this.PlayerTwoName = playerTwoName;
            this.PlayerThreeName = playerThreeName;
            this.PlayerFourName = playerFourName;
            this.PlayerFiveName = playerFiveName;
            this.PlayerSixName = playerSixName;
            this.MoneyPerPlayer = moneyPerPlayer;
        }

        public int PlayersCount { get; set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }
        public string PlayerThreeName { get; set; }
        public string PlayerFourName { get; set; }
        public string PlayerFiveName { get; set; }
        public string PlayerSixName { get; set; }
        public double MoneyPerPlayer { get; set; }
    }
}
