using Sources.ControllersInterfaces.Scenes;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        public void Enter(object payload = null)
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
            throw new System.NotImplementedException();
        }

        public string Name { get; }
    }
}