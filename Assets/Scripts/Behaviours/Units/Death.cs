namespace Behaviours
{
    abstract class Death: IEventSubscription
    {
        protected Unit _unit;
        protected Health _health;
        protected UnitEvents _unitEvents;

        public Death(Unit unit)
        {
            _unitEvents = unit.UnitEvents;
            _health = unit.UnitsAttributes.Health;
            _unit = unit;
        }

        public void Subscribe()
        {
            _unitEvents.HealthIsEnd += UnitDie;
        }

        public void UnSubscribe()
        {
            _unitEvents.HealthIsEnd -= UnitDie;
        }

        protected virtual void UnitDie()
        {
            _unitEvents.Die?.Invoke();
            UnitLifeCycleEvent.Trigger(_unit, UnitCycleType.Dead);
        }
        protected virtual void UnitRevived()
        {
            _unitEvents.Revived?.Invoke();
            UnitLifeCycleEvent.Trigger(_unit, UnitCycleType.Revive);
        }
    }
}
