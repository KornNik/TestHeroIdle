using Behaviours;
using Helpers;

namespace Controllers
{
    class CombatController : ICombat
    {
        public void StartCombat()
        {
            SetTargets();
            ChangeUnitStateEvent.Trigger(UnitStateType.Recharge);
        }

        public void StopCombat()
        {
            ChangeUnitStateEvent.Trigger(UnitStateType.Deafult);
        }

        private void SetTargets()
        {
            Services.Instance.Player.ServicesObject.Combat.SetTarget(Services.Instance.Enemy.ServicesObject);
            Services.Instance.Enemy.ServicesObject.Combat.SetTarget(Services.Instance.Player.ServicesObject);
        }
    }
}