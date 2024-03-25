using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Bears;
using Sources.PresentationsInterfaces.Views.Bears;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Bears
{
    public class BearView : PresentableView<BearPresenter>, IBearView
    {
        [Required] [SerializeField] private BearAnimationView _bearAnimationView;
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public Vector3 Position => transform.position;
        public Vector3 Forward => transform.forward;
        public float StoppingDistance => _navMeshAgent.stoppingDistance;
        public BearAnimationView BearAnimationView => _bearAnimationView;
        public IEnemyHealthView EnemyHealthView { get; set; }
        
        public void Move(Vector3 destination)
        {
            _navMeshAgent.destination = destination;
        }

        public void SetStoppingDistance(float distance)
        {
            _navMeshAgent.stoppingDistance = distance;
        }

        public void SetLookRotation(Quaternion lookRotation)
        {
            transform.rotation = lookRotation;
        }
    }
}