using System;
using Sources.Domain.Enemies;
using Sources.Infrastructure.Factories.Views.Healths;
using Sources.Presentations.Views.Enemy;

namespace Sources.Infrastructure.Factories.Views.Enemies
{
    public class EnemyCommonViewFactory
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyHealthViewFactory _enemyHealthViewFactory;
        private readonly HealthUiFactory _healthUiFactory;

        public EnemyCommonViewFactory(
            EnemyViewFactory enemyViewFactory,
            EnemyHealthViewFactory enemyHealthViewFactory,
            HealthUiFactory healthUiFactory)
        {
            _enemyViewFactory = enemyViewFactory ?? 
                                throw new ArgumentNullException(nameof(enemyViewFactory));
            _enemyHealthViewFactory = enemyHealthViewFactory ?? 
                                      throw new ArgumentNullException(nameof(enemyHealthViewFactory));
            _healthUiFactory = healthUiFactory ?? throw new ArgumentNullException(nameof(healthUiFactory));
        }

        public void Craete(Enemy enemy, EnemyHealth enemyHealth)
        {
            EnemyView enemyView = (EnemyView)_enemyViewFactory.Create(enemy);

            _healthUiFactory.Create(enemyHealth, enemyView.EnemyHealthUi);
            _enemyHealthViewFactory.Create(enemyHealth, enemyView.EnemyHealthView);
        }
    }
}