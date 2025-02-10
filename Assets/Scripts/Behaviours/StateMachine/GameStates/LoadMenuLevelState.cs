namespace Behaviours
{
    sealed class LoadMenuLevelState : LoadLevelState
    {
        public LoadMenuLevelState(GameStateController stateController) 
            : base(stateController)
        {

        }

        protected override void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelMenu(0);
        }
        protected override void StartNeededState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.MenuState);
        }
    }
}
