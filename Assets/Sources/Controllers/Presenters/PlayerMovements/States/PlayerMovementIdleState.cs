using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerMovementIdleState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;

        public PlayerMovementIdleState(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
        }

        public override void Enter(object payload = null)
        {
            SetSpeed(0);
        }
        
        private void SetSpeed(float speed)
        {
            _playerMovement.Speed = speed;
        }
    }
}