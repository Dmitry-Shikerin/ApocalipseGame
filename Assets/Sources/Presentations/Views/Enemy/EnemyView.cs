using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Enemies;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Enemy
{
    public class EnemyView : PresentableView<EnemyPresenter>, IEnemyView
    {
        [Required] [SerializeField] private EnemyHealthView _enemyHealth;
        [Required] [SerializeField] private HealthUi _enemyHealthUi;
        [Required] [SerializeField] private EnemyAnimation _enemyAnimation;
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public EnemyHealthView EnemyHealthView => _enemyHealth;
        public HealthUi EnemyHealthUi => _enemyHealthUi;
        public EnemyAnimation EnemyAnimation => _enemyAnimation;
        
        
        public void Move(Vector3 direction) =>
            _navMeshAgent.destination = direction;
    }
}