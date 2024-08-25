using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerAttackState : AttackState, IEventListener<ChangeWeaponEvent>
    {
        private UniTask _waitForEndAttack;
        private bool _isNextWeaponSwap;
        private PlayerStateController _playerStateController;

        public PlayerAttackState(PlayerStateController stateController) : base(stateController)
        {
            _playerStateController = stateController;
        }
        public override void EnterState()
        {
            base.EnterState();
            _isNextWeaponSwap = false;
            this.EventStartListening<ChangeWeaponEvent>();
        }
        public override void ExitState()
        {
            base.ExitState();
            this.EventStopListening<ChangeWeaponEvent>();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        protected override void AttackLogick()
        {
            if (_currentAttackTimeLeft > 0)
            {
                _currentAttackTimeLeft -= Time.deltaTime;
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_attackTime, _currentAttackTimeLeft, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().AttackSprite));
            }
            else
            {
                if (_isNextWeaponSwap)
                {
                    _isNextWeaponSwap = false;
                    _stateController.ChangeState(_playerStateController.WeaponSwapState);
                }
                else
                {
                    _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                        (new UnitStateInfo(_attackTime, 0, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().AttackSprite));
                    _stateController.ChangeState(_stateController.RechargeState);
                }
            }
        }

        private void WeaponSwapSwitchFlag()
        {
            _isNextWeaponSwap = true;
        }

        public void OnEventTrigger(ChangeWeaponEvent eventType)
        {
            if (eventType.ChangeEventType == ChangeEventType.ButtonDown)
            {
                Debug.Log("SawpButton");
                WeaponSwapSwitchFlag();
            }
        }
    }
}
