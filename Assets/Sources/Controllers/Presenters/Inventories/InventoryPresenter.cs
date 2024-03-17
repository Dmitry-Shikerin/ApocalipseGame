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

        public void AddItem(PointerEventData eventData, InventorySlotView fromSlot, InventorySlotView toSlot)
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

            if (fromSlot.OwnerId == _inventory.OwnerId)
            {
                _inventory.SwitchSlots(fromSlot.Position, toSlot.Position);
                Debug.Log("Inventory SwitchSlots");
            }

            if (fromSlot.OwnerId != _inventory.OwnerId && toSlot.OwnerId == _inventory.OwnerId)
            {
                _inventory.AddItems(toSlot.Position, fromSlot.InventoryItem, fromSlot.Amount);
                fromSlot.InventoryView.RemoveItems(fromSlot);
            }
        }

        public void AddItem()
        {
        }

        public void RemoveItems(InventorySlotView fromSlot)
        {
            _inventory.RemoveItems(fromSlot.Position, fromSlot.InventoryItem.Type, fromSlot.Amount);
        }
    }
}