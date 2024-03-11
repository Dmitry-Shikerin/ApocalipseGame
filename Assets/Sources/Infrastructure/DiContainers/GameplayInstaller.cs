using Sources.Controllers.Presenters.PlayerMovements;
using Sources.Infrastructure.Factories.Controllers.PlayerMovements;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Views.PlayerMovements;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.Services.UpdateServices;
using Zenject;

namespace Sources.Infrastructure.DiContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
            BindPlayer();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<LateUpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();

            Container.Bind<GameplaySceneViewFactory>().AsSingle();
            Container.Bind<GameplaySceneFactory>().AsSingle();
        }
        
        private void BindPlayer()
        {
            Container.Bind<PlayerMovementPresenterFactory>().AsSingle();
            Container.Bind<PlayerMovementViewFactory>().AsSingle();
        }
    }
}