using Helpers;

namespace Behaviours
{
    class GameStateController : BaseStateController, IEventListener<ChangeGameStateEvent>
    {
        private IState _menuState;
        private IState _pauseState;
        private IState _gameState;

        public GameStateController() : base()
        {
            StartState(MenuState);
            this.EventStartListening<ChangeGameStateEvent>();
        }
        ~GameStateController()
        {
            this.EventStopListening<ChangeGameStateEvent>();
        }

        public IState MenuState => _menuState;
        public IState PauseState => _pauseState;
        public IState GameState => _gameState;

        protected override void InitializeStates()
        {
            _menuState = new MenuState(this);
            _pauseState = new PauseState(this);
            _gameState = new GameState(this);
        }

        public void OnEventTrigger(ChangeGameStateEvent eventType)
        {
            switch (eventType.NextGameState)
            {
                case GameStateType.None:
                    throw new System.Exception("State is unknown");
                case GameStateType.ManuState:
                    ChangeState(_menuState);
                    break;
                case GameStateType.GameState:
                    ChangeState(_gameState);
                    break;
                case GameStateType.PauseState:
                    ChangeState(_pauseState);
                    break;
            }
        }
    }
}