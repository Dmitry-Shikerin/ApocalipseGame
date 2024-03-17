using Sources.DomainInterfaces.Items;

namespace Sources.InfrastructureInterfaces.Services.Providers
{
    public interface IItemFactoriesProvider
    {
        IInventoryItem Create<T>()
            where T : IInventoryItem;
    }
}