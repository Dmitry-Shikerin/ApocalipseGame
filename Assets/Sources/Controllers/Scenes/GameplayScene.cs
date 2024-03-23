using System;
using Cysharp.Threading.Tasks;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.InfrastructureInterfaces.Services.SceneLoaderServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly ILateUpdateService _lateUpdateService;
        private readonly IUpdateService _updateService;
        private readonly NewInputService _inputService;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;
        private readonly ICompositeAssetService _compositeAssetService;
        private readonly ISceneLoaderService _sceneLoaderService;

        public GameplayScene(
            ILateUpdateService lateUpdateService,
            IUpdateService updateService,
            NewInputService inputService,
            GameplaySceneViewFactory gameplaySceneViewFactory,
            ICompositeAssetService compositeAssetService,
            ISceneLoaderService sceneLoaderService)
        {
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _gameplaySceneViewFactory = gameplaySceneViewFactory 
                                        ?? throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
            _compositeAssetService = compositeAssetService ?? 
                                     throw new ArgumentNullException(nameof(compositeAssetService));
            _sceneLoaderService = sceneLoaderService ?? throw new ArgumentNullException(nameof(sceneLoaderService));
        }

        public string Name => nameof(GameplayScene);

        public async void Enter(object payload = null)
        {
            await UniTask.WhenAll(
                _compositeAssetService.LoadAsync());
            
            _gameplaySceneViewFactory.Create();
        }

        public async void Exit()
        {
            _updateService.UnregisterAll();
            _lateUpdateService.UnregisterAll();
            
            _compositeAssetService.Release();

            await UniTask.WhenAll(
                _sceneLoaderService.Unload());
        }

        public void Update(float deltaTime)
        {
            _updateService.Update(deltaTime);
            _inputService.Update(deltaTime);
        }

        public void UpdateLate(float deltaTime)
        {
            _lateUpdateService.UpdateLate(deltaTime);
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}