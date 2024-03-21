using System;
using Sources.Domain.Inventories;
using Sources.Domain.Inventories.Dto;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories;
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
            if (fromSlot.OwnerId == _inventory.OwnerId && fromSlot.Id != toSlot.Id)
            {
                _inventory.SwitchSlots(fromSlot.Position, toSlot.Position);
                
                return;
            }

            if (fromSlot.OwnerId == _inventory.OwnerId && fromSlot.Id == toSlot.Id)
            {
                AddItemsResult result = _inventory.AddItems(toSlot.Position, fromSlot.InventoryItem, fromSlot.Amount);
                _inventory.RemoveItems(fromSlot.Position, fromSlot.InventoryItem.Type, result.ItemsAddedAmount);
                
                return;
            }

            if (fromSlot.OwnerId != _inventory.OwnerId && toSlot.OwnerId == _inventory.OwnerId)
            {
                _inventory.AddItems(toSlot.Position, fromSlot.InventoryItem, fromSlot.Amount);
                fromSlot.InventoryView.RemoveItems(fromSlot);
                
                return;
            }
        }

        public void RemoveItems(InventorySlotView fromSlot)
        {
            _inventory.RemoveItems(fromSlot.Position, fromSlot.InventoryItem.Type, fromSlot.Amount);
        }
    }
}