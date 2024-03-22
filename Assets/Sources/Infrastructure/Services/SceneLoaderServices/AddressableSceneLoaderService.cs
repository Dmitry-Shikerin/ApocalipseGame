using Cysharp.Threading.Tasks;
using Sources.InfrastructureInterfaces.Services.SceneLoaderServices;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Sources.Infrastructure.Services.SceneLoaderServices
{
    public class AddressableSceneLoaderService : ISceneLoaderService
    {
        private SceneInstance _currentScene;
        
        public async UniTask LoadAsync(string sceneName) => 
            _currentScene = await Addressables.LoadSceneAsync(sceneName).Task;

        //TODO сделать ли его асинхронным?
        public void Unload() => 
            Addressables.UnloadSceneAsync(_currentScene);
    }
}