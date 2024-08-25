using Data;

namespace Behaviours
{
    struct HealthStruct
    {
        public float HealthRate;
        public float CurrentHealth;

        public HealthStruct(float healthRate, float currentHealth)
        {
            HealthRate = healthRate;
            CurrentHealth = currentHealth;
        }
        public HealthStruct SetValues(float healthRate, float currentHealth)
        {
            HealthRate = healthRate;
            CurrentHealth = currentHealth;
            return this;
        }
    }
    class Health
    {
        private HealthAttributes _healthAttributes;
        private Unit _unit;

        private HealthStruct _healthStruct;
        private UnitEvents _unitEvents;

        public Health(Unit unitReference, HealthAttributes healthAttributes)
        {
            _unitEvents = unitReference.UnitEvents;
            _healthAttributes = healthAttributes;
            _unit = unitReference;
            _healthStruct = new HealthStruct(GetHealthRate(), _healthAttributes.Health);
        }

        public void TakeDamage(float damage)
        {
            if (_healthAttributes.Health > 0)
            {
                var damagedHealth = _healthAttributes.Health - 
                    (damage / _unit.UnitsAttributes.Armor.ArmorAttributes.Armor.CurrentValue);
                if(damagedHealth > 0)
                {
                    _healthAttributes.SetHealth(damagedHealth);
                }
                else
                {
                    _healthAttributes.SetHealth(0);
                    _unitEvents.HealthIsEnd?.Invoke();
                }
                _unitEvents.HealthChanged?.Invoke(_healthStruct.SetValues(GetHealthRate(), _healthAttributes.Health));
            }
        }
        public void TakeHeal(float heal)
        {
            if (_healthAttributes.Health < _healthAttributes.MaxHealth.CurrentValue)
            {
                var healedHealth = _healthAttributes.Health + heal;
                if (healedHealth <= _healthAttributes.MaxHealth.CurrentValue)
                {
                    _healthAttributes.SetHealth(healedHealth);
                }
                else
                {
                    _healthAttributes.SetHealth(_healthAttributes.MaxHealth.CurrentValue);
                }
                _unitEvents.HealthChanged?.Invoke(_healthStruct.SetValues(GetHealthRate(), _healthAttributes.Health));
            }
        }
        public void ResetHealth()
        {
            _healthAttributes.SetHealth(_healthAttributes.MaxHealth.CurrentValue);
            _unitEvents.HealthChanged?.Invoke(_healthStruct.SetValues(GetHealthRate(), _healthAttributes.Health));
        }
        public float GetHealthRate()
        {
            var healthRate = _healthAttributes.Health / _healthAttributes.MaxHealth.CurrentValue;
            return healthRate;
        }
        public float GetMaxHealth()
        {
            var maxHealth = _healthAttributes.MaxHealth.CurrentValue;
            return maxHealth;
        }
    }
}
