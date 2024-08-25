using Helpers.Managers;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Animator))]
    sealed class UnitAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _unitAnimator;
        [SerializeField] private Unit _unitReference;

        private readonly int _attack = Animator.StringToHash(AnimationsName.ATTACK);
        private readonly int _attackRange = Animator.StringToHash(AnimationsName.ATTACK_RANGE);
        private readonly int _cancel = Animator.StringToHash(AnimationsName.CANCEL);
        private readonly int _attackSpeedMulty = Animator.StringToHash(AnimationsName.ATTACK_MULTY);
        private readonly int _death = Animator.StringToHash(AnimationsName.DEATH);
        private readonly int _revive = Animator.StringToHash(AnimationsName.REVIVE);
        private readonly int _weaponSwap = Animator.StringToHash(AnimationsName.WEAPON_SWAP);

        private void OnEnable()
        {
            Subscribe();
        }
        private void OnDisable()
        {
            UnSubscribe();
        }

        public void SetSpeed(float speed)
        {
            _unitAnimator.speed = speed;
        }
        public void OnExecuteAttack()
        {
            _unitReference.Combat.PerformAttack();
        }

        private void OnUnitAttack(WeaponType weaponType)
        {
            if (weaponType == WeaponType.Melee)
            {
                _unitAnimator.SetTrigger(_attack);
            }
            else
            {
                _unitAnimator.SetTrigger(_attackRange);
            }
        }
        private void OnUnitCancel()
        {
            _unitAnimator.SetTrigger(_cancel);
        }
        private void OnUnitDie()
        {
            _unitAnimator.SetTrigger(_death);
        }
        private void OnUnitRevived()
        {
            _unitAnimator.SetTrigger(_revive);
        }
        private void OnUnitWeaponSwap()
        {
            _unitAnimator.SetTrigger(_weaponSwap);
        }
        private void OnUnitAttackSpeedMulty(float speedValue)
        {
            _unitAnimator.SetFloat(_attackSpeedMulty, speedValue);
        }
        private void Subscribe()
        {
            _unitReference.UnitEvents.Die += OnUnitDie;
            _unitReference.UnitEvents.Revived += OnUnitRevived;
            _unitReference.UnitEvents.AttackStarted += OnUnitAttack;
            _unitReference.UnitEvents.AttackFinished += OnUnitCancel;
            _unitReference.UnitEvents.WeaponSwap += OnUnitWeaponSwap;
        }
        private void UnSubscribe()
        {
            _unitReference.UnitEvents.Die -= OnUnitDie;
            _unitReference.UnitEvents.Revived -= OnUnitRevived;
            _unitReference.UnitEvents.AttackStarted -= OnUnitAttack;
            _unitReference.UnitEvents.AttackFinished -= OnUnitCancel;
            _unitReference.UnitEvents.WeaponSwap += OnUnitWeaponSwap;
        }
    }
}
