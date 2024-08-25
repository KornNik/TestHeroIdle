namespace Behaviours
{
    sealed class EnemyDeath : Death
    {
        public EnemyDeath(Unit unit) : base(unit)
        {
        }
        protected override void UnitDie()
        {
            base.UnitDie();
            GameEndEvent.Trigger(EndGameType.EnemyDead);
        }
        protected override void UnitRevived()
        {
            base.UnitRevived();
        }
    }
}
