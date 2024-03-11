using System;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Controllers.Presenters.Forms.Gameplays
{
    public class PauseFormPresenter : PresenterBase
    {
        private readonly IPauseFormView _view;
        private readonly IFormService _formService;

        public PauseFormPresenter(IPauseFormView view, IFormService formService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable() => 
            _view.HudFormButton.AddListener(OnShowHudForm);

        public override void Disable() => 
            _view.HudFormButton.RemoveListener(OnShowHudForm);

        private void OnShowHudForm() => 
            _formService.Show<HudFormView>();
    }
}