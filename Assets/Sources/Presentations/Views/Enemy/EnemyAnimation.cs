using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemy
{
    public class EnemyAnimation : View, IEnemyAnimation
    {
        [Required] [SerializeField] private Animator _animator;

        private readonly int _isIdle = Animator.StringToHash(nameof(_isIdle));
        private readonly int _isMove = Animator.StringToHash(nameof(_isMove));
        private readonly int _isAttack = Animator.StringToHash(nameof(_isAttack));
        private readonly int _isDie = Animator.StringToHash(nameof(_isDie));
        private readonly int _isTakeDamage = Animator.StringToHash(nameof(_isTakeDamage));

        private readonly List<Action> _stoppingAnimations = new List<Action>();

        private void Awake()
        {
            _stoppingAnimations.Add(StopIdle);
            _stoppingAnimations.Add(StopMove);
            _stoppingAnimations.Add(StopAttack);
            _stoppingAnimations.Add(StopTakeDamage);
            _stoppingAnimations.Add(StopDie);
        }

        public void PlayIdle()
        {
            ExceptAnimation(PlayIdle);
            
            _animator.SetBool(_isIdle, true);
        }
        
        public void PlayMove()
        {
            ExceptAnimation(PlayMove);
            
            _animator.SetBool(_isMove, true);
        }

        public void PlayAttack()
        {
            ExceptAnimation(PlayAttack);
            
            _animator.SetBool(_isAttack, true);
        }

        public void PlayTakeDamage()
        {
            ExceptAnimation(PlayTakeDamage);
            
            _animator.SetBool(_isTakeDamage, true);
        }

        public void PlayDie()
        {
            ExceptAnimation(PlayTakeDamage);
            
            _animator.SetBool(_isDie, true);
        }

        private void StopIdle()
        {
            if(_animator.GetBool(_isIdle) == false)
                return;
            
            _animator.SetBool(_isIdle, false);
        }

        private void StopMove()
        {
            if(_animator.GetBool(_isMove) == false)
                return;
            
            _animator.SetBool(_isMove, false);
        }

        private void StopAttack()
        {
            if(_animator.GetBool(_isAttack) == false)
                return;
            
            _animator.SetBool(_isAttack, false);
        }

        private void StopTakeDamage()
        {
            if(_animator.GetBool(_isTakeDamage) == false)
                return;
            
            _animator.SetBool(_isTakeDamage, false);
        }

        private void StopDie()
        {
            if(_animator.GetBool(_isDie) == false)
                return;
            
            _animator.SetBool(_isDie, false);
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