using System;
using System.Collections.Generic;
using Sources.DomainInterfaces.Items;
using Sources.InfrastructureInterfaces.Services.Providers;

namespace Sources.Infrastructure.Services.Providers
{
    public class ItemFactoriesProvider : IItemFactoriesProvider
    {
        private Dictionary<Type, Func<IInventoryItem>> _factories = new Dictionary<Type, Func<IInventoryItem>>();

        public void Add<T>(Func<IInventoryItem> itemFactory) 
            where T : IInventoryItem
        {
            if (_factories.ContainsKey(typeof(T)))
                throw new InvalidOperationException(nameof(T));

            _factories[typeof(T)] = itemFactory;
        }
        
        public IInventoryItem Create<T>()
            where T : IInventoryItem
        {
            if (_factories.ContainsKey(typeof(T)) == false)
                throw new NullReferenceException(nameof(T));

            return _factories[typeof(T)].Invoke();
        }
    }
}