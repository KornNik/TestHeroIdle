namespace Behaviours
{
    sealed class Enemy : Unit
    {
        protected override void Awake()
        {
            base.Awake();
            _death = new EnemyDeath(this);
            _combat = new EnemyCombat(this);
            _stateController = new UnitStateController(this);
        }

    }
}
