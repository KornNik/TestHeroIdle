using Helpers;

namespace Behaviours
{
    class EndLevel : IEventListener<GameEndEvent>
    {
        public EndLevel() 
        {
            this.EventStartListening<GameEndEvent>();
        }
        ~EndLevel()
        {
            this.EventStopListening<GameEndEvent>();
        }
        public void OnEventTrigger(GameEndEvent eventType)
        {
            if (eventType.EndGameType == EndGameType.PlayerDead)
            {
                ChangeGameStateEvent.Trigger(GameStateType.ManuState);
            }
            else if(eventType.EndGameType == EndGameType.EnemyDead)
            {
                ChangeGameStateEvent.Trigger(GameStateType.GameState);
            }
        }
    }
}
