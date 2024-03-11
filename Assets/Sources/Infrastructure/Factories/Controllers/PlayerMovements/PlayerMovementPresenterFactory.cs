﻿using System;
using Sources.Controllers.Presenters.PlayerMovements;
using Sources.Controllers.Presenters.PlayerMovements.States;
using Sources.Domain.Dto;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Services.InputService;
using Sources.Infrastructure.StateMachines.ContextStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.PlayerMovement;

namespace Sources.Infrastructure.Factories.Controllers.PlayerMovements
{
    public class PlayerMovementPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IInputService _inputService;

        public PlayerMovementPresenterFactory
        (
            IUpdateRegister updateRegister,
            IInputService inputService
        )
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public PlayerMovementPresenter Create(PlayerMovement playerMovement, IPlayerMovementView playerMovementView)
        {
            PlayerMovementIdleState idleState = new PlayerMovementIdleState(playerMovement);
            PlayerMovementState state = new PlayerMovementState(
                playerMovement, _inputService);

            FuncContextTransition toWalkTransition = new FuncContextTransition(
                state, context =>
                {
                    if (context is not PlayerInput playerInput)
                        return false;

                    if (playerInput.Direction.magnitude < 0.01f)
                        return false;

                    return true;
                });
            idleState.AddTransition(toWalkTransition);

            FuncContextTransition toIdleTransition = new FuncContextTransition(
                idleState, context =>
                {
                    if (context is not PlayerInput playerInput)
                        return false;

                    if (playerInput.Direction.magnitude > 0.01f)
                        return false;

                    return true;
                });
            state.AddTransition(toIdleTransition);

            return new PlayerMovementPresenter
            (
                playerMovement,
                playerMovementView,
                _updateRegister,
                _inputService,
                idleState
            );
        }
    }
}