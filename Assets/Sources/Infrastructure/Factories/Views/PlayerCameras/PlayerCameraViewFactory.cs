using System;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Controllers.PlayerCameras;
using Sources.Infrastructure.Factories.PlayerCameras;
using Sources.Presentations.Views.PlayerCameras;
using Sources.PresentationsInterfaces.Views.PlayerCameras;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.PlayerCameras
{
    public class PlayerCameraViewFactory
    {
        private readonly PlayerCameraPresenterFactory _playerCameraPresenterFactory;

        public PlayerCameraViewFactory(PlayerCameraPresenterFactory playerCameraPresenterFactory)
        {
            _playerCameraPresenterFactory = playerCameraPresenterFactory ??
                                            throw new ArgumentNullException(nameof(playerCameraPresenterFactory));
        }

        public IPlayerCameraView Create(PlayerCamera playerCamera)
        {
            PlayerCameraView playerCameraView = Object.FindAnyObjectByType<PlayerCameraView>();

            PlayerCameraPresenter playerCameraPresenter = 
                _playerCameraPresenterFactory.Create(playerCamera, playerCameraView);
            
            playerCameraView.Construct(playerCameraPresenter);

            return playerCameraView;
        }
    }
}