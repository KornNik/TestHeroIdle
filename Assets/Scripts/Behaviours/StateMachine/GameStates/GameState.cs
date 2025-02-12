using Controllers;
using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private EndLevel _endLevel;
        private DropItems _dropItems;
        private UnitsGameController _unitsGameController;
        private EventSubscriptionWraper _eventSubscription;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _eventSubscription = new EventSubscriptionWraper(2);
            _unitsGameController = new UnitsGameController();
            _endLevel = new EndLevel();
            _dropItems = new DropItems();

            _eventSubscription.AddEvent(_endLevel);
            _eventSubscription.AddEvent(_dropItems);
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            _unitsGameController.EnterState();
            _eventSubscription.Subscribe();
        }

        public override void ExitState()
        {
            _eventSubscription.UnSubscribe();
            _unitsGameController.ExitState();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _unitsGameController.LogicUpdate();
        }
        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
            _unitsGameController.LogicFixedUpdate();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
            _unitsGameController.LogicLateUpdate();
        }
    }
}
