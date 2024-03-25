using System;
using Sources.DomainInterfaces.Healths;
using Sources.PresentationsInterfaces.Views;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Controllers.Presenters.Enemies
{
    public class HealthUiPresenter : PresenterBase
    {
        private readonly IHealth _health;
        private readonly IHealthUi _healthUi;

        public HealthUiPresenter(IHealth health, IHealthUi healthUi)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healthUi = healthUi ?? throw new ArgumentNullException(nameof(healthUi));
        }

        public override void Enable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        public override void Disable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            float percent = _health.MaxHealth / 100f;
            int currentPercents = 0;
            float currentHealth = 0;

            while (currentHealth < _health.CurrentHealth)
            {
                currentHealth += percent;
                currentPercents++;
            }
            
            Debug.Log($"HealthChanged {currentPercents * 0.01f}");
            
            _healthUi.HealthView.SetFillAmount(currentPercents * 0.01f);
        }
    }
}