using Sources.Infrastructure.StateMachines.ContextStateMachines;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.Contexts;
using Sources.InfrastructureInterfaces.StateMachines.States;

namespace Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States
{
    public interface IContextState : IExiteble, IEnterable, IUpdatable
    {
        void Apply(IContext context, IContextStateChanger contextStateChanger);
    }
}