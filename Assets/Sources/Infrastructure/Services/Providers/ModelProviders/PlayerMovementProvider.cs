using System;
using Sources.Domain.PlayerMovement;
using UnityEngine;

namespace Sources.Infrastructure.Services.Providers.ModelProviders
{
    public class PlayerMovementProvider : IPlayerMovementProvider
    {
        private PlayerMovement _playerMovement;

        //TODO так выглядит более мение
        public Vector3 Position => _playerMovement?.Position ?? Vector3.zero;

        public void Set(PlayerMovement playerMovement) => 
            _playerMovement = playerMovement ?? 
                              throw new NullReferenceException(nameof(playerMovement));
    }
}