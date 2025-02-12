using Behaviours;

namespace Controllers
{
    interface ICombat
    {
        void StartCombat(Unit player, Unit enemy);
        void StopCombat();
    }
}
