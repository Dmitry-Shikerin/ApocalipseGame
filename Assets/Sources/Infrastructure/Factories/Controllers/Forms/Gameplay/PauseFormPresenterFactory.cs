using System;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class PauseFormPresenterFactory
    {
        private readonly IFormService _formService;

        public PauseFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public PauseFormPresenter Create(IPauseFormView view)
        {
            return new PauseFormPresenter(view, _formService);
        }
    }
}