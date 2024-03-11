using System;
using System.ComponentModel;
using Sources.Domain.PlayerMovement;
using Sources.DomainInterfaces.PlayerAnimations;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;
using UnityEngine;

namespace Sources.Controllers.Presenters.PlayerAnimations
{
    public class PlayerAnimationPresenter : PresenterBase
    {
        private readonly IPlayerAnimationChanger _playerAnimationChanger;
        private readonly IPlayerAnimationView _playerAnimationView;

        public PlayerAnimationPresenter
        (
            IPlayerAnimationChanger playerAnimationChanger,
            IPlayerAnimationView playerAnimationView
        )
        {
            _playerAnimationChanger = playerAnimationChanger ??
                                      throw new ArgumentNullException(nameof(playerAnimationChanger));
            _playerAnimationView = playerAnimationView
                                   ?? throw new ArgumentNullException(nameof(playerAnimationView));
        }

        public override void Enable() => 
            _playerAnimationChanger.PropertyChanged += OnPropertyChanged;

        public override void Disable() => 
            _playerAnimationChanger.PropertyChanged += OnPropertyChanged;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnAnimationSpeedChanged(sender, e);
        }

        private void OnAnimationSpeedChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not PlayerMovement playerMovement)
                return;

            if (e.PropertyName != nameof(PlayerMovement.Speed))
                return;

            _playerAnimationView.SetSpeed(_playerAnimationChanger.Speed);
        }
    }
}