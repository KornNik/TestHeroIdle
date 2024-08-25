using UnityEngine;

namespace Data
{
    struct ArmorData
    {
        public float BaseArmor;

        public ArmorData(float baseArmor)
        {
            BaseArmor = baseArmor;
        }
    }
    struct HealthData
    {
        public float MaxHealth;
        public HealthData(float maxHealth)
        {
            MaxHealth = maxHealth;
        }
    }
    struct AttackPowerData
    {
        public float BaseAttackPower;
        public AttackPowerData(float baseAttackPower)
        {
            BaseAttackPower = baseAttackPower;
        }
    }
    struct AttackRechargeData
    {
        public float BaseAttackRecharge;
        public AttackRechargeData(float baseAttackRecharge)
        {
            BaseAttackRecharge = baseAttackRecharge;
        }
    }

    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/Attributes/UnitData")]
    class UnitData : ScriptableObject
    {
        [SerializeField] private float _armor;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _attackPower;
        [SerializeField] private float _attackRecharge;
        [SerializeField] private UnitSounds _unitSounds;

        public float Armor => _armor;
        public float MaxHealth => _maxHealth;
        public float AttackPower => _attackPower;
        public float AttackRecharge => _attackRecharge;

        public ArmorAttributes GetArmorAttributes()
        {
            var newAttributes = new ArmorAttributes(new ArmorData(Armor));
            return newAttributes;
        }
        public HealthAttributes GetHealthAttributes()
        {
            var newAttributes = new HealthAttributes(new HealthData(MaxHealth));
            return newAttributes;
        }
        public AttackPowerAttributes GetAttackPowerAttributes()
        {
            var newAttributes = new AttackPowerAttributes(new AttackPowerData(AttackPower));
            return newAttributes;
        }
        public AttackRechargeAttributes GetAttackRechargeAttributes()
        {
            var newAttributes = new AttackRechargeAttributes(new AttackRechargeData(AttackRecharge));
            return newAttributes;
        }
    }
}
