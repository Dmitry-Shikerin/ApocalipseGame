using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerMovementWalkState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;

        public PlayerMovementWalkState(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
        }

        public override void Enter(object payload = null)
        {
            
        }

        public override void Update(float deltaTime)
        {
            
        }
    }
}