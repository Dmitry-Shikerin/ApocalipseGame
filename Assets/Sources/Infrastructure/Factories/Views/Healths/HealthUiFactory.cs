using System;
using Sources.Controllers.Presenters.Enemies;
using Sources.DomainInterfaces.Healths;
using Sources.Infrastructure.Factories.Controllers.Healths;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Views;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Views.Healths
{
    public class HealthUiFactory
    {
        private readonly HealthUiPresenterFactory _healthUiPresenterFactory;

        public HealthUiFactory(HealthUiPresenterFactory healthUiPresenterFactory)
        {
            _healthUiPresenterFactory = healthUiPresenterFactory ?? 
                                        throw new ArgumentNullException(nameof(healthUiPresenterFactory));
        }

        public IHealthUi Create(IHealth health, HealthUi healthUi)
        {
            HealthUiPresenter healthUiPresenter = _healthUiPresenterFactory.Create(health, healthUi);
            
            healthUi.Construct(healthUiPresenter);
            
            return healthUi;
        }
    }
}