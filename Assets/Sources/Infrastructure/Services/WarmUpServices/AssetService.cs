using Cysharp.Threading.Tasks;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public class AssetService<T> : IAssetService where T : IAssetProvider, new()
    {
        //TODO для чего этот ассет сервис?
        public T Provider { get; } = new T();
        
        public async UniTask LoadAsync() =>
            await Provider.LoadAsync();

        public void Release() =>
            Provider.Release();
    }
}