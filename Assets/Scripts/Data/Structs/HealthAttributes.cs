using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct HealthAttributes
    {
        private float _health;
        private Stat _maxHealth;

        private List<StatModifier> _healthStatModifiers;

        public HealthAttributes(HealthData healthData)
        {
            _health = healthData.MaxHealth;
            _maxHealth = new Stat(healthData.MaxHealth);
            _healthStatModifiers = new List<StatModifier>();
        }

        public float Health => _health;
        public Stat MaxHealth => _maxHealth;

        public void SetHealth(float health)
        {
            _health = health;
        }
    }
}
