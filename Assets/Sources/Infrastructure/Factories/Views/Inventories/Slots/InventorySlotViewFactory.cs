using System;
using Sources.Controllers.Presenters.Inventories.Slots;
using Sources.Domain.Inventories.Slots;
using Sources.Infrastructure.Factories.Controllers.Inventories.Slots;
using Sources.Presentations.Views.Inventories;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;

namespace Sources.Infrastructure.Factories.Views.Inventories.Slots
{
    public class InventorySlotViewFactory
    {
        private readonly InventorySlotPresenterFactory _inventorySlotPresenterFactory;

        public InventorySlotViewFactory(InventorySlotPresenterFactory inventorySlotPresenterFactory)
        {
            _inventorySlotPresenterFactory = inventorySlotPresenterFactory ??
                                             throw new ArgumentNullException(nameof(inventorySlotPresenterFactory));
        }

        public IInventorySlotView Create(InventorySlot inventorySlot, InventorySlotView inventorySlotView)
        {
            InventorySlotPresenter presenter = _inventorySlotPresenterFactory.Create(inventorySlot, inventorySlotView);
            
            inventorySlotView.Construct(presenter);

            return inventorySlotView;
        }
    }
}