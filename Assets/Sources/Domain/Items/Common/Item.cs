using System;
using Sources.Domain.Items.Cloneables;
using Sources.Domain.Items.States;
using Sources.DomainInterfaces.Items;
using Sources.DomainInterfaces.Items.Info;
using Sources.DomainInterfaces.Items.States;

namespace Sources.Domain.Items
{
    public class Item : IInventoryItem, ICloneableItem
    {
        public Item(IInventoryItemInfo info, IInventoryItemState state)
        {
            Info = info;
            State = state;
        }

        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
        
        public IInventoryItem Clone()
        {
            Item clonedItem = new Item(Info, new InventoryItemState());
            clonedItem.State.Amount = State.Amount;
            return clonedItem;
        }
    }
}