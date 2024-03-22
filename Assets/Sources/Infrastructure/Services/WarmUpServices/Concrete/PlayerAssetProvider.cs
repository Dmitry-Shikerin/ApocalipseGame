using Cysharp.Threading.Tasks;
using Sources.Presentations.Views.Players;

namespace Sources.Infrastructure.Services.WarmUpServices.Concrete
{
    public class PlayerAssetProvider : AssetProviderBase
    {
        public PlayerView PlayerView { get; private set; }

        public override async UniTask LoadAsync()
        {
            PlayerView =  await LoadAssetAsync<PlayerView>(nameof(PlayerView));
        }
     }
}