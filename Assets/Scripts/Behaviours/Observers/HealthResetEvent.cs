using Helpers;

namespace Behaviours
{
    struct HealthResetEvent 
    {
        private static HealthResetEvent _healthResetEvent;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_healthResetEvent);
        }
    }
}