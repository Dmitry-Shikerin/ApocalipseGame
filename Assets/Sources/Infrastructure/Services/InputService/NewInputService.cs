using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.StateMachines.States;
using UnityEngine;
using PlayerInput = Sources.Domain.Dto.PlayerInput;

namespace Sources.Infrastructure.Services.InputService
{
    public class NewInputService : IInputService, IUpdatable
    {
        private InputManager _inputManager;
        private float _speed;
        
        public NewInputService()
        {
            _inputManager = new InputManager();
            _inputManager.Enable();
        }
        
        public PlayerInput PlayerInput { get; private set; }

        public void Update(float deltaTime)
        {
            ReadMovement();
        }

        private void ReadMovement()
        {
            Vector2 input = _inputManager.Gameplay.Movement.ReadValue<Vector2>();
            float speed = _inputManager.Gameplay.Run.ReadValue<float>();
            
            PlayerInput = new PlayerInput(new Vector3(input.x, 0, input.y), speed);
        }
    }
}