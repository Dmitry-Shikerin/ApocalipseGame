using System;
using Sources.Controllers.Presenters.PlayerAnimations;
using Sources.DomainInterfaces.PlayerAnimations;
using Sources.Infrastructure.Factories.Controllers.PlayerAnimations;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.Presentations.Views.PlayerAnimation;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;

namespace Sources.Infrastructure.Factories.Views.Players.PlayerAnimations
{
    public class PlayerAnimationViewFactory
    {
        private readonly PlayerAnimationPresenterFactory _playerAnimationPresenterFactory;
        private readonly AssetService<PlayerAssetProvider> _playerAssetProvider;

        public PlayerAnimationViewFactory(
            PlayerAnimationPresenterFactory playerAnimationPresenterFactory)
        {
            _playerAnimationPresenterFactory = playerAnimationPresenterFactory ?? 
                                               throw new ArgumentNullException(nameof(playerAnimationPresenterFactory));
        }

        public IPlayerAnimationView Create(IPlayerAnimationChanger model, PlayerAnimationView view)
        {
            PlayerAnimationPresenter presenter = _playerAnimationPresenterFactory.Create(model, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}