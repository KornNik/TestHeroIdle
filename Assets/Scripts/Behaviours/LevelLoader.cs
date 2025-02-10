using UnityEngine;
using Data;
using Helpers;
using Behaviours;
using Helpers.Extensions;
using Helpers.AssetsPath;

namespace Controllers
{
    sealed class LevelLoader : ILevelLoader
    {
        private Unit _enemy;
        private Unit _player;
        private GameObject _level;
        private LevelData _levelData;

        public void LoadLevelGame(int index)
        {
            ClearLevelNonPLayer();
            LoadLevelVisuals();
            LoadEnemy();
        }
        public void LoadLevelMenu(int index)
        {
            ClearLevelNonPLayer();
            LoadLevelVisuals();
            LoadPlayer();
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                GameObject.Destroy(_level.gameObject);
                _level = null;
            }
            if (!ReferenceEquals(_enemy, null))
            {
                GameObject.Destroy(_enemy.gameObject);
                _enemy = null;
            }
            if (!ReferenceEquals(_player, null))
            {
                GameObject.Destroy(_player.gameObject);
                _player = null;
            }
        }
        public void ClearLevelNonPLayer()
        {
            if (!ReferenceEquals(_level, null))
            {
                GameObject.Destroy(_level.gameObject);
                _level = null;
            }
            if (!ReferenceEquals(_enemy, null))
            {
                GameObject.Destroy(_enemy.gameObject);
                _enemy = null;
            }
        }

        private void LoadLevelVisuals()
        {
            _levelData = Services.Instance.DatasBundle.ServicesObject.GetData<LevelsBundle>().GetRandomLevelData();
            _level = GameObject.Instantiate(_levelData.GetPrefab(), _levelData.GetLevelPosition(), Quaternion.identity);
            _level.transform.localPosition = Vector3.zero;
            _level.transform.localRotation = Quaternion.identity;
        }
        private void LoadUnits()
        {
            LoadPlayer();
            LoadEnemy();
        }
        private void LoadPlayer()
        {
            if (_player != null) return;

            var playerResource = CustomResources.Load<Unit>(ResourcesPathManager.PLAYER_UNIT);
            _player = GameObject.Instantiate(playerResource, Vector3.zero, Quaternion.identity);
            _player.transform.SetLocalPositionAndRotation(_levelData.GetPlayerPosition(),
                Quaternion.Euler(_levelData.GetPlayerRotation()));

            Services.Instance.Player.SetObject(_player as Player);
        }
        private void LoadEnemy()
        {
            var enemyResource = Services.Instance.DatasBundle.ServicesObject.GetData<EnemiesBundle>().GetRandomEnemy();
            _enemy = GameObject.Instantiate(enemyResource, Vector3.zero, Quaternion.identity);
            _enemy.transform.localPosition = _levelData.GetEnemyPosition();
            _enemy.transform.localRotation = Quaternion.identity;

            Services.Instance.Enemy.SetObject(_enemy as Enemy);
        }
    }
    internal interface ILevelLoader
    {
        void LoadLevelGame(int index);
        void LoadLevelMenu(int index);
        void ClearLevelFull();
        void ClearLevelNonPLayer();
    }
}
