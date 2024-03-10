using System;

namespace Sources.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateRegister
    {
        void Register(Action<float> action);
        void UnRegister(Action<float> action);
    }
}