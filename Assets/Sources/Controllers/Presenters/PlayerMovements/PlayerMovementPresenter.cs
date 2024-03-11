using System;
using System.ComponentModel;
using Sources.ControllersInterfaces.Presenters;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.ContextStateMachines;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;
using Sources.PresentationsInterfaces.Views.PlayerMovement;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerMovements
{
    public class PlayerMovementPresenter : ContextStateMachine, IPresenter
    {
        private readonly PlayerMovement _playerMovement;
        private readonly IPlayerMovementView _playerMovementView;
        private readonly IUpdateRegister _updateRegister;
        private readonly IInputService _inputService;

        public PlayerMovementPresenter
        (
            PlayerMovement playerMovement,
            IPlayerMovementView playerMovementView,
            IUpdateRegister updateRegister,
            IInputService inputService,
            IContextState firstState
        ) : base(firstState)
        {
            _playerMovement = playerMovement ?? throw new ArgumentNullException(nameof(playerMovement));
            _playerMovementView = playerMovementView ?? throw new ArgumentNullException(nameof(playerMovementView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public void Enable()
        {
            _playerMovement.PropertyChanged += OnPropertyChanged;
            _updateRegister.Register(OnUpdate);
        }

        public void Disable()
        {
            _playerMovement.PropertyChanged += OnPropertyChanged;
            _updateRegister.UnRegister(OnUpdate);
        }

        private void OnUpdate(float deltaTime)
        {
            Apply(_inputService.PlayerInput);
            Update(deltaTime);
            
            UpdatePosition();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnDirectionChanged(sender, e);
        }

        private void OnDirectionChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(PlayerMovement.Direction))
                return;

            _playerMovementView.Move(_playerMovement.Direction);
        }

        private void UpdatePosition()
        {
            _playerMovement.Position = _playerMovementView.Position;
        }
    }
}