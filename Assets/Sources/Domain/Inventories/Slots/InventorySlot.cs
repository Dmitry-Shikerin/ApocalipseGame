using System;
using Sources.DomainInterfaces.Items;
using UnityEngine;

namespace Sources.Domain.Inventories.Slots
{
    public class InventorySlot
    {
        private string _itemId;
        private int _amount;
        private IInventoryItem _item;

        public InventorySlot(Vector2Int position, string ownerId)
        {
            Position = position;
            OwnerId = ownerId;
        }

        public event Action ItemChanged;
        public event Action ItemAmountChanged;

        public Vector2Int Position { get; }
        public string OwnerId { get; }

        public IInventoryItem Item
        {
            get => _item;
            set
            {
                _item = value;
                Debug.Log($"Item add {Position}");
                ItemChanged?.Invoke();
            }
        }

        public int Amount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    ItemAmountChanged?.Invoke();
                }
            }
        }

        //TODO нужно не забыть длеать этот айтем нал
        public bool IsEmpty => Amount == 0 && Item == null;
    }
}