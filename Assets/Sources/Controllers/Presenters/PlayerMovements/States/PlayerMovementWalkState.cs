using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.InputServices;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerMovementWalkState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IInputService _inputService;

        public PlayerMovementWalkState
        (
            PlayerMovement playerMovement,
            IInputService inputService
        )
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public override void Enter(object payload = null)
        {
        }

        public override void Update(float deltaTime)
        {
            _playerMovement.Direction = _inputService.PlayerInput.Direction * 5 * deltaTime;
            Debug.Log(_playerMovement.Direction);
        }
    }
}