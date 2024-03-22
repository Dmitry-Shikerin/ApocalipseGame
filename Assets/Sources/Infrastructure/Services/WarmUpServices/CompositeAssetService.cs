using Cysharp.Threading.Tasks;
using Sirenix.Utilities;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public class CompositeAssetService : ICompositeAssetService
    {
        private readonly IAssetService[] _assetServices;
        
        public CompositeAssetService(
            AssetService<PlayerAssetProvider> playerAssetProvider,
            AssetService<InventoryItemInfoProvider> inventoryItemInfoProvider)
        {
            _assetServices = new IAssetService[]
            {
                   playerAssetProvider,
                   // inventoryItemInfoProvider
            };
        }
        
        public async UniTask LoadAsync()
        {
            foreach (IAssetService assetService in _assetServices) 
                await assetService.LoadAsync();
        }

        public void Release()
        {
            foreach (var assetService in _assetServices) 
                assetService.Release();
        }
    }
}