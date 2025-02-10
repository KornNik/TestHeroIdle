using Helpers;

namespace Behaviours
{
    class EndLevel : IEventListener<GameEndEvent>, ISubscriber
    {
        public EndLevel() 
        {
           
        }
        public void OnEventTrigger(GameEndEvent eventType)
        {
            if (eventType.EndGameType == EndGameType.PlayerDead)
            {
                ChangeGameStateEvent.Trigger(GameStateType.MenuState);
            }
            else if(eventType.EndGameType == EndGameType.EnemyDead)
            {
                ChangeGameStateEvent.Trigger(GameStateType.GameState);
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
