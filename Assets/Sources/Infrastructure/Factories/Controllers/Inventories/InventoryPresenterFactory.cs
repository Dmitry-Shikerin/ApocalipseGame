using Sources.Controllers.Presenters.Inventories;
using Sources.Domain.Inventories;
using Sources.PresentationsInterfaces.Views.Inventories;

namespace Sources.Infrastructure.Factories.Controllers.Inventories
{
    public class InventoryPresenterFactory
    {
        public InventoryPresenter Create(Inventory inventory, IInventoryView inventoryView)
        {
            return new InventoryPresenter(inventory, inventoryView);
        }
    }
}