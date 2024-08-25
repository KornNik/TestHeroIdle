using Helpers;

namespace Behaviours
{
    sealed class PlayerRechargeState : RechargeState, IEventListener<ChangeWeaponEvent>
    {
        private float _rechargeTimeExtra;
        private PlayerStateController _playerStateController;
        public PlayerRechargeState(PlayerStateController stateController) : base(stateController)
        {
            _playerStateController = stateController;
        }
        public override void EnterState()
        {
            base.EnterState();
            if(_stateController.GetPreviousState() is WeaponSwapState)
            {
                _currentRechargeLeft = _rechargeTimeExtra;
            }
            this.EventStartListening<ChangeWeaponEvent>();
        }
        public override void ExitState()
        {
            base.ExitState();
            this.EventStopListening<ChangeWeaponEvent>();
        }
        public void OnEventTrigger(ChangeWeaponEvent eventType)
        {
            if(eventType.ChangeEventType == ChangeEventType.ButtonDown)
            {
                _rechargeTimeExtra = _currentRechargeLeft;
                _stateController.ChangeState(_playerStateController.WeaponSwapState);
            }
        }
    }
}
