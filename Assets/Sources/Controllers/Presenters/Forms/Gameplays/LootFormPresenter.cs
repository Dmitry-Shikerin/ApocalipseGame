using System;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Controllers.Presenters.Forms.Gameplays
{
    public class LootFormPresenter : PresenterBase
    {
        private readonly ILootFormView _lootFormView;
        private readonly IFormService _formService;

        public LootFormPresenter(ILootFormView lootFormView, IFormService formService)
        {
            _lootFormView = lootFormView ?? throw new ArgumentNullException(nameof(lootFormView));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable() =>
            _lootFormView.HudButton.AddListener(OnShowHud);

        public override void Disable() =>
            _lootFormView.HudButton.RemoveListener(OnShowHud);

        private void OnShowHud() =>
            _formService.Show<HudFormView>();
    }
}