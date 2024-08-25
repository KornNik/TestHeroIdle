using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct AttackPowerAttributes
    {
        private Stat _attackPower;
        private List<StatModifier> _attackStatModifiers;

        public AttackPowerAttributes(AttackPowerData attackData)
        {
            _attackPower = new Stat(attackData.BaseAttackPower);
            _attackStatModifiers = new List<StatModifier>();
        }

        public Stat AttackPower => _attackPower;
    }
}
