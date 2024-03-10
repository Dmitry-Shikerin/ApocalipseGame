using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using UnityEngine;

namespace Sources.Domain.Dto
{
    public struct PlayerInput : IContext
    {
        public PlayerInput(Vector3 direction)
        {
            Direction = direction;
        }

        public Vector3 Direction { get; }
    }
}