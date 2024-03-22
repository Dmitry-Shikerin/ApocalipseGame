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
        
        public void PlayWalk()
        {
            StopPlayIdle();
            
            _animator.SetBool(_isWalk, true);
        }

        public void PlayIdle()
        {
            StopPlayWalk();
            
            _animator.SetBool(_isIdle, true);
        }

        private void StopPlayWalk()
        {
            _animator.SetBool(_isWalk, false);
        }

        private void StopPlayIdle()
        {
            _animator.SetBool(_isIdle, false);
        }
    }
}