using Sources.Domain.Dto;
using Sources.InfrastructureInterfaces.StateMachines.States;

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
            
        }
    }

    public interface IInputService
    {
        PlayerInput PlayerInput { get; }
    }
}