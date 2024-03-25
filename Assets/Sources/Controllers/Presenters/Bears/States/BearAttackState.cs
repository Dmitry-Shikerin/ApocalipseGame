using System;
using Sources.Domain.Bears;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Controllers.Presenters.Bears.States
{
    public class BearAttackState : FiniteState
    {
        private readonly IBearView _bearView;
        private readonly Bear _bear;
        private readonly IBearAnimationView _bearAnimationView;
        private readonly BearAttack _bearAttack;

        public BearAttackState(
            IBearView bearView,
            Bear bear, 
            IBearAnimationView bearAnimationView,
            BearAttack bearAttack)
        {
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _bear = bear ?? throw new ArgumentNullException(nameof(bear));
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearAttack = bearAttack ?? throw new ArgumentNullException(nameof(bearAttack));
        }

        public override void Enter()
        {
            Debug.Log($"Bear enter attack state");
            _bearAnimationView.Attacking += OnAttack;
            
            _bearAnimationView.PlayAttack();
        }

        public override void Exit()
        {
            _bearAnimationView.Attacking -= OnAttack;
        }

        public override void Update(float deltaTime)
        {
        }

        private void OnAttack()
        {
            _bearView.EnemyHealthView.TakeDamage(_bearAttack.Attack());
        }
    }
}