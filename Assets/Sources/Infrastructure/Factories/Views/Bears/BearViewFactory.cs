using System;
using Sources.Controllers.Presenters.Bears;
using Sources.Domain.Bears;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Presentations.Views.Bears;
using Sources.PresentationsInterfaces.Views.Bears;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Bears
{
    public class BearViewFactory
    {
        private readonly BearPresenterFactory _bearPresenterFactory;

        public BearViewFactory(BearPresenterFactory bearPresenterFactory)
        {
            _bearPresenterFactory = bearPresenterFactory 
                                    ?? throw new ArgumentNullException(nameof(bearPresenterFactory));
        }

        public IBearView Create(Bear bear, PlayerMovement playerMovement)
        {
            BearView bearView = Object.FindObjectOfType<BearView>();
            BearAnimationView bearAnimationView = bearView.GetComponent<BearAnimationView>();
            
            BearPresenter bearPresenter = _bearPresenterFactory.Create(
                bear, playerMovement, bearView, bearAnimationView);
            
            bearView.Construct(bearPresenter);

            return bearView;
        }
    }
}