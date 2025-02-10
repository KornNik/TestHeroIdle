using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Item", menuName = "Data/Item")]
    sealed class Item : ScriptableObject
    {
        [SerializeField] private GameObject _itemObject;
        [SerializeField] private Sprite _itemUIVisual;
        [SerializeField] private bool _isQuantitive;

        public GameObject ItemObject => _itemObject;
        public Sprite ItemUIVisual => _itemUIVisual;
        public bool IsQuantitive => _isQuantitive;
    }
}
