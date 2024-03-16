using Sources.Controllers.Presenters.Inventories.Slots;
using Sources.Domain.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;

namespace Sources.Infrastructure.Factories.Controllers.Inventories.Slots
{
    public class InventorySlotPresenterFactory
    {
        public InventorySlotPresenter Create(InventorySlot inventorySlot, IInventorySlotView inventoryView)
        {
            return new InventorySlotPresenter(inventorySlot, inventoryView);
        }
    }
}