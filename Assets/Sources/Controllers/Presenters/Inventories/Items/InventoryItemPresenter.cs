using System;
using Sources.Domain.Inventories.Items;
using Sources.PresentationsInterfaces.Views.Inventories.Items;

namespace Sources.Controllers.Presenters.Inventories.Items
{
    public class InventoryItemPresenter : PresenterBase
    {
        private readonly InventoryItem _inventoryItem;
        private readonly IInventoryItemView _inventoryItemView;

        public InventoryItemPresenter(InventoryItem inventoryItem, IInventoryItemView inventoryItemView)
        {
            _inventoryItem = inventoryItem ?? throw new ArgumentNullException(nameof(inventoryItem));
            _inventoryItemView = inventoryItemView ?? throw new ArgumentNullException(nameof(inventoryItemView));
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}