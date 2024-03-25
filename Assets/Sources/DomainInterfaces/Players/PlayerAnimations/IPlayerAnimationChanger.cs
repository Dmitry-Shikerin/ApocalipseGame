using System.ComponentModel;

namespace Sources.DomainInterfaces.PlayerAnimations
{
    public interface IPlayerAnimationChanger : INotifyPropertyChanged
    {
        float Speed { get; }
    }
}