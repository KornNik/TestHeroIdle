using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    class WeaponSwapState : UnitBaseState
    {
        private float _weaponSwapDelay = 2f;
        private float _weaponSpawCurrentDelay;
        private PlayerStateController _playerStateController;
        public WeaponSwapState(PlayerStateController stateController) : base(stateController)
        {
            _playerStateController = stateController;
        }
        public override void EnterState()
        {
            base.EnterState();
            _weaponSpawCurrentDelay = _weaponSwapDelay;
            ChangeWeaponEvent.Trigger(ChangeEventType.ChangeWeapon);
            _playerStateController.StateObject.UnitEvents.WeaponSwap?.Invoke();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_weaponSpawCurrentDelay > 0)
            {
                _weaponSpawCurrentDelay -= Time.deltaTime;
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_weaponSwapDelay, _weaponSpawCurrentDelay, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().WeaponSwapSprite));
            }
            else
            {
                _weaponSpawCurrentDelay = 0;
                _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
                    (new UnitStateInfo(_weaponSwapDelay, 0, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().WeaponSwapSprite));
                _stateController.ChangeState(_stateController.RechargeState);
            }
        }
    }
}
