using Sources.Domain;
using Sources.Domain.PlayerMovement;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerCamera
{
    public class PlayerCamera
    {
        private readonly PlayerMovement _playerMovement;

        public PlayerCamera(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        //TODO плохо
        public Vector3 Position => _playerMovement.Position;
    }
}