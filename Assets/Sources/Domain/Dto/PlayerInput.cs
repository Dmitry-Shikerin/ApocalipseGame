using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using UnityEngine;

namespace Sources.Domain.Dto
{
    public struct PlayerInput : IContext
    {
        public PlayerInput(Vector3 moveDirection, Vector3 lookDirection, float speed)
        {
            MoveDirection = moveDirection;
            LookDirection = lookDirection;
            Speed = speed;
        }

        public Vector3 MoveDirection { get; }
        public Vector3 LookDirection { get; }
        public float Speed { get; }
    }
}