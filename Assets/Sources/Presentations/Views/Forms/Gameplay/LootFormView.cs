using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.Presentations.Ui.Buttons;
using Sources.PresentationsInterfaces.Ui.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.Gameplay
{
    public class LootFormView : FormBase<LootFormPresenter>, ILootFormView
    {
        [Required] [SerializeField] private ButtonView _hudButtonView;

        public IButtonView HudButton => _hudButtonView;
    }
}