using System;
using Sources.Domain.Inventories.Items.Info;
using Sources.Domain.Items;
using Sources.Domain.Items.Info;
using Sources.Domain.Items.States;
using Sources.Infrastructure.Services.WarmUpServices;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Domain.Items
{
    public class WoodPieFactory
    {
        private readonly AssetService<InventoryItemInfoProvider> _inventoryItemInfoProvider;

        public WoodPieFactory(AssetService<InventoryItemInfoProvider> inventoryItemInfoProvider)
        {
            _inventoryItemInfoProvider = inventoryItemInfoProvider ??
                                         throw new ArgumentNullException(nameof(inventoryItemInfoProvider));
        }

        public WoodPie Create()
        {
            // //TODO этот конфиг нужно загружать в одном местее
            InventoryItemInfoContainer inventoryItemInfoContainer = 
                Resources.Load<InventoryItemInfoContainer>(
                    "Configs/Items/Containers/InventoryItemInfoContainer");
            
            // InventoryItemInfo inventoryItemInfo = 
            //     _inventoryItemInfoProvider.Provider.InventoryItemInfoContainer.WoodPieItemInfo;
            InventoryItemInfo inventoryItemInfo = 
                inventoryItemInfoContainer.WoodPieItemInfo;
            
            return new WoodPie(inventoryItemInfo, new InventoryItemState());
        }
    }
}