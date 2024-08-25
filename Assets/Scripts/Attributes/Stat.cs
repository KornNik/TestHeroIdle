using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Attributes
{
    [Serializable]
    class Stat
    {
        public Action OnStatChanged;

        public readonly float BaseValue;
        public readonly ReadOnlyCollection<StatModifier> Modifiers;

        protected readonly List<StatModifier> _modifiers;
        protected readonly StatsCalculator _statsCalculator;

        protected float _currentValue;

        public virtual float CurrentValue => _currentValue;

        public Stat()
        {
            _modifiers = new List<StatModifier>();
            Modifiers = _modifiers.AsReadOnly();
        }
        public Stat(float baseValue) : this()
        {
            BaseValue = baseValue;
            _currentValue = baseValue;
            _statsCalculator = new StatsCalculator(_modifiers, BaseValue);
        }
        public virtual void AddModifier(StatModifier modifier)
        {
            if (modifier.Value != 0)
            {
                _modifiers.Add(modifier);
                _modifiers.Sort(delegate (StatModifier a, StatModifier b)
                {
                    return a.Order.CompareTo(b.Order);
                });
                _currentValue = CalculateFinalValue();
            }
            OnStatChanged?.Invoke();
        }
        public virtual void RemoveModifier(StatModifier modifier)
        {
            if (modifier.Value != 0)
            {
                _modifiers.Remove(modifier);
                _currentValue = CalculateFinalValue();
            }
            OnStatChanged?.Invoke();
        }
        public virtual void RemoveAllModifiers()
        {
            if (_modifiers.Count != 0)
            {
                _modifiers.Clear();
                _currentValue = CalculateFinalValue();
            }
            OnStatChanged?.Invoke();
        }
        protected virtual float CalculateFinalValue()
        {
            float calculatedValue = BaseValue;
            calculatedValue = _statsCalculator.CalculateStat();
            return calculatedValue;
        }
    }
}
