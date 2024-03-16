using System;
using Sources.Controllers.Presenters.Forms.Gameplays;
using Sources.InfrastructureInterfaces.Services.FormServices;
using Sources.PresentationsInterfaces.Views.Forms.Gameplays;

namespace Sources.Infrastructure.Factories.Controllers.Forms.Gameplay
{
    public class InventoryFormPresenterFactory
    {
        private readonly IFormService _formService;

        public InventoryFormPresenterFactory(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public InventoryFormPresenter Create(IInventoryFormView view)
        {
            return new InventoryFormPresenter(view, _formService);
        }
    }
}