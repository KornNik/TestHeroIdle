using Helpers;

namespace Behaviours
{
    class Equipment : IEventListener<ChangeWeaponEvent>
    {
        private Weapon _meleeWeapon;
        private Weapon _rangeWeapon;

        private Weapon _currentWeapon;
        private EquipmentSpritesData _spriteData;

        public Equipment(Player unit)
        {
            _meleeWeapon = new Weapon(unit, WeaponType.Melee);
            _rangeWeapon = new Weapon(unit, WeaponType.Range);
            _currentWeapon = _meleeWeapon;
            _spriteData = unit.WeaponsVisual;
            SetVisualsWeapons(_currentWeapon.Type);

            this.EventStartListening<ChangeWeaponEvent>();
        }
        ~Equipment() 
        {
            this.EventStopListening<ChangeWeaponEvent>();
        }

        private void ChangeCurrentWeapon()
        {
            if (ReferenceEquals(_currentWeapon, _meleeWeapon))
            {
                _currentWeapon = _rangeWeapon;

            }
            else
            {
                _currentWeapon = _meleeWeapon;
            }
            SetVisualsWeapons(_currentWeapon.Type);
        }

        public Weapon GetCurrentWeapon()
        {
            if(!ReferenceEquals(_currentWeapon, null))
            {
                return _currentWeapon;
            }
            throw new System.Exception($"current weapon is null");
        }
        private void SetVisualsWeapons(WeaponType weaponType)
        {
            if(weaponType == WeaponType.Melee)
            {
                _spriteData._shieldSprite.enabled = true;
                _spriteData._swordSprite.enabled = true;
                _spriteData._arrowSprite.enabled = false;
                _spriteData._bowSprite.enabled = false;
            }
            else if (weaponType == WeaponType.Range)
            {
                _spriteData._shieldSprite.enabled = false;
                _spriteData._swordSprite.enabled = false;
                _spriteData._arrowSprite.enabled = true;
                _spriteData._bowSprite.enabled = true;
            }
        }

        public void OnEventTrigger(ChangeWeaponEvent eventType)
        {
            if (eventType.ChangeEventType == ChangeEventType.ChangeWeapon)
            {
                ChangeCurrentWeapon();
            }
        }
    }
}