using System;
using Sources.DomainInterfaces.Items.Info;
using Sources.DomainInterfaces.Items.States;

namespace Sources.DomainInterfaces.Items
{
    public interface IInventoryItem
    {
        IInventoryItemInfo Info { get; }
        IInventoryItemState State { get; }
        Type Type => GetType();
    }
}