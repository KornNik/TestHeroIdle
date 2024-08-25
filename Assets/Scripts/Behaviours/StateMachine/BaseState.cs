namespace Behaviours
{
    abstract class BaseState : IState
    {
        protected BaseStateController _stateController;

        public BaseState(BaseStateController stateController)
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
