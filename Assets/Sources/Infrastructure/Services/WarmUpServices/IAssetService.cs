using Cysharp.Threading.Tasks;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public interface IAssetService
    {
        UniTask LoadAsync();
        void Release();
    }
}