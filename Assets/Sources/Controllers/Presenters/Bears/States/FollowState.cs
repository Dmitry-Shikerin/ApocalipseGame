using System;
using System.Threading;
using Sources.Domain.Bears;
using Sources.Infrastructure.Services.Providers.ModelProviders;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Controllers.Presenters.Bears.States
{
    public class FollowState : FiniteState
    {
        private readonly Bear _bear;
        private readonly IBearAnimationView _bearAnimationView;
        private readonly IBearView _bearView;
        private readonly IPlayerMovementProvider _playerMovementProvider;

        public FollowState(
            Bear bear,
            IBearAnimationView bearAnimationView,
            IBearView bearView,
            IPlayerMovementProvider playerMovementProvider)
        {
            _bear = bear ?? throw new ArgumentNullException(nameof(bear));
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _playerMovementProvider = playerMovementProvider 
                                      ?? throw new ArgumentNullException(nameof(playerMovementProvider));
        }

        public override void Enter()
        {
            _bearAnimationView.PlayWalk();
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            _bearView.Move(_playerMovementProvider.Position);
            _bear.Position = _bearView.Position;
        }
    }
}