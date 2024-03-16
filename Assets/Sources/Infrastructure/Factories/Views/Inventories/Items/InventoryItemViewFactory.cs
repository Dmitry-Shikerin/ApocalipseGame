using System;
using Sources.Controllers.Presenters.Inventories.Items;
using Sources.Domain.Inventories.Items;
using Sources.Infrastructure.Factories.Controllers.Inventories.Items;
using Sources.Presentations.Views.Inventories.Items;
using Sources.PresentationsInterfaces.Views.Inventories.Items;

namespace Sources.Infrastructure.Factories.Views.Inventories.Items
{
    public class InventoryItemViewFactory
    {
        private readonly InventoryItemPresenterFactory _presenterFactory;

        public InventoryItemViewFactory(InventoryItemPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IInventoryItemView Create(InventoryItem inventoryItem, InventoryItemView inventoryItemView)
        {
            InventoryItemPresenter presenter = _presenterFactory.Create(inventoryItem, inventoryItemView);
            
            inventoryItemView.Construct(presenter);

            return inventoryItemView;
        }
    }
}