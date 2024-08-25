using UnityEngine;
using UnityEngine.UI;
using Behaviours;

namespace GameUI
{
    class HealthUI : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;
        [SerializeField] private Unit _unitReference;

        private UnitEvents _unitsEvents;

        protected virtual void Awake()
        {
            _unitsEvents = _unitReference.UnitEvents;
        }
        protected virtual void OnEnable()
        {
            _unitsEvents.HealthChanged += UpdateObserver;
        }
        protected virtual void OnDisable()
        {
            _unitsEvents.HealthChanged -= UpdateObserver;
        }

        public virtual void UpdateObserver(HealthStruct info)
        {
            _healthImage.fillAmount = info.HealthRate;
        }
    }
}
