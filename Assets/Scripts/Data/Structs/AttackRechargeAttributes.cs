using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct AttackRechargeAttributes
    {
        private Stat _attackRecharge;
        private List<StatModifier> _rechargeStatModifiers;

        public AttackRechargeAttributes(AttackRechargeData rechargeData)
        {
            _attackRecharge = new Stat(rechargeData.BaseAttackRecharge);
            _rechargeStatModifiers = new List<StatModifier>();
        }

        public Stat AttackRecharge => _attackRecharge;
    }
}
