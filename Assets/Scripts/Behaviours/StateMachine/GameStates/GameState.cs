using Controllers;
using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private CombatController _combatController;
        private EndLevel _endLevel;
        private DropItems _dropItems;
        private EventSubscriptionWraper _eventSubscription;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _eventSubscription = new EventSubscriptionWraper(2);
            _combatController = new CombatController();
            _endLevel = new EndLevel();
            _dropItems = new DropItems();

            _eventSubscription.AddEvent(_endLevel);
            _eventSubscription.AddEvent(_dropItems);
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);

            _eventSubscription.Subscribe();
            _combatController.StartCombat();
        }

        public override void ExitState()
        {
            _eventSubscription.UnSubscribe();
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
