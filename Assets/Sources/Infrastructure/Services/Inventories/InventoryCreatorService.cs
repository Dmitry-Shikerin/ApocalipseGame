using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.Inventories.Slots;
using Sources.InfrastructureInterfaces.Services.Inventories;
using Sources.Presentations.Views.Inventories.Slots;
using UnityEngine;

namespace Sources.Infrastructure.Services.Inventories
{
    public class InventoryCreatorService : IInventoryCreatorService
    {
        private readonly InventorySlotViewFactory _inventorySlotViewFactory;

        public InventoryCreatorService(
            InventorySlotViewFactory inventorySlotViewFactory)
        {
            _inventorySlotViewFactory = inventorySlotViewFactory ?? 
                                        throw new ArgumentNullException(nameof(inventorySlotViewFactory));
        }

        public Dictionary<Vector2Int, InventorySlot> Create(Vector2Int size,
            IEnumerable<InventorySlotView> slotViews, string ownerId)
        {
            if (slotViews == null) 
                throw new ArgumentNullException(nameof(slotViews));
            
            Dictionary<Vector2Int, InventorySlot> slots = new Dictionary<Vector2Int, InventorySlot>();

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    int index = i * size.y + j;
                    Vector2Int position = new Vector2Int(i, j);
                    
                    InventorySlot inventorySlot = new InventorySlot(position, ownerId);
                    InventorySlotView inventorySlotView = slotViews.ToList()[index];
                    _inventorySlotViewFactory.Create(inventorySlot, inventorySlotView);
                    
                    slots[position] = inventorySlot;
                }
            }

            return slots;
        }
    }
}