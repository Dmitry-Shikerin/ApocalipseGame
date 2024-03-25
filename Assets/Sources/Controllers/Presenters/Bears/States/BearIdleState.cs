using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Infrastructure.Services.OverlapServices;
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

        private IReadOnlyList<EnemyHealthView> _enemies;

        public BearIdleState(
            IBearAnimationView bearAnimationView,
            OverlapService overlapService,
            IBearView bearView)
        {
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
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
            var enemies = _overlapService.OverlapSphere<EnemyHealthView>(
                _bearView.Position, 10f, 
                1 << LayerMask.NameToLayer("Enemy"),
                1 << LayerMask.NameToLayer("Obstacle"));

            EnemyHealthView enemy = enemies.FirstOrDefault();
            
            _bearView.EnemyHealthView = enemy;
        }
    }
}