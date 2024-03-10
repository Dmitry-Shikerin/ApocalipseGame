using Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines.States;
using Sources.InfrastructureInterfaces.StateMachines.States;

namespace Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines
{
    public interface ISceneStateMachine : IUpdatable, ILateUpdatable, IFixedUpdatable, IExiteble
    {
        void ChangeState(IState state, object payload = null);
    }
}