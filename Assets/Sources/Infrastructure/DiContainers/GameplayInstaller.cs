using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Inventories.Items;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Inventories;
using Sources.Infrastructure.Factories.Controllers.Inventories.Items;
using Sources.Infrastructure.Factories.Controllers.Inventories.Slots;
using Sources.Infrastructure.Factories.Controllers.PlayerAnimations;
using Sources.Infrastructure.Factories.Controllers.PlayerMovements;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.PlayerCameras;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Inventories;
using Sources.Infrastructure.Factories.Views.Inventories.Items;
using Sources.Infrastructure.Factories.Views.Inventories.Slots;
using Sources.Infrastructure.Factories.Views.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.PlayerCameras;
using Sources.Infrastructure.Factories.Views.PlayerInventories;
using Sources.Infrastructure.Factories.Views.PlayerMovements;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.Services.Services;
using Sources.Infrastructure.Services.UpdateServices;
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
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LateUpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();

            Container.Bind<Hud>().FromInstance(_hud);

            Container.Bind<GameplaySceneViewFactory>().AsSingle();
            Container.Bind<GameplayFormServiceFactory>().AsSingle();
            Container.Bind<GameplaySceneFactory>().AsSingle();
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
            Container.Bind<InventoryItemPresenterFactory>().AsSingle();
            Container.Bind<InventoryItemViewFactory>().AsSingle();

            Container.Bind<PlayerInventoryViewFactory>().AsSingle();
        }

        private void BindForms()
        {
            Container.Bind<HudFormPresenterFactory>().AsSingle();
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
            Container.Bind<InventoryFormPresenterFactory>().AsSingle();
        }
    }
}