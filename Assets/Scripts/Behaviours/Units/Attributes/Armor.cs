using Data;

namespace Behaviours
{
    class Armor
    {
        private ArmorAttributes _armorAttributes;

        public Armor(ArmorAttributes armorAttributes)
        {
            _armorAttributes = armorAttributes;
        }

        public ArmorAttributes ArmorAttributes => _armorAttributes;
    }
}
