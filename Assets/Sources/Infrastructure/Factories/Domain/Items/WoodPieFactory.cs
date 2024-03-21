using Sources.Domain.Inventories.Items.Info;
using Sources.Domain.Items;
using Sources.Domain.Items.Info;
using Sources.Domain.Items.States;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Domain.Items
{
    public class WoodPieFactory
    {
        public WoodPie Create()
        {
            //TODO этот конфиг нужно загружать в одном местее
            InventoryItemInfoContainer inventoryItemInfoContainer = 
                Resources.Load<InventoryItemInfoContainer>(
                    "Configs/Items/Containers/InventoryItemInfoContainer");

            InventoryItemInfo inventoryItemInfo = inventoryItemInfoContainer.WoodPieItemInfo;
            
            return new WoodPie(inventoryItemInfo, new InventoryItemState());
        }
    }
}