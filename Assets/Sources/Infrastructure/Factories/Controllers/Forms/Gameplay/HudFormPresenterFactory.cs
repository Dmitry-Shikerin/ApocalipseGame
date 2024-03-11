using System;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class HudFormPresenterFactory
    {
        private readonly IFormService _formService;

        public HudFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public HudFormPresenter Create(IHudFormView view)
        {
            return new HudFormPresenter(view, _formService);
        }
    }
}