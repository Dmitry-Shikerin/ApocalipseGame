using System;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Controllers.Presenters.Forms.Gameplays
{
    public class InventoryFormPresenter : PresenterBase
    {
        private readonly IInventoryFormView _view;
        private readonly IFormService _formService;

        public InventoryFormPresenter(
            IInventoryFormView view,
            IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable() =>
            _view.HudButton.AddListener(OnShowHud);

        public override void Disable() =>
            _view.HudButton.RemoveListener(OnShowHud);

        private void OnShowHud() =>
            _formService.Show<HudFormView>();
    }
}