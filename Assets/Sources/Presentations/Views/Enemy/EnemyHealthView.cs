using Sources.Controllers.Presenters.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemy
{
    public class EnemyHealthView : PresentableView<EnemyHealthPresenter>, IEnemyHealthView
    {
        public Vector3 Position => transform.position;
        
        public void TakeDamage(float damage)
        {
            Presenter.TakeDamage(damage);
        }

    }
}