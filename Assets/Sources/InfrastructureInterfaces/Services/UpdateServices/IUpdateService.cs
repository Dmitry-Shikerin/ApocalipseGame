using Sources.InfrastructureInterfaces.Services.Registers;
using Sources.InfrastructureInterfaces.StateMachines.States;

namespace Sources.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateService : IUpdatable, IAllUnregister
    {
    }
}