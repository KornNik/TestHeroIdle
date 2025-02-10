using Data;
using UnityEngine;

namespace Behaviours
{
    sealed class Enemy : Unit
    {
        [SerializeField] private EnemiesDropItemsData _dropItemsData;

        protected override void Awake()
        {
            base.Awake();
            _death = new EnemyDeath(this);
            _combat = new EnemyCombat(this);
            _stateController = new UnitStateController(this);

            _subscribes.Add(_stateController);
            _subscribes.Add(_death);
        }
        protected override void OnEnable()
        {
            base.OnEnable();

            foreach (var item in _subscribes)
            {
                item.Subscribe();
            }
            _unitEvents.Die += DropItemOnDeath;
        }
        protected override void OnDisable()
        {
            base.OnDisable();

            foreach (var item in _subscribes)
            {
                item.UnSubscribe();
            }
            _unitEvents.Die -= DropItemOnDeath;
        }

        private void DropItemOnDeath()
        {
            var item = _dropItemsData.GetRandomItem();
            ItemDropedEvent.Trigger(ItemDropedType.Droped, item, transform.position);
        }
    }
}
