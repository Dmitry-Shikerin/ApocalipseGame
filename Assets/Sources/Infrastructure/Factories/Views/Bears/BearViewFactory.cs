using System;
using Sources.Controllers.Presenters.Bears;
using Sources.Domain.Bears;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.Infrastructure.Services.WarmUpServices.Concrete;
using Sources.Presentations.Views.Bears;
using Sources.PresentationsInterfaces.Views.Bears;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Bears
{
    public class BearViewFactory
    {
        private readonly BearPresenterFactory _bearPresenterFactory;
        private readonly AssetService<BearAssetProvider> _bearAssetProvider;

        public BearViewFactory(
            BearPresenterFactory bearPresenterFactory,
            AssetService<BearAssetProvider> bearAssetProvider)
        {
            _bearPresenterFactory = bearPresenterFactory 
                                    ?? throw new ArgumentNullException(nameof(bearPresenterFactory));
            _bearAssetProvider = bearAssetProvider ?? throw new ArgumentNullException(nameof(bearAssetProvider));
        }

        public IBearView Create(Bear bear)
        {
            BearView bearView = Object.Instantiate(_bearAssetProvider.Provider.BearView);
            
            BearAnimationView bearAnimationView = bearView.BearAnimationView;
            
            BearPresenter bearPresenter = _bearPresenterFactory.Create(
                bear, bearView, bearAnimationView);
            
            bearView.Construct(bearPresenter);

            return bearView;
        }
    }
}