using System;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines.States;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerMovements.States
{
    public class PlayerIdleState : ContextStateBase
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IPlayerAnimationView _playerAnimationView;
        private readonly IInputService _inputService;

        public PlayerIdleState(
            PlayerMovement playerMovement,
            IPlayerAnimationView playerAnimationView,
            IInputService inputService)
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
            _playerAnimationView = playerAnimationView ?? 
                                   throw new ArgumentNullException(nameof(playerAnimationView));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public override void Enter(object payload = null)
        {
            _playerAnimationView.PlayIdle();
        }

        public override void Update(float deltaTime)
        {
            _playerMovement.Speed = Mathf.MoveTowards(
                _playerMovement.Speed, 0, 0.01f);
            
            float targetSpeed = _inputService.PlayerInput.Speed > 0 
                ? _inputService.PlayerInput.Speed 
                : 0.7f;

            _playerMovement.Speed = Mathf.MoveTowards(
                _playerMovement.Speed, targetSpeed, 0.01f);
            
            _playerMovement.Direction = _playerMovement.Speed * 5 *
                                        deltaTime * _inputService.PlayerInput.MoveDirection.normalized;

            // if(_playerMovement.Direction == Vector3.zero)
            //     return;
            
            _playerMovement.LookDirection = Vector3.RotateTowards(
                _playerMovement.LookDirection, _inputService.PlayerInput.LookDirection -
                                               _playerMovement.LookDirection,
                0.05f, 0.01f);

        }
    }
}