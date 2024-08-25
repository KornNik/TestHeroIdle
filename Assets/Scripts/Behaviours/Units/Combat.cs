using Data;

namespace Behaviours
{
    enum WeaponType
    {
        None,
        Melee,
        Range
    }
    class Combat : IAttacker
    {
        protected Unit _opponent;
        protected UnitEvents _events;
        protected UnitSounds _sounds;

        public Combat(Unit unitReference)
        {
            _events = unitReference.UnitEvents;
            _sounds = unitReference.Sounds;
        }

        public void EndAttack()
        {
            _events.AttackFinished?.Invoke();
        }
        public void PerformAttack()
        {
            if(!ReferenceEquals(_opponent, null))
            {
                AttackTarget();
            }
        }
        public virtual void StartAttack()
        {
            _events.AttackStarted?.Invoke(WeaponType.Melee);
            MakeSoundEvent.Trigger(new SoundEventInfo(_sounds.AttackSound,
                _opponent.transform.position, 1f, true));
        }

        public void SetTarget(Unit target)
        {
            _opponent = target;
        }

        protected virtual void AttackTarget()
        {
            MakeSoundEvent.Trigger(new SoundEventInfo(_sounds.HitSound,
                _opponent.transform.position, 1f, true));
        }
    }
}
