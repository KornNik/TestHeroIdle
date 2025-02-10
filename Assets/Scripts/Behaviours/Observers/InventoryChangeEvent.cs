using Data;
using Helpers;

namespace Behaviours
{
    enum ChangingType
    {
        None,
        ItemRemoved,
        ItemAdded
    }
    struct InventoryChangeEvent
    {
        private static InventoryChangeEvent _inventoryChnageEvent;

        private ChangingType _changeType;
        private Item _itemChanged;

        public ChangingType ChangeType => _changeType;
        public Item ItemChanged => _itemChanged;

        public static void Trigger(ChangingType changeType, Item itemChanged)
        {
            _inventoryChnageEvent._itemChanged = itemChanged;
            _inventoryChnageEvent._changeType = changeType;
            EventManager.TriggerEvent(_inventoryChnageEvent);
        }
    }
}
