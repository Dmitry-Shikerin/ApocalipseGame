using Sources.Utils.ObservablePropeties;

namespace Sources.Domain.Upgraders
{
    public class Upgrader
    {
        public Upgrader(UpgradeData upgradeData, UpgradeConfig upgradeConfig) 
            : this(upgradeConfig.MaxLevel, upgradeData.CurrentLevel)
        {
            
        }
        
        public Upgrader(UpgradeConfig upgradeConfig) : this(upgradeConfig.MaxLevel, 1)
        {
        }
        
        private Upgrader(int maxLevel, int currentLevel)
        {
            MaxLevel = maxLevel;
            CurrentLevelUpgrade = new ObservableProperty<int>(currentLevel);
        }

        public ObservableProperty<int> CurrentLevelUpgrade { get; private set; }
        public int MaxLevel { get; }
    }
}