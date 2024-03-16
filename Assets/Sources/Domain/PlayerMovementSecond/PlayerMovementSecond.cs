using Sources.Domain.Upgraders;
using Sources.Utils.ObservablePropeties;

namespace Sources.Domain.PlayerMovementSecond
{
    public class PlayerMovementSecond
    {
        public PlayerMovementSecond(Upgrader upgrader)
        {
            CurrentLevelUpgrade = upgrader.CurrentLevelUpgrade;
        }

        public ObservableProperty<int> CurrentLevelUpgrade { get; private set; }

        public float Speed => 5 * CurrentLevelUpgrade.Value;
    }
}