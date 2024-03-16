using System.Collections.Generic;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;

namespace Sources.PresentationsInterfaces.Views.Inventories
{
    public interface IInventoryView
    {
        IEnumerable<InventorySlotView> InventorySlotViews { get; }
    }
}