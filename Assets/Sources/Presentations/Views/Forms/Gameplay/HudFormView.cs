﻿using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.Presentations.Ui.Buttons;
using Sources.PresentationsInterfaces.Ui.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class HudFormView : FormBase<HudFormPresenter>, IHudFormView
    {
        [Required][SerializeField] private ButtonView _pauseButtonView;
        [Required][SerializeField] private ButtonView _inventoryButtonView;
        [Required][SerializeField] private ButtonView _lootInventoryButtonView;

        public IButtonView PauseButton => _pauseButtonView;
        public IButtonView InventoryButton => _inventoryButtonView;
        public IButtonView LootInventoryButton => _lootInventoryButtonView;
    }
}