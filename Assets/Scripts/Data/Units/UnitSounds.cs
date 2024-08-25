using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="UnitSound",menuName ="Data/Units/Sounds")]
    sealed class UnitSounds : ScriptableObject
    {
        [SerializeField] private AudioClip _hitSound;
        [SerializeField] private AudioClip _attackSound;

        public AudioClip HitSound => _hitSound;
        public AudioClip AttackSound => _attackSound;
    }
}
