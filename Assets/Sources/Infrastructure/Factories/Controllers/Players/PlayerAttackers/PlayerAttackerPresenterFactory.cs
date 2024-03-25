using Sources.Controllers.Presenters.Players.PlayerAttackkers;
using Sources.Domain.Players.PlayerShooters;
using Sources.PresentationsInterfaces.Views.Players.PlayerAttackers;

namespace Sources.Infrastructure.Factories.Controllers.Players.PlayerAttackers
{
    public class PlayerAttackerPresenterFactory
    {
        public PlayerAttackerPresenter Create(PlayerAttacker playerAttacker, IPlayerAttackerView playerAttackerView)
        {
            return new PlayerAttackerPresenter(playerAttacker, playerAttackerView);
        }
    }
}