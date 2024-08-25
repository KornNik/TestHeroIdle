using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    class AttackState : UnitBaseState
    {
        protected float _attackTime;
        protected float _currentAttackTimeLeft;

        public AttackState(UnitStateController stateController) : base(stateController)
        {

        }
        public override void EnterState()
        {
            base.EnterState();
            _stateController.StateObject.Combat.StartAttack();
            _attackTime = _stateController.StateObject.UnitsAttributes.Attack.AttackRechargeAttributes.AttackRecharge.CurrentValue;
            _currentAttackTimeLeft = _attackTime;
        }
        public override void ExitState()
        {
            base.ExitState();
            _stateController.StateObject.Combat.EndAttack();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            AttackLogick();
        }

        protected virtual void AttackLogick()
        {
            if (_currentAttackTimeLeft > 0)
            {
                _currentAttackTimeLeft -= Time.deltaTime;
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_attackTime, _currentAttackTimeLeft, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().AttackSprite));
            }
            else
            {
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_attackTime, 0, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().AttackSprite));
                _stateController.ChangeState(_stateController.RechargeState);
            }
        }
    }
}
