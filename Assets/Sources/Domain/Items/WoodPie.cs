using Sources.Domain.Items.Common;
using Sources.DomainInterfaces.Items.Info;
using Sources.DomainInterfaces.Items.States;

namespace Sources.Domain.Items
{
    public class WoodPie : Item
    {
        public WoodPie(IInventoryItemInfo info, IInventoryItemState state) : base(info, state)
        {
        }
    }
}