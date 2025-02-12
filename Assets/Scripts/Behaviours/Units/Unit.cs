using Data;
using UnityEngine;

namespace Behaviours
{
    abstract class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitData _unitData;
        [SerializeField] private UnitAnimation _animation;
        [SerializeField] private UnitSounds _sounds;
        [SerializeField] private Transform _model;

        protected Death _death;
        protected Combat _combat;
        protected UnitEvents _unitEvents;
        protected UnitAttributes _unitsAttributes;
        protected UnitStateController _stateController;

        protected EventSubscriptionWraper _eventSubscription;

        public Death Death => _death;
        public Combat Combat => _combat;
        public Transform Model => _model;
        public UnitSounds Sounds => _sounds;
        public UnitEvents UnitEvents => _unitEvents;
        public UnitAttributes UnitsAttributes => _unitsAttributes;
        public UnitStateController StateController => _stateController;

        protected virtual void Awake()
        {
            _eventSubscription = new EventSubscriptionWraper(5);
            _unitEvents = new UnitEvents();
            _unitsAttributes = new UnitAttributes(this, _unitData);;
            _animation.enabled = true;
        }
        protected virtual void OnEnable()
        {
            _eventSubscription.Subscribe();
        }
        protected virtual void OnDisable()
        {
            _eventSubscription.UnSubscribe();
        }

        public void ReceiveDamage(float damage)
        {
            UnitsAttributes.Health.TakeDamage(damage);
        }
    }
}
