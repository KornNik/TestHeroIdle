using Data;

namespace Behaviours
{
    sealed class EnemyCombat : Combat
    {
        private Weapon _currentWeapon;
        public EnemyCombat(Unit unitReference) : base(unitReference)
        {
            _currentWeapon = new Weapon(unitReference, WeaponType.Melee);
        }
        protected override void AttackTarget()
        {
            base.AttackTarget();
            _currentWeapon.InflictDamage(_opponent);
        }
    }
}
