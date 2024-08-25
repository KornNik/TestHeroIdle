namespace Behaviours
{
    abstract class Death
    {
        private Health _health;
        private UnitEvents _unitEvents;
        private Unit _unit;

        public Death(Unit unit)
        {
            _unitEvents = unit.UnitEvents;
            _health = unit.UnitsAttributes.Health;
            _unit = unit;
            _unitEvents.HealthIsEnd += UnitDie;
        }
        ~Death()
        {
            _unitEvents.HealthIsEnd -= UnitDie;
        }

        protected virtual void UnitDie()
        {
            UnitLifeCycleEvent.Trigger(_unit, UnitCycleType.Dead);
            _unitEvents.Die?.Invoke();
        }
        protected virtual void UnitRevived()
        {
            UnitLifeCycleEvent.Trigger(_unit, UnitCycleType.Revive);
            _unitEvents.Revived?.Invoke();
        }
    }
}
