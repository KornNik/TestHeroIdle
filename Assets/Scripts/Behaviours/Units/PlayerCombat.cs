namespace Behaviours
{
    sealed class PlayerCombat : Combat
    {
        private Equipment _equipment;

        public PlayerCombat(Unit unitReference) : base(unitReference)
        {
            _equipment = (unitReference as Player).Equipment;
        }

        public override void StartAttack()
        {
            _events.AttackStarted?.Invoke(_equipment.GetCurrentWeapon().Type);
            MakeSoundEvent.Trigger(new SoundEventInfo(_sounds.AttackSound,
                _opponent.transform.position, 1f, true));
        }

        protected override void AttackTarget()
        {
            base.AttackTarget();
            _equipment.GetCurrentWeapon().InflictDamage(_opponent);
        }
    }
}
