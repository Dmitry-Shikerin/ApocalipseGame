namespace Sources.Domain.Inventories.Dto
{
    public class RemoveItemsResult
    {
        public readonly string InventoryOwnerId;
        public readonly int ItemsToRemoveAmount;
        public readonly bool Success;

        public RemoveItemsResult(
            string inventoryOwnerId,
            int itemsToRemoveAmount,
            bool success)
        {
            InventoryOwnerId = inventoryOwnerId;
            ItemsToRemoveAmount = itemsToRemoveAmount;
            Success = success;
        }
    }
}