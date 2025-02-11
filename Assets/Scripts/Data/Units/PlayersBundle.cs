using UnityEngine;
using Behaviours;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayersBundle", menuName = "Data/Units/PlayersBundle")]
    sealed class PlayersBundle : ScriptableObject
    {
        [SerializeField] private Unit[] _playersToSpawn;

        public Unit GetFirstUnit()
        {
            if (_playersToSpawn.Length == 0) return null;
            var result = _playersToSpawn[0];
            return result;
        }
    }
}
