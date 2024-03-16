using Sources.Controllers.Presenters.Inventories.Items;
using Sources.Domain.Inventories.Items;
using Sources.PresentationsInterfaces.Views.Inventories.Items;

namespace Sources.Infrastructure.Factories.Controllers.Inventories.Items
{
    public class InventoryItemPresenterFactory
    {
        public InventoryItemPresenter Create(InventoryItem inventoryItem, IInventoryItemView inventoryItemView)
        {
            return new InventoryItemPresenter(inventoryItem, inventoryItemView);
        }
    }
}