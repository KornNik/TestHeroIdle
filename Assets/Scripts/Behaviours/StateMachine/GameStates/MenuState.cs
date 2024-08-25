using Helpers;
using UI;

namespace Behaviours
{
    sealed class MenuState : BaseState
    {
        public MenuState(GameStateController stateController) : base(stateController)
        {

        }
        public override void EnterState()
        {
            Services.Instance.LevelController.ServicesObject.LoadLevelMenu(0);
            ScreenInterface.GetInstance().Execute(ScreenTypes.MainMenu);
        }

        public override void ExitState()
        {
            Services.Instance.LevelController.ServicesObject.ClearLevelNonPLayer();
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