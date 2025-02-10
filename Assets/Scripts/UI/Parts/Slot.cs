using Behaviours;
using Data;
using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class Slot: MonoBehaviour, IPoolable
    {
        [SerializeField] private Image _slotImage;
        [SerializeField] private Sprite _emptySlotSprite;
        [SerializeField] private Button _dropItemButton;

        private Item _itemInSlot;
        private Transform _poolTransform;

        public Transform PoolTransform { get => _poolTransform; set => _poolTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }

        private void Awake()
        {

        }
        private void OnEnable()
        {
            _dropItemButton.onClick.AddListener(OnDropItemButtonDown);
            DrawSlotSprite(_slotImage, _itemInSlot);
            DrawDropButton(_dropItemButton, _itemInSlot);
        }
        private void OnDisable()
        {
            _dropItemButton.onClick.RemoveListener(OnDropItemButtonDown);
        }

        public bool IsSlotClear()
        {
            return CheckIsItemInSlot(_itemInSlot);
        }
        public void ClearSlot()
        {
            _itemInSlot = null;
            DrawSlotSprite(_slotImage, _itemInSlot);
            DrawDropButton(_dropItemButton, _itemInSlot);
        }
        public void FillSlot(Item item)
        {
            _itemInSlot = item;
            DrawSlotSprite(_slotImage, _itemInSlot);
            DrawDropButton(_dropItemButton, _itemInSlot);
        }
        public bool IsItemEqual(Item item)
        {
            if (item == _itemInSlot)
            {
                return true;
            }
            return false;
        }

        private void DrawSlotSprite(Image slotImage, Item itemInSlot)
        {
            if (CheckIsItemInSlot(itemInSlot))
            {
                slotImage.sprite = itemInSlot.ItemUIVisual;
            }
            else
            {
                slotImage.sprite = _emptySlotSprite;
            }
        }
        private void DrawDropButton(Button dropButton, Item itemInSlot)
        {
            if (CheckIsItemInSlot(itemInSlot))
            {
                dropButton.interactable = true;
            }
            else
            {
                dropButton.interactable = false;
            }
        }
        private bool CheckIsItemInSlot(Item itemInSlot)
        {
            if (ReferenceEquals(itemInSlot, null))
            {
                return false;
            }
            return true;
        }

        private void OnDropItemButtonDown()
        {
            InventoryChangeEvent.Trigger(ChangingType.ItemRemoved, _itemInSlot);
        }

        public void ReturnToPool()
        {
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            PoolableObject.SetActive(false);

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }

        public void ActiveObject()
        {
            gameObject.SetActive(true);
            transform.SetParent(PoolTransform);
        }
    }
}
