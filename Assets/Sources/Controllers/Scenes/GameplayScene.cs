﻿using System;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Views.Scenes;
using Sources.Infrastructure.Services.InputService;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        private readonly IUpdateService _updateService;
        private readonly InputService _inputService;
        private readonly GameplaySceneViewFactory _gameplaySceneViewFactory;

        public GameplayScene
        (
            IUpdateService updateService,
            InputService inputService,
            GameplaySceneViewFactory gameplaySceneViewFactory
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _gameplaySceneViewFactory = gameplaySceneViewFactory 
                                        ?? throw new ArgumentNullException(nameof(gameplaySceneViewFactory));
        }

        public string Name => nameof(GameplayScene);

        public void Enter(object payload = null)
        {
            _gameplaySceneViewFactory.Create();
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