using UnityEngine.Events;

namespace Sources.PresentationsInterfaces.Ui.Buttons
{
    public interface IButtonView
    {
        void AddListener(UnityAction action);
        void RemoveListener(UnityAction action);
    }
}