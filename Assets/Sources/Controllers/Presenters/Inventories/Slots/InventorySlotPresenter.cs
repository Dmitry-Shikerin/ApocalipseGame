using System;
using Sources.Domain.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine;

namespace Sources.Controllers.Presenters.Inventories.Slots
{
    public class InventorySlotPresenter : PresenterBase
    {
        private readonly InventorySlot _inventorySlot;
        private readonly IInventorySlotView _inventorySlotView;

        public InventorySlotPresenter(InventorySlot inventorySlot, IInventorySlotView inventoryView)
        {
            _inventorySlot = inventorySlot ?? throw new ArgumentNullException(nameof(inventorySlot));
            _inventorySlotView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
        }

        public Vector2Int Position => _inventorySlot.Position;

        public override void Enable()
        {
            _inventorySlot.ItemIdChanged += OnItemIdChanged;
            _inventorySlot.ItemAmountChanged += OnItemAmountChanged;
        }

        public override void Disable()
        {
            _inventorySlot.ItemIdChanged -= OnItemIdChanged;
            _inventorySlot.ItemAmountChanged -= OnItemAmountChanged;
        }

        private void OnItemAmountChanged(int amount)
        {
            _inventorySlotView.AmountText.Set(amount.ToString());
            _inventorySlotView.Amount = amount;
        }

        private void OnItemIdChanged(string itemId)
        {
            _inventorySlotView.IdText.Set(itemId);
            _inventorySlotView.Id = itemId;
        }
    }
}