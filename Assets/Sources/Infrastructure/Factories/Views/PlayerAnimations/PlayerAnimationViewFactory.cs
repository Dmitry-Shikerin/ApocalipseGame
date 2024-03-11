using System;
using Sources.Controllers.Presenters.PlayerAnimations;
using Sources.DomainInterfaces.PlayerAnimations;
using Sources.Infrastructure.Factories.Controllers.PlayerAnimations;
using Sources.Presentations.Views.PlayerAnimation;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.PlayerAnimations
{
    public class PlayerAnimationViewFactory
    {
        private readonly PlayerAnimationPresenterFactory _playerAnimationPresenterFactory;

        public PlayerAnimationViewFactory(PlayerAnimationPresenterFactory playerAnimationPresenterFactory)
        {
            _playerAnimationPresenterFactory = playerAnimationPresenterFactory ?? 
                                               throw new ArgumentNullException(nameof(playerAnimationPresenterFactory));
        }

        public IPlayerAnimationView Create(IPlayerAnimationChanger model)
        {
            PlayerAnimationView view = Object.FindAnyObjectByType<PlayerAnimationView>();

            PlayerAnimationPresenter presenter = new PlayerAnimationPresenter(model, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}