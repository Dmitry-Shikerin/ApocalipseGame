using System;
using Sources.Domain.Inventories;
using Sources.Presentations.Views.Inventories.Items;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.Controllers.Presenters.Inventories
{
    public class InventoryPresenter : PresenterBase
    {
        private readonly Inventory _inventory;
        private readonly IInventoryView _inventoryView;

        public InventoryPresenter(Inventory inventory, IInventoryView inventoryView)
        {
            _inventory = inventory ?? throw new ArgumentNullException(nameof(inventory));
            _inventoryView = inventoryView;
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }

        public void AddItem(PointerEventData eventData, InventorySlotView inventorySlotView)
        {
            // if(eventData.pointerDrag.TryGetComponent(out InventorySlotView inventorySlotView) == false)
            //     return;

            // InventoryItemView inventoryItemView = eventData.pointerDrag.GetComponent<InventoryItemView>();
            // IInventorySlotView inventorySlotView = inventoryItemView.InventorySlotView;

            // _inventory.AddItems(
            //     inventorySlotView.Position,
            //     inventorySlotView.Id,
            //     inventorySlotView.Amount);
            //
            Debug.Log("Inventory Add");
        }

        public void AddItem()
        {
            
        }
    }
}