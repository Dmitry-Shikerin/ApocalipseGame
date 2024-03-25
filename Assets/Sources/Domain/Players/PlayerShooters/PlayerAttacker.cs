using System.Threading;
using Sources.DomainInterfaces.Players.Weapons;

namespace Sources.Domain.Players.PlayerShooters
{
    public class PlayerAttacker
    {
        public PlayerAttacker(IWeapon weapon)
        {
            Weapon = weapon;
        }
        
        IWeapon Weapon { get; }

        public void Attack(CancellationToken cancellationToken)
        {
            Weapon.AttackAsync(cancellationToken);
        }
    }
}