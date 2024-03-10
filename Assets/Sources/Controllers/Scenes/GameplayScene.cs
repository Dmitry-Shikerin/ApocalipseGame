using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly InputService _inputService;

        public GameplayScene
        (
            IUpdateService updateService,
            InputService inputService
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public string Name => nameof(GameplayScene);

        public void Enter(object payload = null)
        {
        }

        public void Exit()
        {
            _updateService.UnregisterAll();
        }

        public void Update(float deltaTime)
        {
            _updateService.Update(deltaTime);
            _inputService.Update(deltaTime);
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}