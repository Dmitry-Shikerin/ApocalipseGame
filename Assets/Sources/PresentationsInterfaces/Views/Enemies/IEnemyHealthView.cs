using Sources.PresentationsInterfaces.Views.Damagebles;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyHealthView : IDamageable
    {
        Vector3 Position { get; }
    }
}