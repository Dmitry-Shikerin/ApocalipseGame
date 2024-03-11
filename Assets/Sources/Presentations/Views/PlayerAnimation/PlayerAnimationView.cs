﻿using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;
using UnityEngine;

namespace Sources.Presentations.Views.PlayerAnimation
{
    public class PlayerAnimationView : View, IPlayerAnimationView
    {
        [Required] [SerializeField] private Animator _animator;

        private readonly int Speed = Animator.StringToHash(nameof(Speed));
        
        public void SetSpeed(float speed) => 
            _animator.SetFloat(Speed, speed);
    }
}