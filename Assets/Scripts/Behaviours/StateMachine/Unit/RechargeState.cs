using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    class RechargeState : UnitBaseState
    {
        protected float _rechargeTime;
        protected float _currentRechargeLeft;

        public RechargeState(UnitStateController stateController) : base(stateController)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            _rechargeTime = _stateController.StateObject.UnitsAttributes
                .Attack.AttackRechargeAttributes.AttackRecharge.CurrentValue;
            _currentRechargeLeft = _rechargeTime;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_currentRechargeLeft > 0)
            {
                _currentRechargeLeft -= Time.deltaTime;
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_rechargeTime, _currentRechargeLeft,
                    Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().RechargeSprite));
            }
            else
            {
                _currentRechargeLeft = 0;
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_rechargeTime, 0,
                    Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().RechargeSprite));
                _stateController.ChangeState(_stateController.AttackState);
            }
        }
    }
}
