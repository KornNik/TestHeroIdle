using Controllers;
using Helpers;

namespace Behaviours
{
    class UnitsGameController : IState
    {
        private Unit _player;
        private Unit _enemy;

        private CombatController _combatController;

        public UnitsGameController()
        {
            _combatController = new CombatController();
        }

        public void EnterState()
        {
            _player = Services.Instance.Player.ServicesObject;
            _enemy = Services.Instance.Enemy.ServicesObject;
            _combatController.StartCombat(_player, _enemy);
        }
        public void ExitState()
        {
            _combatController.StopCombat();
        }
        public void LogicUpdate()
        {
            _player.StateController.Update();
            _enemy.StateController.Update();
        }
        public void LogicFixedUpdate()
        {
            _player.StateController.FixedUpdate();
            _enemy.StateController.FixedUpdate();
        }
        public void LogicLateUpdate()
        {
            _player.StateController.LateUpdate();
            _enemy.StateController.LateUpdate();
        }
    }
}
