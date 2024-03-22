using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Inventories;
using Sources.Infrastructure.Factories.Controllers.Inventories.Slots;
using Sources.Infrastructure.Factories.Controllers.PlayerAnimations;
using Sources.Infrastructure.Factories.Controllers.PlayerMovements;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Domain.Items;
using Sources.Infrastructure.Factories.PlayerCameras;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Services.ItemFactoriesProviders;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.GameInventories;
using Sources.Infrastructure.Factories.Views.Inventories;
using Sources.Infrastructure.Factories.Views.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.Players;
using Sources.Infrastructure.Factories.Views.Players.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.Players.PlayerCameras;
using Sources.Infrastructure.Factories.Views.Players.PlayerMovements;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.Services.Inventories;
using Sources.Infrastructure.Services.Providers;
using Sources.Infrastructure.Services.Providers.ModelProviders;
using Sources.Infrastructure.Services.Services;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.Infrastructure.Services.WarmUpServices.Concrete;
using Sources.InfrastructureInterfaces.Services.Inventories;
using Sources.Presentations.Ui.Huds;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DiContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private Hud _hud;

        public override void InstallBindings()
        {
            BindServices();
            BindPlayer();
            BindForms();
            BindItems();
            BindBears();
            BindAddressableServices();
            BindModelProviders();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LateUpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<IInventoryCreatorService>().To<InventoryCreatorService>().AsSingle();

            Container.Bind<Hud>().FromInstance(_hud);

            Container.Bind<GameplaySceneViewFactory>().AsSingle();
            Container.Bind<GameplayFormServiceFactory>().AsSingle();
            Container.Bind<GameplaySceneFactory>().AsSingle();

            Container.BindInterfacesAndSelfTo<ItemFactoriesProvider>().AsSingle();
            Container.Bind<ItemFactoriesProviderFactory>().AsSingle();
        }

        private void BindPlayer()
        {
            Container.Bind<PlayerMovementPresenterFactory>().AsSingle();
            Container.Bind<PlayerMovementViewFactory>().AsSingle();

            Container.Bind<PlayerCameraPresenterFactory>().AsSingle();
            Container.Bind<PlayerCameraViewFactory>().AsSingle();

            Container.Bind<PlayerAnimationPresenterFactory>().AsSingle();
            Container.Bind<PlayerAnimationViewFactory>().AsSingle();

            Container.Bind<InventoryPresenterFactory>().AsSingle();
            Container.Bind<InventoryViewFactory>().AsSingle();
            Container.Bind<InventorySlotPresenterFactory>().AsSingle();
            Container.Bind<InventorySlotViewFactory>().AsSingle();

            Container.Bind<PlayerInventoryViewFactory>().AsSingle();
            Container.Bind<LootInventoryViewFactory>().AsSingle();

            Container.Bind<PlayerViewFactory>().AsSingle();
        }

        private void BindItems()
        {
            Container.Bind<WoodPieFactory>().AsSingle();
        }

        private void BindModelProviders()
        {
            Container.BindInterfacesAndSelfTo<PlayerMovementProvider>().AsSingle();
        }

        private void BindForms()
        {
            Container.Bind<HudFormPresenterFactory>().AsSingle();
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
            Container.Bind<InventoryFormPresenterFactory>().AsSingle();
            Container.Bind<LootFormPresenterFactory>().AsSingle();
        }

        private void BindBears()
        {
            Container.Bind<BearPresenterFactory>().AsSingle();
            Container.Bind<BearViewFactory>().AsSingle();
        }

        private void BindAddressableServices()
        {
            Container.Bind<ICompositeAssetService>().To<CompositeAssetService>().AsSingle();
            
            Container.Bind<AssetService<PlayerAssetProvider>>().AsSingle();
            Container.Bind<AssetService<InventoryItemInfoProvider>>().AsSingle();
            Container.Bind<AssetService<BearAssetProvider>>().AsSingle();
        }
    }
}