using Sources.DomainInterfaces.Items.Weapons.Info;
using Sources.DomainInterfaces.Items.Weapons.States;

namespace Sources.DomainInterfaces.Items.Weapons
{
    public interface IWeapon
    {
        IWeaponInfo WeaponInfo { get; }
        IWeaponState WeaponState { get; }
    }
}