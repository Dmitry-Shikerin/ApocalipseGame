using System;
using UnityEngine;

namespace Sources.Presentations.Views.Players.PlayerCameras
{
    public class CameraRayGizmo : View
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(Camera.main.transform.position,
                Camera.main.ScreenPointToRay(Input.mousePosition).direction
            * 100);
        }
    }
}