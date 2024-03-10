using System;
using Sources.Controllers.Presenters.PlayerMovements;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Controllers.PlayerMovements;
using Sources.Presentations.Views.PlayerMovements;
using Sources.PresentationsInterfaces.Views.PlayerMovement;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.PlayerMovements
{
    public class PlayerMovementViewFactory
    {
        private readonly PlayerMovementPresenterFactory _playerMovementPresenterFactory;

        public PlayerMovementViewFactory(PlayerMovementPresenterFactory playerMovementPresenterFactory)
        {
            _playerMovementPresenterFactory = 
                playerMovementPresenterFactory 
                ?? throw new ArgumentNullException(nameof(playerMovementPresenterFactory));
        }

        public IPlayerMovementView Create(PlayerMovement playerMovement)
        {
            PlayerMovementView playerMovementView = Object.FindObjectOfType<PlayerMovementView>();
            
            PlayerMovementPresenter presenter = _playerMovementPresenterFactory.Create(
                playerMovement, playerMovementView);
            
            playerMovementView.Construct(presenter);

            return playerMovementView;
        }
    }
}