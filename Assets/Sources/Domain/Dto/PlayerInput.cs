using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using UnityEngine;

namespace Sources.Domain.Dto
{
    public struct PlayerInput : IContext
    {
        public PlayerInput(Vector3 direction, float speed)
        {
            Direction = direction;
            Speed = speed;
        }

        public Vector3 Direction { get; }
        public float Speed { get; }
    }
}