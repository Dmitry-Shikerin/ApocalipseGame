using Cysharp.Threading.Tasks;

namespace Sources.InfrastructureInterfaces.Services.SceneLoaderServices
{
    public interface ISceneLoaderService
    {
        UniTask LoadAsync(string sceneName);
        UniTask Unload();
    }
}