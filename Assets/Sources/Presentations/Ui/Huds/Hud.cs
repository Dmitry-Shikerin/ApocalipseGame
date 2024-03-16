using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Inventories;
using UnityEngine;

namespace Sources.Presentations.Ui.Huds
{
    public class Hud : View
    {
        [Button(ButtonSizes.Large)]
        [FoldoutGroup("Forms")][Required][SerializeField] 
        private HudFormView _hudForm;
        [FoldoutGroup("Forms")][Required][SerializeField] 
        private PauseFormView _pauseForm;
        [FoldoutGroup("Forms")][Required][SerializeField] 
        private InventoryFormView _inventoryForm;

        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Inventories")] [Required] [SerializeField]
        private InventoryView _inventoryView;

        public HudFormView HudForm => _hudForm;
        public PauseFormView PauseForm => _pauseForm;
        public InventoryFormView InventoryForm => _inventoryForm;

        public InventoryView InventoryView => _inventoryView;
    }
}