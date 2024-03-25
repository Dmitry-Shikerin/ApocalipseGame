﻿using System;
using Sources.DomainInterfaces.Healths;
using UnityEngine;

namespace Sources.Domain.Enemies
{
    public class EnemyHealth : IHealth
    {
        private float _currentHealth;

        public EnemyHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        public float MaxHealth { get; }

        public event Action HealthChanged;

        public float CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                HealthChanged?.Invoke();
            }
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            Debug.Log($"{nameof(EnemyHealth)} {CurrentHealth}");
        }
    }
}