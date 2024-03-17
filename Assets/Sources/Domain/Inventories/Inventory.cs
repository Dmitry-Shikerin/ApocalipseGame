using System;
using System.Collections.Generic;
using Sources.Domain.Inventories.Dto;
using Sources.Domain.Inventories.Slots;
using Sources.DomainInterfaces.Items;
using UnityEngine;

namespace Sources.Domain.Inventories
{
    public class Inventory
    {
        private readonly Dictionary<Vector2Int, InventorySlot> _slots;

        private Vector2Int _size;

        public Inventory(Dictionary<Vector2Int, InventorySlot> slots, string ownerId)
        {
            _slots = slots;
            OwnerId = ownerId;
        }
        
        public event Action<Vector2Int> SizeChanged;

        public string OwnerId { get; }
        
        public Vector2Int Size
        {
            get => _size;
            set
            {
                if (_size != value) 
                    SizeChanged?.Invoke(value);
            }
        }

        public AddItemsResult AddItems(IInventoryItem item, int amount = 1)
        {
            int remainingAmount = amount;
            int itemsAddedToSlotsWithSameItemsAmount =
                AddToSlotWithSameItems(item, remainingAmount, out remainingAmount);

            if (remainingAmount <= 0)
                return new AddItemsResult(OwnerId, amount, itemsAddedToSlotsWithSameItemsAmount);

            int itemsAddedToAvailableSlotsAmount =
                AddToFirstAvailableSlots(item, remainingAmount, out remainingAmount);
            int addedItemsAmount = itemsAddedToSlotsWithSameItemsAmount + itemsAddedToAvailableSlotsAmount;

            return new AddItemsResult(OwnerId, amount, addedItemsAmount);
        }
        
        public AddItemsResult AddItems(Vector2Int slotCoords, IInventoryItem item, int amount = 1)
        {
            InventorySlot slot = _slots[slotCoords];
            int newValue = slot.Amount + amount;
            int itemsAddedAmount = 0;

            if (slot.IsEmpty)
                slot.Item = item;

            int itemSlotCapacity = item.Info.MaxItemsInInventorySlot;

            if (newValue > itemSlotCapacity)
            {
                int remainingItems = newValue - itemSlotCapacity;
                int itemsToAddAmount = itemSlotCapacity - slot.Amount;
                itemsAddedAmount += itemsToAddAmount;

                AddItemsResult result = AddItems(item, remainingItems);
                itemsAddedAmount += result.ItemsAddedAmount;
            }
            else
            {
                itemsAddedAmount = amount;
                slot.Amount = newValue;
            }

            return new AddItemsResult(OwnerId, amount, itemsAddedAmount);
        }

        public RemoveItemsResult RemoveItems(string itemId, int amount = 1)
        {
            if (!Has(itemId, amount))
                return new RemoveItemsResult(OwnerId, amount, false);

            int amountToRemove = amount;

            for (int i = 0; i < Size.x; i++)
            {
                for (int j = 0; j < Size.y; j++)
                {
                    Vector2Int slotCoords = new Vector2Int(i, j);
                    InventorySlot slot = _slots[slotCoords];

                    if (slot.ItemId != itemId)
                        continue;

                    if (amountToRemove > slot.Amount)
                    {
                        amountToRemove -= slot.Amount;
                        
                        RemoveItems(slotCoords, itemId, slot.Amount);
                    }
                    else
                    {
                        RemoveItems(slotCoords, itemId, amountToRemove);

                        return new RemoveItemsResult(OwnerId, amount, true);
                    }
                }
            }

            throw new InvalidOperationException("something went wrong, couldn't remove some items");
        }

        public RemoveItemsResult RemoveItems(Vector2Int slotCoords, string itemId, int amount = 1)
        {
            InventorySlot slot = _slots[slotCoords];

            if (slot.IsEmpty || slot.ItemId != itemId || slot.Amount < amount)
                return new RemoveItemsResult(OwnerId, amount, false);

            slot.Amount -= amount;

            if (slot.Amount == 0) 
                slot.ItemId = null;

            return new RemoveItemsResult(OwnerId, amount, true);
        }

        public int GetAmount(string itemId)
        {
            int amount = 0;
            IEnumerable<InventorySlot> slots = _slots.Values;

            foreach (InventorySlot slot in slots)
            {
                if (slot.ItemId == itemId) 
                    amount += slot.Amount;
            }

            return amount;
        }

        public bool Has(string itemId, int amount)
        {
            int amountExist = GetAmount(itemId);
            
            return amountExist >= amount;
        }

        public InventorySlot[,] GetSlots()
        {
            InventorySlot[,] array = new InventorySlot[Size.x, Size.y];

            for (int i = 0; i < Size.x; i++)
            {
                for (int j = 0; j < Size.y; j++)
                {
                    Vector2Int position = new Vector2Int(i, j);
                    array[i, j] = _slots[position];
                }
            }

            return array;
        }

        public void SwitchSlots(Vector2Int slotCoordsA, Vector2Int slotCoordsB)
        {
            InventorySlot slotA = _slots[slotCoordsA];
            InventorySlot slotB = _slots[slotCoordsB];
            string tempSlotItemId = slotA.ItemId;
            int tempSlotItemAmount = slotA.Amount;
            slotA.ItemId = slotB.ItemId;
            slotA.Amount = slotB.Amount;
            slotB.ItemId = tempSlotItemId;
            slotB.Amount = tempSlotItemAmount;
        }

        public void SetSize(Vector2Int newSize)
        {
            throw new NotImplementedException();
        }

        private int AddToSlotWithSameItems(IInventoryItem item, int amount, out int remainingAmount)
        {
            int itemsAddedAmount = 0;
            remainingAmount = amount;

            for (int i = 0; i < Size.x; i++)
            {
                for (int j = 0; j < Size.y; j++)
                {
                    Vector2Int coords = new Vector2Int(i, j);
                    InventorySlot slot = _slots[coords];

                    if (slot.IsEmpty)
                        continue;

                    int slotItemCapacity = GetItemSlotCapacity(slot.ItemId);

                    if (slot.Amount >= slotItemCapacity)
                        continue;

                    if (slot.Item != item)
                        continue;

                    int newValue = slot.Amount + remainingAmount;

                    if (newValue > slotItemCapacity)
                    {
                        remainingAmount = newValue - slotItemCapacity;
                        int itemsToAddAmount = slotItemCapacity - slot.Amount;
                        itemsAddedAmount += itemsToAddAmount;
                        slot.Amount = slotItemCapacity;

                        if (remainingAmount == 0)
                            return itemsAddedAmount;
                    }
                    else
                    {
                        itemsAddedAmount += remainingAmount;
                        slot.Amount = newValue;
                        remainingAmount = 0;

                        return itemsAddedAmount;
                    }
                }
            }

            return itemsAddedAmount;
        }
        
        private int AddToFirstAvailableSlots(IInventoryItem item, int amount, out int remainingAmount)
        {
            int itemsAddedAmount = 0;
            remainingAmount = amount;

            for (int i = 0; i < Size.y; i++)
            {
                for (int j = 0; j < Size.y; j++)
                {
                    Vector2Int coords = new Vector2Int(i, j);
                    InventorySlot slot = _slots[coords];

                    if (!slot.IsEmpty)
                        continue;

                    slot.Item = item;
                    int newValue = remainingAmount;
                    int slotItemCapacity = slot.Item.Info.MaxItemsInInventorySlot;

                    if (newValue > slotItemCapacity)
                    {
                        remainingAmount = newValue - slotItemCapacity;
                        int itemsToAddAmount = slotItemCapacity;
                        itemsAddedAmount += itemsToAddAmount;
                        slot.Amount = slotItemCapacity;
                    }
                    else
                    {
                        itemsAddedAmount += remainingAmount;
                        slot.Amount = newValue;
                        remainingAmount = 0;

                        return itemsAddedAmount;
                    }
                }
            }

            return itemsAddedAmount;
        }

        private void RemoveItemsFromSlot(Vector2Int slotCoords, string itemId, int slotAmount)
        {
            
        }

        private int GetItemSlotCapacity(string itemId)
        {
            return 99;
        }
    }
}