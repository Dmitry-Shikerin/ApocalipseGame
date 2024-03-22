using Cysharp.Threading.Tasks;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public interface IAssetProvider
    {
        UniTask LoadAsync();
        void Release();
    }
}