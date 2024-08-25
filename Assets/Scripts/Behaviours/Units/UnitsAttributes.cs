using Data;

namespace Behaviours
{
    class UnitAttributes
    {
        private Health _health;
        private Armor _armor;
        private Attack _attack;

        public UnitAttributes(Unit unitReference, UnitData unitData)
        {
            _health = new Health(unitReference, unitData.GetHealthAttributes());
            _armor = new Armor(unitData.GetArmorAttributes());
            _attack = new Attack(unitData.GetAttackPowerAttributes(), unitData.GetAttackRechargeAttributes());

        }

        public Health Health => _health;
        public Armor Armor => _armor;
        public Attack Attack => _attack;
    }
}
