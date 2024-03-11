using Sources.Domain.Dto;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.StateMachines.States;
using UnityEngine;

namespace Sources.Infrastructure.Services.InputService
{
    public class InputService : IInputService, IUpdatable
    {
        public PlayerInput PlayerInput { get; private set; }
        
        public void Update(float deltaTime)
        {
            UpdateMovement(deltaTime);
        }

        private void UpdateMovement(float deltaTime)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            float speed = Input.GetAxis("Run");

            PlayerInput = new PlayerInput(direction, speed);
        }
    }
}