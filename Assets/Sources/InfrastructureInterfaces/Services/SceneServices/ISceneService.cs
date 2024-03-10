using Cysharp.Threading.Tasks;

namespace Sources.InfrastructureInterfaces.Services.SceneServices
{
    public interface ISceneService
    {
        UniTask ChangeSceneAsync(string sceneName, object payload);
        void Disable();
    }
}