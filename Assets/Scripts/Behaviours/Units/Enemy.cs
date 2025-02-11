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
            _death = new EnemyDeath(this, _dropItemsData);
            _combat = new EnemyCombat(this);
            _stateController = new UnitStateController(this);

            _eventSubscription.AddEvent(_stateController);
            _eventSubscription.AddEvent(_death);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
        }
    }
}
