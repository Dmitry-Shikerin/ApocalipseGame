using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.PlayerMovements;
using Sources.PresentationsInterfaces.Views.PlayerMovement;
using UnityEngine;

namespace Sources.Presentations.Views.Players.PlayerMovements
{
    public class PlayerMovementView : PresentableView<PlayerMovementPresenter>, IPlayerMovementView
    {
        [Required] [SerializeField] private CharacterController _characterController;

        public Vector3 Position => transform.position;
        
        public void Move(Vector3 direction) => 
            _characterController.Move(direction);

        public void SetLook(Vector3 lookDirection) => 
            transform.forward = lookDirection;
    }
}