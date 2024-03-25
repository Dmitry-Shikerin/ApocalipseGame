using System;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.Domain.Bears;
using Sources.Domain.Enemies;
using Sources.Domain.Inventories;
using Sources.Domain.Items;
using Sources.Domain.PlayerMovement;
using Sources.Domain.Players.PlayerShooters;
using Sources.Domain.Players.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.ItemFactoriesProviders;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Enemies;
using Sources.Infrastructure.Factories.Views.GameInventories;
using Sources.Infrastructure.Factories.Views.Players;
using Sources.Infrastructure.Factories.Views.Players.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.Players.PlayerCameras;
using Sources.Infrastructure.Factories.Views.Players.PlayerMovements;
using Sources.Infrastructure.Factories.Views.Players.Weapons;
using Sources.Infrastructure.Services.Providers.ModelProviders;
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
        private readonly BearViewFactory _bearViewFactory;
        private readonly PlayerViewFactory _playerViewFactory;
        private readonly PlayerMovementProvider _playerMovementProvider;
        private readonly EnemyCommonViewFactory _enemyCommonViewFactory;
        private readonly PlayerAttackerViewFactory _playerAttackerViewFactory;
        private readonly MiniGunViewFactory _miniGunViewFactory;

        public GameplaySceneViewFactory(
            Hud hud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            PlayerMovementViewFactory playerMovementViewFactory,
            PlayerCameraViewFactory playerCameraViewFactory,
            PlayerAnimationViewFactory playerAnimationViewFactory,
            PlayerInventoryViewFactory playerInventoryViewFactory,
            ItemFactoriesProviderFactory itemFactoriesProviderFactory,
            LootInventoryViewFactory lootInventoryViewFactory,
            IItemFactoriesProvider itemFactoriesProvider,
            BearViewFactory bearViewFactory,
            PlayerViewFactory playerViewFactory,
            PlayerMovementProvider playerMovementProvider,
            EnemyCommonViewFactory enemyCommonViewFactory,
            PlayerAttackerViewFactory playerAttackerViewFactory,
            MiniGunViewFactory miniGunViewFactory)
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
            _bearViewFactory = bearViewFactory ?? 
                               throw new ArgumentNullException(nameof(bearViewFactory));
            _playerViewFactory = playerViewFactory ?? 
                                 throw new ArgumentNullException(nameof(playerViewFactory));
            _playerMovementProvider = playerMovementProvider 
                                      ?? throw new ArgumentNullException(nameof(playerMovementProvider));
            _enemyCommonViewFactory = enemyCommonViewFactory ?? 
                                      throw new ArgumentNullException(nameof(enemyCommonViewFactory));
            _playerAttackerViewFactory = playerAttackerViewFactory ?? 
                                         throw new ArgumentNullException(nameof(playerAttackerViewFactory));
            _miniGunViewFactory = miniGunViewFactory ?? 
                                  throw new ArgumentNullException(nameof(miniGunViewFactory));
        }

        public void Create()
        {
            PlayerMovement playerMovement = new PlayerMovement();
            MiniGun miniGun = new MiniGun(5, 0.5f);
            PlayerAttacker playerAttacker = new PlayerAttacker(miniGun);
            _playerMovementProvider.Set(playerMovement);
            _playerViewFactory.Create(playerMovement, playerAttacker, miniGun);
            
            Bear bear = new Bear();
            BearAttack bearAttack = new BearAttack();
            _bearViewFactory.Create(bear, bearAttack);

            Enemy enemy = new Enemy();
            EnemyHealth enemyHealth = new EnemyHealth(100);
            _enemyCommonViewFactory.Craete(enemy, enemyHealth);

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