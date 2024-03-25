using Sources.PresentationsInterfaces.Views.Followables;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.PlayerCameras
{
    public interface IPlayerCameraView : IFollowable
    {
        Vector3 Position { get; }
    }
}