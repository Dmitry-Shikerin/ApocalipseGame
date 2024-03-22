using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Bears
{
    public interface IBearView
    {
        Vector3 Position { get;}

        void Move(Vector3 destination);
    }
}