using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Inventories.Slots;
using Sources.Presentations.Ui.Texts;
using Sources.Presentations.Views.Inventories.Items;
using Sources.PresentationsInterfaces.Ui.Texts;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.Presentations.Views.Inventories.Slots
{
    public class InventorySlotView : PresentableView<InventorySlotPresenter>, IInventorySlotView
    {
        [Required] [SerializeField] private InventoryItemView _inventoryItemView;
        [Required] [SerializeField] private InventoryView _inventoryView;
        [Required] [SerializeField] private TextView _amountTextView;
        [Required] [SerializeField] private TextView _idTextView;

        public InventoryItemView InventoryItemView => _inventoryItemView;
        public Vector2Int Position => Presenter.Position;
        public int Amount { get; set; }
        public string Id { get; set; }
        public ITextView AmountText => _amountTextView;
        public ITextView IdText => _idTextView;

        public void OnDrop(PointerEventData eventData)
        {
            Transform otherItemTransform = eventData.pointerDrag.transform;
            // otherItemTransform.SetParent(transform);
            _inventoryView.AddItem(eventData, this);
            Debug.Log($"Inventory Slot {Position.x} {Position.y} on drop");
            otherItemTransform.localPosition = Vector3.zero;
        }
    }
}