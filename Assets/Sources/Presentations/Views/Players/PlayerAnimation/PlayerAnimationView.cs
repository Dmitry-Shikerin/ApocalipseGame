using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.PlayerAnimations;
using UnityEngine;

namespace Sources.Presentations.Views.Players.PlayerAnimation
{
    public class PlayerAnimationView : View, IPlayerAnimationView
    {
        [Required] [SerializeField] private Animator _animator;

        private readonly int _isIdle = Animator.StringToHash(nameof(_isIdle));
        private readonly int _isForward = Animator.StringToHash(nameof(_isForward));
        private readonly int _isBackward = Animator.StringToHash(nameof(_isBackward));

        private readonly List<Action> _stoppingAnimations = new List<Action>();

        private void Awake()
        {
            _stoppingAnimations.Add(StopIdle);
            _stoppingAnimations.Add(StopForwardWalk);
            _stoppingAnimations.Add(StopBackwardWalk);
        }

        public void PlayIdle()
        {
            ExceptAnimation(StopIdle);
            
            _animator.SetBool(_isIdle, true);
        }

        public void PlayForwardWalk()
        {
            ExceptAnimation(StopForwardWalk);
            
            _animator.SetBool(_isForward, true);
        }

        public void PlayBackwardWalk()
        {
            ExceptAnimation(StopBackwardWalk);
            
            _animator.SetBool(_isBackward, true);
        }

        private void StopIdle()
        {
            if(_animator.GetBool(_isIdle) == false)
                return;
            
            _animator.SetBool(_isIdle, false);
        }

        private void StopForwardWalk()
        {
            if (_animator.GetBool(_isForward) == false)
                return;

            _animator.SetBool(_isForward, false);
        }

        private void StopBackwardWalk()
        {
            if (_animator.GetBool(_isBackward) == false)
                return;

            _animator.SetBool(_isBackward, false);
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