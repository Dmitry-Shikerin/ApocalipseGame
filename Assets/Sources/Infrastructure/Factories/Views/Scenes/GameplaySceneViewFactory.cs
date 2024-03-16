using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.Domain.Inventories;
using Sources.Domain.Inventories.Items;
using Sources.Domain.Inventories.Slots;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Inventories;
using Sources.Infrastructure.Factories.Views.Inventories.Items;
using Sources.Infrastructure.Factories.Views.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.PlayerCameras;
using Sources.Infrastructure.Factories.Views.PlayerInventories;
using Sources.Infrastructure.Factories.Views.PlayerMovements;
using Sources.Presentations.Ui.Huds;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Inventories.Slots;
using Sources.PresentationsInterfaces.Views.Inventories.Slots;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Views.Scenes
{
    public class GameplaySceneViewFactory
    {
        private readonly Hud _hud;
        private readonly GameplayFormServiceFactory _gameplayFormServiceFactory;
        private readonly PlayerMovementViewFactory _playerMovementViewFactory;
        private readonly PlayerCameraViewFactory _playerCameraViewFactory;
        private readonly PlayerAnimationViewFactory _playerAnimationViewFactory;
        private readonly PlayerInventoryViewFactory _playerInventoryViewFactory;

        public GameplaySceneViewFactory(
            Hud hud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            PlayerMovementViewFactory playerMovementViewFactory,
            PlayerCameraViewFactory playerCameraViewFactory,
            PlayerAnimationViewFactory playerAnimationViewFactory,
            PlayerInventoryViewFactory playerInventoryViewFactory)
        {
            _hud = hud ? hud : throw new ArgumentNullException(nameof(hud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _playerMovementViewFactory = playerMovementViewFactory ??
                                         throw new ArgumentNullException(nameof(playerMovementViewFactory));
            _playerCameraViewFactory = playerCameraViewFactory ??
                                       throw new ArgumentNullException(nameof(playerCameraViewFactory));
            _playerAnimationViewFactory = playerAnimationViewFactory ??
                                          throw new ArgumentNullException(nameof(playerAnimationViewFactory));
            _playerInventoryViewFactory = playerInventoryViewFactory 
                                          ?? throw new ArgumentNullException(nameof(playerInventoryViewFactory));
        }

        public void Create()
        {
            PlayerMovement playerMovement = new PlayerMovement();
            _playerMovementViewFactory.Create(playerMovement);
            _playerAnimationViewFactory.Create(playerMovement);

            PlayerCamera playerCamera = new PlayerCamera(playerMovement);
            _playerCameraViewFactory.Create(playerCamera);

            _playerInventoryViewFactory.Create();
            
            _gameplayFormServiceFactory
                .Create()
                .Show<HudFormView>();
        }
    }
}