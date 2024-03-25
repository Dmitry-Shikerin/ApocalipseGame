using System;
using Sources.Domain.PlayerMovement;
using Sources.Domain.Players.PlayerShooters;
using Sources.Domain.Players.Weapons;
using Sources.Infrastructure.Factories.Views.Players.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.Players.PlayerMovements;
using Sources.Infrastructure.Factories.Views.Players.Weapons;
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
        private readonly PlayerAttackerViewFactory _playerAttackerViewFactory;
        private readonly MiniGunViewFactory _miniGunViewFactory;
        private readonly Hud _hud;

        public PlayerViewFactory(
            PlayerMovementViewFactory playerMovementViewFactory,
            PlayerAnimationViewFactory playerAnimationViewFactory,
            AssetService<PlayerAssetProvider> playerAssetProvider,
            Hud hud,
            PlayerAttackerViewFactory playerAttackerViewFactory,
            MiniGunViewFactory miniGunViewFactory)
        {
            _playerMovementViewFactory = playerMovementViewFactory ?? 
                                         throw new ArgumentNullException(nameof(playerMovementViewFactory));
            _playerAnimationViewFactory = playerAnimationViewFactory ?? 
                                          throw new ArgumentNullException(nameof(playerAnimationViewFactory));
            _playerAssetProvider = playerAssetProvider ?? throw new ArgumentNullException(nameof(playerAssetProvider));
            _playerAttackerViewFactory = playerAttackerViewFactory ?? 
                                         throw new ArgumentNullException(nameof(playerAttackerViewFactory));
            _miniGunViewFactory = miniGunViewFactory ??
                                  throw new ArgumentNullException(nameof(miniGunViewFactory));
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
        }

        public PlayerView Create(
            PlayerMovement playerMovement, 
            PlayerAttacker playerAttacker,
            MiniGun miniGun)
        {
            // PlayerView playerView = Object.Instantiate(
            //     _playerAssetProvider.Provider.PlayerView, new Vector3(3,0,-4), Quaternion.identity);
            PlayerView playerView = Object.FindObjectOfType<PlayerView>();
            
            _hud.CinemachineCameraView.Follow(playerView.transform);
            
            _playerMovementViewFactory.Create(
                playerMovement, playerView.PlayerMovementView, playerView.PlayerAnimationView);
            _playerAttackerViewFactory.Create(playerAttacker, playerView.PlayerAttackerView);
            _miniGunViewFactory.Create(miniGun, playerView.MiniGunView);
            
            return playerView;
        }
    }
}