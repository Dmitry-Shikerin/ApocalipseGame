using Sources.Infrastructure.Services.SceneLoaderServices;
using Sources.InfrastructureInterfaces.Services.SceneLoaderServices;
using Zenject;

namespace Sources.Infrastructure.DiContainers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoaderService>().To<AddressableSceneLoaderService>().AsSingle();
        }
    }
}