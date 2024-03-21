using System;
using Sources.DomainInterfaces.Items.Weapons;
using Sources.DomainInterfaces.Items.Weapons.Info;
using Sources.DomainInterfaces.Items.Weapons.States;

namespace Sources.Domain.Weapons
{
    public class Weapon : IWeapon
    {
        public Weapon(IWeaponInfo weaponInfo, IWeaponState weaponState)
        {
            WeaponInfo = weaponInfo ?? throw new ArgumentNullException(nameof(weaponInfo));
            WeaponState = weaponState ?? throw new ArgumentNullException(nameof(weaponState));
        }

        public IWeaponInfo WeaponInfo { get; }
        public IWeaponState WeaponState { get; }

        public void Attack()
        {
            
        }
    }
}