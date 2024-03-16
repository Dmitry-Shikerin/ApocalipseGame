﻿using System;
using UnityEngine;

namespace Sources.Domain.Inventories.Slots
{
    public class InventorySlot
    {
        private string _itemId;
        private int _amount;

        public InventorySlot(Vector2Int position)
        {
            Position = position;
        }

        public event Action<string> ItemIdChanged;
        public event Action<int> ItemAmountChanged;

        public Vector2Int Position { get; }
        
        public string ItemId
        {
            get => _itemId;
            set
            {
                if (_itemId != value)
                {
                    _itemId = value;
                    ItemIdChanged?.Invoke(value);
                }
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
                    ItemAmountChanged?.Invoke(value);
                }
            }
        }

        public bool IsEmpty => Amount == 0 && string.IsNullOrEmpty(ItemId);
    }
}