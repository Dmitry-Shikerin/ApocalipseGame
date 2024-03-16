using Sources.DomainInterfaces.Items.States;

namespace Sources.Domain.Items.States
{
    public class InventoryItemState : IInventoryItemState
    {
        //TODO скорее всего Amount тут не нужен
        public int Amount { get; set; }
        public bool IsEquipped { get; set; }
    }
}