using System;
using Sources.Domain.Players.Weapons;
using Sources.PresentationsInterfaces.Views.Players.Weapons;
using UnityEngine;

namespace Sources.Controllers.Presenters.Players.Weapons
{
    public class MiniGunPresenter : PresenterBase
    {
        private readonly MiniGun _miniGun;
        private readonly IMiniGunView _miniGunView;

        public MiniGunPresenter(MiniGun miniGun, IMiniGunView miniGunView)
        {
            _miniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            _miniGunView = miniGunView ?? throw new ArgumentNullException(nameof(miniGunView));
        }

        public override void Enable()
        {
            _miniGun.Attacked += OnAttack;
        }

        public override void Disable()
        {
            _miniGun.Attacked -= OnAttack;
        }

        private void OnAttack()
        {
            Debug.Log($"MiniGun Attack!");
        }
    }
}