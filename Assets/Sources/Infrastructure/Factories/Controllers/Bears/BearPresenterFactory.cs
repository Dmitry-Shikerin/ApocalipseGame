using System;
using Sources.Controllers.Presenters.Bears;
using Sources.Controllers.Presenters.Bears.States;
using Sources.Domain.Bears;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Services.OverlapServices;
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
        private readonly OverlapService _overlapService;

        public BearPresenterFactory(
            IUpdateRegister updateRegister,
            IPlayerMovementProvider playerMovementProvider,
            OverlapService overlapService)
        {
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _playerMovementProvider = playerMovementProvider 
                                      ?? throw new ArgumentNullException(nameof(playerMovementProvider));
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public BearPresenter Create(
            Bear bear, 
            IBearView bearView, 
            IBearAnimationView bearAnimationView,
            BearAttack bearAttack)
        {
            BearIdleState bearIdleState = new BearIdleState(
                bearAnimationView, _overlapService, bearView, _playerMovementProvider);
            FollowState followState = new FollowState(
                bear, bearAnimationView, bearView, _playerMovementProvider);
            BearMoveToEnemyState moveToEnemyState = new BearMoveToEnemyState(
                bear, bearAnimationView, bearView);
            BearAttackState attackState = new BearAttackState(bearView, bear, bearAnimationView, bearAttack);

            FiniteTransitionBase toFollowTransition = new FiniteTransitionBase(
                followState,
                () => Vector3.Distance(_playerMovementProvider.Position, bearView.Position) > 4f);
            bearIdleState.AddTransition(toFollowTransition);
            attackState.AddTransition(toFollowTransition);
            
            FiniteTransitionBase toIdleTransition = new FiniteTransitionBase(
                bearIdleState, ()=> bearView.EnemyHealthView == null &&  Vector3.Distance(
                    _playerMovementProvider.Position, bearView.Position) < 4f);
            followState.AddTransition(toIdleTransition);
            moveToEnemyState.AddTransition(toIdleTransition);
            
            FiniteTransitionBase toMoveToEnemyTransition = new FiniteTransitionBase(
                moveToEnemyState, 
                () => bearView.EnemyHealthView != null && 
                      Vector3.Distance(_playerMovementProvider.Position, bearView.Position) < 4f);
            bearIdleState.AddTransition(toMoveToEnemyTransition);
            // followState.AddTransition(toMoveToEnemyTransition);
            
            FiniteTransitionBase toAttackTransition = new FiniteTransitionBase(
                attackState, 
                () => bearView.EnemyHealthView != null &&
                     Vector3.Distance(_playerMovementProvider.Position,
                    bearView.Position) < 4f && 
                     Vector3.Distance(bearView.Position,
                         bearView.EnemyHealthView.Position) <= bearView.StoppingDistance);
            moveToEnemyState.AddTransition(toAttackTransition);

            return new BearPresenter(bearIdleState, _updateRegister);
        }
    }
}