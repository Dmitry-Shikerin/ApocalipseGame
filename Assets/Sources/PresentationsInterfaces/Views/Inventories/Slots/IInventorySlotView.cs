using Sources.Presentations.Views.Inventories;
using Sources.Presentations.Views.Inventories.Items;
using Sources.PresentationsInterfaces.Ui.Texts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sources.PresentationsInterfaces.Views.Inventories.Slots
{
    public interface IInventorySlotView : IDropHandler
    {
        InventoryView InventoryView { get; }
        Image Image { get; } 
        InventoryItemView InventoryItemView { get; }
        Vector2Int Position { get; }
        int Amount { get; set; }
        string Id { get; set; }
        string OwnerId { get; }
        
        ITextView AmountText { get; }
        ITextView IdText { get; }
    }
}