using Helpers;

namespace Behaviours
{
    enum UnitCycleType
    {
        None,
        Revive,
        Dead
    }
    struct UnitLifeCycleEvent
    {
        private static UnitLifeCycleEvent _unitLifeCycleEvent;

        private UnitCycleType _unitCycleType;
        private Unit _unit;

        public UnitCycleType UnitCycleType => _unitCycleType;
        public Unit Unit => _unit;

        public static void Trigger(Unit unit, UnitCycleType unitCycleType)
        {
            _unitLifeCycleEvent._unit = unit;
            _unitLifeCycleEvent._unitCycleType = unitCycleType;
            EventManager.TriggerEvent(_unitLifeCycleEvent);
        }
    }
}
