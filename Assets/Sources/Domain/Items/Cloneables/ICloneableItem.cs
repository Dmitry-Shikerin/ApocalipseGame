using Sources.DomainInterfaces.Items;

namespace Sources.Domain.Items.Cloneables
{
    public interface ICloneableItem
    {
        IInventoryItem Clone();
    }
}