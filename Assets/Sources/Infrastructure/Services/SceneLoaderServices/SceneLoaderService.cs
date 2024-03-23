using Cysharp.Threading.Tasks;
using Sources.InfrastructureInterfaces.Services.SceneLoaderServices;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Services.SceneLoaderServices
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask LoadAsync(string sceneName) => 
            await SceneManager.LoadSceneAsync(sceneName);

        public async UniTask Unload()
        {
        }
    }
}