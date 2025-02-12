using Behaviours;

namespace Controllers
{
    class CombatController : ICombat
    {
        public void StartCombat(Unit player, Unit enemy)
        {
            SetTargets(player, enemy);
            ChangeUnitStateEvent.Trigger(UnitStateType.Recharge);
        }

        public void StopCombat()
        {
            ChangeUnitStateEvent.Trigger(UnitStateType.Deafult);
        }

        private void SetTargets(Unit player, Unit enemy)
        {
            player.Combat.SetTarget(enemy);
            enemy.Combat.SetTarget(player);
        }
    }
}