using UI;

namespace Behaviours
{
    class InventoryState : BaseState
    {
        public InventoryState(GameStateController stateController) : base(stateController)
        {

        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.InventoryMenu);
        }

        public override void ExitState()
        {
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }

        private void EndState()
        {
        }
    }
}