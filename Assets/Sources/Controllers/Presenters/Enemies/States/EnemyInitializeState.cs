using System;
using Sources.Domain.Enemies;
using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;

namespace Sources.Controllers.Presenters.Enemies.States
{
    public class EnemyInitializeState : FiniteState
    {
        private readonly Enemy _enemy;

        public EnemyInitializeState(Enemy enemy)
        {
            _enemy = enemy ?? throw new ArgumentNullException(nameof(enemy));
        }

        public override void Enter()
        {
            _enemy.IsInitialized = true;
        }

        public override void Exit()
        {
        }

        public override void Update(float deltaTime)
        {
        }
    }
}