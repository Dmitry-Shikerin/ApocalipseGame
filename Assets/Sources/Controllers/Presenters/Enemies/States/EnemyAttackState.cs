using Sources.Infrastructure.StateMachines.FiniteStateMachines.States;
using Sources.PresentationsInterfaces.Views.Enemies;

namespace Sources.Controllers.Presenters.Enemies.States
{
    public class EnemyAttackState : FiniteState
    {
        public EnemyAttackState(IEnemyView enemyView)
        {
        }
    }
}