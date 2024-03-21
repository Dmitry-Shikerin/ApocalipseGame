using Sources.DomainInterfaces.Items.Info;
using UnityEngine;

namespace Sources.Domain.Items.Info
{
    [CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Configs/InventoryItemInfo", order = 51)]
    public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
    {
        [SerializeField] private string _id;
        [SerializeField] private string _title;
        [SerializeField] private string _description;
        [SerializeField] private int _maxItemsInInventorySlot;
        [SerializeField] private Sprite _spriteIcon;

        public string ID => _id;
        public string Title => _title;
        public string Description => _description;
        public int MaxItemsInInventorySlot => _maxItemsInInventorySlot;
        public Sprite SpriteIcon => _spriteIcon;
    }
}