using Sources.Infrastructure.Factories.Controllers.PlayerCameras;
using Sources.PresentationsInterfaces.Views.PlayerCameras;
using UnityEngine;

namespace Sources.Presentations.Views.Players.PlayerCameras
{
    public class PlayerCameraView : PresentableView<PlayerCameraPresenter>, IPlayerCameraView
    {
        public Vector3 Position => transform.position;
        
        public void Follow(Vector3 position) => 
            transform.position = position;

    }
}