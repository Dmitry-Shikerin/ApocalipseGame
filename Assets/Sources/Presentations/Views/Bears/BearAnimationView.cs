using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;

namespace Sources.Presentations.Views.Bears
{
    public class BearAnimationView : View, IBearAnimationView
    {
        [Required] [SerializeField] private Animator _animator;

        private readonly int _isIdle = Animator.StringToHash(nameof(_isIdle));
        private readonly int _isWalk = Animator.StringToHash(nameof(_isWalk));
        private readonly int _isAttack = Animator.StringToHash(nameof(_isAttack));
        
        private readonly List<Action> _stoppingAnimations = new List<Action>();

        public event Action Attacking;

        private void Awake()
        {
            _stoppingAnimations.Add(StopPlayWalk);
            _stoppingAnimations.Add(StopPlayIdle);
            _stoppingAnimations.Add(StopPlayAttack);
        }

        public void PlayWalk()
        {
            ExceptAnimation(StopPlayWalk);
            
            _animator.SetBool(_isWalk, true);
        }

        public void PlayIdle()
        {
            ExceptAnimation(StopPlayIdle);
            
            _animator.SetBool(_isIdle, true);
        }

        public void PlayAttack()
        {
            ExceptAnimation(StopPlayAttack);
            
            _animator.SetBool(_isAttack, true);
        }
        
        private void OnAttack()
        {
            Attacking?.Invoke();
        }

        private void StopPlayWalk()
        {
            if(_animator.GetBool(_isWalk) == false)
                return;
            
            _animator.SetBool(_isWalk, false);
        }

        private void StopPlayIdle()
        {
            if(_animator.GetBool(_isIdle) == false)
                return;

            _animator.SetBool(_isIdle, false);
        }
        
        private void StopPlayAttack()
        {
            if(_animator.GetBool(_isAttack) == false)
                return;

            _animator.SetBool(_isAttack, true);
        }
        
        private void ExceptAnimation(Action exceptAnimation)
        {
            foreach (Action animation in _stoppingAnimations)
            {
                if (animation == exceptAnimation)
                    continue;
                
                animation.Invoke();
            }
        }
    }
}