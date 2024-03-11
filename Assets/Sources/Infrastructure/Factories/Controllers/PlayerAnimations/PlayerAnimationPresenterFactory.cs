using Sources.Controllers.Presenters.PlayerAnimations;
using Sources.DomainInterfaces.PlayerAnimations;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;

namespace Sources.Infrastructure.Factories.Controllers.PlayerAnimations
{
    public class PlayerAnimationPresenterFactory
    {
        public PlayerAnimationPresenter Create(IPlayerAnimationChanger model, IPlayerAnimationView view)
        {
            return new PlayerAnimationPresenter(model, view);
        }
    }
}