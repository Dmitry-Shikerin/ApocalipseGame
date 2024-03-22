using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Bears;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;
using UnityEngine.AI;

namespace Sources.Presentations.Views.Bears
{
    public class BearView : PresentableView<BearPresenter>, IBearView
    {
        [Required] [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public Vector3 Position => transform.position;
        
        public void Move(Vector3 destination)
        {
            _navMeshAgent.destination = destination;
        }
    }
}