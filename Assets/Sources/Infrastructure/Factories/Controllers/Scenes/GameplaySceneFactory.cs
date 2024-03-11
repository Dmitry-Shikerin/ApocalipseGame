using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly ILateUpdateService _lateUpdateService;
        private readonly IUpdateService _updateService;
        private readonly InputService _inputService;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;

        public GameplaySceneFactory
        (
            ILateUpdateService lateUpdateService,
            IUpdateService updateService,
            InputService inputService,
            GameplaySceneViewFactory gameplaySceneViewFactory
        )
        {
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _gameplaySceneViewFactory = gameplaySceneViewFactory 
                                        ?? throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene
            (
                _lateUpdateService,
                _updateService,
                _inputService,
                _gameplaySceneViewFactory
            );
        }
    }
}