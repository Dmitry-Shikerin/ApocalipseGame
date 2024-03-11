using Sources.PresentationsInterfaces.Views.ILookSettables;
using Sources.PresentationsInterfaces.Views.Movables;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.PlayerMovement
{
    public interface IPlayerMovementView : IMovable, ILookSettable
    {
        Vector3 Position { get; }
    }
}