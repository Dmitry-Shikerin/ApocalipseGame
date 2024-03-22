using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Players.PlayerCameras
{
    public class CinemachineCameraView : View
    {
        [Required] [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public void Follow(Transform target)
        {
            _cinemachineVirtualCamera.Follow = target;
        }
    }
}