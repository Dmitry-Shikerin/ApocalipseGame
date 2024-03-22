using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Controllers.Presenters.Bears.States
{
    public class FollowState : FiniteState
    {
        private readonly IBearAnimationView _bearAnimationView;
        private readonly IBearView _bearView;
        private readonly PlayerMovement _playerMovement;

        private CancellationTokenSource _cancellationTokenSource;

        public FollowState(IBearAnimationView bearAnimationView, IBearView bearView, PlayerMovement playerMovement)
        {
            _bearAnimationView = bearAnimationView ?? throw new ArgumentNullException(nameof(bearAnimationView));
            _bearView = bearView ?? throw new ArgumentNullException(nameof(bearView));
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
        }

        public override void Enter()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _bearAnimationView.PlayWalk();
            Debug.Log("Bear enter WalkState");
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
            _bearView.Move(_playerMovement.Position);
        }
    }
}