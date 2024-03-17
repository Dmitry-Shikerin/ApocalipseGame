using Sources.Domain.Items.Cloneables;
using Sources.Domain.Items.States;
using Sources.DomainInterfaces.Items;
using Sources.DomainInterfaces.Items.Info;
using Sources.DomainInterfaces.Items.States;

namespace Sources.Domain.Items.Common
{
    public class Item : IInventoryItem
    {
        public Item(IInventoryItemInfo info, IInventoryItemState state)
        {
            Info = info;
            State = state;
        }

        public IInventoryItemInfo Info { get; }
        public IInventoryItemState State { get; }
    }
}