using System;
using Sources.Domain.Inventories.Items.Info;
using Sources.Domain.Items;
using Sources.Domain.Items.Info;
using Sources.Domain.Items.States;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.Infrastructure.Services.WarmUpServices.Concrete;
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
            InventoryItemInfo inventoryItemInfo = 
                _inventoryItemInfoProvider.Provider.InventoryItemInfoContainer.WoodPieItemInfo;
            
            return new WoodPie(inventoryItemInfo, new InventoryItemState());
        }
    }
}