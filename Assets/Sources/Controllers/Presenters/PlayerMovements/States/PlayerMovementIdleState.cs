using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using UnityEngine;

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
        }

        public override void Update(float deltaTime)
        {
            _playerMovement.Speed = Mathf.MoveTowards(
                _playerMovement.Speed, 0, 0.01f);
        }
    }
}