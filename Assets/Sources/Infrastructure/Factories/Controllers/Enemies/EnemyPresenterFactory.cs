using System;
using Sources.Controllers.Presenters.Enemies;
using Sources.Controllers.Presenters.Enemies.States;
using Sources.Domain.Enemies;
using Sources.Infrastructure.Services.Providers.ModelProviders;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Infrastructure.Factories.Controllers.Enemies
{
    public class EnemyPresenterFactory
    {
        private readonly IPlayerMovementProvider _playerMovementProvider;
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenterFactory(
            IPlayerMovementProvider playerMovementProvider,
            IUpdateRegister updateRegister)
        {
            _playerMovementProvider = playerMovementProvider ?? 
                                      throw new ArgumentNullException(nameof(playerMovementProvider));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public EnemyPresenter Create(Enemy enemy, IEnemyView enemyView, IEnemyAnimation enemyAnimation)
        {
            EnemyInitializeState initializeState = new EnemyInitializeState(enemy);
            EnemyMoveToPlayerState moveToPlayerState = new EnemyMoveToPlayerState(
                enemyView, enemyAnimation, _playerMovementProvider);
            EnemyAttackState attackState = new EnemyAttackState(enemyView);
            EnemyDeadState deadState = new EnemyDeadState();

            FiniteTransition toMoveToPlayerTransition = new FiniteTransitionBase(
                moveToPlayerState, () => enemy.IsInitialized);
            initializeState.AddTransition(toMoveToPlayerTransition);
            
            return new EnemyPresenter(initializeState, enemy, enemyView, _updateRegister);
        }
    }
}