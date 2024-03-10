using Sources.Controllers.Presenters.PlayerMovements;
using Sources.Infrastructure.Factories.Views.PlayerMovements;
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
            Container.BindInterfacesAndSelfTo<InputService>().AsSingle();
        }
        
        private void BindPlayer()
        {
            Container.Bind<PlayerMovementPresenter>().AsSingle();
            Container.Bind<PlayerMovementViewFactory>().AsSingle();
        }
    }
}