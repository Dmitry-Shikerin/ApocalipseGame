using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Views.PlayerMovements;

namespace Sources.Infrastructure.Factories.Views.Scenes
{
    public class GameplaySceneViewFactory
    {
        private readonly PlayerMovementViewFactory _playerMovementViewFactory;

        public GameplaySceneViewFactory
        (
            PlayerMovementViewFactory playerMovementViewFactory
        )
        {
            _playerMovementViewFactory = playerMovementViewFactory ??
                                         throw new ArgumentNullException(nameof(playerMovementViewFactory));
        }

        public void Create()
        {
            PlayerMovement playerMovement = new PlayerMovement();
            _playerMovementViewFactory.Create(playerMovement);
        }
    }
}