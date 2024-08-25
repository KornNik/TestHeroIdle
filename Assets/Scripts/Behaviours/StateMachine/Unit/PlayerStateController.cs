namespace Behaviours
{
    sealed class PlayerStateController : UnitStateController
    {
        private IState _weaponSwapState;

        public PlayerStateController(Unit unitStateObject) : base(unitStateObject)
        {

        }

        public IState WeaponSwapState => _weaponSwapState;

        protected override void InitializeStates()
        {
            base.InitializeStates();
            _weaponSwapState = new WeaponSwapState(this);
            _rechargeState =  new PlayerRechargeState(this);
            _attackState = new PlayerAttackState(this);
        }

        protected override void ChangeStateByType(UnitStateType stateType)
        {
            base.ChangeStateByType(stateType);
            switch (stateType)
            {
                case UnitStateType.WeaponSwap:
                    ChangeState(_weaponSwapState);
                    break;
            }
        }
    }
}
