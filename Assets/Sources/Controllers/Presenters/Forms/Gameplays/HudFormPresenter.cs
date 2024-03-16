using System;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Controllers.Presenters.Forms.Gameplays
{
    public class HudFormPresenter : PresenterBase
    {
        private readonly IHudFormView _hudFormView;
        private readonly IFormService _formService;

        public HudFormPresenter(
            IHudFormView hudFormView,
            IFormService formService)
        {
            _hudFormView = hudFormView ?? throw new ArgumentNullException(nameof(hudFormView));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            _hudFormView.PauseButton.AddListener(OnShowPauseMenu);
            _hudFormView.InventoryButton.AddListener(OnShowInventory);
        }

        public override void Disable()
        {
            _hudFormView.PauseButton.RemoveListener(OnShowPauseMenu);
            _hudFormView.InventoryButton.RemoveListener(OnShowInventory);
        }

        private void OnShowPauseMenu() => 
            _formService.Show<PauseFormView>();

        private void OnShowInventory() =>
            _formService.Show<InventoryFormView>();
    }
}