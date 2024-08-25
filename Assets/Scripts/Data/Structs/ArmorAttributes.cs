using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct ArmorAttributes
    {
        private Stat _armor;
        private List<StatModifier> _armorStatModifiers;

        public ArmorAttributes(ArmorData armorData)
        {
            _armor = new Stat(armorData.BaseArmor);
            _armorStatModifiers = new List<StatModifier>();
        }

        public Stat Armor => _armor;
    }
}
