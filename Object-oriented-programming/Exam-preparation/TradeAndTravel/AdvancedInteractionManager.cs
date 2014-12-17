using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class AdvancedInteractionManager : InteractionManager
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

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
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
                    this.HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    this.HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            GatheringLocation actorLocationAsGathering = actor.Location as GatheringLocation;

            if (actorLocationAsGathering != null)
            {
                if (actor.ListInventory().Any(item => item.ItemType == actorLocationAsGathering.RequiredItem))
                {
                    Item gatheredItem = actorLocationAsGathering.ProduceItem(commandWords[2]);
                    this.AddToPerson(actor, gatheredItem);
                    gatheredItem.UpdateWithInteraction("gather");
                }
            }
        }

        private void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            Item craftedItem = null;
            if (actor.ListInventory().Any(item => item.ItemType == ItemType.Wood) && actor.ListInventory().Any(item => item.ItemType == ItemType.Iron))
            {
                craftedItem = new Weapon(commandWords[3]);
            }
            if (actor.ListInventory().Any(item => item.ItemType == ItemType.Iron))
            {
                craftedItem = new Armor(commandWords[3]);
            }
            if (craftedItem != null)
            {
                this.AddToPerson(actor, craftedItem);
                craftedItem.UpdateWithInteraction("craft");
            }
        }
    }
}
