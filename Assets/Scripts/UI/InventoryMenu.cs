using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class InventoryMenu : BaseUI
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private InventoryUI _inventoryUI;


        private void OnEnable()
        {
            _backButton.onClick.AddListener(OnBackButtonDown);
        }
        private void OnDisable()
        {
            _backButton.onClick.RemoveListener(OnBackButtonDown);
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

        private void OnBackButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.PreviouseState);
        }
    }
}
