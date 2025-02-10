using Helpers;
using System.Collections.Generic;

namespace Behaviours
{
    class GameStateController : BaseStateController, IEventListener<ChangeGameStateEvent>
    {
        private Dictionary<GameStateType, IState> _states = new Dictionary<GameStateType, IState>(5);

        public GameStateController() : base()
        {
            StartState(GetState(GameStateType.LoadMenuLevelState));
            this.EventStartListening<ChangeGameStateEvent>();
        }
        ~GameStateController()
        {
            this.EventStopListening<ChangeGameStateEvent>();
        }

        protected override void InitializeStates()
        {
            _states.Clear();
            _states.Add(GameStateType.MenuState, new MenuState(this));
            _states.Add(GameStateType.InventoryState, new InventoryState(this));
            _states.Add(GameStateType.GameState, new GameState(this));
            _states.Add(GameStateType.ExitLevelState, new ExitLevelState(this));
            _states.Add(GameStateType.LoadGameLevelState, new LoadGameLevelState(this));
            _states.Add(GameStateType.LoadMenuLevelState, new LoadMenuLevelState(this));
        }

        private IState GetState(GameStateType gameState)
        {
            if (_states.ContainsKey(gameState))
            {
                var state = _states[gameState];
                return state;
            }
            return null;
        }

        public void OnEventTrigger(ChangeGameStateEvent eventType)
        {
            if(eventType.NextGameState == GameStateType.PreviouseState)
            {
                ChangeState(_previousState);
                return;
            }
            ChangeState(GetState(eventType.NextGameState));
        }

        public void Subscribe()
        {
            this.EventStartListening<ChangeGameStateEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<ChangeGameStateEvent>();
        }
    }
}