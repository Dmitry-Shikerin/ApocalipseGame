using System;
using Sources.Domain.Inventories.Slots;
using Sources.DomainInterfaces.Items;
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
        public string OwnerId => _inventorySlot.OwnerId;
        public IInventoryItem InventoryItem => _inventorySlot.Item;

        public override void Enable()
        {
            OnItemAmountChanged();
            OnItemIdChanged();
            OnItemSpriteChanged();
            
            _inventorySlot.ItemChanged += OnItemIdChanged;
            _inventorySlot.ItemAmountChanged += OnItemAmountChanged;
        }

        public override void Disable()
        {
            _inventorySlot.ItemChanged -= OnItemIdChanged;
            _inventorySlot.ItemAmountChanged -= OnItemAmountChanged;
        }

        private void OnItemAmountChanged()
        {
            _inventorySlotView.AmountText.Set(_inventorySlot.Amount.ToString());
            _inventorySlotView.Amount = _inventorySlot.Amount;
            
            OnItemSpriteChanged();
        }

        private void OnItemIdChanged()
        {
            if (_inventorySlot.Item == null)
            {
                _inventorySlotView.IdText.Set("");
                _inventorySlotView.Id = "";
                
                return;
            }
            
            string id = _inventorySlot.Item.Info.ID;
            
            _inventorySlotView.IdText.Set(id);
            _inventorySlotView.Id = id;
            
            OnItemSpriteChanged();
        }

        private void OnItemSpriteChanged()
        {
            if (_inventorySlot.Item == null)
            {
                _inventorySlotView.Image.sprite = null;
                _inventorySlotView.Image.color = Color.clear;
                
                return;
            }
            
            _inventorySlotView.Image.color = Color.white;
            _inventorySlotView.Image.sprite = _inventorySlot.Item.Info.SpriteIcon;
        }
    }
}