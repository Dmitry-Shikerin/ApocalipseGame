using System;

namespace Sources.InfrastructureInterfaces.Services.Registers
{
    public interface IFloatActionRegister
    {
        void Register(Action<float> action);
        void UnRegister(Action<float> action);
    }
}