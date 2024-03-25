using System;
using Sources.Controllers.Presenters.Players.Weapons;
using Sources.Domain.Players.Weapons;
using Sources.Infrastructure.Factories.Controllers.Players.Weapons;
using Sources.Presentations.Views.Players.Weapons;
using Sources.PresentationsInterfaces.Views.Players.Weapons;

namespace Sources.Infrastructure.Factories.Views.Players.Weapons
{
    public class MiniGunViewFactory
    {
        private readonly MiniGunPresenterFactory _miniGunPresenterFactory;

        public MiniGunViewFactory(MiniGunPresenterFactory miniGunPresenterFactory)
        {
            _miniGunPresenterFactory = miniGunPresenterFactory ?? 
                                       throw new ArgumentNullException(nameof(miniGunPresenterFactory));
        }

        public IMiniGunView Create(MiniGun miniGun, MiniGunView miniGunView)
        {
            MiniGunPresenter miniGunPresenter = _miniGunPresenterFactory.Create(miniGun, miniGunView);
            
            miniGunView.Construct(miniGunPresenter);
            
            return miniGunView;
        }
    }
}