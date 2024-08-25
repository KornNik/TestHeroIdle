using UnityEngine;
using Behaviours;

namespace Data
{
    [CreateAssetMenu(fileName ="EnemiesBundle",menuName ="Data/EnemiesBundle")]
    class EnemiesBundle : ScriptableObject
    {
        [SerializeField] private Unit[] _enemiesToSpawn;

        public Unit GetRandomEnemy()
        {
            var random = Random.Range(0, _enemiesToSpawn.Length);
            var enemy = _enemiesToSpawn[random];
            if(enemy != null)
            {
                return enemy;
            }
            throw new System.Exception("enemy is null");
        }
    }
}
