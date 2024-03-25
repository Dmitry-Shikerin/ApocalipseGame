using Sirenix.OdinInspector;
using Sources.Presentations.Views.Players.PlayerAnimation;
using Sources.Presentations.Views.Players.PlayerAttackers;
using Sources.Presentations.Views.Players.PlayerMovements;
using Sources.Presentations.Views.Players.Weapons;
using UnityEngine;

namespace Sources.Presentations.Views.Players
{
    public class PlayerView : View
    {
        [Required] [SerializeField] private PlayerMovementView _playerMovementView;
        [Required] [SerializeField] private PlayerAnimationView _playerAnimationView;
        [Required] [SerializeField] private PlayerAttackerView _playerAttackerView;
        [Required] [SerializeField] private MiniGunView _miniGunView;
        
        public PlayerMovementView PlayerMovementView => _playerMovementView;
        public PlayerAnimationView PlayerAnimationView => _playerAnimationView;
        public PlayerAttackerView PlayerAttackerView => _playerAttackerView;
        public MiniGunView MiniGunView => _miniGunView;
    }
}