using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Inventories;
using Sources.Domain.Inventories.Items;
using Sources.Domain.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.Inventories;
using Sources.Infrastructure.Factories.Views.Inventories.Items;
using Sources.Infrastructure.Factories.Views.Inventories.Slots;
using Sources.InfrastructureInterfaces.Services.Inventories;
using Sources.Presentations.Ui.Huds;
using Sources.Presentations.Views.Inventories.Slots;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.GameInventories
{
    public class PlayerInventoryViewFactory
    {
        private readonly Hud _hud;
        private readonly InventoryViewFactory _inventoryViewFactory;
        private readonly IInventoryCreatorService _inventoryCreatorService;
        private readonly InventorySlotViewFactory _inventorySlotViewFactory;
        private readonly InventoryItemViewFactory _inventoryItemViewFactory;

        public PlayerInventoryViewFactory(
            Hud hud,
            InventoryViewFactory inventoryViewFactory,
            IInventoryCreatorService inventoryCreatorService,
            InventorySlotViewFactory inventorySlotViewFactory,
            InventoryItemViewFactory inventoryItemViewFactory)
        {
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
            _inventoryViewFactory = inventoryViewFactory ?? throw new ArgumentNullException(nameof(inventoryViewFactory));
            _inventoryCreatorService = inventoryCreatorService ?? 
                                       throw new ArgumentNullException(nameof(inventoryCreatorService));
            _inventorySlotViewFactory = inventorySlotViewFactory ?? throw new ArgumentNullException(nameof(inventorySlotViewFactory));
            _inventoryItemViewFactory = inventoryItemViewFactory ?? throw new ArgumentNullException(nameof(inventoryItemViewFactory));
        }

        public Inventory Create()
        {
            // Dictionary<Vector2Int, InventorySlot> slots = _inventoryCreatorService.Create(
            //     new Vector2Int(4, 3), _hud.PlayerInventoryView.InventorySlotViews);
            
            Vector2Int size = new Vector2Int(4, 3);
            Dictionary<Vector2Int, InventorySlot> slots = new Dictionary<Vector2Int, InventorySlot>();

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    int index = i * size.y + j;
                    Vector2Int position = new Vector2Int(i, j);
                    
                    InventorySlot inventorySlot = new InventorySlot(position, "player");
                    InventorySlotView inventorySlotView = _hud.PlayerInventoryView.InventorySlotViews.ToList()[index];
                    InventorySlotView lotInventorySlotView = _hud.PlayerLootInventoryView.InventorySlotViews.ToList()[index];
                    _inventorySlotViewFactory.Create(inventorySlot, inventorySlotView);
                    _inventorySlotViewFactory.Create(inventorySlot, lotInventorySlotView);
                    
                    InventoryItem inventoryItem = new InventoryItem();
                    _inventoryItemViewFactory.Create(inventoryItem, inventorySlotView.InventoryItemView);
                    _inventoryItemViewFactory.Create(inventoryItem, lotInventorySlotView.InventoryItemView);

                    slots[position] = inventorySlot;
                }
            }
            
            Inventory inventory = new Inventory(slots, "player");
            _inventoryViewFactory.Create(inventory, _hud.PlayerInventoryView);
            
            _inventoryViewFactory.Create(inventory, _hud.PlayerLootInventoryView);

            return inventory;
        }
    }
}