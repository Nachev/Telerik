namespace TradeAndTravel
{
    using System;
    using System.Linq;

    public class ExtendedInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }

            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant" :
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person; 
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            Item craftedItem = null;
            string itemType = commandWords[2];
            string itemName = commandWords[3];
            switch (itemType)
            {
                case "armor" :
                    foreach (var item in actor.ListInventory())
                    {
                        if (item.ItemType == ItemType.Iron)
                        {
                            craftedItem = new Armor(itemName);
                            this.AddToPerson(actor, craftedItem);
                            return;
                        }
                    }

                    break;
                case "weapon" :
                    bool hasIron = new bool();
                    bool hasWood = new bool();

                    foreach (var item in actor.ListInventory())
                    {
                        if (item.ItemType == ItemType.Iron)
                        {
                            hasIron = true;
                        }
                        else if (item.ItemType == ItemType.Wood)
                        {
                            hasWood = true;
                        }

                        if (hasIron && hasWood)
                        {
                            craftedItem = new Weapon(itemName);
                            this.AddToPerson(actor, craftedItem);
                            return;
                        }
                    }

                    break;
                default:
                    break;
            }

        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            Item gatherItem = null;
            string itemName = commandWords[2];
            switch (actor.Location.LocationType)
            {
                case LocationType.Mine:
                    foreach (var item in actor.ListInventory())
                    {
                        if (item.ItemType == ItemType.Armor)
                        {
                            gatherItem = new Iron(itemName);
                            this.AddToPerson(actor, gatherItem);
                            return;
                        }
                    }

                    break;
                case LocationType.Forest:
                    foreach (var item in actor.ListInventory())
                    {
                        if (item.ItemType == ItemType.Weapon)
                        {
                            gatherItem = new Wood(itemName);
                            this.AddToPerson(actor, gatherItem);
                            return;
                        }
                    }

                    break;
                default:
                    break;
            }
        }
    }
}
