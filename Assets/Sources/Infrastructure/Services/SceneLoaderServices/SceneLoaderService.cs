﻿using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Services.SceneLoaderServices
{
    public class SceneLoaderService
    {
        public async UniTask LoadAsync(string sceneName) => 
            await SceneManager.LoadSceneAsync(sceneName);
    }
}