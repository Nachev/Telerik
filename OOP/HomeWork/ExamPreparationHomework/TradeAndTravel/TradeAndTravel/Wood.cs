namespace TradeAndTravel
{
    using System;
    using System.Linq;

    public class Wood : Item
    {
        private const int GeneralWoodValue = 2;

        public Wood(string name, Location location = null) 
            : base(name, GeneralWoodValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            base.UpdateWithInteraction(interaction);
            if (interaction.ToLower() == "drop" && this.Value > 0)
            {
                this.Value -= 1;
            }
        }
    }
}
