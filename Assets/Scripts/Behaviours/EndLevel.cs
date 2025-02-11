using Helpers;

namespace Behaviours
{
    class EndLevel : IEventListener<GameEndEvent>, IEventSubscription
    {
        public EndLevel() 
        {
           
        }
        public void OnEventTrigger(GameEndEvent eventType)
        {
            if (eventType.EndGameType == EndGameType.PlayerDead)
            {
                ChangeGameStateEvent.Trigger(GameStateType.LoadMenuLevelState);
            }
            else if (eventType.EndGameType == EndGameType.RefreshLevel)
            {
                ChangeGameStateEvent.Trigger(GameStateType.LoadGameLevelState);
            }
        }

        public void Subscribe()
        {
            this.EventStartListening<GameEndEvent>();
        }

        public void UnSubscribe()
        {
            this.EventStopListening<GameEndEvent>();
        }
    }
}
