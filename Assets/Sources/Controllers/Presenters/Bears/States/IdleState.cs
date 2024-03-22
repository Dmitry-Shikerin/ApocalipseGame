using System;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;

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
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}