using System;
using System.Collections.Generic;
using Sources.Domain.Inventories;
using Sources.Domain.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.Inventories;
using Sources.InfrastructureInterfaces.Services.Inventories;
using Sources.Presentations.Ui.Huds;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.GameInventories
{
    public class LootInventoryViewFactory
    {
        private readonly InventoryViewFactory _inventoryViewFactory;
        private readonly IInventoryCreatorService _inventoryCreatorService;
        private readonly Hud _hud;

        public LootInventoryViewFactory(
                Hud hud,
                InventoryViewFactory inventoryViewFactory,
                IInventoryCreatorService inventoryCreatorService)
        {
            _inventoryViewFactory = inventoryViewFactory ?? 
                                    throw new ArgumentNullException(nameof(inventoryViewFactory));
            _inventoryCreatorService = inventoryCreatorService ?? 
                                       throw new ArgumentNullException(nameof(inventoryCreatorService));
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
        }

        public Inventory Create(string ownerId)
        {
            Dictionary<Vector2Int, InventorySlot> slots = _inventoryCreatorService.Create(
                new Vector2Int(4, 3), _hud.LootInventoryView.InventorySlotViews, ownerId);
            
            Inventory inventory = new Inventory(slots, ownerId);
            _inventoryViewFactory.Create(inventory, _hud.LootInventoryView);
            
            return inventory;
        }
    }
}