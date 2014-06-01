namespace TradeAndTravel
{
    using System;
    using System.Linq;

    public class Mine : Location, IGatheringLocation
    {
        public Mine(string name) 
            : base(name, LocationType.Mine)
        {
        }

        public ItemType GatheredType
        {
            get { return ItemType.Iron; }
        }

        public ItemType RequiredItem
        {
            get { return ItemType.Armor; }
        }

        public Item ProduceItem(string name)
        {
            throw new NotImplementedException();
        }
    }
}
