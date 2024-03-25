using System;
using Sources.Domain.Players.PlayerShooters;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.PresentationsInterfaces.Views.Players.PlayerAttackers;

namespace Sources.Controllers.Presenters.Players.PlayerAttackkers
{
    public class PlayerAttackerPresenter : PresenterBase
    {
        private readonly IInputService _inputService;
        private readonly PlayerAttacker _playerAttacker;
        private readonly IPlayerAttackerView _playerAttackerView;

        public PlayerAttackerPresenter(IInputService inputService)
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public PlayerAttackerPresenter(PlayerAttacker playerAttacker, IPlayerAttackerView playerAttackerView)
        {
            _playerAttacker = playerAttacker ?? throw new ArgumentNullException(nameof(playerAttacker));
            _playerAttackerView = playerAttackerView ?? throw new ArgumentNullException(nameof(playerAttackerView));
        }

        public override void Enable()
        {
        }

        public override void Disable()
        {
        }
    }
}