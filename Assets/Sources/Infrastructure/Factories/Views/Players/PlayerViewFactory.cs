using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Views.Players.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.Players.PlayerMovements;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.Infrastructure.Services.WarmUpServices.Concrete;
using Sources.Presentations.Ui.Huds;
using Sources.Presentations.Views.Players;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Players
{
    public class PlayerViewFactory
    {
        private readonly PlayerMovementViewFactory _playerMovementViewFactory;
        private readonly PlayerAnimationViewFactory _playerAnimationViewFactory;
        private readonly AssetService<PlayerAssetProvider> _playerAssetProvider;
        private readonly Hud _hud;

        public PlayerViewFactory(
            PlayerMovementViewFactory playerMovementViewFactory,
            PlayerAnimationViewFactory playerAnimationViewFactory,
            AssetService<PlayerAssetProvider> playerAssetProvider,
            Hud hud)
        {
            _playerMovementViewFactory = playerMovementViewFactory ?? 
                                         throw new ArgumentNullException(nameof(playerMovementViewFactory));
            _playerAnimationViewFactory = playerAnimationViewFactory ?? 
                                          throw new ArgumentNullException(nameof(playerAnimationViewFactory));
            _playerAssetProvider = playerAssetProvider ?? throw new ArgumentNullException(nameof(playerAssetProvider));
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
        }

        public PlayerView Create(PlayerMovement playerMovement)
        {
            PlayerView playerView = Object.Instantiate(
                _playerAssetProvider.Provider.PlayerView, new Vector3(3,0,-4), Quaternion.identity);
            
            _hud.CinemachineCameraView.Follow(playerView.transform);
            
            _playerMovementViewFactory.Create(playerMovement, playerView.PlayerMovementView);
            _playerAnimationViewFactory.Create(playerMovement, playerView.PlayerAnimationView);

            return playerView;
        }
    }
}