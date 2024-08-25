using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class MainMenu : BaseUI
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _resetHealthButton;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartButtonDown);
            _resetHealthButton.onClick.AddListener(OnResetHealthButtonDown);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartButtonDown);
            _resetHealthButton.onClick.RemoveListener(OnResetHealthButtonDown);
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
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
        private void OnResetHealthButtonDown()
        {
            HealthResetEvent.Trigger();
        }
    }
}