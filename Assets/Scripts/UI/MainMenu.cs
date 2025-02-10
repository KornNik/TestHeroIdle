using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class MainMenu : BaseUI
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _resetHealthButton;
        [SerializeField] private Button _inventoryButton;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartButtonDown);
            _resetHealthButton.onClick.AddListener(OnResetHealthButtonDown);
            _inventoryButton.onClick.AddListener(OnInventoryButtonDown);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartButtonDown);
            _resetHealthButton.onClick.RemoveListener(OnResetHealthButtonDown);
            _inventoryButton.onClick.RemoveListener(OnInventoryButtonDown);
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

        private void OnStartButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.LoadGameLevelState);
        }
        private void OnResetHealthButtonDown()
        {
            HealthResetEvent.Trigger();
        }
        private void OnInventoryButtonDown()
        {
            ScreenInterface.GetInstance().Execute(Helpers.ScreenTypes.InventoryMenu);
        }
    }
}