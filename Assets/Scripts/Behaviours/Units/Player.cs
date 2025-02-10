using Helpers;
using System;
using UnityEngine;

namespace Behaviours
{
    [Serializable]
    struct EquipmentSpritesData
    {
        public SpriteRenderer _bowSprite;
        public SpriteRenderer _arrowSprite;
        public SpriteRenderer _shieldSprite;
        public SpriteRenderer _swordSprite;
    }

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

            _subscribes.Add(_stateController);
            _subscribes.Add(_death);
            _subscribes.Add(_equipment);
            _subscribes.Add(_inventory);
        }
        protected override void OnEnable()
        {
            base.OnEnable();

            foreach (var subscriber in _subscribes)
            {
                subscriber.Subscribe();
            }
            this.EventStartListening<HealthResetEvent>();
        }
        protected override void OnDisable()
        {
            base.OnDisable();

            foreach (var subscriber in _subscribes)
            {
                subscriber.UnSubscribe();
            }
            this.EventStopListening<HealthResetEvent>();
        }
        public void OnEventTrigger(HealthResetEvent eventType)
        {
            UnitsAttributes.Health.ResetHealth();
        }
    }
}
