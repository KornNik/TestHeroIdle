using Data;

namespace Behaviours
{
    class Weapon : IDamager
    {
        private WeaponType _type;
        private AttackPowerAttributes _attackPowerAttributes;
        public Weapon(Unit unitReference, WeaponType weaponType)
        {
            _attackPowerAttributes = unitReference.UnitsAttributes.Attack.AttackPowerAttributes;
            _type = weaponType;
        }

        public WeaponType Type => _type;

        public void InflictDamage(IDamageable damageable)
        {
            damageable.ReceiveDamage(_attackPowerAttributes.AttackPower.CurrentValue);
        }
    }
}
