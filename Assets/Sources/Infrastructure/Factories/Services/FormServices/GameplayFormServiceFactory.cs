using System;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Views.Forms;
using Sources.Infrastructure.Services.Services;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.Presentations.Ui.Huds;
using Sources.Presentations.Views.Forms.Gameplay;

namespace Sources.Infrastructure.Factories.Services.FormServices
{
    public class GameplayFormServiceFactory
    {
        private readonly Hud _hud;
        private readonly FormService _formService;
        private readonly HudFormPresenterFactory _hudFormPresenterFactory;
        private readonly PauseFormPresenterFactory _pauseFormPresenterFactory;

        public GameplayFormServiceFactory
        (
            Hud hud,
            FormService formService,
            HudFormPresenterFactory hudFormPresenterFactory,
            PauseFormPresenterFactory pauseFormPresenterFactory
        )
        {
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _hudFormPresenterFactory = hudFormPresenterFactory ??
                                       throw new ArgumentNullException(nameof(hudFormPresenterFactory));
            _pauseFormPresenterFactory = pauseFormPresenterFactory ??
                                         throw new ArgumentNullException(nameof(pauseFormPresenterFactory));
        }

        public IFormService Create()
        {
            Form<HudFormView, HudFormPresenter> hudForm = 
                new Form<HudFormView, HudFormPresenter>(
                _hudFormPresenterFactory.Create, _hud.HudForm);
            _formService.Add(hudForm);

            Form<PauseFormView, PauseFormPresenter> pauseForm = 
                new Form<PauseFormView, PauseFormPresenter>(
                _pauseFormPresenterFactory.Create, _hud.PauseForm);
            _formService.Add(pauseForm);

            _formService.Show<HudFormView>();
            
            return _formService;
        }
    }
}