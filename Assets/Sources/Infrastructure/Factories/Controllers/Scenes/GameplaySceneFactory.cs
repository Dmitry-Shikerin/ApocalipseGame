using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.SceneLoaderServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly ILateUpdateService _lateUpdateService;
        private readonly IUpdateService _updateService;
        private readonly NewInputService _inputService;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;
        private readonly ICompositeAssetService _compositeAssetService;
        private readonly ISceneLoaderService _sceneLoaderService;

        public GameplaySceneFactory(
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

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene
            (
                _lateUpdateService,
                _updateService,
                _inputService,
                _gameplaySceneViewFactory,
                _compositeAssetService,
                _sceneLoaderService
            );
        }
    }
}