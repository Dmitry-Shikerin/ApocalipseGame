using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Inventories;
using Sources.Presentations.Views.Players.PlayerCameras;
using UnityEngine;
using UnityEngine.Serialization;

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
        [FoldoutGroup("Forms")][Required][SerializeField] 
        private LootFormView _lootForm;

        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Inventories")] [Required] [SerializeField]
        private InventoryView _playerInventoryView;
        [FoldoutGroup("Inventories")] [Required] [SerializeField]
        private InventoryView _playerLootInventoryView;
        [FoldoutGroup("Inventories")] [Required] [SerializeField]
        private InventoryView _lootInventoryView;
        
        [Button(ButtonSizes.Large)] 
        [FoldoutGroup("Camera")] [Required] [SerializeField]
        private CinemachineCameraView _cinemachineCameraView;


        public HudFormView HudForm => _hudForm;
        public PauseFormView PauseForm => _pauseForm;
        public InventoryFormView InventoryForm => _inventoryForm;
        public LootFormView LootForm => _lootForm;

        public InventoryView PlayerInventoryView => _playerInventoryView;
        public InventoryView PlayerLootInventoryView => _playerLootInventoryView;
        public InventoryView LootInventoryView => _lootInventoryView;
        
        public CinemachineCameraView CinemachineCameraView => _cinemachineCameraView;
    }
}