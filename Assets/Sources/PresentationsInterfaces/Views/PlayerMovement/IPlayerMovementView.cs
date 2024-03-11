using Sources.PresentationsInterfaces.Views.Movables;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.PlayerMovement
{
    public interface IPlayerMovementView : IMovable
    {
        Vector3 Position { get; }
    }
}