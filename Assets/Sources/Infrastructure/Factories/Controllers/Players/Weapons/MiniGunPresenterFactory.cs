using Sources.Controllers.Presenters.Players.Weapons;
using Sources.Domain.Players.Weapons;
using Sources.PresentationsInterfaces.Views.Players.Weapons;

namespace Sources.Infrastructure.Factories.Controllers.Players.Weapons
{
    public class MiniGunPresenterFactory
    {
        public MiniGunPresenter Create(MiniGun miniGun, IMiniGunView miniGunView)
        {
            return new MiniGunPresenter(miniGun, miniGunView);
        }
    }
}