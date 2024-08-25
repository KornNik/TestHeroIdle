using UnityEngine;
using Data;
using Helpers;
using Behaviours;
using Helpers.Extensions;
using Helpers.AssetsPath;

namespace Controllers
{
    sealed class LevelLoader : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransformPosition;
        [SerializeField] private Transform _enemyTransformPosition;
        [SerializeField] private Transform _levelVisualTransformPosition;

        private Unit _enemy;
        private Unit _player;
        private GameObject _level;
        private LevelData _levelData;

        private void Awake()
        {

        }
        public void LoadLevelGame(int index)
        {
            ClearLevelNonPLayer();
            LoadLevelVisuals(index);
            LoadEnemy();
        }
        public void LoadLevelMenu(int index)
        {
            ClearLevelNonPLayer();
            LoadLevelVisuals(index);
            LoadPlayer();
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                Destroy(_level.gameObject);
                _level = null;
            }
            if (!ReferenceEquals(_enemy, null))
            {
                Destroy(_enemy.gameObject);
                _enemy = null;
            }
            if (!ReferenceEquals(_player, null))
            {
                Destroy(_player.gameObject);
                _player = null;
            }
        }
        public void ClearLevelNonPLayer()
        {
            if (!ReferenceEquals(_level, null))
            {
                Destroy(_level.gameObject);
                _level = null;
            }
            if (!ReferenceEquals(_enemy, null))
            {
                Destroy(_enemy.gameObject);
                _enemy = null;
            }
        }

        private void LoadLevelVisuals(int index)
        {
            _levelData = Services.Instance.DatasBundle.ServicesObject.GetData<LevelsBundle>().GetRandomLevelData();
            _level = Instantiate(_levelData.GetPrefab(), _levelData.GetLevelPosition(), Quaternion.identity, _levelVisualTransformPosition);
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
            _player = Instantiate(playerResource, Vector3.zero, Quaternion.identity, _playerTransformPosition);
            _player.transform.localPosition = Vector3.zero;
            _player.transform.localRotation = Quaternion.identity;

            Services.Instance.Player.SetObject(_player as Player);
        }
        private void LoadEnemy()
        {
            var enemyResource = Services.Instance.DatasBundle.ServicesObject.GetData<EnemiesBundle>().GetRandomEnemy();
            _enemy = Instantiate(enemyResource, _enemyTransformPosition);
            _enemy.transform.localPosition = Vector3.zero;
            _enemy.transform.localRotation = Quaternion.identity;

            Services.Instance.Enemy.SetObject(_enemy as Enemy);
        }
    }
}
