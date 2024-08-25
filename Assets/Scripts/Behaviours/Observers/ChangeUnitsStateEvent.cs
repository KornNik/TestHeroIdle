using Helpers;

namespace Behaviours
{
    enum UnitStateType
    {
        None,
        Attack,
        Recharge,
        WeaponSwap,
        Deafult
    }
    struct ChangeUnitStateEvent
    {
        private static ChangeUnitStateEvent _changeUnitStateEvent;

        private UnitStateType _nextUnitState;

        public UnitStateType NextUnitState => _nextUnitState;

        public static void Trigger(UnitStateType nextUnitState)
        {
            _changeUnitStateEvent._nextUnitState = nextUnitState;
            EventManager.TriggerEvent(_changeUnitStateEvent);
        }
    }
}