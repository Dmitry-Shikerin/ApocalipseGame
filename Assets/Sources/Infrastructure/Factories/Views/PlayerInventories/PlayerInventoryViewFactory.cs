using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Inventories;
using Sources.Domain.Inventories.Items;
using Sources.Domain.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.Inventories;
using Sources.Infrastructure.Factories.Views.Inventories.Items;
using Sources.Infrastructure.Factories.Views.Inventories.Slots;
using Sources.Presentations.Ui.Huds;
using Sources.Presentations.Views.Inventories.Slots;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.PlayerInventories
{
    public class PlayerInventoryViewFactory
    {
        private readonly Hud _hud;
        private readonly InventorySlotViewFactory _inventorySlotViewFactory;
        private readonly InventoryItemViewFactory _inventoryItemViewFactory;
        private readonly InventoryViewFactory _inventoryViewFactory;

        public PlayerInventoryViewFactory(
            Hud hud,
            InventorySlotViewFactory inventorySlotViewFactory,
            InventoryItemViewFactory inventoryItemViewFactory,
            InventoryViewFactory inventoryViewFactory)
        {
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
            _inventorySlotViewFactory = inventorySlotViewFactory ?? throw new ArgumentNullException(nameof(inventorySlotViewFactory));
            _inventoryItemViewFactory = inventoryItemViewFactory ?? throw new ArgumentNullException(nameof(inventoryItemViewFactory));
            _inventoryViewFactory = inventoryViewFactory ?? throw new ArgumentNullException(nameof(inventoryViewFactory));
        }

        public Inventory Create()
        {
            Dictionary<Vector2Int, InventorySlot> slots = new Dictionary<Vector2Int, InventorySlot>();

            Vector2Int size = new Vector2Int(4, 3);

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    int index = i * size.y + j;
                    Vector2Int position = new Vector2Int(i, j);
                    
                    InventorySlot inventorySlot = new InventorySlot(position);
                    InventorySlotView inventorySlotView = _hud.InventoryView.InventorySlotViews.ToList()[index];
                    _inventorySlotViewFactory.Create(inventorySlot, inventorySlotView);
                    
                    InventoryItem inventoryItem = new InventoryItem();
                    _inventoryItemViewFactory.Create(inventoryItem, inventorySlotView.InventoryItemView);

                    slots[position] = inventorySlot;
                }
            }

            Inventory inventory = new Inventory(slots, "player");
            _inventoryViewFactory.Create(inventory, _hud.InventoryView);

            return inventory;
        }
    }
}