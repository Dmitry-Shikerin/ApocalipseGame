using Cysharp.Threading.Tasks;
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.Players;

namespace Sources.Infrastructure.Services.WarmUpServices.Concrete
{
    public class BearAssetProvider : AssetProviderBase
    {
        public BearView BearView { get; private set; }

        public override async UniTask LoadAsync()
        {
            BearView =  await LoadAssetAsync<BearView>(nameof(BearView));
        }

    }
}