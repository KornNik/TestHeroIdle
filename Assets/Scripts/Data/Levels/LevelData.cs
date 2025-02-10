using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="LevelData",menuName ="Data/Level/LevelData")]
    class LevelData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private GameObject _levelPrefab;
        [SerializeField] private Vector3 _levelPosition;
        [SerializeField] private Vector3 _playerPosition;
        [SerializeField] private Vector3 _playerRotation;
        [SerializeField] private Vector3 _enemyPosition;

        public string GetName()
        {
            return _name;
        }
        public GameObject GetPrefab()
        {
            return _levelPrefab;
        }
        public Vector3 GetLevelPosition()
        {
            return _levelPosition;
        }
        public Vector3 GetEnemyPosition()
        {
            return _enemyPosition;
        }
        public Vector3 GetPlayerPosition()
        {
            return _playerPosition;
        }
        public Vector3 GetPlayerRotation()
        {
            return _playerRotation;
        }
    }
}
