using System;
using Sources.Controllers.Presenters.Bears;
using Sources.Controllers.Presenters.Bears.States;
using Sources.Domain.Bears;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.Transitions;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Infrastructure.Factories.Controllers.Bears
{
    public class BearPresenterFactory
    {
        private readonly IUpdateRegister _updateRegister;

        public BearPresenterFactory(IUpdateRegister updateRegister)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public BearPresenter Create(
            Bear bear,
            PlayerMovement playerMovement, 
            IBearView bearView, 
            IBearAnimationView bearAnimationView)
        {
            IdleState idleState = new IdleState(bearAnimationView);
            FollowState followState = new FollowState(bearAnimationView, bearView, playerMovement);

            FiniteTransitionBase toFollowTransition = new FiniteTransitionBase(
                followState,
                () => Vector3.Distance(playerMovement.Position, bearView.Position) > 3f);
            idleState.AddTransition(toFollowTransition);
            
            FiniteTransitionBase toIdleTransition = new FiniteTransitionBase(
                idleState, () => Vector3.Distance(playerMovement.Position, bearView.Position) < 3f);
            followState.AddTransition(toIdleTransition);

            return new BearPresenter(idleState, _updateRegister);
        }
    }
}