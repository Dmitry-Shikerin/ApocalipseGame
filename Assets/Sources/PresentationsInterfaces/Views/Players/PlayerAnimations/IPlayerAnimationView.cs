using Sources.PresentationsInterfaces.Views.AnimationSpeedSetables;

namespace Sources.PresentationsInterfaces.Views.PlayerAnimations
{
    public interface IPlayerAnimationView
    {
        void PlayIdle();
        void PlayForwardWalk();
        void PlayBackwardWalk();
    }
}