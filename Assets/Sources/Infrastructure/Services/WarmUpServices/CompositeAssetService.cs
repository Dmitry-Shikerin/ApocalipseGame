using Cysharp.Threading.Tasks;
using Sirenix.Utilities;
using Sources.Infrastructure.Services.WarmUpServices.Concrete;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public class CompositeAssetService : ICompositeAssetService
    {
        private readonly IAssetService[] _assetServices;
        
        public CompositeAssetService(
            AssetService<PlayerAssetProvider> playerAssetProvider,
            AssetService<InventoryItemInfoProvider> inventoryItemInfoProvider,
            AssetService<BearAssetProvider> bearAssetProvider)
        {
            _assetServices = new IAssetService[]
            {
                   playerAssetProvider,
                   inventoryItemInfoProvider,
                   bearAssetProvider,
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