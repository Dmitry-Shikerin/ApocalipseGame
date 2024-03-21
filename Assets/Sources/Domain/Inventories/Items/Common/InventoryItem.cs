using Sources.DomainInterfaces.Items;
using Sources.DomainInterfaces.Items.Info;
using Sources.DomainInterfaces.Items.States;

namespace Sources.Domain.Items.Common
{
    public class InventoryItem : IInventoryItem
    {
        public InventoryItem(IInventoryItemInfo info, IInventoryItemState state)
        {
            Info = info;
            State = state;
        }

        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
    }
}