using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class Player : Unit, IEventListener<HealthResetEvent>
    {
        [SerializeField] private EquipmentSpritesData _weaponsVisual;

        private Equipment _equipment;
        private Inventory _inventory;
        
        public Equipment Equipment  => _equipment;
        public EquipmentSpritesData WeaponsVisual => _weaponsVisual;

        protected override void Awake()
        {
            base.Awake();

            _inventory = new Inventory();
            _equipment = new Equipment(this);
            _death = new PlayerDeath(this);
            _combat = new PlayerCombat(this);
            _stateController = new PlayerStateController(this);

            _eventSubscription.AddEvent(_stateController);
            _eventSubscription.AddEvent(_death);
            _eventSubscription.AddEvent(_equipment);
            _eventSubscription.AddEvent(_inventory);
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            this.EventStartListening<HealthResetEvent>();
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            this.EventStopListening<HealthResetEvent>();
        }
        public void OnEventTrigger(HealthResetEvent eventType)
        {
            UnitsAttributes.Health.ResetHealth();
        }
    }
}
