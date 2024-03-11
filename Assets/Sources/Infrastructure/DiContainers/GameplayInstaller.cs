using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.PlayerAnimations;
using Sources.Infrastructure.Factories.Controllers.PlayerMovements;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.PlayerCameras;
using Sources.Infrastructure.Factories.Views.PlayerAnimations;
using Sources.Infrastructure.Factories.Views.PlayerCameras;
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
        [SerializeField] private Hud _hud;

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

            Container.Bind<Hud>().FromInstance(_hud).AsSingle();

            Container.Bind<GameplaySceneViewFactory>().AsSingle();
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
        }

        private void BindForms()
        {
            Container.Bind<HudFormPresenterFactory>().AsSingle();
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
        }
    }
}