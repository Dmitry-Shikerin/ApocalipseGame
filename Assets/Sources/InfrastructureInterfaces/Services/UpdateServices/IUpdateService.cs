namespace Sources.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateService
    {
        void Update(float deltaTime);
        void UnregisterAll();
    }
}