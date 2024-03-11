using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.PlayerMovements;
using Sources.PresentationsInterfaces.Views.PlayerMovement;
using UnityEngine;

namespace Sources.Presentations.Views.PlayerMovements
{
    public class PlayerMovementView : PresentableView<PlayerMovementPresenter>, IPlayerMovementView
    {
        [Required] [SerializeField] private CharacterController _characterController;
        
        public void Move(Vector3 direction) => 
            _characterController.Move(direction);
    }
}