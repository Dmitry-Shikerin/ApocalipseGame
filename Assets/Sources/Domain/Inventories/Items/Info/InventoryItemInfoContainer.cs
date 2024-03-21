using Sirenix.OdinInspector;
using Sources.Domain.Items.Info;
using UnityEngine;

namespace Sources.Domain.Inventories.Items.Info
{
    [CreateAssetMenu(
        fileName = "InventoryItemInfoContainer", 
        menuName = "Configs/InventoryItemInfoContainer", 
        order = 51)]
    public class InventoryItemInfoContainer : ScriptableObject
    {
        [Required] [SerializeField] private InventoryItemInfo _woodPieItemInfo;
        
        public InventoryItemInfo WoodPieItemInfo => _woodPieItemInfo;
    }
}