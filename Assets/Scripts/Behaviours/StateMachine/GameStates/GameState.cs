using Controllers;
using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private CombatController _combatController;
        private EndLevel _endLevel;
        public GameState(GameStateController stateController) : base(stateController)
        {
            _combatController = new CombatController();
            _endLevel = new EndLevel();
        }

        public override void EnterState()
        {
            Services.Instance.LevelController.ServicesObject.LoadLevelGame(0);
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            _combatController.StartCombat();
        }

        public override void ExitState()
        {
            Services.Instance.LevelController.ServicesObject.ClearLevelNonPLayer();
            _combatController.StopCombat();
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
