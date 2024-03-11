using System;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Views.PlayerCameras;
using Sources.Infrastructure.Factories.Views.PlayerMovements;

namespace Sources.Infrastructure.Factories.Views.Scenes
{
    public class GameplaySceneViewFactory
    {
        private readonly PlayerMovementViewFactory _playerMovementViewFactory;
        private readonly PlayerCameraViewFactory _playerCameraViewFactory;

        public GameplaySceneViewFactory
        (
            PlayerMovementViewFactory playerMovementViewFactory,
            PlayerCameraViewFactory playerCameraViewFactory
        )
        {
            _playerMovementViewFactory = playerMovementViewFactory ??
                                         throw new ArgumentNullException(nameof(playerMovementViewFactory));
            _playerCameraViewFactory = playerCameraViewFactory ?? 
                                       throw new ArgumentNullException(nameof(playerCameraViewFactory));
        }

        public void Create()
        {
            PlayerMovement playerMovement = new PlayerMovement();
            _playerMovementViewFactory.Create(playerMovement);

            PlayerCamera playerCamera = new PlayerCamera(playerMovement);
            _playerCameraViewFactory.Create(playerCamera);
        }
    }
}