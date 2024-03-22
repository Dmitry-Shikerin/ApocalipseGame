using Cysharp.Threading.Tasks;
using Sources.Domain.Inventories.Items.Info;

namespace Sources.Infrastructure.Services.WarmUpServices.Concrete
{
    public class InventoryItemInfoProvider : AssetProviderBase
    {
        public InventoryItemInfoContainer InventoryItemInfoContainer { get; private set; }
        
        public override async UniTask LoadAsync()
        {
            InventoryItemInfoContainer = await LoadObjectAsync<InventoryItemInfoContainer>(
                nameof(InventoryItemInfoContainer));
        }
    }
}