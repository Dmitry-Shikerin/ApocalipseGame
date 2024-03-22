using System;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Controllers.Presenters.Bears.States
{
    public class IdleState : FiniteState
    {
        private readonly IBearAnimationView _bearAnimationView;

        public IdleState(IBearAnimationView bearAnimationView)
        {
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
        }

        public override void Enter()
        {
            _bearAnimationView.PlayIdle();
            Debug.Log("Bear enter IdleState");
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}