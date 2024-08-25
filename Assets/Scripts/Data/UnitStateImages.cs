using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitStateImages", menuName = "Data/StateImages")]
    sealed class UnitStateImages : ScriptableObject
    {
        [SerializeField] private Sprite _attackSprite;
        [SerializeField] private Sprite _rechargeSprite;
        [SerializeField] private Sprite _weaponSwapSprite;

        public Sprite AttackSprite => _attackSprite;
        public Sprite RechargeSprite => _rechargeSprite;
        public Sprite WeaponSwapSprite => _weaponSwapSprite;
    }
}
