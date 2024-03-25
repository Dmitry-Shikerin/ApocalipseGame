using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Bears
{
    public interface IBearView
    {
        Vector3 Position { get;}
        float StoppingDistance { get; }
        IEnemyHealthView EnemyHealthView { get; set; }

        void Move(Vector3 destination);
        void SetStoppingDistance(float distance);
    }
}