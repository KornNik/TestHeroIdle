using Data;

namespace Behaviours
{
    class Attack
    {
        private AttackPowerAttributes _attackPowerAttributes;
        private AttackRechargeAttributes _attackRechargeAttributes;

        public Attack(AttackPowerAttributes attackPowerAttributes, AttackRechargeAttributes attackRechargeAttributes)
        {
            _attackPowerAttributes = attackPowerAttributes;
            _attackRechargeAttributes = attackRechargeAttributes;
        }

        public AttackPowerAttributes AttackPowerAttributes => _attackPowerAttributes;
        public AttackRechargeAttributes AttackRechargeAttributes => _attackRechargeAttributes;
    }
}
