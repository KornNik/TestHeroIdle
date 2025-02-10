using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    enum ItemDropedType
    {
        None,
        Droped,
        Cleaned
    }
    struct ItemDropedEvent
    {
        private static ItemDropedEvent _itemDropedEvent;

        private ItemDropedType _itemDropedType;
        private Item _item;
        private Vector3 _position;

        public ItemDropedType ItemDropedType => _itemDropedType;
        public Item Item => _item;
        public Vector3 Position => _position;

        public static void Trigger(ItemDropedType itemDropedType, Item item, Vector3 position)
        {
            _itemDropedEvent._itemDropedType = itemDropedType;
            _itemDropedEvent._item = item;
            _itemDropedEvent._position = position;
            EventManager.TriggerEvent(itemDropedType);
        }
    }
}
