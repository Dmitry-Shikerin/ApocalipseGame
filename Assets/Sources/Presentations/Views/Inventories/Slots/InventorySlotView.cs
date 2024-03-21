using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Inventories.Slots;
using Sources.DomainInterfaces.Items;
using Sources.Presentations.Ui.Texts;
using Sources.Presentations.Views.Inventories.Items;
using Sources.PresentationsInterfaces.Ui.Texts;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sources.Presentations.Views.Inventories.Slots
{
    public class InventorySlotView : PresentableView<InventorySlotPresenter>, IInventorySlotView
    {
        [Required] [SerializeField] private InventoryItemView _inventoryItemView;
        [Required] [SerializeField] private InventoryView _inventoryView;
        [Required] [SerializeField] private TextView _amountTextView;
        [Required] [SerializeField] private TextView _idTextView;
        [Required] [SerializeField] private Image _image;

        public InventoryView InventoryView => _inventoryView;
        public Image Image => _image;
        public IInventoryItem InventoryItem => Presenter.InventoryItem;
        public InventoryItemView InventoryItemView => _inventoryItemView;
        public Vector2Int Position => Presenter.Position;
        public int Amount { get; set; }
        public string Id { get; set; }
        public string OwnerId => Presenter.OwnerId;
        public ITextView AmountText => _amountTextView;
        public ITextView IdText => _idTextView;

        public void OnDrop(PointerEventData eventData)
        {
            InventorySlotView fromSlot = 
                (InventorySlotView)eventData.pointerDrag.GetComponent<InventoryItemView>().InventorySlotView;
            _inventoryView.AddItem(eventData, fromSlot, this);
        }
    }
}