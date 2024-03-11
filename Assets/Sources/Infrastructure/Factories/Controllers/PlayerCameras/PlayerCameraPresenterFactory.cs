using System;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.Infrastructure.Factories.Controllers.PlayerCameras;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.Presentations.Views.PlayerCameras;
using Sources.PresentationsInterfaces.Views.PlayerCameras;

namespace Sources.Infrastructure.Factories.PlayerCameras
{
    public class PlayerCameraPresenterFactory
    {
        private readonly ILateUpdateRegister _lateUpdateRegister;

        public PlayerCameraPresenterFactory(ILateUpdateRegister lateUpdateRegister)
        {
            _lateUpdateRegister = lateUpdateRegister ?? 
                                  throw new ArgumentNullException(nameof(lateUpdateRegister));
        }

        public PlayerCameraPresenter Create(PlayerCamera playerCamera, IPlayerCameraView playerCameraView)
        {
            return new PlayerCameraPresenter(playerCamera, playerCameraView, _lateUpdateRegister);
        }
    }
}