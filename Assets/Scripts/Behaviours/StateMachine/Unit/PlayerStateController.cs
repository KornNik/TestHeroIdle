namespace Behaviours
{
    sealed class PlayerStateController : UnitStateController
    {
        public PlayerStateController(Unit unitStateObject) : base(unitStateObject)
        {

        }

        public IState WeaponSwapState => GetState(UnitStateType.WeaponSwap);

        protected override void InitializeStates()
        {
            base.InitializeStates();
            _states.Add(UnitStateType.WeaponSwap, new WeaponSwapState(this));
            _states[UnitStateType.Recharge] = new PlayerRechargeState(this);
            _states[UnitStateType.Attack] = new PlayerAttackState(this);
        }
    }
}
