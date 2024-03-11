using Sources.InfrastructureInterfaces.Services.Registers;
using Sources.InfrastructureInterfaces.StateMachines.States;

namespace Sources.InfrastructureInterfaces.Services.UpdateServices
{
    public interface ILateUpdateService : ILateUpdatable, IAllUnregister
    {
    }
}