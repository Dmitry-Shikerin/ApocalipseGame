using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Sources.Infrastructure.Services.WarmUpServices
{
    public abstract class WarmUpService
    {
        protected GameObject Instance;

        protected async UniTask LoadAssetAsync(string key)
        {
            if (Instance != null)
                 throw new InvalidOperationException(nameof(Instance));
            
            Instance = await Addressables.LoadAssetAsync<GameObject>(key);
        }

        public void Release()
        {
            Addressables.Release(Instance);
        }
    }
}