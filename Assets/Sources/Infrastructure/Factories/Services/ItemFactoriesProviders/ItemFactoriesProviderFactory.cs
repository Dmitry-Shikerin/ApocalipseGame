using System;
using Sources.Domain.Items;
using Sources.Infrastructure.Factories.Domain.Items;
using Sources.Infrastructure.Services.Providers;
using Sources.InfrastructureInterfaces.Services.Providers;

namespace Sources.Infrastructure.Factories.Services.ItemFactoriesProviders
{
    public class ItemFactoriesProviderFactory
    {
        private readonly ItemFactoriesProvider _itemFactoriesProvider;
        private readonly WoodPieFactory _woodPieFactory;

        public ItemFactoriesProviderFactory(
            ItemFactoriesProvider itemFactoriesProvider,
            WoodPieFactory woodPieFactory)
        {
            _itemFactoriesProvider = itemFactoriesProvider ?? 
                                     throw new ArgumentNullException(nameof(itemFactoriesProvider));
            _woodPieFactory = woodPieFactory ?? throw new ArgumentNullException(nameof(woodPieFactory));
        }

        public IItemFactoriesProvider Create()
        {
            _itemFactoriesProvider.Add<WoodPie>(_woodPieFactory.Create);

            return _itemFactoriesProvider;
        }
    }
}