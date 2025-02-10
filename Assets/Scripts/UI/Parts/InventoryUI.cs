using Behaviours;
using Data;
using Helpers;
using System;
using UnityEngine;

namespace UI
{
    sealed class InventoryUI : MonoBehaviour, IEventListener<InventoryChangeEvent>
    {
        private const int SLOTS_VALUE = 20;

        [SerializeField] private Slot _slotPrefab;
        [SerializeField] private Transform _slotsParent;

        private CertainPool<Slot> _slotsPool;

        private void Awake()
        {
            _slotsPool = new CertainPool<Slot>(SLOTS_VALUE, _slotsParent, _slotPrefab);
            EnableSlots();
        }
        private void OnEnable()
        {
            this.EventStartListening<InventoryChangeEvent>();
        }
        private void OnDisable()
        {
            this.EventStopListening<InventoryChangeEvent>();
        }
        private void EnableSlots()
        {
            for (int i = 0; i < SLOTS_VALUE; i++)
            {
                var slot = _slotsPool.GetObject() as Slot;
                if (slot is Slot)
                {
                    slot.ActiveObject();
                }
                else
                {
                    throw new Exception($"{this.GetType()} is trying to get slot from pool but something went wrong ");
                }
            }
        }
        private Slot FindEmpty()
        {
            foreach (var slot in _slotsPool.PoolablesList)
            {
                if (slot.IsSlotClear())
                {
                    return slot;
                }
            }
            return null;
        }
        private Slot FindSlotWithItem(Item item)
        {
            foreach (var slot in _slotsPool.PoolablesList)
            {
                if (slot.IsItemEqual(item))
                {
                    return slot;
                }
            }
            return null;
        }

        private void ClearItemSlot(Item item)
        {
            var slotWithItem = FindSlotWithItem(item);
            if (slotWithItem != null)
            {
                slotWithItem.ClearSlot();
            }
            else
            {
                Debug.Log($"{this} is trying to remove item but inventory dasnt have this item");
            }
        }
        private void AddItemSlot(Item item)
        {
            var emptySlot = FindEmpty();
            if (emptySlot != null)
            {
                emptySlot.FillSlot(item);
            }
            else
            {
                Debug.Log($"{this} is trying to add item but inventory is full");
            }
        }

        public void OnEventTrigger(InventoryChangeEvent eventType)
        {
            if(eventType.ChangeType== ChangingType.ItemRemoved)
            {
                ClearItemSlot(eventType.ItemChanged);
            }
            else if (eventType.ChangeType == ChangingType.ItemAdded)
            {
                AddItemSlot(eventType.ItemChanged);
            }
        }
    }
}
