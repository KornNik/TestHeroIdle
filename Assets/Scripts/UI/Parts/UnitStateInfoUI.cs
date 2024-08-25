using UnityEngine;
using UnityEngine.UI;
using Data;
using Helpers;
using Behaviours;

namespace UI
{
    class UnitStateInfoUI : MonoBehaviour
    {
        [SerializeField] private Image _stateImage;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Unit _unitReference;

        private UnitStateImages _stateImages;
        private UnitEvents _unitEvents;

        private void Awake()
        {
            _unitEvents = _unitReference.UnitEvents;
            _stateImages = Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>();
        }

        private void OnEnable()
        {
            _unitEvents.RechargeTick += OnRechargeTick;
        }
        private void OnDisable()
        {
            _unitEvents.RechargeTick -= OnRechargeTick;
        }

        private void OnRechargeTick(UnitStateInfo unitStateInfo)
        {
            _fillImage.fillAmount = unitStateInfo.TimeLeft / unitStateInfo.TimeValue;
            _stateImage.sprite = unitStateInfo.StateSprite;
        }
    }
}
