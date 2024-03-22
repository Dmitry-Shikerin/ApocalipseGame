using Cysharp.Threading.Tasks;
using Sources.Presentations.Views.PlayerAnimation;
using Sources.Presentations.Views.PlayerMovements;
using Sources.Presentations.Views.Players;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public class PlayerAssetProvider : AssetProviderBase
    {
        public PlayerView PlayerView { get; private set; }

        public override async UniTask LoadAsync()
        {
            PlayerView =  await LoadAssetAsync<PlayerView>("PlayerView");
        }
     }
}