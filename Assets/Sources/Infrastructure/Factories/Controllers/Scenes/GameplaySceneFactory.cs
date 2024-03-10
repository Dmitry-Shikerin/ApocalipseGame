using System;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Scenes;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.InfrastructureInterfaces.Factories.Controllers.Scenes;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Infrastructure.Factories.Controllers.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
    {
        private readonly IUpdateService _updateService;
        private readonly InputService _inputService;

        public GameplaySceneFactory
        (
            IUpdateService updateService,
            InputService inputService
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public async UniTask<IScene> Create(object payload)
        {
            return new GameplayScene
            (
                _updateService,
                _inputService
            );
        }
    }
}