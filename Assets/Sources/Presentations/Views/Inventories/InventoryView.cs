using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Inventories;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.Presentations.Views.Inventories
{
    public class InventoryView : PresentableView<InventoryPresenter>, IInventoryView
    {
        [Required] [SerializeField] private List<InventorySlotView> _inventorySlotViews;

        public IEnumerable<InventorySlotView> InventorySlotViews => _inventorySlotViews;

        public void AddItem(PointerEventData eventData, InventorySlotView fromSlot, InventorySlotView toSlot)
        {
            Presenter.AddItem(eventData, fromSlot, toSlot);
        }

        public void RemoveItems(InventorySlotView fromSlot)
        {
            Presenter.RemoveItems(fromSlot);
        }
    }
}