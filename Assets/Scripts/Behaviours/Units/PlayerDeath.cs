namespace Behaviours
{
    sealed class PlayerDeath : Death
    {
        public PlayerDeath(Unit unit) : base(unit)
        {
        }
        protected override void UnitDie()
        {
            base.UnitDie();
            GameEndEvent.Trigger(EndGameType.PlayerDead);
        }
        protected override void UnitRevived()
        {
            base.UnitRevived();
        }
    }
}
