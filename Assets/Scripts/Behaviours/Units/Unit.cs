using Data;
using UnityEngine;

namespace Behaviours
{
    abstract class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField] private UnitData _unitData;
        [SerializeField] private UnitAnimation _animation;
        [SerializeField] private UnitSounds _sounds;

        protected Death _death;
        protected Combat _combat;
        protected UnitEvents _unitEvents;
        protected UnitAttributes _unitsAttributes;
        protected UnitStateController _stateController;

        public Death Death => _death;
        public Combat Combat => _combat;
        public UnitSounds Sounds => _sounds;
        public UnitEvents UnitEvents => _unitEvents;
        public UnitAttributes UnitsAttributes => _unitsAttributes;
        public UnitStateController StateController => _stateController;

        protected virtual void OnEnable()
        {
        }
        protected virtual void OnDisable()
        {
        }
        protected virtual void Awake()
        {
            _unitEvents = new UnitEvents();
            _unitsAttributes = new UnitAttributes(this, _unitData);;
            _animation.enabled = true;
        }
        private void Update()
        {
            _stateController.Update();
        }
        private void FixedUpdate()
        {
            _stateController.FixedUpdate();
        }
        private void LateUpdate()
        {
            _stateController.LateUpdate();
        }

        public void ReceiveDamage(float damage)
        {
            UnitsAttributes.Health.TakeDamage(damage);
        }
    }
}
