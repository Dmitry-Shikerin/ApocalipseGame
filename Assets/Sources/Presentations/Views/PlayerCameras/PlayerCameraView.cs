using Sources.Infrastructure.Factories.Controllers.PlayerCameras;
using UnityEngine;

namespace Sources.Presentations.Views.PlayerCameras
{
    public class PlayerCameraView : PresentableView<PlayerCameraPresenter>, IPlayerCameraView
    {
        public void Follow(Vector3 position) => 
            transform.position = position;
    }
}