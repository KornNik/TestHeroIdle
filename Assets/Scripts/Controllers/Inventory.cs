using Data;
using Helpers;
using System.Collections.Generic;

namespace Behaviours
{
    sealed class Inventory : IEventListener<InventoryChangeEvent>, IEventSubscription
    {
        private HashSet<Item> _itemsInInventory;

        public Inventory()
        {
            _itemsInInventory = new HashSet<Item>(10);
        }

        private void RemoveItem(Item itemToRemove)
        {
            _itemsInInventory.Remove(itemToRemove);
        }
        private void AddItem(Item itemToAdd)
        {
            _itemsInInventory.Add(itemToAdd);
        }

        public void OnEventTrigger(InventoryChangeEvent eventType)
        {
            if (eventType.ChangeType == ChangingType.ItemAdded)
            {
                AddItem(eventType.ItemChanged);
            }
            else if(eventType.ChangeType == ChangingType.ItemRemoved)
            {
                RemoveItem(eventType.ItemChanged);
            }
        }
        public void Subscribe()
        {
            this.EventStartListening<InventoryChangeEvent>();
        }

        public void UnSubscribe()
        {
            this.EventStopListening<InventoryChangeEvent>();
        }
    }
}
