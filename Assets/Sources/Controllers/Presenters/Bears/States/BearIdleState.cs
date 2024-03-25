using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Infrastructure.Services.OverlapServices;
using Sources.Infrastructure.Services.Providers.ModelProviders;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.Presentations.Views.Enemy;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Controllers.Presenters.Bears.States
{
    public class BearIdleState : FiniteState
    {
        private readonly IBearAnimationView _bearAnimationView;
        private readonly OverlapService _overlapService;
        private readonly IBearView _bearView;
        private readonly IPlayerMovementProvider _playerMovementProvider;

        private IReadOnlyList<EnemyHealthView> _enemies;

        public BearIdleState(
            IBearAnimationView bearAnimationView,
            OverlapService overlapService,
            IBearView bearView,
            IPlayerMovementProvider playerMovementProvider)
        {
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _playerMovementProvider = playerMovementProvider ?? throw new ArgumentNullException(nameof(playerMovementProvider));
        }

        public override void Enter()
        {
            Debug.Log($"Bear enter idle state");
            _bearAnimationView.PlayIdle();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            FindEnemy();
        }

        private void FindEnemy()
        {
            if(_bearView.EnemyHealthView != null)
                return;
            
            var enemies = _overlapService.OverlapSphere<EnemyHealthView>(
                _playerMovementProvider.Position, 5f, 
                1 << LayerMask.NameToLayer("Enemy"),
                1 << LayerMask.NameToLayer("Obstacle"));

            EnemyHealthView enemy = enemies.FirstOrDefault();
            
            _bearView.EnemyHealthView = enemy;
        }
    }
}