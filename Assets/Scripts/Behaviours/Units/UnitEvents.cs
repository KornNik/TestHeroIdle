using System;

namespace Behaviours
{
    class UnitEvents
    {
        public Action Die;
        public Action Revived;
        public Action WeaponSwap;
        public Action HealthIsEnd;
        public Action AttackFinished;
        public Action<WeaponType> AttackStarted;
        public Action<HealthStruct> HealthChanged;
        public Action<UnitStateInfo> RechargeTick;
    }
}
