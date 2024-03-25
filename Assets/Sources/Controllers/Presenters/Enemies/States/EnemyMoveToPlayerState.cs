using System;
using Sources.Infrastructure.Services.Providers.ModelProviders;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Controllers.Presenters.Enemies.States
{
    public class EnemyMoveToPlayerState : FiniteState
    {
        private readonly IEnemyView _enemyView;
        private readonly IEnemyAnimation _enemyAnimation;
        private readonly IPlayerMovementProvider _playerMovementProvider;

        public EnemyMoveToPlayerState(
            IEnemyView enemyView,
            IEnemyAnimation enemyAnimation,
            IPlayerMovementProvider playerMovementProvider)
        {
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _enemyAnimation = enemyAnimation ?? throw new ArgumentNullException(nameof(enemyAnimation));
            _playerMovementProvider = playerMovementProvider ?? 
                                      throw new ArgumentNullException(nameof(playerMovementProvider));
        }

        public override void Enter()
        {
            // _enemyAnimation.PlayMove();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            // _enemyView.Move(_playerMovementProvider.Position);
        }
    }
}