using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct AttributeCharacteristics
    {
        private Stat _stat;
        private List<StatModifier> _statModifiers;

        public AttributeCharacteristics(float statValue)
        {
            _stat = new Stat(statValue);
            _statModifiers = new List<StatModifier>();
        }

        public Stat Stat => _stat;
    }
}
