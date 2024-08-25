namespace Behaviours
{
    abstract class UnitBaseState : IState
    {
        protected UnitStateController _stateController;

        public UnitBaseState(UnitStateController stateController)
        {
            _stateController = stateController;
        }

        public virtual void EnterState()
        {
        }
        public virtual void ExitState()
        {
        }
        public virtual void LogicFixedUpdate()
        {
        }
        public virtual void LogicUpdate()
        {
        }
        public void LogicLateUpdate()
        {
        }
    }
}

