using Helpers;

namespace Behaviours
{
    enum ChangeEventType
    {
        None,
        ButtonDown,
        ChangeWeapon
    }
    struct ChangeWeaponEvent
    {
        private static ChangeWeaponEvent _changeWeaponEvent;

        private ChangeEventType _changeEventType;

        public ChangeEventType ChangeEventType => _changeEventType;

        public static void Trigger(ChangeEventType changeEventType)
        {
            _changeWeaponEvent._changeEventType = changeEventType;
            EventManager.TriggerEvent(_changeWeaponEvent);
        }
    }
}