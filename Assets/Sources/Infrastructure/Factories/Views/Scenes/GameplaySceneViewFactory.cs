using System;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.Domain.Inventories;
using Sources.Domain.Items;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.ItemFactoriesProviders;
using Sources.Infrastructure.Factories.Views.GameInventories;
using Sources.Infrastructure.Factories.Views.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.PlayerCameras;
using Sources.Infrastructure.Factories.Views.PlayerMovements;
using Sources.InfrastructureInterfaces.Services.Providers;
using Sources.Presentations.Ui.Huds;
using Sources.Presentations.Views.Forms.Gameplay;
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
        private readonly ItemFactoriesProviderFactory _itemFactoriesProviderFactory;
        private readonly LootInventoryViewFactory _lootInventoryViewFactory;
        private readonly IItemFactoriesProvider _itemFactoriesProvider;

        public GameplaySceneViewFactory(
            Hud hud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            PlayerMovementViewFactory playerMovementViewFactory,
            PlayerCameraViewFactory playerCameraViewFactory,
            PlayerAnimationViewFactory playerAnimationViewFactory,
            PlayerInventoryViewFactory playerInventoryViewFactory,
            ItemFactoriesProviderFactory itemFactoriesProviderFactory,
            LootInventoryViewFactory lootInventoryViewFactory,
            IItemFactoriesProvider itemFactoriesProvider)
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
            _itemFactoriesProviderFactory = itemFactoriesProviderFactory ?? 
                                            throw new ArgumentNullException(nameof(itemFactoriesProviderFactory));
            _lootInventoryViewFactory = lootInventoryViewFactory;
            _itemFactoriesProvider = itemFactoriesProvider ??
                                     throw new ArgumentNullException(nameof(itemFactoriesProvider));
        }

        public void Create()
        {
            PlayerMovement playerMovement = new PlayerMovement();
            _playerMovementViewFactory.Create(playerMovement);
            _playerAnimationViewFactory.Create(playerMovement);

            PlayerCamera playerCamera = new PlayerCamera(playerMovement);
            _playerCameraViewFactory.Create(playerCamera);

            _itemFactoriesProviderFactory.Create();
            
            Inventory inventory = _playerInventoryViewFactory.Create();
            inventory.AddItems(new Vector2Int(0, 0), _itemFactoriesProvider.Create<WoodPie>(), 2);
            inventory.AddItems(new Vector2Int(0, 1), _itemFactoriesProvider.Create<WoodPie>(), 2);
            inventory.AddItems(new Vector2Int(0, 2), _itemFactoriesProvider.Create<WoodPie>(), 2);
            
            
            _lootInventoryViewFactory.Create("woodPie");

            _gameplayFormServiceFactory
                .Create()
                .Show<HudFormView>();
        }
    }
}