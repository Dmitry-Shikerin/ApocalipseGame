using System;
using Sources.Controllers.Presenters.Inventories;
using Sources.Domain.Inventories;
using Sources.Infrastructure.Factories.Controllers.Inventories;
using Sources.Presentations.Views.Inventories;
using Sources.PresentationsInterfaces.Views.Inventories;

namespace Sources.Infrastructure.Factories.Views.Inventories
{
    public class InventoryViewFactory
    {
        private readonly InventoryPresenterFactory _inventoryPresenterFactory;

        public InventoryViewFactory(InventoryPresenterFactory inventoryPresenterFactory)
        {
            _inventoryPresenterFactory = inventoryPresenterFactory ?? 
                                         throw new ArgumentNullException(nameof(inventoryPresenterFactory));
        }

        public IInventoryView Create(Inventory inventory, InventoryView inventoryView)
        {
            InventoryPresenter inventoryPresenter = _inventoryPresenterFactory.Create(inventory, inventoryView);
            
            inventoryView.Construct(inventoryPresenter);

            return inventoryView;
        }
    }
}