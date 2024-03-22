using System;
using Sources.Controllers.Presenters.Bears;
using Sources.Controllers.Presenters.Bears.States;
using Sources.Domain.Bears;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Services.Providers.ModelProviders;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Bears
{
    public class BearPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;
        private readonly IPlayerMovementProvider _playerMovementProvider;

        public BearPresenterFactory(
            IUpdateRegister updateRegister,
            IPlayerMovementProvider playerMovementProvider)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _playerMovementProvider = playerMovementProvider 
                                      ?? throw new ArgumentNullException(nameof(playerMovementProvider));
        }

        public BearPresenter Create(
            Bear bear, 
            IBearView bearView, 
            IBearAnimationView bearAnimationView)
        {
            IdleState idleState = new IdleState(bearAnimationView);
            FollowState followState = new FollowState(bearAnimationView, bearView, _playerMovementProvider);

            FiniteTransitionBase toFollowTransition = new FiniteTransitionBase(
                followState,
                () => Vector3.Distance(_playerMovementProvider.Position, bearView.Position) > 3f);
            idleState.AddTransition(toFollowTransition);
            
            FiniteTransitionBase toIdleTransition = new FiniteTransitionBase(
                idleState, () => Vector3.Distance(
                    _playerMovementProvider.Position, bearView.Position) < 3f);
            followState.AddTransition(toIdleTransition);

            return new BearPresenter(idleState, _updateRegister);
        }
    }
}