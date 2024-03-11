using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.InputServices;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerMovementState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IInputService _inputService;

        public PlayerMovementState
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
            float targetSpeed = _inputService.PlayerInput.Speed > 0 
                ? _inputService.PlayerInput.Speed 
                : 0.7f;

            _playerMovement.Speed = Mathf.MoveTowards(
                _playerMovement.Speed, targetSpeed, 0.01f);
            
            _playerMovement.Direction = _playerMovement.Speed *
                                        deltaTime * _inputService.PlayerInput.Direction.normalized;

            if(_playerMovement.Direction == Vector3.zero)
                return;
            
            _playerMovement.LookDirection = Vector3.RotateTowards(
                _playerMovement.LookDirection, _playerMovement.Direction,
                0.05f, 0.01f);
        }
    }
}