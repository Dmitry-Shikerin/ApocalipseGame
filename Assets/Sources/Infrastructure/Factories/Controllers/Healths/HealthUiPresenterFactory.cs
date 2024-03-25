using Sources.Controllers.Presenters.Enemies;
using Sources.DomainInterfaces.Healths;
using Sources.PresentationsInterfaces.Views;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Controllers.Healths
{
    public class HealthUiPresenterFactory
    {
        public HealthUiPresenter Create(IHealth health, IHealthUi healthUi)
        {
            return new HealthUiPresenter(health, healthUi);
        }
    }
}