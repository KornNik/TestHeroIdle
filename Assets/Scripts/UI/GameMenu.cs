using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{ 
    sealed class GameMenu : BaseUI
    {
        [SerializeField] private Button _returnButton;
        [SerializeField] private Button _changeEquipButton;

        private void OnEnable()
        {
            _returnButton.onClick.AddListener(OnReturnButton);
            _changeEquipButton.onClick.AddListener(OnChangeEquipButtonDown);
        }
        private void OnDisable()
        {
            _returnButton.onClick.RemoveListener(OnReturnButton);
            _changeEquipButton.onClick.RemoveListener(OnChangeEquipButtonDown);
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void OnReturnButton()
        {
            ChangeGameStateEvent.Trigger(GameStateType.ManuState);
        }
        private void OnChangeEquipButtonDown()
        {
            ChangeWeaponEvent.Trigger(ChangeEventType.ButtonDown);
        }
    }
}