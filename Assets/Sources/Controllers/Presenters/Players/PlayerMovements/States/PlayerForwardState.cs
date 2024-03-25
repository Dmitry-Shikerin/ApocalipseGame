using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerForwardState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IInputService _inputService;
        private readonly IPlayerAnimationView _playerAnimationView;

        public PlayerForwardState
        (
            PlayerMovement playerMovement,
            IInputService inputService,
            IPlayerAnimationView playerAnimationView
        )
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _playerAnimationView = playerAnimationView ?? throw new ArgumentNullException(nameof(playerAnimationView));
        }

        public override void Enter(object payload = null)
        {
            _playerAnimationView.PlayForwardWalk();
        }

        public override void Update(float deltaTime)
        {
            float targetSpeed = _inputService.PlayerInput.Speed > 0 
                ? _inputService.PlayerInput.Speed 
                : 0.7f;

            _playerMovement.Speed = Mathf.MoveTowards(
                _playerMovement.Speed, targetSpeed, 0.01f);
            
            _playerMovement.Direction = _playerMovement.Speed * 5 *
                                        deltaTime * _inputService.PlayerInput.MoveDirection.normalized;

            // if(_playerMovement.Direction == Vector3.zero)
            //     return;

            Vector3 direction = _inputService.PlayerInput.LookDirection -
                                _playerMovement.LookDirection;

            _playerMovement.LookDirection = direction;

            // _playerMovement.LookDirection = Vector3.RotateTowards(
            //     _playerMovement.LookDirection, _inputService.PlayerInput.LookDirection -
            //     _playerMovement.LookDirection,
            //     0.05f, 0.01f);
        }
    }
}