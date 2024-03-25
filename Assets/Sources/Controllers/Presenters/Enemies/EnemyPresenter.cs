using System;
using Sources.ControllersInterfaces.Presenters;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Controllers.Presenters.Enemies
{
    public class EnemyPresenter : FiniteStateMachine, IPresenter
    {
        private readonly FiniteState _startState;
        private readonly Enemy _enemy;
        private readonly IEnemyView _enemyView;
        private readonly IUpdateRegister _updateRegister;

        public EnemyPresenter(
            FiniteState startState, 
            Enemy enemy, 
            IEnemyView enemyView,
            IUpdateRegister updateRegister)
        {
            _startState = startState ?? throw new ArgumentNullException(nameof(startState));
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
            _enemyView = enemyView ?? throw new ArgumentNullException(nameof(enemyView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public void Enable()
        {
            Start(_startState);
            _updateRegister.Register(Update);
        }

        public void Disable()
        {
            _updateRegister.UnRegister(Update);
            Stop();
        }
    }
}