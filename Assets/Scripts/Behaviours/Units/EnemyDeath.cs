using Data;

namespace Behaviours
{
    sealed class EnemyDeath : Death
    {
        private EnemiesDropItemsData _dropItemsData;

        public EnemyDeath(Unit unit, EnemiesDropItemsData dropItemsData) : base(unit)
        {
            _dropItemsData = dropItemsData;
        }
        protected override void UnitDie()
        {
            base.UnitDie();
            var item = _dropItemsData.GetRandomItem();
            ItemDropedEvent.Trigger(ItemDropedEventType.Droped, item, _unit.transform.position);
        }
        protected override void UnitRevived()
        {
            base.UnitRevived();
        }
    }
}
