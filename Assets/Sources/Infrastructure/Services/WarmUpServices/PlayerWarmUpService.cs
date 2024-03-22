using System;
using Cysharp.Threading.Tasks;
using Sources.Presentations.Views.PlayerMovements;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public class PlayerWarmUpService : WarmUpService
    {
        public PlayerMovementView PlayerMovementView {get; private set;}

        public async UniTask LoadAsync()
        {
            await LoadAssetAsync("PlayerMovementView");
            
            if(Instance.TryGetComponent(out PlayerMovementView playerMovementView) == false)
                throw new InvalidOperationException();
                
            PlayerMovementView = playerMovementView;
        }
     }
}