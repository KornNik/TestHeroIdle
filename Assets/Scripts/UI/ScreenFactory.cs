using UnityEngine;
using Helpers;
using Helpers.Extensions;
using Data;

namespace UI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameMenu _gameMenu;
        private MainMenu _mainMenu;
        private InventoryMenu _inventoryMenu;
        private LoadingScreen _loadingScreen;

        private DataResourcePrefabs _dataPrefabs;


        public ScreenFactory()
        {
            _dataPrefabs = Services.Instance.DataResourcePrefabs.ServicesObject;

            var resources = _dataPrefabs.GetScreenPrefab(ScreenTypes.Canvas);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity).GetComponent<Canvas>();
        }

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = _dataPrefabs.GetScreenPrefab(ScreenTypes.GameMenu);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<GameMenu>();
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = _dataPrefabs.GetScreenPrefab(ScreenTypes.MainMenu);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<MainMenu>();
            }
            return _mainMenu;
        }
        public InventoryMenu GetInventoryMenu()
        {
            if (_inventoryMenu == null)
            {
                var resources = _dataPrefabs.GetScreenPrefab(ScreenTypes.InventoryMenu);
                _inventoryMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<InventoryMenu>();
            }
            return _inventoryMenu;
        }
        public LoadingScreen GetLoadingScreen()
        {
            if (_loadingScreen == null)
            {
                var resources = _dataPrefabs.GetScreenPrefab(ScreenTypes.LoadingScreen);
                _loadingScreen = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<LoadingScreen>();
            }
            return _loadingScreen;
        }
    }
}