using Sirenix.OdinInspector;
using Sources.Presentations.Views.PlayerAnimation;
using Sources.Presentations.Views.PlayerMovements;
using UnityEngine;

namespace Sources.Presentations.Views.Players
{
    public class PlayerView : View
    {
        [Required] [SerializeField] private PlayerMovementView _playerMovementView;
        [Required] [SerializeField] private PlayerAnimationView _playerAnimationView;
        
        public PlayerMovementView PlayerMovementView => _playerMovementView;
        public PlayerAnimationView PlayerAnimationView => _playerAnimationView;
    }
}