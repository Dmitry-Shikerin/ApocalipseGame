using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine.EventSystems;

namespace Sources.PresentationsInterfaces.Views.Inventories.Items
{
    public interface IInventoryItemView : IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        IInventorySlotView InventorySlotView { get; }
    }
}