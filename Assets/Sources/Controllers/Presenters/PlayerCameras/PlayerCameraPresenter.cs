using System;
using Sources.Controllers.Presenters;
using Sources.Controllers.Presenters.PlayerCamera;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.PlayerCameras;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.PlayerCameras
{
    public class PlayerCameraPresenter : PresenterBase
    {
        private readonly PlayerCamera _playerCamera;
        private readonly IPlayerCameraView _playerCameraView;
        private readonly ILateUpdateRegister _lateUpdateRegister;

        public PlayerCameraPresenter(
            PlayerCamera playerCamera,
            IPlayerCameraView playerCameraView,
            ILateUpdateRegister lateUpdateRegister)
        {
            _playerCamera = playerCamera ?? throw new ArgumentNullException(nameof(playerCamera));
            _playerCameraView = playerCameraView ?? throw new ArgumentNullException(nameof(playerCameraView));
            _lateUpdateRegister = lateUpdateRegister ?? throw new ArgumentNullException(nameof(lateUpdateRegister));
        }

        public override void Enable() => 
            _lateUpdateRegister.Register(OnLateUpdate);

        public override void Disable() => 
            _lateUpdateRegister.UnRegister(OnLateUpdate);

        private void OnLateUpdate(float deltaTime) =>
            _playerCameraView.Follow(_playerCamera.Position);
    }
}