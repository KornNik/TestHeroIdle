using Controllers;
using Helpers;
using System.Collections.Generic;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private CombatController _combatController;
        private EndLevel _endLevel;
        private DropItems _dropItems;

        private List<ISubscriber> _subscribers;
        public GameState(GameStateController stateController) : base(stateController)
        {
            _subscribers = new List<ISubscriber>();
            _combatController = new CombatController();
            _endLevel = new EndLevel();
            _dropItems = new DropItems();

            _subscribers.Add(_endLevel);
            _subscribers.Add(_dropItems);
        }

        public override void EnterState()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Subscribe();
            }
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            _combatController.StartCombat();
        }

        public override void ExitState()
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.UnSubscribe();
            }
            _combatController.StopCombat();
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }
    }
}
