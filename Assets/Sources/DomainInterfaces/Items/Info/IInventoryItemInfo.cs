using UnityEngine;

namespace Sources.DomainInterfaces.Items.Info
{
    public interface IInventoryItemInfo
    {
        string ID { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemsInInventorySlot { get; }
        Sprite SpriteIcon { get; }
    }
}