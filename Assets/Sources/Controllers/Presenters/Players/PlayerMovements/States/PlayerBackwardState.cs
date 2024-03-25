using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerBackwardState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IPlayerAnimationView _playerAnimationView;

        public PlayerBackwardState(
            PlayerMovement playerMovement,
            IPlayerAnimationView playerAnimationView)
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
            _playerAnimationView = playerAnimationView ?? throw new ArgumentNullException(nameof(playerAnimationView));
        }

        public override void Exit()
        {
        }

        public override void Enter(object payload = null)
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}