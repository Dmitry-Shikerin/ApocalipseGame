using Sources.InfrastructureInterfaces.StateMachines.States;

namespace Sources.InfrastructureInterfaces.StateMachines.SceneStateMachines.States
{
    public interface IState : IEnterable, IExiteble, IUpdatable, ILateUpdatable, IFixedUpdatable
    {
    }
}