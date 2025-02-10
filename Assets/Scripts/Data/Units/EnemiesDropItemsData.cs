using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyDropItemsTable", menuName = "Data/EnemyDropItemsTable")]
    sealed class EnemiesDropItemsData : ScriptableObject
    {
        [SerializeField] private Item[] _items;

        public Item GetRandomItem()
        {
            var random = Random.Range(0, _items.Length);
            var randomItem = _items[random];
            if(randomItem != null)
            {
                return randomItem;
            }
            else
            {
                throw new System.Exception("random item is null");
            }
        }
    }
}
