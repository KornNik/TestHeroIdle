namespace Behaviours
{
    sealed class LoadGameLevelState : LoadLevelState
    {

        public LoadGameLevelState(GameStateController stateController) 
            : base(stateController)
        {

        }
        protected override void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelGame(0);
        }
        protected override void StartNeededState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
