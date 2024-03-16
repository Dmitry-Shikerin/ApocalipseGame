using Sources.Presentations.Views.Inventories.Items;
using Sources.PresentationsInterfaces.Ui.Texts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.PresentationsInterfaces.Views.Inventories.Slots
{
    public interface IInventorySlotView : IDropHandler
    {
        InventoryItemView InventoryItemView { get; }
        Vector2Int Position { get; }
        int Amount { get; set; }
        string Id { get; set; }
        
        ITextView AmountText { get; }
        ITextView IdText { get; }
    }
}