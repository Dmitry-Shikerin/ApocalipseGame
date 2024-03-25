using System;
using Sources.Controllers.Presenters.Enemies;
using Sources.Domain.Enemies;
using Sources.Infrastructure.Factories.Controllers.Enemies;
using Sources.Presentations.Views.Enemy;
using Sources.PresentationsInterfaces.Views.Enemies;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyViewFactory
    {
        private readonly EnemyPresenterFactory _enemyPresenterFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;

        public EnemyViewFactory(
            EnemyPresenterFactory enemyPresenterFactory,
            EnemyHealthViewFactory enemyHealthViewFactory)
        {
            _enemyPresenterFactory = enemyPresenterFactory ??
                                     throw new ArgumentNullException(nameof(enemyPresenterFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory 
                                      ?? throw new ArgumentNullException(nameof(enemyHealthViewFactory));
        }

        public IEnemyView Create(Enemy enemy)
        {
            EnemyView enemyView = Object.FindObjectOfType<EnemyView>();
            EnemyPresenter enemyPresenter = _enemyPresenterFactory.Create(
                enemy, enemyView, enemyView.EnemyAnimation);
            enemyView.Construct(enemyPresenter);
            
            return enemyView;
        }
    }
}