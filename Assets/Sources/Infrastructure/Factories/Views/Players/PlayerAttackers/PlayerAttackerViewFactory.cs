using System;
using Sources.Controllers.Presenters.Players.PlayerAttackkers;
using Sources.Domain.Players.PlayerShooters;
using Sources.Infrastructure.Factories.Controllers.Players.PlayerAttackers;
using Sources.Presentations.Views.Players.PlayerAttackers;
using Sources.PresentationsInterfaces.Views.Players.PlayerAttackers;

namespace Sources.Infrastructure.Factories.Views.Players
{
    public class PlayerAttackerViewFactory
    {
        private readonly PlayerAttackerPresenterFactory _playerAttackerPresenterFactory;

        public PlayerAttackerViewFactory(PlayerAttackerPresenterFactory playerAttackerPresenterFactory)
        {
            _playerAttackerPresenterFactory = 
                playerAttackerPresenterFactory ?? 
                throw new ArgumentNullException(nameof(playerAttackerPresenterFactory));
        }

        public IPlayerAttackerView Create(PlayerAttacker playerAttacker, PlayerAttackerView playerAttackerView)
        {
            PlayerAttackerPresenter playerAttackerPresenter =
                _playerAttackerPresenterFactory.Create(playerAttacker, playerAttackerView);
            
            playerAttackerView.Construct(playerAttackerPresenter);

            return playerAttackerView;
        }
    }
}