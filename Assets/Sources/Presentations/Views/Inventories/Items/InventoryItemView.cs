using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Inventories.Items;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories.Items;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Sources.Presentations.Views.Inventories.Items
{
    public class InventoryItemView : PresentableView<InventoryItemPresenter>, IInventoryItemView
    {
        [Required] [SerializeField] private RectTransform _rectTransform;
        [Required] [SerializeField] private Canvas _mainCanvas;
        [Required] [SerializeField] private CanvasGroup _canvasGroup;
        [Required] [SerializeField] private InventorySlotView _inventorySlotView;

        public IInventorySlotView InventorySlotView => _inventorySlotView;

        public void OnBeginDrag(PointerEventData eventData)
        {
            Transform slotTransform = _rectTransform.parent;
            slotTransform.SetAsLastSibling();
            _canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.localPosition = Vector3.zero;
            _canvasGroup.blocksRaycasts = true;
        }
    }
}