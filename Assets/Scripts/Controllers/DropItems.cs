using Behaviours;
using Data;
using Helpers;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

namespace Controllers
{
    sealed class DropItems : IEventListener<ItemDropedEvent>, IEventSubscription
    {
        private GameObject _dropedItemObject;
        private UniTask _dropedItemTask;
        private float _dropedItemTimerValue = 2f;

        public DropItems()
        {

        }

        private void DropItem(Item dropedItem, Vector3 position)
        {
            var itemObject = GameObject.Instantiate(dropedItem.ItemObject, position, Quaternion.identity);
            _dropedItemObject = itemObject;
            InventoryChangeEvent.Trigger(ChangingType.ItemAdded, dropedItem);
            _dropedItemTask = DropItemTask();
        }
        private void ClearItem()
        {
            GameObject.Destroy(_dropedItemObject);
        }

        private async UniTask DropItemTask()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_dropedItemTimerValue));
            ClearItem();
            GameEndEvent.Trigger(EndGameType.RefreshLevel);
        }

        public void OnEventTrigger(ItemDropedEvent eventType)
        {
            Debug.Log("EventCatch");
            if (eventType.ItemDropedType == ItemDropedEventType.Droped)
            {
                DropItem(eventType.Item, eventType.Position);
            }
            else
            {
                ClearItem();
            }
        }

        public void Subscribe()
        {
            this.EventStartListening();
        }

        public void UnSubscribe()
        {
            this.EventStopListening();
        }
    }
}
