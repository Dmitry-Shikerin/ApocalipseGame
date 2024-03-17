using System.Collections.Generic;
using Sources.Domain.Inventories.Slots;
using Sources.Presentations.Views.Inventories.Slots;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Inventories
{
    public interface IInventoryCreatorService
    {
        Dictionary<Vector2Int, InventorySlot> Create(Vector2Int size,
            IEnumerable<InventorySlotView> slotViews, string ownerId);
    }
}