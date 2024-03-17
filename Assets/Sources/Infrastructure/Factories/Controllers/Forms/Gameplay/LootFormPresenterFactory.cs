using System;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class LootFormPresenterFactory
    {
        private readonly IFormService _formService;

        public LootFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public LootFormPresenter Create(ILootFormView view)
        {
            return new LootFormPresenter(view, _formService);
        }
    }
}