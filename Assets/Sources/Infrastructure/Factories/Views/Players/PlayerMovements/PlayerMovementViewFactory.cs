using System;
using Sources.Controllers.Presenters.PlayerMovements;
using Sources.Domain.PlayerMovement;
using Sources.Infrastructure.Factories.Controllers.PlayerMovements;
using Sources.Infrastructure.Services.WarmUpServices;
using Sources.Infrastructure.Services.WarmUpServices.Concrete;
using Sources.Presentations.Views.PlayerMovements;
using Sources.PresentationsInterfaces.Views.PlayerMovement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Players.PlayerMovements
{
    public class PlayerMovementViewFactory
    {
        private readonly PlayerMovementPresenterFactory _playerMovementPresenterFactory;
        private readonly AssetService<PlayerAssetProvider> _playerAssetProvider;

        public PlayerMovementViewFactory(
            PlayerMovementPresenterFactory playerMovementPresenterFactory)
        {
            _playerMovementPresenterFactory = 
                playerMovementPresenterFactory 
                ?? throw new ArgumentNullException(nameof(playerMovementPresenterFactory));
        }

        public IPlayerMovementView Create(PlayerMovement playerMovement, PlayerMovementView playerMovementView)
        {
            PlayerMovementPresenter presenter = _playerMovementPresenterFactory.Create(
                playerMovement, playerMovementView);
            
            playerMovementView.Construct(presenter);

            return playerMovementView;
        }
    }
}