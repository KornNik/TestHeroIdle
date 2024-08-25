using Helpers;

namespace Behaviours
{
    enum EndGameType
    {
        None,
        PlayerDead,
        EnemyDead
    }
    struct GameEndEvent
    {
        private static GameEndEvent _gameEndEvent;

        private EndGameType _endGameType;

        public EndGameType EndGameType  => _endGameType;

        public static void Trigger(EndGameType endGameType)
        {
            _gameEndEvent._endGameType = endGameType;
            EventManager.TriggerEvent(_gameEndEvent);
        }
    }
}
